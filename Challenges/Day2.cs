using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Challenges
{
    public class Day2 : IChallenge
    {
        public string AnswerFirstChallenge()
        {
            var passwordInfos = ParsePasswordInfosFromTextFile();

            return passwordInfos.Count(password => 
                password.IsCorrectForFirstChallenge()).ToString();
        }

        public string AnswerSecondChallenge()
        {
            var passwordInfos = ParsePasswordInfosFromTextFile();

            return passwordInfos.Count(password =>
                password.IsCorrectForSecondChallenge()).ToString();
        }

        private List<PasswordInfo> ParsePasswordInfosFromTextFile()
        {
            List<PasswordInfo> passwordInfos = new List<PasswordInfo>();

            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@".\Input\day2.txt");
            while ((line = file.ReadLine()) != null)
            {
                int dashIndex = line.IndexOf('-');
                int columnIndex = line.IndexOf(':');
                int firstSpaceIndex = line.IndexOf(' ');
                int lastSpaceIndex = line.LastIndexOf(' ');

                int lowerNumber = int.Parse(line.Substring(0, dashIndex));
                int higherNumber = int.Parse(line.Substring(dashIndex + 1, firstSpaceIndex - dashIndex - 1));
                char mandatoryCharacter = line.Substring(columnIndex - 1, 1)[0];
                string fullPassword = line.Substring(lastSpaceIndex + 1, line.Length - lastSpaceIndex - 1);
                passwordInfos.Add(new PasswordInfo(lowerNumber, higherNumber, mandatoryCharacter, fullPassword));
            }
            file.Close();

            return passwordInfos;
        }
    }

    public class PasswordInfo 
    {
        public int LowerNumber { get; }
        public int HigherNumber { get; }
        public string MandatoryCharacter { get; }
        public string FullPassword { get; }

        public PasswordInfo(int lowerNumber, int higherNumber, 
            char mandatoryCharacter, string fullPassword)
        {
            LowerNumber = lowerNumber;
            HigherNumber = higherNumber;
            MandatoryCharacter = mandatoryCharacter.ToString();
            FullPassword = fullPassword;
        }

        public bool IsCorrectForFirstChallenge() 
        {
            var passwordSizeWithoutMandCharacter = FullPassword.Replace(MandatoryCharacter, 
                    string.Empty).Length;
            var numberOfCharacter = FullPassword.Length - passwordSizeWithoutMandCharacter;
            return numberOfCharacter >= LowerNumber && numberOfCharacter <= HigherNumber;
        }

        public bool IsCorrectForSecondChallenge()
        {
            var passwordAsArray = FullPassword.ToCharArray();
            bool isLowerIndexMandatoryCharacter = passwordAsArray[LowerNumber - 1].ToString() == MandatoryCharacter;
            bool isHigherIndexMandatoryCharacter = passwordAsArray[HigherNumber - 1].ToString() == MandatoryCharacter;
            return isLowerIndexMandatoryCharacter ^ isHigherIndexMandatoryCharacter;
        }
    }
}
