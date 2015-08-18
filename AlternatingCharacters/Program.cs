using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = Convert.ToInt32(Console.ReadLine());
            if (val1 >= 1 && val1 <= 10)
            {
                List<string> noOfTestCases = new List<string>();
                for (int x = 0; x < val1; x++)
                {
                    string input = Convert.ToString(Console.ReadLine());
                    if (input.Length >= 1 && input.Length <= 100000)
                        noOfTestCases.Add(input);
                }

                if (noOfTestCases.Count > 0)
                {
                    foreach (string word in noOfTestCases)
                    {
                        List<char> letters = new List<char>(word);
                        int deletions = 0;
                        char? lastCharUsed = null;

                        foreach (char ch in letters)
                        {
                            if (lastCharUsed == null)
                            {
                                lastCharUsed = ch;
                            }
                            else
                            {
                                if (lastCharUsed == ch)
                                {
                                    deletions++;
                                    continue;
                                }
                                else
                                {
                                    lastCharUsed = ch;
                                }
                            }
                        }

                        Console.WriteLine(deletions);
                    }
                }
            }
        }
    }
}
