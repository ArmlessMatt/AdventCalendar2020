using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Challenges
{
    public class Day4 : IChallenge
    {
        public string AnswerFirstChallenge()
        {
            var input = ReadInput();
            int validCounter = 0;
            foreach (var passport in input)
            {
                if (passport.Contains("byr:") && passport.Contains("iyr:") && passport.Contains("eyr:") &&
                        passport.Contains("hgt:") && passport.Contains("hcl:") && passport.Contains("ecl:")
                        && passport.Contains("pid:")) 
                {
                    validCounter++;
                }
            }
            return validCounter.ToString();
        }

        public string AnswerSecondChallenge()
        {
            var input = ReadInput();
            var passports = ConvertInputToPassport(input);
            return passports.Count(passport => passport.IsValid()).ToString();
        }

        private List<string> ReadInput()
        {
            var input = new List<string>();

            string fileline;
            string inputline = string.Empty;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@".\Input\day4.txt");
            while ((fileline = file.ReadLine()) != null)
            {
                if (fileline != string.Empty)
                {
                    inputline += " " + fileline;
                }
                else 
                {
                    input.Add(inputline);
                    inputline = string.Empty;
                }
            }
            if(inputline != string.Empty) 
            {
                input.Add(inputline);
            }
            file.Close();
            return input;
        }

        private List<Passport> ConvertInputToPassport(List<string> input) 
        {
            List<Passport> passports = new List<Passport>();
            foreach (var passport in input)
            {
                var newPass = new Passport();
                int byrIndex = passport.IndexOf("byr");
                int iyrIndex = passport.IndexOf("iyr");
                int eyrIndex = passport.IndexOf("eyr");
                int hgtIndex = passport.IndexOf("hgt");
                int hclIndex = passport.IndexOf("hcl");
                int eclIndex = passport.IndexOf("ecl");
                int pidIndex = passport.IndexOf("pid");
                if (byrIndex != -1) 
                {
                    var nextSpaceIndex = passport.IndexOf(' ', byrIndex);
                    if (nextSpaceIndex == -1)
                    {
                        nextSpaceIndex = passport.Length;
                    }
                    newPass.byr = passport.Substring(byrIndex + 4, nextSpaceIndex - byrIndex - 4);
                }
                if (iyrIndex != -1)
                {
                    var nextSpaceIndex = passport.IndexOf(' ', iyrIndex);
                    if (nextSpaceIndex == -1)
                    {
                        nextSpaceIndex = passport.Length;
                    }
                    newPass.iyr = passport.Substring(iyrIndex + 4, nextSpaceIndex - iyrIndex - 4);
                }
                if (eyrIndex != -1)
                {
                    var nextSpaceIndex = passport.IndexOf(' ', eyrIndex);
                    if (nextSpaceIndex == -1) 
                    {
                        nextSpaceIndex = passport.Length;
                    }
                    newPass.eyr = passport.Substring(eyrIndex + 4, nextSpaceIndex - eyrIndex - 4);
                }
                if (hgtIndex != -1)
                {
                    var nextSpaceIndex = passport.IndexOf(' ', hgtIndex);
                    if (nextSpaceIndex == -1)
                    {
                        nextSpaceIndex = passport.Length;
                    }
                    newPass.hgt = passport.Substring(hgtIndex + 4, nextSpaceIndex - hgtIndex - 4);
                }
                if (hclIndex != -1)
                {
                    var nextSpaceIndex = passport.IndexOf(' ', hclIndex);
                    if (nextSpaceIndex == -1)
                    {
                        nextSpaceIndex = passport.Length;
                    }
                    newPass.hcl = passport.Substring(hclIndex + 4, nextSpaceIndex - hclIndex - 4);
                }
                if (eclIndex != -1)
                {
                    var nextSpaceIndex = passport.IndexOf(' ', eclIndex);
                    if (nextSpaceIndex == -1)
                    {
                        nextSpaceIndex = passport.Length;
                    }
                    newPass.ecl = passport.Substring(eclIndex + 4, nextSpaceIndex - eclIndex - 4);
                }
                if (pidIndex != -1)
                {
                    var nextSpaceIndex = passport.IndexOf(' ', pidIndex);
                    if (nextSpaceIndex == -1)
                    {
                        nextSpaceIndex = passport.Length;
                    }
                    newPass.pid = passport.Substring(pidIndex + 4, nextSpaceIndex - pidIndex - 4);
                }
                passports.Add(newPass);
            }
            return passports;
        }
    }

    public class Passport 
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }

        public bool IsValid() 
        {
            if (byr == null || iyr == null || eyr == null || hgt == null
                || hcl == null || ecl == null || pid == null) 
            {
                return false;
            }
            var byrAsInt = int.Parse(byr);
            if (byrAsInt < 1920 || byrAsInt > 2002) 
            {
                return false;
            }
            var iyrAsInt = int.Parse(iyr);
            if (iyrAsInt < 2010 || iyrAsInt > 2020)
            {
                return false;
            }
            var eyrAsInt = int.Parse(eyr);
            if (eyrAsInt < 2020 || eyrAsInt > 2030)
            {
                return false;
            }

            var cmIndex = hgt.IndexOf("cm");
            var inIndex = hgt.IndexOf("in");
            var unitIndex = cmIndex != -1 ? cmIndex : inIndex;
            if (unitIndex == -1) 
            {
                return false;
            }
            var hgtNumber = int.Parse(hgt.Substring(0, unitIndex));
            if (cmIndex != -1 && (hgtNumber < 150 || hgtNumber > 193))
            {
                return false;
            }
            else if (inIndex != -1 && (hgtNumber < 59 || hgtNumber > 76))
            {
                return false;
            }

            Regex rgx = new Regex(@"^#[0-9a-f]{6}$");
            if (!rgx.IsMatch(hcl)) 
            {
                return false;
            }

            var eyePossibleValues = " amb blu brn gry grn hzl oth ";
            if (!eyePossibleValues.Contains(" " + ecl + " ")) 
            {
                return false;
            }

            if (pid.Length != 9 || !int.TryParse(pid, out var pidParsed)) 
            {
                return false;
            }
            return true;
        }
    }
}
