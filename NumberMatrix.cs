namespace TreasureCatte;

class NumberMatrix
{
    private Dictionary<int, PossibleNumber> matrix;
    private const int startingX = 4;
    private const int startingY = 13;
    private int currentX;
    private int currentY;
    private int currentNumber;

    public NumberMatrix()
    {
        matrix = new Dictionary<int, PossibleNumber>();
        currentY = startingY;

        for(int firstDigit = 1; firstDigit <= 9; firstDigit++)
        {
            currentX = startingX;
            for(int secondDigit = 0; secondDigit <= 9; secondDigit++)
            {
                currentNumber = (firstDigit * 10) + secondDigit;
                matrix[currentNumber] = new PossibleNumber(currentX, currentY);
                currentX += 3;
            }
            currentY++;
        }
    }

    public int getXCoord(int key)
    {
        return matrix[key].X;
    }
    public int getYCoord(int key)
    {
        return matrix[key].Y;
    }
    public bool getPossible(int key)
    {
        return matrix[key].Possible;
    }
    public void setXCoord(int key, int coord)
    {
        matrix[key].X = coord;
    }
    public void setYCoord(int key, int coord)
    {
        matrix[key].Y = coord;
    }
    public void setPossible(int key, bool isValid)
    {
        matrix[key].Possible = isValid;
    }
}