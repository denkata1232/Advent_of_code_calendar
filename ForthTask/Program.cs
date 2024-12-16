
using System.Text;

namespace ForthTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("forth_input.txt"))
            {
                string line = sr.ReadLine();
                char[,] check = new char[4, line.Length];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < line.Length; j++)
                    {
                        check[i, j] = line[j];
                    }
                    line = sr.ReadLine();
                }
                int count = 0;
                while (line != null)
                {
                    count += DiagXMAS(check);
                }
            }
        }

        private static int DiagXMAS(char[,] check)
        {
            int count = 0;

            return count;
        }

        private static bool XmasCheck(string word)
        {
            return word.ToString() is "XMAS" or "SAMX";
        }

        private static void FirstPart(StreamReader sr)
        {
            string line = sr.ReadLine();
            char[,] check = new char[4, line.Length];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < line.Length; j++)
                {
                    check[i, j] = line[j];
                }
                line = sr.ReadLine();
            }
            int count = FirstChecker(check);
            while (line != null)
            {
                check = MoveToNextRow(check, line);
                count += Checker(check);
                line = sr.ReadLine();
            }
            Console.WriteLine(count);
        }

        private static int FirstChecker(char[,] check)
        {
            int count = 0;
            count += FirstHorCheck(check);
            count += VerCheck(check);
            count += DiagCheck(check);
            return count;
        }

        private static int FirstHorCheck(char[,] check)
        {
            int count = 0;
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < check.GetLength(0); i++)
            {
                for (int j = 0; j < check.GetLength(1); j++)
                {
                    word.Append(check[i, j]);
                    if (word.Length > 4)
                    {
                        word.Remove(0, 1);
                    }
                    if (word.ToString() is "XMAS" or "SAMX") count++;
                }
                word.Clear();
            }
            return count;
        }

        private static int Checker(char[,] check)
        {
            int count = 0;
            count += HorCheck(check);
            count += VerCheck(check);
            count += DiagCheck(check);
            return count;
        }

        private static int HorCheck(char[,] check)
        {
            StringBuilder word = new StringBuilder();
            int count = 0;
            for (int i = 0; i < check.GetLength(1); i++)
            {
                word.Append(check[3, i]);
                if (word.Length > 4)
                {
                    word.Remove(0, 1);
                }
                if (word.ToString() is "XMAS" or "SAMX") count++;
            }
            return count;
        }

        private static char[,] MoveToNextRow(char[,] check, string line)
        {
            char[] row = line.ToCharArray();
            for (int i = check.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = check.GetLength(1) - 1; j >= 0; j--)
                {
                    (check[i, j], row[j]) = (row[j], check[i, j]);
                }
            }
            return check;
        }

        private static int DiagCheck(char[,] check)
        {
            int count = 0;
            count += ForwardDiagCheck(check);
            count += BackwardDiagCheck(check);
            return count;
        }

        private static int BackwardDiagCheck(char[,] check)
        {
            int count = 0;
            StringBuilder word = new StringBuilder();
            for (int i = 3; i < check.GetLength(1); i++)
            {
                word.Append(check[0, i]);
                word.Append(check[1, i - 1]);
                word.Append(check[2, i - 2]);
                word.Append(check[3, i - 3]);
                if (word.ToString() is "XMAS" or "SAMX") count++;
                word.Clear();
            }
            return count;
        }

        private static int ForwardDiagCheck(char[,] check)
        {
            int count = 0;
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < check.GetLength(1) - 3; i++)
            {
                word.Append(check[0, i]);
                word.Append(check[1, i + 1]);
                word.Append(check[2, i + 2]);
                word.Append(check[3, i + 3]);
                if (word.ToString() is "XMAS" or "SAMX") count++;
                word.Clear();
            }
            return count;
        }

        private static int VerCheck(char[,] check)
        {
            int count = 0;
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < check.GetLength(1); i++)
            {
                for (int j = 0; j < check.GetLength(0); j++)
                {
                    word.Append(check[j, i]);
                    if (word.Length > 4)
                    {
                        word.Remove(0, 1);
                    }
                    if (word.ToString() is "XMAS" or "SAMX") count++;
                }
                word.Clear();
            }
            return count;
        }

        private static void Print(char[,] check)
        {
            for (int i = 0; i < check.GetLength(0); i++)
            {
                for (int j = 0; j < check.GetLength(1); j++)
                {
                    Console.Write(check[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
