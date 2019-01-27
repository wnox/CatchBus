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
            client.DefaultRequestHeaders.Add("version", "android-insigma.waybook.jinan-2349");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");

            //Console.WriteLine("Hello World!");
            // QueryBus("432").Wait();
            // QueryLineStation("431").Wait();
            QueryLineName("BRT").Wait();
            // ProcessRepositories().Wait();

        }

        //根据名称模糊查询线路
        private static async Task QueryLineName(string lineName)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var streamTask = client.GetStreamAsync($"http://60.216.101.229/server-ue2/rest/buslines/simple/370100/{lineName}");
            var serializer = new DataContractJsonSerializer(typeof(RepoLineName));
            var repositories = serializer.ReadObject(await streamTask) as RepoLineName;
            if (repositories.status.code == "0")
            {
                foreach (var result in repositories.result)
                {
                    Console.WriteLine(result.id + "," + result.lineName);
                }
            }
            else
            {
                Console.WriteLine(repositories.status.code + " " + repositories.status.msg);
            }
        }

        //根据线路ID查询线路站点
        private static async Task QueryLineStation(string lineId)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var streamTask = client.GetStreamAsync($"http://60.216.101.229/server-ue2/rest/buslines/370100/{lineId}");
            var serializer = new DataContractJsonSerializer(typeof(RepoLine));
            var repositories = serializer.ReadObject(await streamTask) as RepoLine;
            if (repositories.status.code == "0")
            {
                foreach (var result in repositories.result.stations)
                {
                    Console.WriteLine(result.id + "," + result.stationName);
                }
            }
            else
            {
                Console.WriteLine(repositories.status.code + " " + repositories.status.msg);
            }
        }

        //根据线路ID查询车辆位置
        private static async Task QueryBus(string lineId)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var streamTask = client.GetStreamAsync($"http://60.216.101.229/server-ue2/rest/buses/busline/370100/{lineId}");
            var serializer = new DataContractJsonSerializer(typeof(RepoBus));
            var repositories = serializer.ReadObject(await streamTask) as RepoBus;
            if (repositories.status.code == "0")
            {
                foreach (var result in repositories.result)
                {
                    Console.WriteLine(result.stationSeqNum + "," + result.nextStation);
                }
            }
            else
            {
                Console.WriteLine(repositories.status.code + " " + repositories.status.msg);
            }
        }

        //读取文本示例方法
        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetStringAsync("http://60.216.101.229/server-ue2/rest/buslines/370100/431");
            var msg = await stringTask;
            Console.Write(msg);
        }


    }

}
