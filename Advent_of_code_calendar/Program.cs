namespace Advent_of_code_calendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*second part input*/
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            using (StreamReader sr = new StreamReader("first_input.txt"))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    int[] elements = line
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    list1.Add(elements[0]);
                    list2.Add(elements[1]);
                    line = sr.ReadLine();
                }
            }
            list1.Sort();
            list2.Sort();
            int similarity = 1;
            foreach (var item in list1)
            {
                int count = 0;
                foreach (var item2 in list2)
                {
                    if (item == item2) count++;
                    else if (item < item2) break;
                }
                similarity += count * item;
            }
            similarity -= 1;
            Console.WriteLine(similarity);
        }
    }
}
