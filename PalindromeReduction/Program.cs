using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeReduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = int.Parse(Console.ReadLine());
            if (val1 >= 1 && val1 <= 10)
            {
                List<string> noOfTestCases = new List<string>();
                for (int x = 0; x < val1; x++)
                {
                    string input = Convert.ToString(Console.ReadLine());
                    if (input.Length >= 1 && input.Length <= 10000)
                        noOfTestCases.Add(input);
                }

                int reduction;
                if (noOfTestCases.Count > 0)
                {
                    foreach (string word in noOfTestCases)
                    {
                        StringBuilder alterWord = new StringBuilder(word);
                        reduction = 0;
                        if (!IsPalindrome(word))
                        {
                            for (int x = 0; x < word.Length; x++)
                            {
                                char firstChar = Convert.ToChar(alterWord.ToString().Substring(x, 1));
                                int lastCharIndex = (word.Length - 1) - x;
                                char lastChar = Convert.ToChar(alterWord.ToString().Substring(lastCharIndex, 1));
                                if (firstChar != lastChar)
                                {
                                    int diff = firstChar - lastChar;
                                    if (diff > 0)
                                        reduction += diff;
                                    else
                                        reduction += (diff * -1);

                                    alterWord.Replace(lastChar, firstChar, lastCharIndex, 1);
                                    if (IsPalindrome(alterWord.ToString()))
                                        break;
                                }
                            }
                        }

                        Console.WriteLine(reduction);
                    }
                }
            }

            //Console.ReadLine();
        }

        private static bool IsPalindrome(string str)
        {
            bool flag = true;
            int i = 0;
            int j = str.Length - 1;

            while (i < j)
            {
                if (str[i] != str[j])
                {
                    flag = false;
                    break;
                }

                i++;
                j--;
            }

            return flag;
        }
    }
}
