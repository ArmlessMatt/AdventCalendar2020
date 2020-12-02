using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Challenges
{
    public class Day1 : IChallenge
    {
        public string AnswerFirstChallenge()
        {
            throw new NotImplementedException();
        }

        public string AnswerSecondChallenge()
        {
            var input = new List<int>();

            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@".\Input\day1.txt");
            while ((line = file.ReadLine()) != null)
            {
                input.Add(int.Parse(line));
            }

            file.Close();

            for (int i = 0; i < input.Count(); i++)
            {
                var firstNumber = input[i];
                for (int j = i + 1; j < input.Count(); j++)
                {
                    var secondNumber = input[j];
                    for (int k = j + 1; k < input.Count(); k++)
                    {
                        var thirdNumber = input[k];
                        if (firstNumber + secondNumber + thirdNumber == 2020)
                        {
                            return (firstNumber * secondNumber * thirdNumber).ToString();
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
