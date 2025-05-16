using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter a number: ");
            string numInput = Console.ReadLine();
            int num;

            if (long.TryParse(numInput, out long longNum))
            {
                if (longNum > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(null, "The number you entered is too large.");
                }
                else if (longNum < int.MinValue)
                {
                    throw new ArgumentOutOfRangeException(null, "The number you entered is too small.");
                }

                num = (int)longNum;
            }

            else
            {
                throw new FormatException($"'{numInput}' is not a valid number.");
            }

            Console.Write("Enter a name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            else if (!Regex.IsMatch(name, @"^[a-zA-Z\s'-]+$"))
            {
                throw new ArgumentException("Name contains invalid characters. Only letters, spaces, hyphens (-), and apostrophes (') are allowed.");
            }


            Console.WriteLine("Enter numbers separated by spaces:");
            string numbersInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(numbersInput))
            {
                throw new ArgumentException("Number list cannot be empty.");
            }

            string[] inputArray = numbersInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbersList = new List<int>();

            foreach (string item in inputArray)
            {
                if (long.TryParse(item, out long parsedLong))
                {
                    if (parsedLong > int.MaxValue)
                    {
                        throw new ArgumentOutOfRangeException(null, $"Number '{item}' is too large.");
                    }
                    else if (parsedLong < int.MinValue)
                    {
                        throw new ArgumentOutOfRangeException(null, $"Number '{item}' is too small.");
                    }
                    else
                    {
                        numbersList.Add((int)parsedLong);
                    }
                }
                else
                {
                    throw new FormatException($"'{item}' is not a valid number.");
                }
            }

            int[] numbers = numbersList.ToArray();
            Task_1(num, name, numbers);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Input error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Input error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }

    public static void Task_1(int num, string name, int[] numbers)
    {
        Console.WriteLine("\n-------------------\n"); //Added a blank line for clarity in the Console.

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


/*
 * 2nd Task:
 *  
 * Given bracket sequence: [((())()(())]]
 *  
 * Can this sequence be considered correct? 
 *  
 * - No, for a bracket sequence to be considered correct,
 *   every opening bracket has to have a corresponding 
 *   closing bracket of the same type, and they must be properly nested.
 * 
 * If the answer to the previous question is “no,” then what needs to be changed to make it correct? 
 * 
 * - There are many ways to make it correct:
 * 
 *   1st option --> Replace the first opening parenthesis "(" on the left with the bracket "[". That way, 
 *   we have matching pairs of brackets on both sides, and correctly nested sets of parentheses inside.
 *   [[(())()(())]]
 *   
 *   2nd option --> Remove the first parenthesis "(" on the left along with the first or second bracket "]" from the right.
 *   That way, the first opening bracket from the left has the symmetrical one on the right side, and there are correctly
 *   nested sets of parentheses inside.
 *   [(())()(())]
 *    
 *   Alternatively, we could remove or replace parentheses and brackets from both sides, such as removing 
 *   the first two and last two characters in the sequence (which would leave us with a perfectly correct sequence), but
 *   the point is this: Every opening bracket or parenthesis has to have its pair — a matching closing bracket on the corresponding side.
 *   (())()(())
 * 
 */

