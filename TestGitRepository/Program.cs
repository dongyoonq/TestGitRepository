using System;

namespace TestGitRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1 StringFind
            StringFind.Find();

            // #2 StringWordCountFind
            FindWordCount.Find();

            // #3 IsPrime
            if(IsPrime.CheckPrime(int.Parse(Console.ReadLine())))
                Console.WriteLine("소수 입니다.");
            else
                Console.WriteLine("소수가 아닙니다.");
        }
    }
}
