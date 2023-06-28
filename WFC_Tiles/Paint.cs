using SkiaSharp;

namespace WFC_Tiles
{
    public static class Paint
    {
        public static void Painter(List<Point> points, string imagePath, int n, int m)
        {
            SKBitmap bitmap = new SKBitmap(n*100, m*100);

            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);
                using var paint = new SKPaint
                {
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill
                };
                for (int i = 0; i < points.Count; i++)
                {
                    canvas.DrawBitmap(points[i].Possible[0].Bitmap, SKRect.Create(points[i].X*100, points[i].Y*100,100, 100));
                }
            }

            using (var stream = new SKFileWStream(imagePath))
            {
                bitmap.Encode(stream, SKEncodedImageFormat.Png, 10000);
            }
        }
    }
}