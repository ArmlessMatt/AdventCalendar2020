using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Challenges
{
    public class Day3 : IChallenge
    {
        public string AnswerFirstChallenge()
        {
            var input = ReadInput();

            int singleLineLength = input.First().Length - 1;
            int currentHorizontalPositition = 0; 
            int totalTrees = 0;
            for (int i = 1; i < input.Count; i++)
            {
                currentHorizontalPositition += 3;
                if (currentHorizontalPositition > singleLineLength)
                {
                    currentHorizontalPositition -= singleLineLength + 1;
                }
                if (input[i][currentHorizontalPositition] == '#') 
                {
                    totalTrees += 1;
                }
            }
            return totalTrees.ToString();
        }

        public string AnswerSecondChallenge()
        {
            var input = ReadInput();

            int singleLineLength = input.First().Length - 1;
            int currentHorizontalPositition1 = 0;
            int currentHorizontalPositition3 = 0;
            int currentHorizontalPositition5 = 0;
            int currentHorizontalPositition7 = 0;
            int totalTrees1 = 0;
            int totalTrees3 = 0;
            int totalTrees5 = 0;
            int totalTrees7 = 0;

            for (int i = 1; i < input.Count; i++)
            {
                currentHorizontalPositition1 += 1;
                currentHorizontalPositition3 += 3;
                currentHorizontalPositition5 += 5;
                currentHorizontalPositition7 += 7;
                if (currentHorizontalPositition1 > singleLineLength)
                {
                    currentHorizontalPositition1 -= singleLineLength + 1;
                }
                if (currentHorizontalPositition3 > singleLineLength)
                {
                    currentHorizontalPositition3 -= singleLineLength + 1;
                }
                if (currentHorizontalPositition5 > singleLineLength)
                {
                    currentHorizontalPositition5 -= singleLineLength + 1;
                }
                if (currentHorizontalPositition7 > singleLineLength)
                {
                    currentHorizontalPositition7 -= singleLineLength + 1;
                }
                if (input[i][currentHorizontalPositition1] == '#')
                {
                    totalTrees1 += 1;
                }
                if (input[i][currentHorizontalPositition3] == '#')
                {
                    totalTrees3 += 1;
                }
                if (input[i][currentHorizontalPositition5] == '#')
                {
                    totalTrees5 += 1;
                }
                if (input[i][currentHorizontalPositition7] == '#')
                {
                    totalTrees7 += 1;
                }
            }
            currentHorizontalPositition1 = 0;
            int totalTrees2Down = 0;

            for (int i = 2; i < input.Count; i+=2)
            {
                currentHorizontalPositition1 += 1;
                if (currentHorizontalPositition1 > singleLineLength)
                {
                    currentHorizontalPositition1 -= singleLineLength + 1;
                }
                if (input[i][currentHorizontalPositition1] == '#')
                {
                    totalTrees2Down += 1;
                }
            }

            return (totalTrees1 * totalTrees3 * totalTrees5 * 
                totalTrees7 * totalTrees2Down).ToString();
        }

        private List<string> ReadInput() 
        {
            var input = new List<string>();

            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@".\Input\day3.txt");
            while ((line = file.ReadLine()) != null)
            {
                input.Add(line);
            }

            file.Close();
            return input;
        }
    }
}
