using System.Runtime.InteropServices.ComTypes;

namespace Sudoku;

public class Utils
{
    public static (int,int) findLowestEntropy(List<object>[,] array)
    {
        int x1 = 0;
        int y1 = 0;
        int minEnt = Int32.MaxValue;
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (array[y, x][0] is bool objBool && !objBool && array[y, x].Count < minEnt)
                {
                    x1 = x;
                    y1 = y;
                    minEnt = array[y, x].Count;
                }
            }
        }
        return (x1, y1);
    }

    public static void getRandom(List<object>[,] array, int x, int y)
    {
        Random rand = new Random();
        object temp = array[y,x][rand.Next(1, array[y, x].Count)];
        array[y,x].Clear();
        array[y,x].Add(false);
        array[y,x].Add(temp);
    }

    public static void clearNeighbours(List<object>[,] array, int x, int y)
    {
        var clear = array[y, x][1];
        for (int i = 0; i < 9; i++)
        {
            if (i != x)
            {
                array[y, i].Remove(clear);
            }
            if (i != y)
            {
                array[i, x].Remove(clear);
            }
        }
        
        int xstart = x - x % 3;
        int ystart = y - y % 3;

        for (int y1 = 0; y1 < 3; y1++)
        {
            for (int x1 = 0; x1 < 3; x1++)
            {
                if (!(y1 + ystart == y && x1 + xstart == x))
                {
                    array[y1 + ystart, x1 + xstart].Remove(clear);
                }
            }
        }
        array[y, x][0] = true;
    }

    public static void addInputArray(int[,] inputArray, List<object>[,] outputArray)
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (inputArray[y, x] != 0)
                {
                    outputArray[y,x].Clear();
                    outputArray[y,x].Add(false);
                    outputArray[y,x].Add(inputArray[y, x]);
                }
            }
        }
    }
}