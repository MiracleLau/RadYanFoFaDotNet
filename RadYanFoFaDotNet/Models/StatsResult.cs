namespace RadYanFoFaDotNet.Models;

/// <summary>
/// 统计聚合查询结果
/// </summary>
public class StatsResult
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
    /// 唯一计数
    /// </summary>
    public Distinct? Distinct { get; set; }
        
    /// <summary>
    /// 聚合信息
    /// </summary>
    public Aggs? Aggs { get; set; }
        
    /// <summary>
    /// 上次更新时间
    /// </summary>
    public string? LastUpdateTime { get; set; }
}

/// <summary>
/// 唯一计数
/// </summary>
public class Distinct
{
    /// <summary>
    /// ip计数
    /// </summary>
    public int IP { get; set; }
    
    /// <summary>
    /// 标题计数
    /// </summary>
    public int Title { get; set; }
    
    /// <summary>
    /// fid计数
    /// </summary>
    public int FId { get; set; }
    
    /// <summary>
    /// 主机计数
    /// </summary>
    public int Host { get; set; }
    
    /// <summary>
    /// 服务器计数
    /// </summary>
    public int Server { get; set; }
    
    /// <summary>
    /// icp计数
    /// </summary>
    public int ICP { get; set; }
    
    /// <summary>
    /// 域名计数
    /// </summary>
    public int Domain { get; set; }
}

/// <summary>
/// 聚合信息
/// </summary>
public class Aggs
{
    /// <summary>
    /// ASN编号统计
    /// </summary>
    public CommonAggsInfo[]? AsNumber { get; set; }
        
    /// <summary>
    /// ASN组织统计
    /// </summary>
    public CommonAggsInfo[]? AsOrganization { get; set; }
        
    /// <summary>
    /// 资产类型统计
    /// </summary>
    public CommonAggsInfo[]? AssetType { get; set; }
        
    /// <summary>
    /// 国家、城市统计
    /// </summary>
    public Country[]? Countries { get; set; }
        
    /// <summary>
    /// 域名统计
    /// </summary>
    public CommonAggsInfo[]? Domain { get; set; }
        
    /// <summary>
    /// fid统计
    /// </summary>
    public CommonAggsInfo[]? FId { get; set; }
        
    /// <summary>
    /// icp统计
    /// </summary>
    public CommonAggsInfo[]? ICP { get; set; }
        
    /// <summary>
    /// 系统统计
    /// </summary>
    public CommonAggsInfo[]? OS { get; set; }
        
    /// <summary>
    /// 端口统计
    /// </summary>
    public CommonAggsInfo[]? Port { get; set; }
        
    /// <summary>
    /// 协议统计
    /// </summary>
    public CommonAggsInfo[]? Protocol { get; set; }
        
    /// <summary>
    /// 服务器统计
    /// </summary>
    public CommonAggsInfo[]? Server { get; set; }
        
    /// <summary>
    /// 标题统计
    /// </summary>
    public CommonAggsInfo[]? Title { get; set; }
        
}

/// <summary>
/// 公用的聚合信息类
/// </summary>
public class CommonAggsInfo
{
    public int Count { get; set; }
    public string? Name { get; set; }
}

/// <summary>
/// 国家信息
/// </summary>
public class Country
{
    /// <summary>
    /// Base64编码的搜索语法
    /// </summary>
    public string? Code { get; set; }
        
    /// <summary>
    /// 数量
    /// </summary>
    public int Count { get; set; }
        
    /// <summary>
    /// 国家名称
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// 国家代码
    /// </summary>
    public string? NameCode { get; set; }
        
    /// <summary>
    /// 区域统计
    /// </summary>
    public Region[]? Regions { get; set; }
}

/// <summary>
/// 区域信息
/// </summary>
public class Region
{
    /// <summary>
    /// Base64编码后的搜索语法
    /// </summary>
    public string? Code { get; set; }
        
    /// <summary>
    /// 数量
    /// </summary>
    public int Count { get; set; }
        
    /// <summary>
    /// 区域名称
    /// </summary>
    public string? Name { get; set; }
}