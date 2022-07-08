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

    /**
     * 修改默认的api域名
     */
    public void SetApiDomain(string domain)
    {
        _apiDomain = domain + "/api/v1/";
        _httpClient = new RestClient(domain);
    }
    
    /**
     * 修改要返回的字段
     */
    public void SetGetFields(List<string> fields)
    {
        _fields = fields;
    }
    
    
    /**
     * 获取用户信息
     */
    public UserInfo? GetUserInfo()
    {
        var request = new RestRequest("info/my")
            .AddQueryParameter("email",_apiEmail)
            .AddQueryParameter("key", _apiKey);
        return _httpClient.Get<UserInfo>(request);
    }
    
    /**
     * 异步获取用户信息
     */
    public async Task<UserInfo?> GetUserInfoAsync()
    {
        var request = new RestRequest("info/my")
            .AddQueryParameter("email",_apiEmail)
            .AddQueryParameter("key", _apiKey);
        return await _httpClient.GetAsync<UserInfo>(request, _source.Token);
    }

    /**
     * 执行查询语句
     */
    public SearchResult? Search(string queryString, int page = 1, int size = 20, bool isFullData = false)
    {
        var qBase64 = Utils.Base64Encode(queryString);
        var request = new RestRequest("search/all")
            .AddQueryParameter("qbase64",qBase64)
            .AddQueryParameter("fields", Strings.Join(_fields.ToArray(),","))
            .AddQueryParameter("page", page)
            .AddQueryParameter("size", size)
            .AddQueryParameter("full", isFullData);
        return _httpClient.Get<SearchResult>(request);
    }
    
    /**
     * 异步执行查询语句
     */
    public Task<SearchResult?> SearchAsync(string queryString, int page = 1, int size = 20, bool isFullData = false)
    {
        var qBase64 = Utils.Base64Encode(queryString);
        var request = new RestRequest("search/all")
            .AddQueryParameter("qbase64",qBase64)
            .AddQueryParameter("fields", Strings.Join(_fields.ToArray(),","))
            .AddQueryParameter("page", page)
            .AddQueryParameter("size", size)
            .AddQueryParameter("full", isFullData);
        return _httpClient.GetAsync<SearchResult>(request);
    }
}