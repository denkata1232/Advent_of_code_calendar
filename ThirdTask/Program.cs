using System.Text;

namespace ThirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("third_input.txt"))
            {
                long sum = 0;
                char[] allowed = ['m', 'u', 'l', '(', ')', ','];
                char[] commander = ['d', 'o', 'n', '\'', 't', '(', ')'];
                StringBuilder multiplier = new StringBuilder();
                StringBuilder command = new StringBuilder();
                char symbol = (char)sr.Read();
                bool go = true;
                while (symbol != 65535)
                {
                    go = CommandInstructions(commander, ref command, symbol, go);
                    if (go)
                        SumOperatoin(ref sum, allowed, ref multiplier, symbol);
                    symbol = (char)sr.Read();
                }
                Console.WriteLine(sum);
            }
        }

        private static bool CommandInstructions(char[] commander, ref StringBuilder command,
            char symbol, bool go)
        {
            if (commander.Contains(symbol))
            {
                command.Append(symbol);
                if (symbol == ')')
                {
                    while (command.Length != 0 && command[0] != 'd') command.Remove(0, 1);
                }
                if (command.ToString() == "don't()") go = false;
                else if (command.ToString() == "do()") go = true;
            }
            else command.Clear();
            return go;
        }

        private static void SumOperatoin(ref long sum, char[] allowed,
            ref StringBuilder multiplier, char symbol)
        {
            if (allowed.Contains(symbol) || char.IsDigit(symbol))
            {
                multiplier.Append(symbol);
                if (symbol == ')')
                {
                    string test = multiplier.ToString();
                    //Console.WriteLine(test);
                    while (test.Length != 0 && test[0] != 'm')
                    {
                        test = test.Substring(1);
                    }
                    if (test.Length >= 8)
                    {
                        if (test.Substring(0, 4) == "mul(")
                        {
                            string first = null;
                            int i = 4;
                            for (; i < test.Length; i++)
                            {
                                if (!char.IsDigit(test[i])) break;
                                first += test[i];
                            }
                            i++;
                            string second = null;
                            for (; i < test.Length - 1; i++)
                            {
                                second += test[i];
                            }
                            sum += int.Parse(first) * int.Parse(second);
                            //Console.WriteLine($"curr sum is {sum}");
                            multiplier.Clear();
                        }
                    }
                    else { multiplier.Clear(); }
                }
            }
            else { multiplier.Clear(); }
        }
    }
}
