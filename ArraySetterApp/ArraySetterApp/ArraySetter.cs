using BenchmarkDotNet.Attributes;
using System;

namespace ArraySetterApp
{
    [MemoryDiagnoser]
    [RankColumn]
    public class ArraySetter
    {
        [Benchmark]
        public void SetArrayValuesWithIf()
        {
            var arr = new int[7, 7];
            var random = new Random();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    arr[i, j] = IsInScope(i, j) ? 0 : random.Next(1, 100);
                }
            }

            //for (int i = 0; i < 7; i++)
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        Console.Write($"{arr[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
        }

        public void SetArrayValuesWithIfOptimized()
        {
            var arr = new int[7, 7];
            var random = new Random();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (!IsInScope(i, j))
                    {
                        arr[i, j] = random.Next(1, 100);
                    }

                }
            }

            //for (int i = 0; i < 7; i++)
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        Console.Write($"{arr[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
        }

        [Benchmark]
        public void SetArrayValuesByZero()
        {
            var arr = new int[7, 7];
            var random = new Random();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    arr[i, j] = random.Next(1, 100);
                }
            }

            for (int i = 2; i < 5; i++)
            {
                for (int j = 2; j < 5; j++)
                {
                    arr[i, j] = 0;
                }
            }

            //for (int i = 0; i < 7; i++)
            //{
            //    for (int j = 0; j < 7; j++)
            //    {
            //        Console.Write($"{arr[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
        }

        private bool IsInScope(int i, int j)
        {
            return i >= 2 &&
                   i <= 4 &&
                   j >= 2 &&
                   j <= 4;
        }
    }
}
