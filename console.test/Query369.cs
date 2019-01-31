using System.Net.Http;
using System.Threading.Tasks;
using console.test;
using System.Runtime.Serialization.Json;


public class Query369
{
    private const string URL_BUSNAME = "http://60.216.101.229/server-ue2/rest/buslines/simple/370100/";
    private const string URL_LINESTATION = "http://60.216.101.229/server-ue2/rest/buslines/370100/";
    private const string URL_LINEBUS = "http://60.216.101.229/server-ue2/rest/buses/busline/370100/";
    private static readonly HttpClient client = new HttpClient();

    //构造函数
    public Query369()
    {
        client.DefaultRequestHeaders.Add("version", "android-insigma.waybook.jinan-2349");
        client.DefaultRequestHeaders.Add("Connection", "keep-alive");
        client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
    }

    public string HowLong()
    {
        Task<RepoLineName> lineName = QueryLineName("BRT");
        return lineName.Result.result.Length.ToString();
    }
    
    //根据名称模糊查询线路
    private async Task<RepoLineName> QueryLineName(string lineName)
    {
        client.DefaultRequestHeaders.Accept.Clear();

        var streamTask = client.GetStreamAsync(URL_BUSNAME + lineName);
        var serializer = new DataContractJsonSerializer(typeof(RepoLineName));
        var repositories = serializer.ReadObject(await streamTask) as RepoLineName;
        return repositories;
    }

    //根据线路ID查询线路站点
    private static async Task<RepoLine> QueryLineStation(string lineId)
    {
        client.DefaultRequestHeaders.Accept.Clear();

        var streamTask = client.GetStreamAsync(URL_LINESTATION + lineId);
        var serializer = new DataContractJsonSerializer(typeof(RepoLine));
        var repositories = serializer.ReadObject(await streamTask) as RepoLine;
        return repositories;

    }

    //根据线路ID查询车辆位置
    private static async Task<RepoBus> QueryBus(string lineId)
    {
        client.DefaultRequestHeaders.Accept.Clear();

        var streamTask = client.GetStreamAsync(URL_LINEBUS + lineId);
        var serializer = new DataContractJsonSerializer(typeof(RepoBus));
        var repositories = serializer.ReadObject(await streamTask) as RepoBus;
        return repositories;

    }

    //读取文本示例方法
    private static async Task ProcessRepositories()
    {
        client.DefaultRequestHeaders.Accept.Clear();

        var stringTask = client.GetStringAsync("http://60.216.101.229/server-ue2/rest/buslines/370100/431");
        var msg = await stringTask;
        // Console.Write(msg);
    }

}