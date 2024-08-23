using System.Collections.Generic;

namespace DoubleLinkedList
{
    internal static class Program
    {
        static void Main()
        {
            string[] words = ["Little", "Alex", "Horne", "loves", "Greg", "Davies"];

            DoubleLinkedList<string> myList = [];

            foreach (string word in words)
            {
                myList.AddToEnd(word);
            }

            Console.WriteLine(myList.Contains("Alex"));
            Console.WriteLine();

            foreach(var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            myList.Remove("Little");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            myList.Remove("loves");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
