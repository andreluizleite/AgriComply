using System.Text.RegularExpressions;

namespace AdventCode2024.Day3
{
    public class PartOne
    {
        public int CalculateMultiplications()
        {
            int total = 0;

            Regex mulPattern = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

            var corruptedMemory = ReadInputFromFile();

            // Find all matches in the corrupted memory
            MatchCollection matches = mulPattern.Matches(corruptedMemory);

            // Iterate through all the matches and calculate the product
            foreach (Match match in matches)
            {
                int num1 = int.Parse(match.Groups[1].Value);  // First number
                int num2 = int.Parse(match.Groups[2].Value);  // Second number
                total += num1 * num2;
            }

            return total;
        }

        private string ReadInputFromFile()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                var filePath = "/../../../day3/input.txt";
                // Read all content from the text file
                string content = File.ReadAllText(path + filePath);
                return content;
            }
            catch (Exception ex)
            {
                // Handle file reading errors
                Console.WriteLine("Error reading the file: " + ex.Message);
                return null;
            }
        }
    }
}
