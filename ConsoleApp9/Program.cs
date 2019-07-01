using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.IO;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpWebRequest request = WebRequest.CreateHttp("http://mail.ru");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            request.KeepAlive = true;
            request.UserAgent = "Internet Explorer";
            request.Headers.Add(HttpRequestHeader.Translate, "en");

            Console.WriteLine("Key count: {0}", response.Headers.Count);
            for (int i = 0; i < response.Headers.Count; i++)
            {
                Console.Write(response.Headers.Keys[i] + ": ");
                foreach (var a in response.Headers.GetValues(i))
                {
                    Console.WriteLine(a + "; ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------");
            StreamReader httpPage = new StreamReader(response.GetResponseStream());
            
            Console.WriteLine(httpPage.ReadToEnd());
            
            Console.ReadLine();
        }
    }
}
