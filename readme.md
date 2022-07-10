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
    public bool Error { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public int FCoin { get; set; }
    public bool IsVip { get; set; }
    public int VipLevel { get; set; }
    public bool IsVerified { get; set; }
    public string? Avatar { get; set; }
    public string? Message { get; set; }
    public string? FoFaCliVersion { get; set; }
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
    public bool Error { get; set; }
    public int Size { get; set; }
    public int Page { get; set; }
    public string? Mode { get; set; }
    public string? Query { get; set; }
    public List<List<string>>? Results { get; set; }
}
```



#### Todo

- [ ]  根据favicon地址获取图标哈希

- [ ]  聚合统计
