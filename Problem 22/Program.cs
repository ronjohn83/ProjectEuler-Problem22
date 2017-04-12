using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NameScores());
            Console.Read();
        }
        private static Int64 NameScores()
        {
            List<string> names = new List<string>();
            string getNames = File.ReadAllText("names.txt");

            string[] splitName = getNames.Split(',');
            string trimName;
            int alphabeticalValue = 0;
            int score = 0;
            int index;
            Int64 totalScore = 0;

            foreach (var name in splitName)
            {
                trimName = name.Trim('"');
                names.Add(trimName);
            }

            names.Sort();

            foreach (var name in names)
            {
                char[] nameArray = name.ToCharArray();

                foreach (var letter in nameArray)
                {
                    alphabeticalValue += letter - 65 + 1;
                }

                index = names.IndexOf(name);
                score = (index + 1) * alphabeticalValue;
                totalScore += score;

                score = 0;
                alphabeticalValue = 0;
            }

            return totalScore;
        }
    }
}
