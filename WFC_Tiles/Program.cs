using System.Net.Mime;
using WFC_Tiles;
using SkiaSharp;

const int n = 32;
const int m = 32;
//const string directoryPath = "TilesSimple";
const string directoryPath = "Tiles";
//const string directoryPath = "Tiles2";
//const string directoryPath = "Road";

string[] imagePaths = Directory.GetFiles(directoryPath);
List<Tile> tiles = new List<Tile>();
foreach(string imagePath in imagePaths)
{
    SKBitmap bitmap = SKBitmap.Decode(imagePath);
    List<string> tilePoints = new List<string>
    {
        bitmap.GetPixel((int)Math.Ceiling(bitmap.Width*0.25)-1,0).ToString(),bitmap.GetPixel((int)Math.Ceiling(bitmap.Width*0.5)-1,0).ToString(),
        bitmap.GetPixel((int)Math.Ceiling(bitmap.Width*0.75)-1,0).ToString(),bitmap.GetPixel(bitmap.Width-1,(int)Math.Ceiling(bitmap.Height*0.25)-1).ToString(),
        bitmap.GetPixel(bitmap.Width-1,(int)Math.Ceiling(bitmap.Height*0.5)-1).ToString(),bitmap.GetPixel(bitmap.Width-1,(int)Math.Ceiling(bitmap.Height*0.75)-1).ToString(),
        bitmap.GetPixel((int)Math.Ceiling(bitmap.Width*0.75)-1,bitmap.Height-1).ToString(),bitmap.GetPixel((int)Math.Ceiling(bitmap.Width*0.5)-1,bitmap.Height-1).ToString(),
        bitmap.GetPixel((int)Math.Ceiling(bitmap.Width*0.25)-1,bitmap.Height-1).ToString(),bitmap.GetPixel(0,(int)Math.Ceiling(bitmap.Height*0.75)-1).ToString(),
        bitmap.GetPixel(0,(int)Math.Ceiling(bitmap.Height*0.5)-1).ToString(),bitmap.GetPixel(0,(int)Math.Ceiling(bitmap.Height*0.25)-1).ToString()
    };
    Tile tile = new Tile(imagePath, tilePoints, bitmap);
    tiles.Add(tile);
}


List<Point> points = new List<Point>();
int k = 0;
points = Start();
List<Point> Start()
{
    List<Point> points = new List<Point>();
    for (int y = 0; y < m; y++)
    {
        for (int x = 0; x < n; x++)
        {
            points.Add(new Point(false,new List<Tile>(tiles),x,y));
        }
    }
    k = 0;
    return points;
}
while (k < n * m)
{
    (points, int id) = Utils.LowestEntropy(points);
    if (points[id].Possible.Count > 1)
    {
        points = Utils.Randomise(points, id);
    }
    if(points[id].Possible.Count == 0){
    {
        Console.WriteLine("unlucky");
        points = Start();
    }}
    points = Utils.UpdateNeighbours(points, id);
    if(points[id].Possible.Count == 0){
    {
        Console.WriteLine("unlucky");
        points = Start();
    }}
    k++;
}

Paint.Painter(points, "image.png",n,m);