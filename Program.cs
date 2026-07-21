using System;
using System.Collections.Generic;

namespace TreasureCatte;

enum Digit
{
    First,
    Second
}

class Program
{
    static Dictionary<int, bool> numbers = new Dictionary<int, bool>();

    static void Odd(Digit digitPlace) // Odd digits are good, so mark evens as false
    {
        try
        {
            switch (digitPlace)
            {
                case Digit.First:
                    foreach (int i in numbers.Keys)
                    {
                        if (((i / 10) % 10) % 2 == 0)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                case Digit.Second:
                    foreach (int i in numbers.Keys)
                    {
                        if ((i % 10) % 2 == 0)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Error: Invalid digit placement.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    static void Even(Digit digitPlace) // Even digits are good, so mark odds as false
    {
        try
        {
            switch (digitPlace)
            {
                case Digit.First:
                    foreach (int i in numbers.Keys)
                    {
                        if (((i / 10) % 10) % 2 == 1)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                case Digit.Second:
                    foreach (int i in numbers.Keys)
                    {
                        if ((i % 10) % 2 == 1)
                        {
                            numbers[i] = false;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Error: Invalid digit placement.");
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
            if(target < 0 || target > 9) // Out of range
            {
                throw new ArgumentOutOfRangeException("Error: Target number must be between 0 and 9.");
            }

            foreach(int i in numbers.Keys)
            {
                if(((i / 10) % 10) != target && (i % 10) != target)
                {
                    numbers[i] = false;
                }
            }
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
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