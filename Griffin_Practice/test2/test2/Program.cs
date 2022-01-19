﻿namespace OIDC.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;

    using Griffin.WebServer;
    using Griffin.WebServer.Modules;

    public class HttpWorker : IWorkerModule
    {
        #region Fields

        Dictionary<string, Action<IHttpContext>> actions = new Dictionary<string, Action<IHttpContext>>();

        #endregion Fields

        #region Methods

        static void Main(string[] args)
        {
        }

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
            if (actions.ContainsKey(context.Request.Uri.LocalPath.ToString()))
            {
                actions[context.Request.Uri.LocalPath.ToString()](context);
            }
            else
            {
                context.Response.StatusCode = 404;
                WriteTextToResponse(context, "Error 404 - Page not found.");
            }

            return ModuleResult.Continue;
        }

        public void HandleRequestAsync(IHttpContext context, Action<IAsyncModuleResult> callback)
        {
            // Since this module only supports sync
            callback(new AsyncModuleResult(context, HandleRequest(context)));
        }

        #endregion Methods
    }

    public class SimpleWebServer
    {
        #region Fields

        private X509Certificate2 certificate;
        int port;
        private HttpServer _listener;
        private HttpWorker _worker;

        #endregion Fields

        #region Constructors

        public SimpleWebServer(string prefixes, X509Certificate2 certificate = null)
        {
            Uri uri = new Uri(prefixes);
            this.port = uri.Port;
            this.certificate = certificate;

            _worker = new HttpWorker();
            ModuleManager moduleManager = new ModuleManager();
            moduleManager.Add(_worker);
            _listener = new HttpServer(moduleManager);
        }

        #endregion Constructors

        #region Methods

        public void addUrlAction(string path, Action<IHttpContext> method)
        {
            _worker.addUrlAction(path, method);
        }

        public void Run()
        {
            _listener.Start(IPAddress.Any, port, certificate);
        }

        public void Stop()
        {
            _listener.Stop();
        }

        #endregion Methods
    }
}