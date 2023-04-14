using System;

namespace TestGitRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // #1 StringFind
            StringFind.Find();

            // #2 StringWordCountFind
            FindWordCount.Find();

            // #3 IsPrime
            if(IsPrime.CheckPrime(int.Parse(Console.ReadLine())))
                Console.WriteLine("소수 입니다.");
            else
                Console.WriteLine("소수가 아닙니다.");

            // #4 SumOfDigits
            SumOfDigits.Run(int.Parse(Console.ReadLine()));

            // #5 FindCommonItems
            int[] arr1 = { 1, 5, 5, 10 };
            int[] arr2 = { 3, 4, 5, 5, 10 };
            int[] arr3 = { 5, 5, 10, 20 };
            int[] result = FindCommonItems.Run(arr1, arr2, arr3);
            foreach(int item in result)
                Console.WriteLine($"{item}");
            */

            // #6 UpAndDown
            UpAndDown.Run();
        }
    }
}
