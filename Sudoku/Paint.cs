using SkiaSharp;

namespace Sudoku
{
    public static class Paint
    {
        public static void Painter(List<object>[,] array,string imagePath)
        {
            SKBitmap bitmap = new SKBitmap(900, 900);

            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);
                var paint = new SKPaint
                {
                    Color = SKColors.Black,
                    StrokeWidth = 4,
                    IsAntialias = true,
                    Style = SKPaintStyle.Stroke
                };
                
                var labelPaint = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 50,
                    TextAlign = SKTextAlign.Center,
                    IsAntialias = true
                };
                
                for (int y = 0; y < 9; y++)
                {
                    if (y % 3 == 0) paint.StrokeWidth = 8;
                    else paint.StrokeWidth = 4;
                    canvas.DrawLine(y*100,0, y*100, 900, paint);
                    canvas.DrawLine(0,y*100, 900, y*100, paint);
                    for (int x = 0; x < 9; x++)
                    {
                        canvas.DrawText(array[y,x][1].ToString(),x*100 + 50,y * 100 + 65, labelPaint);
                    }
                }
            }

            using (var stream = new SKFileWStream(imagePath))
            {
                bitmap.Encode(stream, SKEncodedImageFormat.Png, 10000);
            }
        }
    }
}