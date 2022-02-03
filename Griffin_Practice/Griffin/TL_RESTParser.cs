using System;
using System.Collections.Generic;
using System.IO;


namespace MTTAuth
{
    public abstract class IService
    {
        private Dictionary<string, string> Heardermap = new Dictionary<string, string>();
        public abstract MemoryStream Run(string RequestData);
    }
    public class TL_RESTParser
    {
        private static System.Threading.SpinLock _spinlock = new System.Threading.SpinLock();
        private static Dictionary<string, IService> APIMAP = new Dictionary<string, IService>();
        public static bool InsertAPIMode(string _iden, IService service)
        {
            bool lockTaken = false;
            _spinlock.Enter(ref lockTaken);
            bool ret = true;
            if (APIMAP.ContainsKey(_iden.ToUpper())) ret = false;
            else APIMAP.Add(_iden.ToUpper(), service);
            _spinlock.Exit(false);
            return ret;
        }
        public static bool ExistAPIMode(string _iden)
        {
            bool lockTaken = false;
            _spinlock.Enter(ref lockTaken);
            bool ret = false;
            if (APIMAP.ContainsKey(_iden.ToUpper())) ret = true;
            _spinlock.Exit(false);
            return ret;
        }
        public TL_RESTParser(TL_HttpContext context, string _URI)
        {
            try
            {
                if (context.Request.Body != null)
                {
                    var BodyStream = new StreamReader(context.Request.Body);
                    string sBody = BodyStream.ReadToEnd().ToString();
                    context.Response.Body = APIMAP[_URI].Run(sBody);
                }
                else
                {
                    context.Response.Body = APIMAP[_URI].Run(null);
                }

                context.Channel.Send(context.Response);
            }
            catch (Exception _e)
            {
                context.Channel.Send(context.Response);
                Console.WriteLine(_e.Message);
            }
        }
    }
}
