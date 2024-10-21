using DataStructuresLibrary;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(1, 4);
            Console.WriteLine("Custom List:");
            foreach(var item in list.ToArray())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"list countains 2: {list.Contains(2)}");
            list.Remove(2);
            Console.WriteLine("List after removing 2:");
            foreach(var item in list.ToArray())
            {
                Console.WriteLine(item);
            }
            BinarySearchThree tree = new BinarySearchThree();
            tree.Add(10);
            tree.Add(5);
            tree.Add(20);
            tree.Add(15);
            Console.WriteLine("Binary Search Three (in order traversal):");
            foreach(var item in tree.ToArray())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Tree conatains 15: {tree.Contains(15)}");
            tree.Clear();
            Console.WriteLine($"Three count after clearing: {tree.Count}");
        }
    }
}