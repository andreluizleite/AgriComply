namespace AdventCode2024.Day1
{
    class PartOne
    {
        public int CalcDistance()
        {
            // Input lists
            List<int> A;
            List<int> B;

            (A, B) = Input.ReadInputFromFile();

            if (A.Count != B.Count)
            {
                Console.WriteLine("Lists must have the same length.");
                return 0;
            }

            // Sort both lists independently
            A.Sort();
            B.Sort();

            int totalDistance = 0;

            Dictionary<int, int> dictionaryBCounter = new Dictionary<int, int>();

            foreach (int b in B)
            {
                if (!dictionaryBCounter.ContainsKey(b))
                {
                    dictionaryBCounter.Add(b, 1);
                }
                else
                {
                    dictionaryBCounter[b]++;
                }
            }

            // Calculate pairwise distances between sorted lists
            for (int i = 0; i < A.Count; i++)
            {
                totalDistance += Math.Abs(A[i] - B[i]);
            }

            Console.WriteLine("Day 1, Part One: Total distance: " + totalDistance);

            return totalDistance;
        }

    }
}
