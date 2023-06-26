using WFC_first;

char[,] inputArray =
{
    { 'B', 'B', 'B', 'b', 'K', 'g', 'g', 'g' },
    { 'B', 'b', 'b', 'K', 'g', 'g', 'g', 'g' },
    { 'b', 'b', 'K', 'g', 'g', 'G', 'G', 'g' },
    { 'b', 'K', 'g', 'G', 'G', 'G', 'G', 'g' },
    { 'K', 'g', 'G', 'G', 'F', 'F', 'G', 'g' },
    { 'g', 'g', 'G', 'G', 'F', 'G', 'G', 'g' },
    { 'g', 'g', 'g', 'G', 'G', 'G', 'g', 'g' },
    { 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g' }
    /*{'B', 'B', 'b'},
    {'B', 'b', 'K'},
    {'b', 'K', 'K'}*/
};

const int n = 128;
const int m = 128;

Dictionary<char, int> possibilities = new Dictionary<char, int>();
List<string> rules = new List<string>();
for (int i = 0; i < inputArray.GetLength(0); i++)
{
    for (int j = 0; j < inputArray.GetLength(1); j++)
    {
        if (i + 1 < inputArray.GetLength(1))
        {
            string rule = inputArray[i,j] + "S" + inputArray[i+1,j];
            if (!rules.Contains(rule))
            {
                rules.Add(rule);
            }
        }
        if (j + 1 < inputArray.GetLength(1))
        {
            string rule = inputArray[i,j] + "E" + inputArray[i,j + 1];
            if (!rules.Contains(rule))
            {
                rules.Add(rule);
            }
        }
        if (i > 0)
        {
            string rule = inputArray[i,j] + "N" + inputArray[i-1,j];
            if (!rules.Contains(rule))
            {
                rules.Add(rule);
            }
        }
        if (j > 0)
        {
            string rule = inputArray[i,j] + "W" + inputArray[i,j - 1];
            if (!rules.Contains(rule))
            {
                rules.Add(rule);
            }
        }

        if (!possibilities.ContainsKey(inputArray[i, j]))
        {
            possibilities.Add(inputArray[i,j], 1);
        }
        else
        {
            possibilities[inputArray[i, j]]++;
        }
    }
}

List<Pixels> pixels = new List<Pixels>();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        Dictionary<char, int> possible = new Dictionary<char, int>(possibilities);
        Pixels pixel = new Pixels(false, i, j, possible);
        pixels.Add(pixel);
    }
}

pixels[0].Possible = new Dictionary<char, int>();
pixels[0].Possible.Add('B', 1);

int k = 0;
while (true)
{
    (pixels, int id) = Utils.LowestEntropy(pixels);

    if (pixels[id].Possible.Count > 1)
    {
        pixels = Utils.RevealRandom(pixels, id);
    }

    pixels = Utils.UpdateNeighbors(pixels, id, rules, n, m);
    k++;
    if(k == pixels.Count)break;
}

Paint.Painter(inputArray, "InputImage.png");
char[,] outputArray = new char[n,m];
for (int i = 0; i < pixels.Count; i++)
{
    outputArray[pixels[i].Y, pixels[i].X] = pixels[i].Possible.FirstOrDefault().Key;
}
Paint.Painter(outputArray, "OutputImage.png");
