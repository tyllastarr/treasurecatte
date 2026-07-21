using System;
using System.Collections.Generic;

namespace TreasureCatte;

class Program
{
    static Dictionary<int,bool> numbers = new Dictionary<int, bool>();

    static void ResetArray()
    {
        for(int i = 10; i < 100; i++)
        {
            numbers[i] = false;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}