using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace phonedata_benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!");
            BenchmarkRunner.Run<TestPhoneData>();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }

    public class TestPhoneData
    {

        [Benchmark]
        public void TestLookup()
        {
            var pd = new Phonedata.PhoneData();
            var dt1 = DateTime.Now;
            var phones = File.ReadAllLines("test.txt");
            phones = phones.Where(m => !string.IsNullOrEmpty(m)).Select(m => m.Trim()).ToArray();
            Parallel.ForEach(phones, (phone) =>
            {
                var phoneInfo = pd.Lookup(phone);
            });
            var dt2 = DateTime.Now;
            Console.WriteLine($"并行计算 {phones.Length}个手机号码的查找，用时： {(dt2 - dt1).TotalMilliseconds}毫秒。\n");

        }
    }
}
