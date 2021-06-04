using System;

namespace UnimodalArrayMax
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var arr = new UnimodalArray(new int[] { 1, 2, 2, 4, 5, 3, 2, 1  });
            var res = arr.FindMax();
            Console.WriteLine("Hello World! " + res);
        }
        
    }
}
