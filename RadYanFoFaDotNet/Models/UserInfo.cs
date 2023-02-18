namespace RadYanFoFaDotNet.Models;

/// <summary>
/// 账号信息查询结果
/// </summary>
public class UserInfo
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
    /// 用户邮箱
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// 用户名
    /// </summary>
    public string? Username { get; set; }
    
    /// <summary>
    /// F币余额
    /// </summary>
    public int FCoin { get; set; }
    
    /// <summary>
    /// 是否为VIP
    /// </summary>
    public bool IsVip { get; set; }
    
    /// <summary>
    /// VIP等级
    /// </summary>
    public int VipLevel { get; set; }
    
    /// <summary>
    /// 是否已验证
    /// </summary>
    public bool IsVerified { get; set; }
    
    /// <summary>
    /// 头像
    /// </summary>
    public string? Avatar { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? Message { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? FoFaCliVersion { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public bool FoFaServer { get; set; }
}