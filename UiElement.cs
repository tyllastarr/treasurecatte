namespace TreasureCatte;

class UiElement
{
    private int height;
    private int width;
    private string title;
    public int Height
    {
        get { return height; }
        set { height = value; }
    }
    public int Width
    {
        get { return width; }
        set { width = value; }
    }
    public string Title
    {
        get { return title; }
        set { title = value.ToUpper(); } // Title must be in all uppercase
    }

    public UiElement(int newHeight, int newWidth, string newTitle)
    {
        height = newHeight;
        width = newWidth;
        title = newTitle.ToUpper();
    }
    public UiElement() : this(1, 1, "")
    {

    }
    public UiElement(int newHeight) : this(newHeight, 1, "")
    {

    }
    public UiElement(string newTitle) : this(1, 1, newTitle)
    {

    }

    public string[] CreateElement()
    {
        int fullHeight = height + 2;
        string[] output = new string[fullHeight];

        // Title line
        if (title == "") // Title is empty
        {
            output[0] = "┌";
            for (int i = 1; i <= width; i++)
            {
                output[0] += "─";
            }
            output[0] += "┐";
        }
        else
        {
            output[0] = "┌──"; // Two line elements before title starts
            output[0] += title;
            for (int i = title.Length + 2; i <= width; i++)
            {
                output[0] += "─";
            }
            output[0] += "┐";
        }

        // Content lines
        for (int i = 1; i < output.Length; i++)
        {
            output[i] = "│";

            for (int j = 1; j <= width; j++)
            {
                output[i] += " ";
            }

            output[i] += "│";
        }

        // Bottom border
        output[output.Length - 1] = "└";

        for (int i = 1; i <= width; i++)
        {
            output[output.Length - 1] += "─";
        }

        output[output.Length - 1] += "┘";

        return output;
    }
}