using System;
using System.Collections.Generic;
using System.Text;

namespace TestGitRepository
{
    internal class IsPrime
    {
        public static bool CheckPrime(int n)
        {
            int cnt = 0;
            for(int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    cnt++;
            }

            return cnt == 2 ? true : false;
        }
    }
}
