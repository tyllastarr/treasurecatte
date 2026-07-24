namespace TreasureCatte;

class PossibleNumber
{
    private bool possible;
    private int left;
    private int top;

    public bool Possible
    {
        get { return possible; }
        set { possible = value; }
    }
    public int Left
    {
        get { return left; }
        set { left = value; }
    }
    public int Top
    {
        get { return top; }
        set { top = value; }
    }

    public PossibleNumber(int newLeft, int newTop, bool isPossible)
    {
        left = newLeft;
        top = newTop;
        possible = isPossible;
    }
    public PossibleNumber(int newLeft, int newTop) : this(newLeft, newTop, true)
    {
        
    }
}