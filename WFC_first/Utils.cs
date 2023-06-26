namespace WFC_first;

public static class Utils
{
    public static (List<Pixels>,int)LowestEntropy(List<Pixels> pixels)
    {
        int id = 0;
        int minEnt = Int32.MaxValue;
        for (int i = 0; i < pixels.Count; i++)
        {
            if (!pixels[i].Finished && pixels[i].Possible.Count < minEnt)
            {
                id = i;
                minEnt = pixels[i].Possible.Count;
            }
        }
        return (pixels, id);
    }

    public static List<Pixels> RevealRandom(List<Pixels> pixels, int id)
    {
        int totalWeight = pixels[id].Possible.Values.Sum();

        char temp = '?';
        int tempi = 0;
        Random random = new Random();
        int randomNumber = random.Next(totalWeight);

        foreach (var kvp in pixels[id].Possible)
        {
            if (randomNumber < kvp.Value)
            {
                temp = kvp.Key;
                tempi = kvp.Value;
                break;
            }
            randomNumber -= kvp.Value;
        }
        pixels[id].Possible.Clear();
        pixels[id].Possible.Add(temp, tempi);
        return pixels;
    }

    public static List<Pixels> UpdateNeighbors(List<Pixels> pixels, int id, List<string> rules, int n, int m)
    {
        int x = pixels[id].X;
        int y = pixels[id].Y;
        char current = pixels[id].Possible.FirstOrDefault().Key;
        for (int i = 0; i < pixels.Count; i++)
        {
            if (x > 0 && pixels[i].X == x - 1 && pixels[i].Y == y)
            {
                Dictionary<char, int> possibleByRules = new Dictionary<char,int>();
                for (int j = 0; j < rules.Count; j++)
                {
                    if (rules[j][0] == current && rules[j][1] == 'W' && pixels[i].Possible.ContainsKey(rules[j][2]))
                    {
                        possibleByRules.Add(rules[j][2], pixels[i].Possible[rules[j][2]]);
                    }
                }
                pixels[i].Possible = possibleByRules;
            }
            if (y > 0 && pixels[i].X == x && pixels[i].Y == y - 1)
            {
                Dictionary<char, int> possibleByRules = new Dictionary<char,int>();
                for (int j = 0; j < rules.Count; j++)
                {
                    if (rules[j][0] == current && rules[j][1] == 'N' && pixels[i].Possible.ContainsKey(rules[j][2]))
                    {
                        possibleByRules.Add(rules[j][2], pixels[i].Possible[rules[j][2]]);
                    }
                }
                pixels[i].Possible = possibleByRules;
            }
            if (x+1 < n && pixels[i].X == x + 1 && pixels[i].Y == y)
            {
                Dictionary<char, int> possibleByRules = new Dictionary<char,int>();
                for (int j = 0; j < rules.Count; j++)
                {
                    if (rules[j][0] == current && rules[j][1] == 'E' && pixels[i].Possible.ContainsKey(rules[j][2]))
                    {
                        possibleByRules.Add(rules[j][2], pixels[i].Possible[rules[j][2]]);
                    }
                }
                pixels[i].Possible = possibleByRules;
            }
            if (y+1 < m && pixels[i].X == x && pixels[i].Y == y + 1)
            {
                Dictionary<char, int> possibleByRules = new Dictionary<char,int>();
                for (int j = 0; j < rules.Count; j++)
                {
                    if (rules[j][0] == current && rules[j][1] == 'S' && pixels[i].Possible.ContainsKey(rules[j][2]))
                    {
                        possibleByRules.Add(rules[j][2], pixels[i].Possible[rules[j][2]]);
                    }
                }
                pixels[i].Possible = possibleByRules;
            }
        }

        pixels[id].Finished = true;
        return pixels;
    }
    
}