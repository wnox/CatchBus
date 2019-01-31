using System;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;


namespace console.test
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {


            //Console.WriteLine("Hello World!");
            // QueryBus("432").Wait();
            // QueryLineStation("431").Wait(); 
            // QueryLineName("BRT").Wait();
            // ProcessRepositories().Wait();
            var qry = new Query369();
            Console.WriteLine(qry.HowLong());
        }


        

    }

}
