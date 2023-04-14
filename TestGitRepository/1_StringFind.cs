using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitRepository
{
    internal class StringFind
    {
        public static void Find()
        {
            string str = Console.ReadLine();
            string find = Console.ReadLine();

            int answer = -1;

            str = new string(str.Replace(find, "?"));

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '?')
                {
                    answer = i;
                    break;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
