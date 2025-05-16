using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        Console.Write("Enter a name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter numbers separated by spaces:");
        string[] inputArray = Console.ReadLine().Split(' ');
        int[] numbers = Array.ConvertAll(inputArray, int.Parse);

        Task_1(num, name, numbers);
    }

    public static void Task_1(int num, string name, int[] numbers)
    {
        Console.WriteLine("\n-------------------\n"); //Added a blank line for clarity in the 

        if (num > 7)
        {
            Console.WriteLine("Hello");
        }

        if (name == "John")
        {
            Console.WriteLine("Hello, John");
        }
        else
        {
            Console.WriteLine("There is no such name");
        }

        foreach (int i in numbers)
        {
            if (i % 3 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
