using System;
using System.Collections.Generic;

namespace Dynamic_Programming
{
    class Worm
    {
        private List<int> subsequence = new List<int>();
        private List<int> temp = new List<int>();
        private List<int> tail = new List<int>();
        public int LengthSequence
        {
            get { return subsequence.Count; }
        }
        public List<int> Subsequence
        {
            get { return subsequence; }
        }
        public List<int> Temp
        {
            get { return temp; }
        }
        public List<int> Tail
        {
            get { return tail; }
        }
        public Worm(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (i < a.Length / 2)
                {
                    temp.Add(a[i]);
                }
                if (i >= a.Length / 2)
                {
                    tail.Add(a[i]);
                }
            }
        }
    }
    class Program
    {
        static void InputArray(int[] a)
        {
            Console.WriteLine("Input array: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("a[{0}] = ", i + 1);
                a[i] = int.Parse(Console.ReadLine());
            }
        }
        static void ShowArray(int[] a)
        {
            Console.WriteLine("Array: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }
        //static void DeleteDuplicateElements(List<int> temp)
        //{
        //    int i = 0;
        //    while (i != temp.Count)
        //    {
        //        for (int j = i + 1; j < temp.Count; j++)
        //        {
        //            if (temp[i] == temp[j])
        //            {
        //                temp.Remove(temp[j]);
        //            }
        //        }
        //        i++;
        //    }
        //}
        static void RainyDay(List<int> temp, List<int> subsequence, List<int> tail, int head)
        {
            bool isEnd = true;
            for (int i = 0; i < temp.Count; i++)
            {
                if (head % temp[i] == 0)
                {
                    subsequence.Add(temp[i]);
                    head = temp[i];
                    temp.Remove(temp[i]);
                    isEnd = false;
                }
            }
            if (subsequence.Count > 0)
            {
                head = subsequence[subsequence.Count - 1];
            }
            for (int i = 0; i < temp.Count; i++)
            {
                tail.Add(temp[i]);
            }
            tail.Sort();
            tail.Reverse();
            temp.Clear();
            if (isEnd)
            {
                return;
            }
            RainyDay(tail, subsequence, temp, head);
        }
        static void MidNight(List<int> temp, List<int> subsequence, int moon)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i] % moon == 0)
                {
                    subsequence.Add(temp[i]);
                    moon = temp[i];
                }
            }
            subsequence.Sort();
            temp.Clear();
        }
        static void SunDay(List<int> temp, List<int> subsequence, List<int> tail, int head)
        {
            for (int i = temp.Count - 1; i >= 0; i--)
            {
                if (head % temp[i] == 0)
                {
                    subsequence.Add(temp[i]);
                    head = temp[i];
                    temp.Remove(temp[i]);
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                tail.Add(temp[i]);
            }
            tail.Sort();
            temp.Clear();
            if (subsequence.Count > 0)
            {
                MidNight(tail,subsequence, subsequence[0]);
            }
        }
        static int ElementWithMaxLength(int[] a)
        {
            int max = 0, number = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                    number = i;
                }
            }
            return number;
        }
        static void Implementation(int[] a)
        {
            Worm[] combinations = new Worm[a.Length];
            int longWorm;
            int[] lengthWorms = new int[a.Length];
            InputArray(a);
            Array.Sort(a);
            Array.Reverse(a);
            ShowArray(a);
            for (int i = 0; i < combinations.Length / 2; i++)
            {
                combinations[i] = new Worm(a);
            }
            Array.Reverse(a);
            ShowArray(a);
            for (int i = combinations.Length / 2; i < combinations.Length; i++)
            {
                combinations[i] = new Worm(a);
            }
            int j = combinations.Length / 2 - 1;
            for (int i = 0; i < combinations.Length; i++)
            {
                if (i >= combinations.Length / 2)
                {
                    SunDay(combinations[i].Temp, combinations[i].Subsequence, combinations[i].Tail, a[j]);
                    j--;
                    continue;
                }
                RainyDay(combinations[i].Temp, combinations[i].Subsequence, combinations[i].Tail, a[i]);
            }
            for (int i = 0; i < a.Length; i++)
            {
                lengthWorms[i] = combinations[i].LengthSequence;
            }
            longWorm = ElementWithMaxLength(lengthWorms);
            ShowArray(combinations[longWorm].Subsequence.ToArray());
        }
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Input array size (>3): ");
                n = int.Parse(Console.ReadLine());
            }
            while (n < 4);
            int[] arr = new int[n];
            Implementation(arr);
        }
    }
}
