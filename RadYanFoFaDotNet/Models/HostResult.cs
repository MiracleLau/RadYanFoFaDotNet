using System.Text.Json.Serialization;

namespace RadYanFoFaDotNet.Models;

/// <summary>
/// Host聚合查询结果
/// </summary>
public class HostResult
{
    /// <summary>
    /// 是否出错
    /// </summary>
    public bool Error { get; set; }
        
    /// <summary>
    /// 错误信息
    /// </summary>
    public string? ErrMsg { get; set; }
        
    /// <summary>
    /// 主机地址
    /// </summary>
    public string? Host { get; set; }
        
    /// <summary>
    /// ip地址
    /// </summary>
    public string? Ip { get; set; }
        
    /// <summary>
    /// asn编号
    /// </summary>
    public int Asn { get; set; }
        
    /// <summary>
    /// 所属组织
    /// </summary>
    public string? Org { get; set; }
        
    /// <summary>
    /// 国家
    /// </summary>
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }
        
    /// <summary>
    /// 国家代码
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }
        
    /// <summary>
    /// 协议列表
    /// </summary>
    public string[]? Protocol { get; set; }
        
    /// <summary>
    /// 端口列表
    /// </summary>
    public int[]? Port { get; set; }
        
    /// <summary>
    /// 分类标签
    /// </summary>
    public string[]? Category { get; set; }
        
    /// <summary>
    /// 产品标签
    /// </summary>
    public string[]? Product { get; set; }
        
    /// <summary>
    /// 端口详情，仅在查询时传入detail=true时生效
    /// </summary>
    public PortList[]? Ports { get; set; }
        
    /// <summary>
    /// 更新时间
    /// </summary>
    [JsonPropertyName("update_time")]
    public string? UpdateTime { get; set; }
}

/// <summary>
/// 端口详情
/// </summary>
public class PortList
{
    /// <summary>
    /// 端口
    /// </summary>
    public int Port { get; set; }
        
    /// <summary>
    /// 协议
    /// </summary>
    public string? Protocol { get; set; }
        
    /// <summary>
    /// 产品详情列表
    /// </summary>
    public ProductList[]? Products { get; set; }
}

/// <summary>
/// 产品详情列表
/// </summary>
public class ProductList
{
    /// <summary>
    /// 产品名称
    /// </summary>
    public string? Product { get; set; }
        
    /// <summary>
    /// 产品分类
    /// </summary>
    public string? Category { get; set; }
        
    /// <summary>
    /// 产品分层： 5 应用层， 4 支持层， 3 服务层，2 系统层， 1 硬件层， 0 无组件分层
    /// </summary>
    public int Level { get; set; }
        
    /// <summary>
    /// 产品是否为硬件；值为 1 是硬件，否则为非硬件
    /// </summary>
    public int SortHardCode { get; set; }
}