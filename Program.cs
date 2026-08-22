namespace TreasureCatte;

using System.Collections.ObjectModel;

class Program
{
    static NumberMatrix matrix = new NumberMatrix();
    static int numClues = 0;
    static int maxClues = 6;
    static string[] clueList = new string[6];
    static readonly ReadOnlyCollection<int> numFor100 = new ReadOnlyCollection<int>(new[] { 1, 3, 7, 15, 31, 63 });
    static UiElement currentClues = new UiElement(6, 59, "CURRENT CLUES");
    static UiElement possibleNumbers = new UiElement(9, 31, "POSSIBLE NUMBERS");
    static UiElement controls = new UiElement(8, 40, "CONTROLS");
    static UiElement percentDone = new UiElement(1, 13, "% TO OPEN");
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
                    AddClue("The first digit is odd.");
                    break;
                case 2:
                    for (int i = 10; i <= 99; i++)
                    {
                        if ((i % 10) % 2 == 0)
                        {
                            matrix.SetPossible(i, false);
                        }
                    }
                    AddClue("The second digit is odd.");
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
                    AddClue("The first digit is even.");
                    break;
                case 2:
                    for (int i = 10; i <= 99; i++)
                    {
                        if ((i % 10) % 2 == 1)
                        {
                            matrix.SetPossible(i, false);
                        }
                    }
                    AddClue("The second digit is even.");
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

            AddClue("The combination is between " + lowerBound + " and " + upperBound + ".");
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

            AddClue("One of the two digits is " + target + ".");
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
                    AddClue("The first digit is " + target + ", " + (target + 1) + ", or " + (target + 2) + ".");
                    break;
                case 2:
                    for (int i = 10; i <= 99; i++)
                    {
                        if ((i % 10) != target && (i % 10) != target + 1 && (i % 10) != target + 2)
                        {
                            matrix.SetPossible(i, false);
                        }
                    }
                    AddClue("The second digit is " + target + ", " + (target + 1) + ", or " + (target + 2) + ".");
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
            ResetPromptArea();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(38, 19);
            Console.Write("First or second digit?");

            switch (Console.ReadKey(true).KeyChar)
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
            ResetPromptArea();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(38, 19);
            Console.Write(prompt);

            switch (Console.ReadKey(true).KeyChar)
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
                    break;
            }

            if(inputInt <= maxTarget)
            {
                validInput = true;
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
            ResetPromptArea();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(38, 19);
            Console.Write(prompt);
            inputStr = Console.ReadLine();

            if(int.TryParse(inputStr, out inputInt))
            {
                if(inputInt >= 10 && inputInt <= 99)
                {
                    validInput = true;
                } 
            }

        } while (validInput == false);

        return inputInt;
    }

    static int FindPercentDone()
    {
        int count = 0;

        for(int i = 10; i <= 99; i++)
        {
            if(matrix.GetPossible(i) == true)
            {
                count++;
            }
        }

        double percent = (double)numFor100[maxClues - 1 - numClues] / count;

        if (percent < 1)
        {
            return (int)(percent * 100);
        } else
        {
            return 100;
        }
    }

    static void AddClue(string newClue)
    {
        if (numClues >= 0 && numClues < maxClues)
        {
            clueList[numClues] = newClue;
            if (numClues < maxClues - 1)
            {
                numClues++;
            }
        }
    }

    static void ResetMatrix()
    {
        for (int i = 10; i < 100; i++)
        {
            matrix.SetPossible(i, true);
        }

        for(int i = 0; i < 6; i++)
        {
            clueList[i] = "";
        }

        numClues = 0;
        maxClues = FindTargetDigit(6, "How many attempts allowed? ");
    }

    static void ResetPromptArea()
    {
        Console.SetCursorPosition(38, 19);
        Console.Write("                                         ");
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

    static void DrawClues()
    {
        if (clueList[0] == "") // No clues
        {
            return;
        }

        int position = 1;

        do
        {
            Console.SetCursorPosition(2, position + 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(position + ": " + clueList[position - 1]);
            position++;
        } while (position <= 6 && clueList[position - 1] != "");
    }

    static void DrawControls()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(38, 12);
        Console.Write("O: Odd Number");
        Console.SetCursorPosition(38, 13);
        Console.Write("E: Even Number");
        Console.SetCursorPosition(38, 14);
        Console.Write("B: Between Two Numbers");
        Console.SetCursorPosition(38, 15);
        Console.Write("D: One Digit is a Number");
        Console.SetCursorPosition(38, 16);
        Console.Write("T: Three Number Sequence");
        Console.SetCursorPosition(38, 17);
        Console.Write("R: Reset");
        Console.SetCursorPosition(38, 18);
        Console.Write("X: Exit");



    }

    static void DrawPercentDone()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(69, 7);
        Console.Write(FindPercentDone() + "%");
    }

    static void DrawUi()
    {
        Console.ForegroundColor = ConsoleColor.White;
        DrawUiElement(currentClues, 1, 1);
        DrawUiElement(possibleNumbers, 1, 10);
        DrawUiElement(controls, 37, 11);
        DrawUiElement(percentDone, 63, 6);
        DrawNumbers();
        DrawClues();
        DrawControls();
        DrawPercentDone();
        Console.SetCursorPosition(66, 2);
        Console.Write("Treasure");
        Console.SetCursorPosition(70, 3);
        Console.Write("Catte");
        Console.SetCursorPosition(3, 22);
        Console.Write("Created by Tyll'a");
    }

    static void Main(string[] args)
    {
        DrawUi();
        ResetMatrix();
        do
        {
            DrawUi();

            inputChar = Char.ToUpper(Console.ReadKey(true).KeyChar);

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
                    break;

            }

        } while (exit == false);
    }
}