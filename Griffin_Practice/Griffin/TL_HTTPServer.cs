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

namespace MTTAuth
{
    public class TL_HttpContext : HttpContext
    {
        public ITcpChannel Channel { get; set; }
    }
    public class TL_HTTPServer
    {
        private readonly BufferSlicePool _bufferSlicePool;
        private readonly IModuleManager _moduleManager = new ModuleManager();
        private readonly ChannelTcpListenerConfiguration _configuration;
        private Griffin.Net.Protocols.Http.HttpListener _listener;
        public TL_HTTPServer()
        {
            BodyDecoder = new CompositeIMessageSerializer();
            _configuration = new ChannelTcpListenerConfiguration(() => new HttpMessageDecoder(BodyDecoder), () => new HttpMessageEncoder());
            _bufferSlicePool = new BufferSlicePool(65535, 100);
            ApplicationInfo = new MemoryItemStorage();
            AllowedSslProtocols = SslProtocols.Tls12;
        }

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

        public IMessageSerializer BodyDecoder { get; set; }

        public IItemStorage ApplicationInfo { get; set; }

        public SslProtocols AllowedSslProtocols { get; set; }

        public int LocalPort
        {
            get
            {
                if (_listener == null)
                    throw new InvalidOperationException("Listener must have been started first.");
                return _listener.LocalPort;
            }
        }

        private void Add(IHttpModule module)
        {
            _moduleManager.Add(module);
        }

        public void Start(IPAddress ipAddress, int port)
        {
            if (ipAddress == null) throw new ArgumentNullException("ipAddress");
            if (_listener != null)
                throw new InvalidOperationException("Stop the server before restarting.");
            _listener = new Griffin.Net.Protocols.Http.HttpListener(_configuration);
            _listener.BodyDecoder = BodyDecoder;
            _listener.MessageReceived = OnClientRequest;
            _listener.Start(ipAddress, port);
        }

        public void Start(IPAddress ipAddress, int port, X509Certificate certifiate)
        {
            if (ipAddress == null) throw new ArgumentNullException("ipAddress");
            if (_listener != null)
                throw new InvalidOperationException("Stop the server before restarting.");

            var factory = new SecureTcpChannelFactory(new ServerSideSslStreamBuilder(certifiate, AllowedSslProtocols));
            _listener = new Griffin.Net.Protocols.Http.HttpListener();
            _listener.ChannelFactory = factory;
            _listener.MessageReceived = OnClientRequest;
            _listener.Start(ipAddress, port);
        }

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

        protected void SendResponse(IAsyncModuleResult obj)
        {
            TL_HttpContext context = ((TL_HttpContext)obj.Context);
            string _URI = context.Request.Uri.AbsolutePath.ToUpper();
            if (TL_RESTParser.ExistAPIMode(_URI)) new TL_RESTParser(context, _URI);
        }

        public void Stop()
        {
            _listener.Stop();
            _listener = null;
        }
    }
}
