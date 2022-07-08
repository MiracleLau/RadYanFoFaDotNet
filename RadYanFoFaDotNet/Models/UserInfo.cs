namespace RadYanFoFaDotNet.Models;

public class UserInfo
{
    public bool Error { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public int FCoin { get; set; }
    public bool IsVip { get; set; }
    public int VipLevel { get; set; }
    public bool IsVerified { get; set; }
    public string Avatar { get; set; }
    public string Message { get; set; }
    public string FoFaCliVersion { get; set; }
    public bool FoFaServer { get; set; }
}