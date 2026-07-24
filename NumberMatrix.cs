namespace TreasureCatte;

class NumberMatrix
{
    private Dictionary<int, PossibleNumber> matrix;
    private const int startingLeft = 4;
    private const int startingTop = 13;
    private int left;
    private int top;
    private int currentNumber;

    public NumberMatrix()
    {
        matrix = new Dictionary<int, PossibleNumber>();
        top = startingTop;

        for(int firstDigit = 1; firstDigit <= 9; firstDigit++)
        {
            left = startingLeft;
            for(int secondDigit = 0; secondDigit <= 9; secondDigit++)
            {
                currentNumber = (firstDigit * 10) + secondDigit;
                matrix[currentNumber] = new PossibleNumber(left, top);
                left += 3;
            }
            top++;
        }
    }

    public int GetLeft(int key)
    {
        return matrix[key].Left;
    }
    public int GetTop(int key)
    {
        return matrix[key].Top;
    }
    public bool GetPossible(int key)
    {
        return matrix[key].Possible;
    }
    public void SetLeft(int key, int newLeft)
    {
        matrix[key].Left = newLeft;
    }
    public void SetTop(int key, int newTop)
    {
        matrix[key].Top = newTop;
    }
    public void SetPossible(int key, bool isValid)
    {
        matrix[key].Possible = isValid;
    }
}