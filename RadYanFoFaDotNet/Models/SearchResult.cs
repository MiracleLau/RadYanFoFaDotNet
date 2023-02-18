namespace RadYanFoFaDotNet.Models;

/// <summary>
/// 搜索结果
/// </summary>
public class SearchResult
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
    /// 查询总数量
    /// </summary>
    public int Size { get; set; }
    
    /// <summary>
    /// 当前页码
    /// </summary>
    public int Page { get; set; }
    
    /// <summary>
    /// mode
    /// </summary>
    public string? Mode { get; set; }
    
    /// <summary>
    /// 查询语句
    /// </summary>
    public string? Query { get; set; }
    
    /// <summary>
    /// 结果列表
    /// </summary>
    public List<List<string>>? Results { get; set; }
}