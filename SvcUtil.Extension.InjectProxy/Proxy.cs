using System;
using System.Net;
using System.Configuration;

namespace SvcUtil.Extension.InjectProxy
{
    public class Proxy : IWebProxy
    {
        public string domain { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }
        public string proxyUri { get; private set; }

        public Proxy ()
        {
            this.domain = ConfigurationManager.AppSettings["domain"];
            this.username = ConfigurationManager.AppSettings["username"];
            this.password = ConfigurationManager.AppSettings["password"];
            this.proxyUri = ConfigurationManager.AppSettings["proxyUri"];
        }

        public ICredentials Credentials
        {
            get { return new NetworkCredential(username, password, domain); }
            set { }
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri(proxyUri);
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
