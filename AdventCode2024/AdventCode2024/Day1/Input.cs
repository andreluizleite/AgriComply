namespace AdventCode2024.Day1
{
    public static class Input
    {
        public static (List<int>, List<int>) ReadInputFromFile()
        {
            try
            {
                string filePath = "/../../../day1/input.txt";
                string path = Directory.GetCurrentDirectory();
                List<int> listA = new List<int>();
                List<int> listB = new List<int>();

                // Read all content from the text file
                IEnumerable<string> content = File.ReadLines(path + filePath);               

                foreach (string line in content) 
                {
                    string[] splittedString = line.Split("   ");
                    listA.Add(Int32.Parse(splittedString[0]));
                    listB.Add(Int32.Parse(splittedString[1]));
                }

                return (listA, listB);
            }
            catch (Exception ex)
            {
                // Handle file reading errors
                Console.WriteLine("Error reading the file: " + ex.Message);
                throw ex;
            }
        }
    }
}
