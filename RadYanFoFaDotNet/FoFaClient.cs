using Microsoft.VisualBasic;
using RadYanFoFaDotNet.Models;
using RestSharp;

namespace RadYanFoFaDotNet;

public class FoFaClient
{
    private readonly string _apiEmail;
    private readonly string _apiKey;
    private readonly CancellationTokenSource _source;
    
    private string _apiDomain;
    private RestClient _httpClient;
    private List<string> _fields;

    public FoFaClient(string email, string key)
    {
        _apiEmail = email;
        _apiKey = key;
        _apiDomain = "https://fofa.info/api/v1/";
        _httpClient = new RestClient(_apiDomain);
        _source = new CancellationTokenSource();
        _fields = new List<string>
        {
            "ip",
            "port",
            "protocol",
            "country_name",
            "host",
            "domain",
            "server",
            "title"
        };
    }

    /// <summary>
    /// 修改默认的API域名
    /// </summary>
    /// <param name="domain">带有https前缀的域名</param>
    public void SetApiDomain(string domain)
    {
        _apiDomain = domain + "/api/v1/";
        _httpClient = new RestClient(domain);
    }
    
    /// <summary>
    /// 修改查询结果中返回的字段
    /// </summary>
    /// <param name="fields">要返回的字段列表</param>
    public void SetGetFields(List<string> fields)
    {
        _fields = fields;
    }
    
    
    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns>用户的信息</returns>
    public UserInfo? GetUserInfo()
    {
        var request = new RestRequest("info/my")
            .AddQueryParameter("email",_apiEmail)
            .AddQueryParameter("key", _apiKey);
        return _httpClient.Get<UserInfo>(request);
    }
    
    /// <summary>
    /// 异步方式获取用户信息
    /// </summary>
    /// <returns>用户信息</returns>
    public async Task<UserInfo?> GetUserInfoAsync()
    {
        var request = new RestRequest("info/my")
            .AddQueryParameter("email",_apiEmail)
            .AddQueryParameter("key", _apiKey);
        return await _httpClient.GetAsync<UserInfo>(request, _source.Token);
    }

    /// <summary>
    /// 执行查询语句
    /// </summary>
    /// <param name="queryString">查询语句</param>
    /// <param name="page">要获取第几页数据，默认为1</param>
    /// <param name="size">每页返回多少条数据，默认为20</param>
    /// <param name="isFullData">是否查询所有的数据，false为仅查询最近一年，默认为false</param>
    /// <returns>搜索结果</returns>
    public SearchResult? Search(string queryString, int page = 1, int size = 20, bool isFullData = false)
    {
        var qBase64 = Utils.Base64Encode(queryString);
        var request = new RestRequest("search/all")
            .AddQueryParameter("email",_apiEmail)
            .AddQueryParameter("key", _apiKey)
            .AddQueryParameter("qbase64",qBase64)
            .AddQueryParameter("fields", Strings.Join(_fields.ToArray(),","))
            .AddQueryParameter("page", page)
            .AddQueryParameter("size", size)
            .AddQueryParameter("full", isFullData);
        return _httpClient.Get<SearchResult>(request);
    }
    
    /// <summary>
    /// 异步执行查询语句
    /// </summary>
    /// <param name="queryString">查询语句</param>
    /// <param name="page">要获取第几页数据，默认为1</param>
    /// <param name="size">每页返回多少条数据，默认为20</param>
    /// <param name="isFullData">是否查询所有的数据，false为仅查询最近一年，默认为false</param>
    /// <returns>搜索结果</returns>
    public Task<SearchResult?> SearchAsync(string queryString, int page = 1, int size = 20, bool isFullData = false)
    {
        var qBase64 = Utils.Base64Encode(queryString);
        var request = new RestRequest("search/all")
            .AddQueryParameter("email",_apiEmail)
            .AddQueryParameter("key", _apiKey)
            .AddQueryParameter("qbase64",qBase64)
            .AddQueryParameter("fields", Strings.Join(_fields.ToArray(),","))
            .AddQueryParameter("page", page)
            .AddQueryParameter("size", size)
            .AddQueryParameter("full", isFullData);
        return _httpClient.GetAsync<SearchResult>(request);
    }
    
    // Todo: 聚合统计
}