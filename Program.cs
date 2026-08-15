namespace TreasureCatte;

class Program
{
    static NumberMatrix matrix = new NumberMatrix();
    static UiElement currentClues = new UiElement(6, 59, "CURRENT CLUES");
    static UiElement possibleNumbers = new UiElement(9, 31, "POSSIBLE NUMBERS");
    static UiElement controls = new UiElement(8, 40, "CONTROLS");
    static bool exit = false;
    static char inputChar;
    static bool validInput;
    static int inputInt;


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

    static int FindDigitPlace()
    {
        do
        {
            Console.SetCursorPosition(1, 22);
            Console.Write("First or second digit?");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    validInput = true;
                    inputInt = 1;
                    break;
                case '2':
                    validInput = true;
                    inputInt = 2;
                    break;
                default:
                    Console.WriteLine("Invalid entry.");
                    validInput = false;
                    break;
            }
        } while (validInput == false);

        return inputInt;
    }
    static int FindTargetDigit(int maxTarget = 9, string prompt = "Which digit?")
    {
        validInput = false;

        do
        {
            Console.SetCursorPosition(1, 22);
            Console.Write(prompt);

            switch (Console.ReadKey().KeyChar)
            {
                case '0':
                    inputInt = 0;
                    break;
                case '1':
                    inputInt = 1;
                    break;
                case '2':
                    inputInt = 2;
                    break;
                case '3':
                    inputInt = 3;
                    break;
                case '4':
                    inputInt = 4;
                    break;
                case '5':
                    inputInt = 5;
                    break;
                case '6':
                    inputInt = 6;
                    break;
                case '7':
                    inputInt = 7;
                    break;
                case '8':
                    inputInt = 8;
                    break;
                case '9':
                    inputInt = 9;
                    break;
                default:
                    Console.WriteLine("Invalid entry.");
                    break;
            }

            if(inputInt <= maxTarget)
            {
                validInput = true;
            } else
            {
                Console.WriteLine("Invalid entry.");
            }

        } while (validInput == false);

        return inputInt;
    }

    static int InputNumber(string prompt = "Please enter the number:")
    {
        string inputStr;
        int inputInt;

        validInput = false;

        do
        {
            Console.SetCursorPosition(1, 22);
            Console.Write(prompt);
            inputStr = Console.ReadLine();

            if(int.TryParse(inputStr, out inputInt))
            {
                if(inputInt >= 10 && inputInt <= 99)
                {
                    validInput = true;
                } else
                {
                    Console.WriteLine("Invalid entry.");
                }
            } else
            {
                Console.WriteLine("Invalid entry.");
            }

        } while (validInput == false);

        return inputInt;
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
                Console.ForegroundColor = ConsoleColor.Black;
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
        Console.ForegroundColor = ConsoleColor.White;
        DrawUiElement(currentClues, 1, 1);
        DrawUiElement(possibleNumbers, 1, 10);
        DrawUiElement(controls, 37, 11);
        DrawNumbers();
        Console.SetCursorPosition(1, 22);
    }

    static void Main(string[] args)
    {
        do
        {
            DrawUi();

            inputChar = Char.ToUpper(Console.ReadKey().KeyChar);

            switch (inputChar)
            {
                case 'X': // Exit
                    exit = true;
                    break;

                case 'R': // Reset
                    ResetMatrix();
                    break;

                case 'O': // Odd number
                    Odd(FindDigitPlace());
                    break;

                case 'E': // Even number
                    Even(FindDigitPlace());
                    break;

                case 'B': // Between two numbers
                    BetweenNumbers(InputNumber("Please enter lower bound:"), InputNumber("Please enter upper bound:"));
                    break;

                case 'D': // One digit is a number
                    OneDigitIsNumber(FindTargetDigit(9));
                    break;

                case 'T': // Three number sequence
                    ThreeNumberSequence(FindDigitPlace(), FindTargetDigit(7));
                    break;

                default:
                    Console.WriteLine("Invalid entry.");
                    break;

            }

        } while (exit == false);
    }
}