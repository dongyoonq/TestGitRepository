using System;
using System.Collections.Generic;
using System.Linq;

namespace TestGitRepository
{
    internal class FindCommonItems
    {
        public static int[] Run(int[] arr1, int[] arr2, int[] arr3)
        {
            List<int> list = new List<int>();

            for(int i = 0; i < arr1.Length; i++)
                for(int j = 0; j < arr2.Length; j++)
                    if(arr1[i] == arr2[j])
                        list.Add(arr1[i]);

            int[] temp = list.Distinct().ToArray();
            list = new List<int>();

            for(int i = 0; i < temp.Length;i++)
                for(int j =0; j < arr3.Length; j++)
                    if(temp[i] == arr3[j])
                        list.Add(temp[i]);

            temp = list.Distinct().ToArray();

            return temp;
        }
    }
}
