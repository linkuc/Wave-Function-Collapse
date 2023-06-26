using SkiaSharp;

namespace WFC_first
{
    public static class Paint
    {
        public static void Painter(char[,] array,string imagePath)
        {
            SKBitmap bitmap = new SKBitmap(array.GetLength(0) * 10, array.GetLength(1) * 10);

            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);
                using var paint = new SKPaint
                {
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill
                };

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        switch (array[j, i])
                        {
                            case 'A':
                                paint.Color = SKColors.Aqua;
                                break;
                            case 'a':
                                paint.Color = SKColors.LightSkyBlue;
                                break;
                            case 'B':
                                paint.Color = SKColors.Blue;
                                break;
                            case 'b':
                                paint.Color = SKColors.LightBlue;
                                break;
                            case 'C':
                                paint.Color = SKColors.Black;
                                break;
                            case 'c':
                                paint.Color = SKColors.LightCyan;
                                break;
                            case 'D':
                                paint.Color = SKColors.DeepPink;
                                break;
                            case 'd':
                                paint.Color = SKColors.Pink;
                                break;
                            case 'E':
                                paint.Color = SKColors.SaddleBrown;
                                break;
                            case 'e':
                                paint.Color = SKColors.Brown;
                                break;
                            case 'F':
                                paint.Color = SKColors.DarkGray;
                                break;
                            case 'f':
                                paint.Color = SKColors.Gray;
                                break;
                            case 'G':
                                paint.Color = SKColors.Green;
                                break;
                            case 'g':
                                paint.Color = SKColors.LimeGreen;
                                break;
                            case 'H':
                                paint.Color = SKColors.HotPink;
                                break;
                            case 'h':
                                paint.Color = SKColors.LightPink;
                                break;
                            case 'I':
                                paint.Color = SKColors.IndianRed;
                                break;
                            case 'i':
                                paint.Color = SKColors.LightSalmon;
                                break;
                            case 'J':
                                paint.Color = SKColors.NavajoWhite;
                                break;
                            case 'j':
                                paint.Color = SKColors.MediumAquamarine;
                                break;
                            case 'K':
                                paint.Color = SKColors.Khaki;
                                break;
                            case 'k':
                                paint.Color = SKColors.Gold;
                                break;
                            case 'L':
                                paint.Color = SKColors.Lavender;
                                break;
                            case 'l':
                                paint.Color = SKColors.Plum;
                                break;
                            case 'M':
                                paint.Color = SKColors.Magenta;
                                break;
                            case 'm':
                                paint.Color = SKColors.MediumOrchid;
                                break;
                            case 'N':
                                paint.Color = SKColors.NavajoWhite;
                                break;
                            case 'n':
                                paint.Color = SKColors.SandyBrown;
                                break;
                            case 'O':
                                paint.Color = SKColors.Orange;
                                break;
                            case 'o':
                                paint.Color = SKColors.DarkOrange;
                                break;
                            case 'P':
                                paint.Color = SKColors.Purple;
                                break;
                            case 'p':
                                paint.Color = SKColors.MediumPurple;
                                break;
                            case 'Q':
                                paint.Color = SKColors.DarkOrange;
                                break;
                            case 'q':
                                paint.Color = SKColors.PeachPuff;
                                break;
                            case 'R':
                                paint.Color = SKColors.Red;
                                break;
                            case 'r':
                                paint.Color = SKColors.LightCoral;
                                break;
                            case 'S':
                                paint.Color = SKColors.Silver;
                                break;
                            case 's':
                                paint.Color = SKColors.LightGray;
                                break;
                            case 'T':
                                paint.Color = SKColors.Teal;
                                break;
                            case 't':
                                paint.Color = SKColors.DarkSlateGray;
                                break;
                            case 'U':
                                paint.Color = SKColors.OrangeRed;
                                break;
                            case 'u':
                                paint.Color = SKColors.Tomato;
                                break;
                            case 'V':
                                paint.Color = SKColors.Violet;
                                break;
                            case 'v':
                                paint.Color = SKColors.BlueViolet;
                                break;
                            case 'W':
                                paint.Color = SKColors.White;
                                break;
                            case 'w':
                                paint.Color = SKColors.WhiteSmoke;
                                break;
                            case 'X':
                                paint.Color = SKColors.Yellow;
                                break;
                            case 'x':
                                paint.Color = SKColors.LightYellow;
                                break;
                            case 'Y':
                                paint.Color = SKColors.YellowGreen;
                                break;
                            case 'y':
                                paint.Color = SKColors.PaleGreen;
                                break;
                            case 'Z':
                                paint.Color = SKColors.DarkMagenta;
                                break;
                            case 'z':
                                paint.Color = SKColors.MediumVioletRed;
                                break;
                            default:
                                paint.Color = SKColors.Black;
                                break;
                        }

                        canvas.DrawRect(i * 10, j * 10, i * 10 + 10, j * 10 + 10, paint);
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