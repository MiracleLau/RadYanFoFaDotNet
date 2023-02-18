using System.Text;
using RestSharp;

namespace RadYanFoFaDotNet;

public static class Utils
{
    /// <summary>
    /// 字符串base64编码
    /// </summary>
    /// <param name="str">要进行编码的字符串</param>
    /// <returns>base64字符串</returns>
    public static string Base64Encode(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// 计算icon hash
    /// </summary>
    /// <param name="fileBytes">icon的文件字节</param>
    /// <returns>哈希值</returns>
    public static int CalculateIconHash(byte[] fileBytes)
    {
        var fileBase64 = Convert.ToBase64String(fileBytes, Base64FormattingOptions.InsertLineBreaks);
        // C#给字符串加的换行是\r\n，所以需要把\r给去掉，并且需要在结尾加上一个\n
        fileBase64 = fileBase64.Replace("\r", "") + "\n";
        var base644Bytes = Encoding.UTF8.GetBytes(fileBase64);
        return MurmurHash3.GetMurmur32BitsX86(base644Bytes, 0);

    }

    /// <summary>
    /// 通过本地icon文件进行哈希值
    /// </summary>
    /// <param name="file">文件名称</param>
    /// <returns>哈希值</returns>
    public static int GetIconHashFromFile(string file)
    {
        var fileBytes = File.ReadAllBytes(file);
        return CalculateIconHash(fileBytes);
    }

    /// <summary>
    /// 通过favicon的url地址来计算哈希值
    /// </summary>
    /// <param name="url">favicon的地址</param>
    /// <param name="timeout">超时时间，单位毫秒，默认是3000毫秒，即3秒</param>
    /// <returns>哈希值</returns>
    public static int GetIconHashFromHttp(string url, int timeout = 3000)
    {
        var options = new RestClientOptions(url)
        {
            MaxTimeout = timeout,
            ThrowOnAnyError = true,
        };
        var client = new RestClient(options);
        var request = new RestRequest();
        var result = client.Get(request).RawBytes;
        if (result is null) return -1;
        return CalculateIconHash(result);
    }

}