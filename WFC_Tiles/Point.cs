namespace WFC_Tiles;

public class Point
{
    public bool Finished;
    public List<Tile> Possible;
    public int X;
    public int Y;

    public Point(bool finished, List<Tile> possible, int x, int y)
    {
        Finished = finished;
        Possible = possible;
        X = x;
        Y = y;
    }
}