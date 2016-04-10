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
        static void DeleteNeededElements(List<int> temp, List<int> main)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < main.Count; j++)
                {
                    if (temp[i] == main[j])
                    {
                        temp.Remove(temp[i]);
                    }
                }
            }
        }
        static void DeleteDuplicateElements(List<int> temp)
        {
            int i = 0;
            while (i != temp.Count)
            {
                for (int j = i + 1; j < temp.Count; j++)
                {
                    if (temp[i] == temp[j])
                    {
                        temp.Remove(temp[j]);
                    }
                }
                i++;
            }
        }
        static void RainyDay(List<int> temp, List<int> subsequence, List<int> tail, int head)
        {
            bool isEnd = true;
            for (int i = 0; i < temp.Count; i++)
            {
                if (head % temp[i] == 0)
                {
                    subsequence.Add(temp[i]);
                    head = temp[i];
                    isEnd = false;
                }
            }
            DeleteNeededElements(temp, subsequence);
            for (int i = 0; i < temp.Count; i++)
            {
                tail.Add(temp[i]);
            }
            tail.Sort();
            tail.Reverse();
            DeleteDuplicateElements(tail);
            head = subsequence[subsequence.Count - 1];
            if (isEnd)
            {
                return;
            }
            RainyDay(tail, subsequence, temp, head);
        }
        static void SunDay(List<int> temp, List<int> subsequence, List<int> tail, int head)
        {
            bool isEnd = true;
            for (int i = 0; i < temp.Count; i++)
            {
                if (head % temp[i] == 0)
                {
                    subsequence.Add(temp[i]);
                    head = temp[i];
                    isEnd = false;
                }
            }
            DeleteNeededElements(temp, subsequence);
            for (int i = 0; i < temp.Count; i++)
            {
                tail.Add(temp[i]);
            }
            tail.Sort();
            tail.Reverse();
            DeleteDuplicateElements(tail);
            head = subsequence[subsequence.Count - 1];
            if (isEnd)
            {
                return;
            }
            RainyDay(tail, subsequence, temp, head);
        }
        static int MaxLength(int[] a)
        {
            int max = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }
            return max;
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
            //for (int i = combinations.Length / 2; i < combinations.Length; i++)
            //{
            //    combinations[i] = new Worm(a);
            //}
            //for (int i = 0; i < combinations.Length; i++)
            //{
            //    RainyDay(combinations[i].Temp, combinations[i].Subsequence, combinations[i].Tail, a[i]);
            //}
            //for (int i = 0; i < a.Length; i++)
            //{
            //    lengthWorms[i] = combinations[i].LengthSequence;
            //}
            //longWorm = MaxLength(lengthWorms);
            //ShowArray(combinations[longWorm].Subsequence.ToArray());
        }
        static void Main(string[] args)
        {
            int n;
            Console.Write("Input array size: ");
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Implementation(arr);
        }
    }
}
