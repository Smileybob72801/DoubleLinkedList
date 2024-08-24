using System.Collections.Generic;
using System.Diagnostics;

namespace DoubleLinkedList
{
    internal static class Program
    {
        static void Main()
        {
            Stopwatch stopWatch = new();

            string[] words = ["Little", "Alex", "Horne", "loves", "Greg", "Davies"];

            string[] empty = new string[12];

            ILinkedList<string?> myList = new DoubleLinkedList<string?>();

            foreach (string word in words)
            {
                myList.AddItemToEnd(word);
            }

            Console.WriteLine("Results of CopyTo method:");
            myList.CopyTo(empty, 3);
            foreach (string word in empty)
            {
                if (word is null)
                    Console.WriteLine("null");
                else
                    Console.WriteLine(word);
            }
            Console.WriteLine();

            Console.WriteLine("Does the linked list contain \"Alex\"?");
            Console.WriteLine(myList.Contains("Alex"));
            Console.WriteLine();

            Console.WriteLine("Using the enumerator to iterate through the linked list.");
            foreach (string? item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Reversing the list," +
                "then using the enumerator again to iterate through the linked list.");
            myList.ReverseNodes();
            foreach (string? item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Using the Remove method to remove \"Little\", and then " +
                "iterating the linked list again.");
            myList.Remove("Little");
            foreach (string? item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Now let's remove \"loves\" from the middle of the linked list.");
            myList.Remove("loves");
            foreach (string? item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Calling the Clear method, then iterating the linked list.");
            myList.Clear();
            foreach (string? item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            ILinkedList<string?> newList = new DoubleLinkedList<string?>();

            Node<string?> customNodeOne = new("The Taskmaster");
            Node<string?> customNodeTwo = new("is fair, but ");
            Node<string?> customNodeThree = new("is mostly cruel.");

            Console.WriteLine("Building a new list with nodes rather than strings.");
            newList.AddNode(customNodeOne);
            newList.AddNode(customNodeThree);

            foreach (string? item in newList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Inserting a node before another node, an O(1) operation.");
            newList.InsertBeforeNode(customNodeTwo, customNodeThree);
            foreach (string? item in newList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Removing a node is also O(1).");
            newList.RemoveNode(customNodeTwo);
            foreach (string? item in newList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            int[] bigArray = Enumerable.Range(0, 10_000_000).ToArray();

            ILinkedList<int?> intList = new DoubleLinkedList<int?>();

            foreach (int number in bigArray)
            {
                Node<int?> newNode = new(number);
                intList.AddNode(newNode);
            }

            Node<int?> nodeAtEndOfList = new(10_000_002);
            intList.AddNode(nodeAtEndOfList);

            Console.WriteLine("Searching a large list of ints for a specific element");
            ToggleWatch();
            Console.WriteLine(intList.Contains(9_999_999));
            ToggleWatch();

            Console.WriteLine("Demonstrating the speed of adding a node to the middle" +
                "of a doubly linked list.");
            Node<int?> addedNode = new(10_000_001);
            ToggleWatch();
            intList.InsertBeforeNode(addedNode, nodeAtEndOfList);
            ToggleWatch();

            Console.WriteLine("And now lets remove that node.");
            ToggleWatch();
            intList.RemoveNode(addedNode);
            ToggleWatch();

            Console.ReadKey();

            void ToggleWatch()
            {
                if (!stopWatch.IsRunning)
                {
                    stopWatch.Reset();
                    stopWatch.Start();
                }
                else
                {
                    stopWatch.Stop();
                    Console.WriteLine($"Took {stopWatch.Elapsed.TotalMilliseconds} ms");
                }
            }
        }
    }
}
