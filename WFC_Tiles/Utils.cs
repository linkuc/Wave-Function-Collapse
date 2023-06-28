namespace WFC_Tiles;

public class Utils
{
    public static (List<Point>, int) LowestEntropy(List<Point> points)
    {
        int id = 0;
        int minEnt = Int32.MaxValue;

        for (int i = 0; i < points.Count; i++)
        {
            if (!points[i].Finished && points[i].Possible.Count < minEnt)
            {
                id = i;
                minEnt = points[i].Possible.Count;
            }
        }
        return (points, id);
    }

    public static List<Point> Randomise(List<Point> points, int id)
    {
        Random rand = new Random();
        Tile temp = points[id].Possible[rand.Next(0, points[id].Possible.Count)];
        points[id].Possible.Clear();
        points[id].Possible.Add(temp);
        return points;
    }

    public static List<Point> UpdateNeighbours(List<Point> points, int id)
    {
        int x = points[id].X;
        int y = points[id].Y;
        List<string> current = points[id].Possible[0].Points;
        for (int i = 0; i < points.Count; i++)
        {
            if (points[i].X == x - 1 && points[i].Y == y)
            {
                for (int j = 0; j < points[i].Possible.Count; j++)
                {
                    if (current[11] != points[i].Possible[j].Points[3] || current[10] != points[i].Possible[j].Points[4] || current[9] != points[i].Possible[j].Points[5])
                    {
                        points[i].Possible.Remove(points[i].Possible[j]);
                        j--;
                    }
                }
            }
            if (points[i].X == x + 1 && points[i].Y == y)
            {
                for (int j = 0; j < points[i].Possible.Count; j++)
                {
                    if (current[3] != points[i].Possible[j].Points[11] || current[4] != points[i].Possible[j].Points[10] || current[5] != points[i].Possible[j].Points[9])
                    {
                        points[i].Possible.Remove(points[i].Possible[j]);
                        j--;
                    }
                }
            }
            if (points[i].X == x && points[i].Y == y - 1)
            {
                for (int j = 0; j < points[i].Possible.Count; j++)
                {
                    if (current[0] != points[i].Possible[j].Points[8] || current[1] != points[i].Possible[j].Points[7] || current[2] != points[i].Possible[j].Points[6])
                    {
                        points[i].Possible.Remove(points[i].Possible[j]);
                        j--;
                    }
                }
            }
            if (points[i].X == x && points[i].Y == y + 1)
            {
                for (int j = 0; j < points[i].Possible.Count; j++)
                {
                    if (current[8] != points[i].Possible[j].Points[0] || current[7] != points[i].Possible[j].Points[1] || current[6] != points[i].Possible[j].Points[2])
                    {
                        points[i].Possible.Remove(points[i].Possible[j]);
                        j--;
                    }
                }
            }
        }
        points[id].Finished = true;
        return points;
    }
}