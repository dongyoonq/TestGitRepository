using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitRepository
{
    internal class FindWordCount
    {
        public static void Find()
        {
            string str = Console.ReadLine();
            string[] strArray = str.Split(' ');
            Console.WriteLine(strArray.Length);
        }
    }
}
