using System;
using Griffin.Net.Channels;
using Griffin.Net.Protocols.Http;
using Griffin.WebServer;
using Griffin.WebServer.Modules;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Griffin.Net.Buffers;
using Griffin.Net;
using Griffin.Net.Protocols.Serializers;
using System.Security.Authentication;

namespace GriffinWebServerTest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TL_HTTPServer server = new TL_HTTPServer();
            TL_HTTPServer();
        }
    }

    // TL_HttpContext 클래스
    public class TL_HttpContext : HttpContext
    {
        public ITcpChannel Channel { get; set; }
    }

    // TL_HTTPServer 클래스
    public class TL_HTTPServer
    {
        // 인스턴스 변수들
        private readonly BufferSlicePool _bufferSlicePool;
        private readonly IModuleManager _moduleManager = new ModuleManager(); // 객체생성
        private readonly ChannelTcpListenerConfiguration _configuration;
        private Griffin.Net.Protocols.Http.HttpListener _listener;

        public IMessageSerializer BodyDecoder { get; set; }
        public IItemStorage ApplicationInfo { get; set; }
        public SslProtocols AllowedSslProtocols { get; set; }
        public int LocalPort
        {
            get
            {
                if (_listener == null)
                    throw new InvalidOperationException("리스너가 먼저 시작되어야 합니다.");
                return _listener.LocalPort;
            }
        }

        // 생성자
        public TL_HTTPServer()
        {
            BodyDecoder = new CompositeIMessageSerializer();
            _configuration = new ChannelTcpListenerConfiguration(() => new HttpMessageDecoder(BodyDecoder), () => new HttpMessageEncoder());
            _bufferSlicePool = new BufferSlicePool(65535, 100);
            ApplicationInfo = new MemoryItemStorage();
            AllowedSslProtocols = SslProtocols.Tls12;
        }

        // private 생성자 : 클래스의 인스턴스를 만들 수 없게 할 때 사용
        private TL_HTTPServer(IModuleManager moduleManager, ChannelTcpListenerConfiguration configuration)
        {
            if (moduleManager == null) throw new ArgumentNullException("moduleManager");
            if (configuration == null) throw new ArgumentNullException("configuration");

            BodyDecoder = new CompositeIMessageSerializer();
            _moduleManager = moduleManager;
            _configuration = configuration;
            _bufferSlicePool = new BufferSlicePool(65535, 100);
            ApplicationInfo = new MemoryItemStorage();
            AllowedSslProtocols = SslProtocols.Tls12;
        }

        private void Add(IHttpModule module)
        {
            _moduleManager.Add(module);
        }

        // 인증서 없을 때 Start 메서드
        public void Start(IPAddress iPAddress, int port)
        {
            if (iPAddress == null) throw new ArgumentNullException("ipAddress");
            if (_listener != null)
                throw new InvalidOperationException("Stop the server before restarting");
            _listener = new Griffin.Net.Protocols.Http.HttpListener(_configuration);
            _listener.BodyDecoder = BodyDecoder;
            _listener.MessageReceived = OnClientRequest;
            _listener.Start(iPAddress, port);
        }

        // 인증서 있을 때 Start 메서드
        public void Start(IPAddress iPAddress, int port, X509Certificate certificate)
        {
            if (iPAddress == null) throw new ArgumentNullException("ipAddress");
            if (_listener != null)
                throw new InvalidOperationException("Stop the server before restarting");

            var factory = new SecureTcpChannelFactory(new ServerSideSslStreamBuilder(certificate, AllowedSslProtocols));
            _listener = new Griffin.Net.Protocols.Http.HttpListener();
            _listener.ChannelFactory = factory;
            _listener.MessageReceived = OnClientRequest;
            _listener.Start(iPAddress, port);
        }

        // OnClientRequest 메서드
        protected void OnClientRequest(ITcpChannel channel, object message)
        {
            var context = new TL_HttpContext
            {
                Channel = channel,
                Items = new MemoryItemStorage(),
                Request = (IHttpRequest)message,
                Response = ((IHttpRequest)message).CreateResponse()
            };
            _moduleManager.InvokeAsync(context, SendResponse);
        }

        // sendResponse 메서드
        protected void SendResponse(IAsyncModuleResult obj)
        {
            TL_HttpContext context = ((TL_HttpContext)obj.Context);
            string _URI = context.Request.Uri.AbsolutePath.ToUpper();
        }

        // Stop 메서드
        public void Stop()
        {
            _listener.Stop();
            _listener = null;
        }
    }
}
