**FOFA .Net Sdk**

用于.Net 6的FOFA SDK

#### 安装方法

```powershell
Install-Package RadYanFoFaDotNet
```

#### 使用方法

##### 创建客户端

```csharp
var client = new FoFaClient(email, key);    // email:Fofa的邮箱，key：fofa的api key
```

#### 设置Api 地址

默认使用的`https://fofa.info`，如果后期有改变可以使用下面方法进行设置：

```csharp
client.SetApiDomain("https://fofa.info");
```

#### 获取用户信息

```csharp
// 同步获取
var result = client.GetUserInfo();
// 异步获取
var result = client.GetUserInfoAsync();
```

##### 返回数据

返回如下的类，类的字段与官方返回的数据一一对应

```csharp
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
```

#### 执行查询

```csharp
// 同步获取
// page: 当前第几页，默认为1
// size: 每页多少条数据，默认为20
// isFullData: 是否显示所有数据，默认为false，即只搜索最近一年的数据
var result = client.SearchAsync("要执行的查询语句", page=1, size=20, isFullData = false);
// 异步获取
var result = client.SearchAsync("要执行的查询语句" page=1, size=20, isFullData = false);
```

默认返回的结果字段为：

`ip,port,protocol,country_name,host,domain,server,title`

如需修改返回字段，请根据[官方文档](https://fofa.info/api)中对`fields`字段的说明进行设置，设置返回字段可以通过如下方法：

```csharp
client.SetGetFields(List<string> fields);
```

##### 返回数据

返回如下类：

```csharp
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
```

#### 统计聚合查询

```csharp
// 同步方式
// fields：
var stats = client.SearchStats("搜索语法", fields = null);

// 异步方式
var stats = client.SearchStatsAsync("搜索语法", fields = null);
```

##### 返回结果

```csharp
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
```

#### Host聚合查询

```csharp
// 同步方式
// isDetail：是否显示端口详情
var host = client.SearchHost("主机地址", isDetail = false);
// 异步方式
var host = client.SearchHostAsync("主机地址", isDetail = false);
```

##### 返回结果

```csharp
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
```

#### 计算favicon文件的哈希

计算favicon哈希的方式有两种，一种是通过favicon的http地址来获取，另一种是通过favicon的本地文件。

##### 通过favicon的http地址获取

需要传入favicon的http地址`url`，以及http请求超时时间`timeout`，http的地址需要是完整的地址，如：`https://github.com/favicon.ico`，time参数是的单位是毫秒，默认为2000，即2秒。

```csharp
Utils.GetIconHashFromHttp(url,timeout) 
```

##### 通过favicon文件获取

也可以直接通过本地的favicon的文件来获取哈希值，只需要传入完整的favicon文件的路径即可，如：`d:/favicon.ico`。

```csharp
Utils.GetIconHashFromHttp(file) 
```

#### Todo

- [x] 根据favicon地址获取图标哈希

- [x] 聚合统计
