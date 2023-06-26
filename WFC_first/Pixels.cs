namespace WFC_first;

public class Pixels
{
    public bool Finished;
    public int X;
    public int Y;
    public Dictionary<char, int> Possible;
    
    public Pixels(bool finished, int x,int y,Dictionary<char, int> possible)
    {
        Finished = finished;
        X = x;
        Y = y;
        Possible = possible;
    }
}