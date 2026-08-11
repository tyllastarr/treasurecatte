namespace TreasureCatte;

class Program
{
    static NumberMatrix matrix = new NumberMatrix();
    static UiElement currentClues = new UiElement(6, 59, "CURRENT CLUES");
    static UiElement possibleNumbers = new UiElement(9, 31, "POSSIBLE NUMBERS");
    static UiElement controls = new UiElement(8, 40, "CONTROLS");
    static bool exit = false;
    static char inputChar;


    static void Odd(int digitPlace) // Odd digits are good, so mark evens as false
    {
        try
        {
            switch (digitPlace)
            {
                case 1:
                    for (int i = 10; i <= 99; i++)
                    {
                        if (((i / 10) % 10) % 2 == 0)
                        {
                            matrix.SetPossible(i, false);
                        }
                    }
                    break;
                case 2:
                    for (int i = 10; i <= 99; i++)
                    {
                        if ((i % 10) % 2 == 0)
                        {
                            matrix.SetPossible(i, false);
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
                    for (int i = 10; i <= 99; i++)
                    {
                        if (((i / 10) % 10) % 2 == 1)
                        {
                            matrix.SetPossible(i, false);
                        }
                    }
                    break;
                case 2:
                    for (int i = 10; i <= 99; i++)
                    {
                        if ((i % 10) % 2 == 1)
                        {
                            matrix.SetPossible(i, false);
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

            for (int i = 10; i <= 99; i++)
            {
                if (i < lowerBound)
                {
                    matrix.SetPossible(i, false);
                }
                if (i > upperBound)
                {
                    matrix.SetPossible(i, false);
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

            for (int i = 10; i <= 99; i++)
            {
                if (((i / 10) % 10) != target && (i % 10) != target)
                {
                    matrix.SetPossible(i, false);
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
                    for (int i = 10; i <= 99; i++)
                    {
                        if (((i / 10) % 10) != target && ((i / 10) % 10) != target + 1 && ((i / 10) % 10) != target + 2)
                        {
                            matrix.SetPossible(i, false);
                        }
                    }
                    break;
                case 2:
                    for (int i = 10; i <= 99; i++)
                    {
                        if ((i % 10) != target && (i % 10) != target + 1 && (i % 10) != target + 2)
                        {
                            matrix.SetPossible(i, false);
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

        for (int i = 10; i <= 99; i++)
        {
            if (matrix.GetPossible(i) == true)
            {
                numTrue++;
            }
        }

        int[] trueItems = new int[numTrue];
        int index = 0;

        for (int i = 10; i <= 99; i++)
        {
            if (matrix.GetPossible(i) == true)
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

    static void ResetMatrix()
    {
        for (int i = 10; i < 100; i++)
        {
            matrix.SetPossible(i, true);
        }
    }

    static void DrawUiElement(UiElement element, int left, int top)
    {
        int currentTop;
        int index;

        Console.SetCursorPosition(left, top);
        Console.Write(element.FullElement[0]);

        currentTop = top + 1;

        for(index = 1; index < element.FullElement.Length; index++)
        {
            Console.SetCursorPosition(left, currentTop);
            Console.Write(element.FullElement[index]);
            currentTop++;
        }
    }

    static void DrawNumbers()
    {
        int median = FindMedian();

        for(int i = 10; i <= 99; i++)
        {
            if(i == median)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } else if(matrix.GetPossible(i) == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            } else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.SetCursorPosition(matrix.GetLeft(i), matrix.GetTop(i));

            Console.Write(i);
        }
    }

    static void DrawUi()
    {
        DrawUiElement(currentClues, 1, 1);
        DrawUiElement(possibleNumbers, 1, 10);
        DrawUiElement(controls, 37, 11);
        DrawNumbers();
        Console.SetCursorPosition(1, 22);
    }

    static void ProgramLoop()
    {
        DrawUi();
        
        inputChar = Char.ToUpper(Console.ReadKey().KeyChar);

        switch(inputChar)
        {
            // TODO: This is where logic for which key is pressed will go
        }

        ProgramLoop();
    }

    static void Main(string[] args)
    {
        ProgramLoop();
    }
}