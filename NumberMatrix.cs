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
                // TODO: Calculate X and Y coordinates, then add to dictionary
            }
        }
    }
}