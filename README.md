## phonedata.bat analysis With NetCore

 modify from [Phonedata](https://github.com/sndnvaps/Phonedata)

## Benchmark Test:

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18362.30 (1903/May2019Update/19H1)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|     Method |     Mean |   Error |   StdDev |
|----------- |---------:|--------:|---------:|
| TestLookup | 253.1 ms | 5.04 ms | 10.63 ms |

```
OverheadJitting  1: 1 op, 300100.00 ns, 300.1000 us/op
12345678999 is not in phonedata
32652365321 is not in phonedata
11111111111 is not in phonedata
25525632145 is not in phonedata
12354546872 is not in phonedata
12345678910 is not in phonedata
12771665555 is not in phonedata
并行计算 27768个手机号码的查找，用时： 37.31毫秒。
```

 
## example code
```
Install-Package Phonedata_NetCore -Version 1.0.0
```

```csharp
using System;
using Phonedata;

namespace PhonedataDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var pd = new PhoneData();
            string output;
            output = pd.Lookup("15168236518").ToString();
            Console.WriteLine(output);
            Console.WriteLine("Hello World!");
        }
    }
}

output :

PhoneNum: 15168236518
AreaZon: 0571
CardType: 中国移动
City: 杭州
ZipCode: 310000
Province: 浙江
```

## 手机号码库

- 归属地信息库文件大小：4,040,893 字节
- 归属地信息库最后更新：2020年04月
- 手机号段记录条数：447893 
- Md5： a474c3c607bcca348c1ca486d909066d

## 其他语言支持 

 go: https://github.com/xluohome/phonedata

 python: https://github.com/lovedboy/phone
 
 php :  https://github.com/shitoudev/phone-location , https://github.com/iwantofun/php_phone
 
 php ext: https://github.com/jonnywang/phone
 
 java: https://github.com/fengjiajie/phone-number-geo
 
 Node: https://github.com/conzi/phone
 
 C++: https://github.com/yanxijian/phonedata
 
 C#: https://github.com/sndnvaps/Phonedata

 NetCore: https://github.com/windnight/Phonedata_NetCore
  

## phone.dat文件格式

```
| 4 bytes |                     <- phone.dat 版本号
------------
| 4 bytes |                     <-  第一个索引的偏移
-----------------------
|  offset - 8            |      <-  记录区
-----------------------
|  index                 |      <-  索引区
-----------------------

```

* `头部` 头部为8个字节，版本号为4个字节，第一个索引的偏移为4个字节。
* `记录区` 中每条记录的格式为"\<省份\>|\<城市\>|\<邮编\>|\<长途区号\>\0"。 每条记录以'\0'结束。  
* `索引区` 中每条记录的格式为"<手机号前七位><记录区的偏移><卡类型>"，每个索引的长度为9个字节。

解析步骤:

 * 解析头部8个字节，得到索引区的第一条索引的偏移。
 * 在索引区用二分查找得出手机号在记录区的记录偏移。
 * 在记录区从上一步得到的记录偏移处取数据，直到遇到'\0'。


 ## 安全保证

手机号归属地信息是通过网上公开数据进行收集整理。

对手机号归属地信息数据的绝对正确，我不做任何保证。因此在生产环境使用前请您自行校对测试。

