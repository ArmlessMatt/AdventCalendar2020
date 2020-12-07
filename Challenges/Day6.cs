using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Challenges
{
    public class Day6 : IChallenge
    {
        public string AnswerFirstChallenge()
        {
            var input = ReadInput();
            var totalCount = 0;

            foreach (var group in input)
            {
                var groupUniqueQuestion = new List<char>();
                foreach (var character in group)
                {
                    if (!groupUniqueQuestion.Exists(charac => charac == character)) 
                    {
                        groupUniqueQuestion.Add(character);
                    }
                }
                totalCount += groupUniqueQuestion.Count;
            }
            return totalCount.ToString();
        }

        public string AnswerSecondChallenge()
        {
            var input = ReadInput();
            var totalCount = 0;

            foreach (var group in input)
            {
                var persons = group.Split('/');
                var groupUniqueQuestion = new List<char>();
                foreach (var character in group)
                {
                    if (!groupUniqueQuestion.Exists(charac => charac == character && charac != '/'))
                    {
                        bool inEveryPerson = true;
                        foreach (var person in persons)
                        {
                            if (!person.Contains(character)) 
                            {
                                inEveryPerson = false;
                                break;
                            }
                        }
                        if (inEveryPerson) { groupUniqueQuestion.Add(character); }
                    }
                }
                totalCount += groupUniqueQuestion.Count;
            }
            return totalCount.ToString();
        }

        private List<string> ReadInput()
        {
            var input = new List<string>();

            string inputLine = string.Empty;
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@".\Input\day6.txt");
            while ((line = file.ReadLine()) != null)
            {
                if(line == string.Empty) 
                {
                    if (inputLine[inputLine.Length - 1] == '/') 
                    {
                        inputLine = inputLine.Substring(0, inputLine.Length - 1);
                    }
                    input.Add(inputLine);
                    inputLine = string.Empty;
                    continue;
                }
                inputLine += line + '/';
            }
            if (inputLine != string.Empty) 
            {
                if (inputLine[inputLine.Length - 1] == '/')
                {
                    inputLine = inputLine.Substring(0, inputLine.Length - 1);
                }
                input.Add(inputLine);
            }
            file.Close();
            return input;
        }
    }
}
