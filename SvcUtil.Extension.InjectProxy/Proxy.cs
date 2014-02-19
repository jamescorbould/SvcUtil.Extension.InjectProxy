using System;
using System.Net;
using System.Configuration;

namespace SvcUtil.Extension.InjectProxy
{
    public class Proxy : IWebProxy
    {
        private string domain { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string proxyUri { get; set; }

        public Proxy ()
        {
            this.domain = ConfigurationSettings.AppSettings["domain"];
            this.username = ConfigurationSettings.AppSettings["username"];
            this.password = ConfigurationSettings.AppSettings["password"];
            this.proxyUri = ConfigurationSettings.AppSettings["uri"];
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
}
