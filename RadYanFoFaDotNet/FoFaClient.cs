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
    private readonly string _searchApiUrl;
    private readonly string _loginApiUrl;
    private readonly string _statsApiUrl;
    private readonly string _hostApiUrl;
    private RestClient _httpClient;
    private List<string> _fields;

    public FoFaClient(string email, string key)
    {
        _apiEmail = email;
        _apiKey = key;
        _apiDomain = "https://fofa.info";
        _httpClient = new RestClient(_apiDomain);
        _source = new CancellationTokenSource();
        _searchApiUrl = "/api/v1/search/all";
        _loginApiUrl = "/api/v1/info/my";
        _statsApiUrl = "/api/v1/search/stats";
        _hostApiUrl = "/api/v1/host/";
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
        _apiDomain = domain;
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
        var request = new RestRequest(_loginApiUrl)
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
        var request = new RestRequest(_loginApiUrl)
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
        var request = new RestRequest(_searchApiUrl)
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
        var request = new RestRequest(_searchApiUrl)
            .AddQueryParameter("email",_apiEmail)
            .AddQueryParameter("key", _apiKey)
            .AddQueryParameter("qbase64",qBase64)
            .AddQueryParameter("fields", Strings.Join(_fields.ToArray(),","))
            .AddQueryParameter("page", page)
            .AddQueryParameter("size", size)
            .AddQueryParameter("full", isFullData);
        return _httpClient.GetAsync<SearchResult>(request);
    }

    /// <summary>
    /// 聚合统计
    /// </summary>
    /// <param name="queryString">搜索语法</param>
    /// <param name="fields">要获取的字段，默认为SetGetFields设置的值</param>
    /// <returns>统计信息</returns>
    public StatsResult? SearchStats(string queryString, List<string>? fields = null)
    {
        fields ??= _fields;
        var qBase64 = Utils.Base64Encode(queryString);
        var request = new RestRequest(_statsApiUrl)
            .AddQueryParameter("email", _apiEmail)
            .AddQueryParameter("key", _apiKey)
            .AddQueryParameter("qbase64", qBase64)
            .AddQueryParameter("fields", Strings.Join(fields.ToArray(), ","));
        return _httpClient.Get<StatsResult>(request);
    }

    /// <summary>
    /// 异步获取聚合统计
    /// </summary>
    /// <param name="queryString">搜索语法</param>
    /// <param name="fields">要获取的字段，默认为SetGetFields设置的值</param>
    /// <returns>统计信息</returns>
    public Task<StatsResult?> SearchStatsAsync(string queryString, List<string>? fields = null)
    {
        fields ??= _fields;
        
        var qBase64 = Utils.Base64Encode(queryString);
        var request = new RestRequest(_statsApiUrl)
            .AddQueryParameter("email", _apiEmail)
            .AddQueryParameter("key", _apiKey)
            .AddQueryParameter("qbase64", qBase64)
            .AddQueryParameter("fields", Strings.Join(fields.ToArray(), ","));
        return _httpClient.GetAsync<StatsResult>(request);
    }

    /// <summary>
    /// Host聚合查询
    /// </summary>
    /// <param name="host">主机名，通常为ip地址</param>
    /// <param name="isDetail">是否显示端口详情，默认为不显示</param>
    /// <returns>主机聚合的查询结果</returns>
    public HostResult? SearchHost(string host, bool isDetail = false)
    {
        var apiHost = _hostApiUrl + host;
        var request = new RestRequest(apiHost)
            .AddQueryParameter("email", _apiEmail)
            .AddQueryParameter("key", _apiKey)
            .AddQueryParameter("detail", isDetail);
        return _httpClient.Get<HostResult>(request);
    }

    /// <summary>
    /// 异步Host聚合查询
    /// </summary>
    /// <param name="host">主机名，通常为ip地址</param>
    /// <param name="isDetail">是否显示端口详情，默认为不显示</param>
    /// <returns>主机聚合的查询结果</returns>
    public Task<HostResult?> SearchHostAsync(string host, bool isDetail = false)
    {
        var apiHost = _hostApiUrl + host;
        var request = new RestRequest(apiHost)
            .AddQueryParameter("email", _apiEmail)
            .AddQueryParameter("key", _apiKey)
            .AddQueryParameter("detail", isDetail);
        return _httpClient.GetAsync<HostResult>(request);
    }
}