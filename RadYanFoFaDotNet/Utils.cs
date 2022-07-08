using System.Text;

namespace RadYanFoFaDotNet;

public class Utils
{
    /**
     * 字符串base64编码
     */
    public static string Base64Encode(string str)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(bytes);
    }
    
    // Todo: 计算icon的哈希
    // Todo: 计算证书的序列号
}