using System;
using DatastructuresLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(String[] args)
        {
            var observableList = new ObservableList<string>();

            observableList.ItemAdded += (sender, e) =>
            {
                System.Console.WriteLine($"Елемент додано{e.Item}");
            };
            observableList.ItemInserted += (sender, e) =>
            {
                System.Console.WriteLine($"Елемент вставлено: {e.Item} на індекс {e.Index}");
            };
            observableList.ItemRemoved += (sender, e) =>
            {
                System.Console.WriteLine($"Елемент видалено: {e.Item}");
            };
            observableList.Add("Hello");
            observableList.Add("Wrold");
            observableList.Insert(1, "Observable");
            observableList.Remove("World");

            System.Console.WriteLine("Поточний список:");
            for(int i = 0; i < observableList.Count; i++)
            {
                System.Console.WriteLine(observableList[i]);
            }
        }
    }
}