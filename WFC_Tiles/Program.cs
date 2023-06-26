using System.Net.Mime;
using WFC_Tiles;
using SkiaSharp;

const int n = 64;
const int m = 64;

List<Tile> tiles = new List<Tile>();
List<List<int>> tilePoints = new List<List<int>>
{
    new List<int>{0, 0, 0, 0},
    new List<int>{1, 1, 0, 1},
    new List<int>{1, 1, 1, 0},
    new List<int>{0, 1, 1, 1},
    new List<int>{1, 0, 1, 1}
};
for (int i = 0; i < 5; i++)
{
    string imagePath = "C:/Users/linas/Desktop/Programming/WFC/WFC_Tiles/"+i+".png";
    SKBitmap bitmap = SKBitmap.Decode(imagePath);
    Tile tile = new Tile(tilePoints[i], bitmap);
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
    points = Utils.UpdateNeighbours(points, id);
    if(points[id].Possible.Count == 0)points = Start();
    k++;
}

Paint.Painter(points, "image.png",n,m);