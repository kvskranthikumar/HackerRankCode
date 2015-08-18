using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeLengthPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentNames = new string[] { "Bharti", "Bharat", "Akash", "Bhavya", "Chand", "Brijesh", "Chetak", "Arvind", "Bhavna" };
            Console.WriteLine(Convert.ToString(PalindromeLengthPuzzle(studentNames)));
        }

        public static int PalindromeLengthPuzzle(string[] input1)
        {
            int result = 0;
            string inputWord = "";
            string palindromWord = "";
            if (input1.Length > 0 && input1.Length <= 1000)
            {
                foreach (string word in input1)
                {
                    char firstChar = Convert.ToChar(word.Substring(0, 1));
                    inputWord += firstChar;
                }

                //string finalPalWord = longestPalindromeString(palidromWord);
                string[] possibleWords = Combination2(inputWord);

                foreach (string word in possibleWords)
                {
                    if (IsPalindrome(word) && word.Length > result)
                    {
                        result = word.Length;
                        palindromWord = word;
                    }
                }
            }

            return result;
        }

        public static string[] Combination2(string str)
        {
            List<string> output = new List<string>();
            // Working buffer to build new sub-strings
            char[] buffer = new char[str.Length];

            Combination2Recurse(str.ToCharArray(), 0, buffer, 0, output);

            return output.ToArray();
        }

        public static void Combination2Recurse(char[] input, int inputPos, char[] buffer, int bufferPos, List<string> output)
        {
            if (inputPos >= input.Length)
            {
                //Add only non-empty strings
                if (bufferPos > 0)
                    output.Add(new string(buffer, 0, bufferPos));

                return;
            }

            //Recurs 2 times - one time without adding current input char, one time with.
            Combination2Recurse(input, inputPos + 1, buffer, bufferPos, output);

            buffer[bufferPos] = input[inputPos];
            Combination2Recurse(input, inputPos + 1, buffer, bufferPos + 1, output);
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


        public static String longestPalindromeString(String word)
        {
            char[] input = word.ToCharArray();
            int longestPalindromeStart = 0;
            int longestPalindromeEnd = 0;

            for (int mid = 0; mid < input.Length; mid++)
            {
                // for odd palindrome case like 14341, 3 will be the mid
                int left = mid - 1;
                int right = mid + 1;
                // we need to move in the left and right side by 1 place till they reach the end
                while (left >= 0 && right < input.Length)
                {
                    // below check to find out if its a palindrome
                    if (input[left] == input[right])
                    {
                        // update global indexes only if this is the longest one till now
                        if (right - left > longestPalindromeEnd
                                - longestPalindromeStart)
                        {
                            longestPalindromeStart = left;
                            longestPalindromeEnd = right;
                        }
                    }
                    else
                        break;
                    left--;
                    right++;
                }

                // for even palindrome, we need to have similar logic with mid size 2
                // for that we will start right from one extra place
                left = mid;
                right = mid + 1;// for example 12333321 when we choose 33 as mid
                while (left >= 0 && right < input.Length)
                {
                    if (input[left] == input[right])
                    {
                        if (right - left > longestPalindromeEnd
                                - longestPalindromeStart)
                        {
                            longestPalindromeStart = left;
                            longestPalindromeEnd = right;
                        }
                    }
                    else
                        break;
                    left--;
                    right++;
                }
            }
            // we have the start and end indexes for longest palindrome now
            return word.Substring(longestPalindromeStart, longestPalindromeEnd + 1);
        }

    }
}
