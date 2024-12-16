namespace SecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("second_input.txt"))
            {
                int safeReports = 0;
                string line = sr.ReadLine();
                while (line != null)
                {
                    List<int> nums = line
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                    if (IsValidReport(nums))
                    {
                        safeReports++;
                        Console.WriteLine($"found the {safeReports} one in with");
                        goto next;
                    }
                    if (nums.Select((t, i) => nums.Where((_, index) => index != i).ToList())
                        .Any(IsValidReport))
                    {
                        safeReports++;
                        Console.WriteLine($"found the {safeReports} one in without");
                    }
                next:
                    line = sr.ReadLine();
                }
                Console.WriteLine(safeReports);
            }
        }
        private static bool IsValid(List<int> nums)
        {
            bool direction = (nums[0] < nums[1]) ? true : false;
            bool isSafe = true;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                int diff;
                if (direction)
                {
                    diff = nums[i + 1] - nums[i];
                }
                else
                {
                    diff = nums[i] - nums[i + 1];
                }
                if (diff < 1 || diff > 3)
                {
                    isSafe = false;
                }
            }
            return isSafe;
        }

        static bool IsValidReport(List<int> levels)
        {
            // We don't care about the numbers, just wether going up or down, not both
            var isIncreasing = IsIncreasing(levels);
            var isDecreasing = IsDecreasing(levels);

            if (!isIncreasing && !isDecreasing) return false;

            // Check that all adjacent levels differ by at least 1 and at most 3
            for (var i = 0; i < levels.Count - 1; i++)
            {
                var diff = Math.Abs(levels[i + 1] - levels[i]);
                if (diff is < 1 or > 3)
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsIncreasing(List<int> numbers)
        {
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < numbers[i - 1]) return false;
            }

            return true;
        }

        static bool IsDecreasing(List<int> numbers)
        {
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > numbers[i - 1]) return false;
            }

            return true;
        }
    }
}
