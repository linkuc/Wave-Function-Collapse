using SkiaSharp;

namespace WFC_Tiles;

public class Tile
{
    public List<int> Points;
    public SKBitmap Bitmap;

    public Tile(List<int> points, SKBitmap bitmap)
    {
        Points = points;
        Bitmap = bitmap;
    }
}