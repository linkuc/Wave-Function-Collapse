using Sudoku;

/*int[,] InputArray =
{
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};*/

int[,] InputArray =
{
    { 0, 5, 0, 0, 6, 0, 1, 0, 4 },
    { 0, 0, 0, 7, 0, 0, 0, 0, 2 },
    { 0, 0, 0, 0, 0, 9, 3, 0, 0 },
    { 2, 0, 9, 6, 0, 0, 0, 5, 0 },
    { 0, 1, 0, 0, 0, 0, 0, 4, 0 },
    { 0, 4, 0, 0, 0, 2, 9, 0, 3 },
    { 0, 0, 6, 8, 0, 0, 0, 0, 0 },
    { 7, 0, 0, 0, 0, 5, 0, 0, 0 },
    { 1, 0, 4, 0, 2, 0, 0, 8, 0 }
};

List<object>[,] OutputArray = new List<object>[9,9];

int i;
start();
void start()
{
    for (int y = 0; y < 9; y++)
    {
        for (int x = 0; x < 9; x++)
        {
            List<object> temp = new List<object>{false, 1,2,3,4,5,6,7,8,9};
            OutputArray[y, x] = temp;
        }
    }
    Utils.addInputArray(InputArray,OutputArray);
    i = 0;
}
while (true)
{
    (int x1, int y1) = Utils.findLowestEntropy(OutputArray);

    if (OutputArray[y1, x1].Count > 2)
    {
        Utils.getRandom(OutputArray,x1,y1);
    }
    
    if (OutputArray[y1, x1].Count == 1)
    {
        start();
    }

    Utils.clearNeighbours(OutputArray,x1,y1);
    i++;
    if (i == 81) break;
}

for (int y = 0; y < 9; y++)
{
    for (int x = 0; x < 9; x++)
    {
        Console.Write(InputArray[y,x] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine();

for (int y = 0; y < 9; y++)
{
    for (int x = 0; x < 9; x++)
    {
        Console.Write(OutputArray[y,x][1] + " ");
    }
    Console.WriteLine();
}

Paint.Painter(OutputArray, "Image.png");


