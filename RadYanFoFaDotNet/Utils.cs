using System.Text;

namespace RadYanFoFaDotNet;

public static class Utils
{
    /**
     * 字符串base64编码
     */
    public static string Base64Encode(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(bytes);
    }
    
    // Todo: 计算icon的哈希
}