using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitRepository
{
    internal class SumOfDigits
    {
        public static int Run(int num)
        {
            int sum = 0;
            while(num != 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
    }
}
