using System;
using System.Collections.Generic;

namespace TreasureCatte;

class Program
{
    static Dictionary<int, bool> numbers = new Dictionary<int, bool>();

    static void Odd(int digitPlace) // Odd digits are good, so mark evens as false
    {
        try
        {
            switch (digitPlace)
            {
                case 1:
                    foreach (int i in numbers.Keys)
                    {
                        if (((i / 10) % 10) % 2 == 0)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                case 2:
                    foreach (int i in numbers.Keys)
                    {
                        if ((i % 10) % 2 == 0)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Error: Invalid digit placement.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    static void Even(int digitPlace) // Even digits are good, so mark odds as false
    {
        try
        {
            switch (digitPlace)
            {
                case 1:
                    foreach (int i in numbers.Keys)
                    {
                        if (((i / 10) % 10) % 2 == 1)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                case 2:
                    foreach (int i in numbers.Keys)
                    {
                        if ((i % 10) % 2 == 1)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Error: Invalid digit placement.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void BetweenNumbers(int lowerBound, int upperBound)
    {
        try
        {
            if (lowerBound < 10 || lowerBound > 99) // Check to see if lower bound is out of range
            {
                throw new ArgumentOutOfRangeException("Error: Lower bound must be between 10 and 99.");
            }
            if (upperBound < 10 || upperBound > 99) // Check to see if upper bound is out of range
            {
                throw new ArgumentOutOfRangeException("Error: Upper bound must be between 10 and 99.");
            }

            foreach (int i in numbers.Keys)
            {
                if (i < lowerBound)
                {
                    numbers[i] = false;
                }
                if (i > upperBound)
                {
                    numbers[i] = false;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void OneDigitIsNumber(int target)
    {
        try
        {
            if (target < 0 || target > 9) // Out of range
            {
                throw new ArgumentOutOfRangeException("Error: Target number must be between 0 and 9.");
            }

            foreach (int i in numbers.Keys)
            {
                if (((i / 10) % 10) != target && (i % 10) != target)
                {
                    numbers[i] = false;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    static void ThreeNumberSequence(int digitPlace, int target)
    {
        try
        {
            if (target < 0 || target > 7) // Out of range
            {
                throw new ArgumentOutOfRangeException("Error: Target number must be between 0 and 7.");
            }

            switch (digitPlace)
            {
                case 1:
                    foreach (int i in numbers.Keys)
                    {
                        if (((i / 10) % 10) != target && ((i / 10) % 10) != target + 1 && ((i / 10) % 10) != target + 2)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                case 2:
                    foreach (int i in numbers.Keys)
                    {
                        if ((i % 10) != target && (i % 10) != target + 1 && (i % 10) != target + 2)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Error: Invalid digit placement.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static int FindMedian()
    {
        int numTrue = 0;

        foreach (int i in numbers.Keys)
        {
            if (numbers[i] == true)
            {
                numTrue++;
            }
        }

        int[] trueItems = new int[numTrue];
        int index = 0;

        foreach (int i in numbers.Keys)
        {
            if (numbers[i] == true)
            {
                trueItems[index] = i;
                index++;
            }
        }

        Array.Sort(trueItems);
        int size = trueItems.Length;
        int mid = size / 2;

        if (size % 2 != 0)
        {
            return trueItems[mid];
        }
        else
        {
            return trueItems[mid - 1];
        }
    }

    static void ResetArray()
    {
        for (int i = 10; i < 100; i++)
        {
            numbers[i] = true;
        }
    }

    static void Main(string[] args)
    {
        ResetArray();
        Console.WriteLine("Hello, World!");
    }
}