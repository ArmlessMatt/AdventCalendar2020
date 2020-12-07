using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Challenges
{
    public class Day7 : IChallenge
    {
        public string AnswerFirstChallenge()
        {
            var input = ReadInput();

            return FindBagsThatCanContain("shiny gold", input).Count.ToString();
        }

        private List<string> FindBagsThatCanContain(string color, List<string> fullInput) 
        {
            List<string> colors = new List<string>();
            foreach (var item in fullInput)
            {
                if (item.Substring(item.IndexOf("bags"), item.Length - item.IndexOf("bags")).Contains(color)) 
                {
                    var colorFound = item.Substring(0, item.IndexOf(" bags"));
                    if (!colors.Exists(col => col == colorFound)) 
                    {
                        colors.Add(colorFound);
                        var nextLayerColors = FindBagsThatCanContain(colorFound, fullInput);
                        foreach (var nextLayerColor in nextLayerColors)
                        {
                            if (!colors.Exists(col => col == nextLayerColor))
                            {
                                colors.Add(nextLayerColor);
                            }
                        }   
                    }
                }
            }

            return colors;
        }

        public string AnswerSecondChallenge()
        {
            var input = ReadInput();

            return (FindBagsIn("shiny gold", input)-1).ToString();
        }

        private int FindBagsIn(string color, List<string> fullInput)
        {
            var totalResult = 1;
            foreach (var item in fullInput)
            {
                if (item.Substring(0, item.IndexOf("bags")).Contains(color))
                {
                    var colorsInfos = new List<string>();
                    var indexContains = item.IndexOf("contain") + 8;
                    var lengthToKeep = item.Length - (item.IndexOf("contain") + 9);
                    if (item.Contains("no other")) 
                    {
                        continue;
                    }
                    if (!item.Contains(',')) 
                    {
                        colorsInfos.Add(item.Substring(indexContains,
                            lengthToKeep));
                    }
                    else 
                    {
                        colorsInfos = item.Substring(indexContains,
                                        lengthToKeep).Split(',').ToList();
                    }
                    for (int i = 0; i < colorsInfos.Count; i++)
                    {
                        colorsInfos[i] = colorsInfos[i].TrimStart();
                    }
                    var parsedColors = new List<BagInfo>();
                    if (colorsInfos.Count == 1)
                    {
                        int number = int.Parse(colorsInfos[0][0].ToString());
                        var bagColor = colorsInfos[0].Replace("bags", "").Replace("bag", "").Replace(number.ToString() + " ", "").Trim();
                        parsedColors.Add(new BagInfo { Color = bagColor.Trim(), Number = number });
                    }
                    else
                    {
                        foreach (var colorInfo in colorsInfos)
                        {
                            int number = int.Parse(colorInfo[0].ToString());
                            var bagIndex = colorInfo.IndexOf("bag");
                            var bagColor = colorInfo.Substring(1, colorInfo.Length - 2)
                                .Replace("bags", "").Replace("bag", "");
                            parsedColors.Add(new BagInfo { Color = bagColor.Trim(), Number = number });
                        }
                    }
                    foreach (var parsedColor in parsedColors) 
                    {
                        totalResult += FindBagsIn(parsedColor.Color, fullInput) * parsedColor.Number;
                    }
                }
            }

            return totalResult;
        }

        private List<string> ReadInput()
        {
            var input = new List<string>();

            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@".\Input\day7.txt");
            while ((line = file.ReadLine()) != null)
            {
                input.Add(line);
            }

            file.Close();
            return input;
        }
    }

    public class BagInfo 
    {
        public int Number { get; set; }
        public string Color { get; set; }
    }
}
