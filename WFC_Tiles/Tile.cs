using SkiaSharp;

namespace WFC_Tiles;

public class Tile
{
    public string Name;
    public List<string> Points;
    public SKBitmap Bitmap;

    public Tile(string name, List<string> points, SKBitmap bitmap)
    {
        Name = name;
        Points = points;
        Bitmap = bitmap;
    }
}