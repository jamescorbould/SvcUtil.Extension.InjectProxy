﻿using System;
using System.Net;

namespace SvcUtil.Extension.InjectProxy
{
    public class Proxy : IWebProxy
    {
        private string domain { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string proxyUri { get; set; }

        public ICredentials Credentials
        {
            get { return new NetworkCredential("user", "password"); }
            //or get { return new NetworkCredential("user", "password","domain"); }
            set { }
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri("http://my.proxy:8080");
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
}