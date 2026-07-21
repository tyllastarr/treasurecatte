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
    static Dictionary<int,bool> numbers = new Dictionary<int, bool>();

    static void Odd(Digit digitPlace) // Odd digits are good, so mark evens as false
    {
        switch(digitPlace)
        {
            case Digit.First:
                foreach(int i in numbers.Keys)
                {
                    if(((i / 10) % 10) % 2 == 0)
                    {
                        numbers[i] = false;
                        Console.WriteLine(i + " is " + numbers[i]);
                    }
                }
                break;
            case Digit.Second:
                foreach(int i in numbers.Keys)
                {
                    if((i % 10) % 2 == 0)
                    {
                        numbers[i] = false;
                        Console.WriteLine(i + " is " + numbers[i]);
                    }
                }
                break;
        }
    }


    static void Even(Digit digitPlace) // Odd digits are good, so mark evens as false
    {
        switch(digitPlace)
        {
            case Digit.First:
                foreach(int i in numbers.Keys)
                {
                    if(((i / 10) % 10) % 2 == 1)
                    {
                        numbers[i] = false;
                        Console.WriteLine(i + " is " + numbers[i]);
                    }
                }
                break;
            case Digit.Second:
                foreach(int i in numbers.Keys)
                {
                    if((i % 10) % 2 == 1)
                    {
                        numbers[i] = false;
                        Console.WriteLine(i + " is " + numbers[i]);
                    }
                }
                break;
        }
    }
    static void ResetArray()
    {
        for(int i = 10; i < 100; i++)
        {
            numbers[i] = true;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}