using System.Collections.Generic;

namespace DoubleLinkedList
{
    internal static class Program
    {
        static void Main()
        {
            string[] words = ["Little", "Alex", "Horne", "loves", "Greg", "Davies"];

            string[] empty = new string[12];

            DoubleLinkedList<string> myList = [];

            foreach (string word in words)
            {
                myList.AddToEnd(word);
            }

            Console.WriteLine("Results of CopyTo method:");
            myList.CopyTo(empty, 3);
            foreach(string word in empty)
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
            foreach(string? item in myList)
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

            Console.ReadKey();
        }
    }
}
