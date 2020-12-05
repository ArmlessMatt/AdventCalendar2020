using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Challenges
{
    public class Day5 : IChallenge
    {
        public string AnswerFirstChallenge()
        {
            var input = ReadInput();

            var highestSeatId = 0;

            foreach (var seat in input)
            {
                var currentRow = string.Empty;
                var currentColumn = string.Empty;
                foreach (var character in seat)
                {
                    if (character == 'F') 
                    {
                        currentRow += '0';
                    }
                    else if (character == 'B')
                    {
                        currentRow += '1';
                    }
                    if (character == 'R')
                    {
                        currentColumn += '1';
                    }
                    else if (character == 'L')
                    {
                        currentColumn += '0';
                    }
                }
                var rowAsInt = Convert.ToInt32(currentRow, 2);
                var columnAsInt = Convert.ToInt32(currentColumn, 2);
                var seatId = (rowAsInt * 8) + columnAsInt;
                if (seatId > highestSeatId) 
                {
                    highestSeatId = seatId;
                }
            }
            return highestSeatId.ToString();
        }

        public string AnswerSecondChallenge()
        {
            var input = ReadInput();

            var seatIds = new List<int>();

            foreach (var seat in input)
            {
                var currentRow = string.Empty;
                var currentColumn = string.Empty;
                foreach (var character in seat)
                {
                    if (character == 'F')
                    {
                        currentRow += '0';
                    }
                    else if (character == 'B')
                    {
                        currentRow += '1';
                    }
                    if (character == 'R')
                    {
                        currentColumn += '1';
                    }
                    else if (character == 'L')
                    {
                        currentColumn += '0';
                    }
                }
                var rowAsInt = Convert.ToInt32(currentRow, 2);
                var columnAsInt = Convert.ToInt32(currentColumn, 2);
                var seatId = (rowAsInt * 8) + columnAsInt;
                seatIds.Add(seatId);
            }
            seatIds.Sort();
            var id = 0;
            for (int i = 0; i < seatIds.Count - 2; i++)
            {
                if(seatIds[i + 1] - seatIds[i] != 1) 
                {
                    id = i + 1;
                    break;
                }
            }
            return (seatIds[id] - 1).ToString();
        }

        private List<string> ReadInput()
        {
            var input = new List<string>();

            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@".\Input\day5.txt");
            while ((line = file.ReadLine()) != null)
            {
                input.Add(line);
            }

            file.Close();
            return input;
        }
    }
}
