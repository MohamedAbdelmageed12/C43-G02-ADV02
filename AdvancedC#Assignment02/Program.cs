using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment02_AdvancedCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Q1: Count numbers greater than X in an array
            int[] numbers = { 11, 5, 3 };
            int[] queries = { 1, 5, 13 };
            foreach (var x in queries)
            {
                Console.WriteLine(numbers.Count(n => n > x));
            }
            #endregion

            #region Q2: Check if an array is a palindrome
            int[] palindromeArray = { 1, 3, 2, 3, 1 };
            Console.WriteLine(palindromeArray.SequenceEqual(palindromeArray.Reverse()) ? "YES" : "NO");
            #endregion

            #region Q3: Reverse a queue using a stack
            Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0) stack.Push(queue.Dequeue());
            while (stack.Count > 0) queue.Enqueue(stack.Pop());
            Console.WriteLine(string.Join(", ", queue));
            #endregion

            #region Q4: Check balanced parentheses
            string input = "[()]{})";
            Console.WriteLine(IsBalanced(input) ? "Balanced" : "Not Balanced");
            #endregion

            #region Q5: Remove duplicates from an array
            int[] arrayWithDuplicates = { 1, 2, 2, 3, 4, 4, 5 };
            int[] uniqueArray = arrayWithDuplicates.Distinct().ToArray();
            Console.WriteLine(string.Join(", ", uniqueArray));
            #endregion

            #region Q6: Remove all odd numbers from an array list
            List<int> arrayList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            arrayList.RemoveAll(n => n % 2 != 0);
            Console.WriteLine(string.Join(", ", arrayList));
            #endregion

            #region Q7: Implement a queue for different data types
            Queue<object> mixedQueue = new Queue<object>();
            mixedQueue.Enqueue(1);
            mixedQueue.Enqueue("Apple");
            mixedQueue.Enqueue(5.28);
            Console.WriteLine(string.Join(", ", mixedQueue));
            #endregion

            #region Q8: Search for a target integer in a stack
            Stack<int> numStack = new Stack<int>(new[] { 10, 20, 30, 40, 50 });
            int target = 30;
            int count = 0;
            bool found = false;
            foreach (var num in numStack)
            {
                count++;
                if (num == target)
                {
                    found = true;
                    break;
                }
            }
            Console.WriteLine(found ? $"Target was found successfully and the count = {count}" : "Target was not found");
            #endregion

            #region Q9: Find intersection of two arrays
            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };
            var intersection = arr1.Intersect(arr2).ToArray();
            Console.WriteLine("[" + string.Join(", ", intersection) + "]");
            #endregion

            #region Q10: Find contiguous sublist that sums to target
            List<int> list = new List<int> { 1, 2, 3, 7, 5 };
            int targetSum = 12;
            FindSublistWithSum(list, targetSum);
            #endregion

            #region Q11: Reverse first K elements of a queue
            Queue<int> queueK = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            int K = 3;
            ReverseFirstKElements(queueK, K);
            Console.WriteLine(string.Join(", ", queueK));
            #endregion
        }

        static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char> { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            foreach (char c in s)
            {
                if (pairs.ContainsValue(c)) stack.Push(c);
                else if (pairs.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[c]) return false;
                }
            }
            return stack.Count == 0;
        }

        static void FindSublistWithSum(List<int> list, int target)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int sum = 0;
                for (int j = i; j < list.Count; j++)
                {
                    sum += list[j];
                    if (sum == target)
                    {
                        Console.WriteLine("[" + string.Join(", ", list.GetRange(i, j - i + 1)) + "]");
                        return;
                    }
                }
            }
            Console.WriteLine("No sublist found");
        }

        static void ReverseFirstKElements(Queue<int> queue, int k)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < k; i++) stack.Push(queue.Dequeue());
            while (stack.Count > 0) queue.Enqueue(stack.Pop());
            for (int i = 0; i < queue.Count - k; i++) queue.Enqueue(queue.Dequeue());
        }
    }
}
