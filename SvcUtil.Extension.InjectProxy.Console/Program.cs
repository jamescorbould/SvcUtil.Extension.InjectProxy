using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SvcUtil.Extension.InjectProxy;

namespace SvcUtil.Extension.InjectProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy { };
            Console.WriteLine("domain = {0}", proxy.domain);
            Console.WriteLine("username = {0}", proxy.username);
            Console.WriteLine("password = {0}", proxy.password);
            Console.WriteLine("proxyUri = {0}", proxy.proxyUri);
            Console.ReadKey();
        }
    }
}
