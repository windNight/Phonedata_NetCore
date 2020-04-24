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
