using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SecondLargest
{
    class Program
    {
        static int[] array = new int[]{10,9,5,4,11,100,120,110};// { 7, 3, 11, 9, 2, 1, 12, 14, 6, 10 };
        static void Main(string[] args)
        {
            var tmp = new Dictionary<int, List<int>>();
            var res = FindMax(array, tmp);

            Console.WriteLine(res);
        }

        private static int? FindMax(int[] array, Dictionary<int, List<int>> tmp)
        {
            
            var maxIndex = ComparePairs(array, array.Select((x, i)=> i).ToList(), 0, tmp);
             var indexesToCompare = new List<int>();
             var index = maxIndex;
            for(var j=0;j<tmp.Keys.Count;j++)
            {
                var levelIds = tmp[j];
               indexesToCompare.Add(levelIds[index/2]);
               index = index/2;
           }
           var second = ComparePairs(array, indexesToCompare, 0, new Dictionary<int, List<int>>());
            return array[second];
        }

        private static int ComparePairs(int[] array, List<int> levelIndexes, int level, Dictionary<int, List<int>> minlevelIndexes)
        {
            if(levelIndexes.Count == 1){
                return levelIndexes.First();
            }
            var newLevel = new List<int>();
            minlevelIndexes.Add(level, new List<int>());
            for (int i = 0; i < levelIndexes.Count-1; i = i + 2)
            {
                var first = array[levelIndexes[i]];
                var second = array[levelIndexes[i+1]];
                if (first < second)
                {
                    minlevelIndexes[level].Add(levelIndexes[i]);
                    newLevel.Add(levelIndexes[i+1]);
                }
                else
                {
                     minlevelIndexes[level].Add(levelIndexes[i+1]);
                     newLevel.Add(levelIndexes[i]);
                }
                
            }
            if(levelIndexes.Count %2==1){
                newLevel.Add(levelIndexes.Last());
            }
            
            return ComparePairs(array, newLevel, level +1, minlevelIndexes);
            
        }

    }






}
