using System;
using System.Net;
using System.Configuration;
using System.Reflection;
using System.Linq;

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
            // Change the AppDomain default config file location, since this assembly will be installed in the GAC.
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"C:\Temp\SvcUtil.Extension.InjectProxy.dll.config");
            ResetConfigMechanism();

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

        // Taken from http://stackoverflow.com/questions/6150644/change-default-app-config-at-runtime/6151688#6151688
        private static void ResetConfigMechanism()
        {
            typeof(ConfigurationManager)
                .GetField("s_initState", BindingFlags.NonPublic |
                                         BindingFlags.Static)
                .SetValue(null, 0);

            typeof(ConfigurationManager)
                .GetField("s_configSystem", BindingFlags.NonPublic |
                                            BindingFlags.Static)
                .SetValue(null, null);

            typeof(ConfigurationManager)
                .Assembly.GetTypes()
                .Where(x => x.FullName ==
                            "System.Configuration.ClientConfigPaths")
                .First()
                .GetField("s_current", BindingFlags.NonPublic |
                                       BindingFlags.Static)
                .SetValue(null, null);
        }
    }
}
