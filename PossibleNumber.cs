namespace TreasureCatte;

class PossibleNumber
{
    private bool possible;
    private int x;
    private int y;

    public bool Possible
    {
        get { return possible; }
        set { possible = value; }
    }
    public int X
    {
        get { return x; }
        set { x = value; }
    }
    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public PossibleNumber(int xCoord, int yCoord)
    {
        x = xCoord;
        y = yCoord;
        possible = true;
    }
    public PossibleNumber(int xCoord, int yCoord, bool isPossible)
    {
        x = xCoord;
        y = yCoord;
        possible = isPossible;
    }
}