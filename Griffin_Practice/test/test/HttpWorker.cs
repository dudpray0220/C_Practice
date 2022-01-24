using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Griffin.WebServer;
using Griffin.WebServer.Modules;

namespace test
{
    class HttpWorker : IWorkerModule
    {
        #region Fields

        Dictionary<string, Action<IHttpContext>> actions = new Dictionary<string, Action<IHttpContext>>();

        #endregion Fields

        #region Methods

        // static 메서드
        public static void WriteTextToResponse(IHttpContext context, string bodyText)
        {
            context.Response.Body = new MemoryStream();
            var writer = new StreamWriter(context.Response.Body);
            writer.Write(bodyText);
            writer.Flush();
        }

        public void addUrlAction(string path, Action<IHttpContext> method)
        {
            actions.Add(path, method);
        }

        // DemoServer의 MyModule.cs에 있는 코드들
        public void BeginRequest(IHttpContext context)
        {
            // Do nothing special
        }

        public void EndRequest(IHttpContext context)
        {
            // Do nothing special
        }

        public ModuleResult HandleRequest(IHttpContext context)
        {   
            // dictionary 타입의 변수인 actions
            if (actions.ContainsKey(context.Request.Uri.LocalPath.ToString())) // dictionary에 키가 포함되어 있으면
            {
                actions[context.Request.Uri.LocalPath.ToString()](context);
            }
            else // 키가 없으면 404 에러
            {
                context.Response.StatusCode = 404;
                WriteTextToResponse(context, "Error 404 - Page not found.");
            }

            return ModuleResult.Continue; // 0은 성공(0시 Continue), 1은 실패
        }

        public void HandleRequestAsync(IHttpContext context, Action<IAsyncModuleResult> callback)
        {
            // Since this module only supports sync
            callback(new AsyncModuleResult(context, HandleRequest(context)));
        }

        #endregion Methods
    }
}
