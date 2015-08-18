using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = int.Parse(Console.ReadLine());
            if (val1 >= 1 && val1 <= 1000)
            {
                List<List<int>> positionOfNumbers = new List<List<int>>();
                List<List<int>> noOfTestCases = new List<List<int>>();
                for (int x = 0; x < val1; x++)
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input >= 2 && input <= 1000)
                    {
                        string sequence = Convert.ToString(Console.ReadLine());
                        if (!string.IsNullOrEmpty(sequence))
                        {
                            List<int> copies = new List<int>();
                            string[] numbers = sequence.Split(' ');

                            for (int num = 0; num < numbers.Length; num++)
                            {
                                if (!string.IsNullOrEmpty(numbers[num]))
                                {
                                    int seqNum = int.Parse(numbers[num]);
                                    if (seqNum >= 1 && seqNum <= 1000000)
                                    {
                                        copies.Add(seqNum);

                                        List<int> triplet = new List<int>();
                                        if (num == 0)
                                        {
                                            triplet.Add(0);
                                            triplet.Add(seqNum);
                                            triplet.Add(int.Parse(numbers[num + 1]));
                                        }
                                        else if (num == numbers.Length - 1)
                                        {
                                            triplet.Add(int.Parse(numbers[num - 1]));
                                            triplet.Add(seqNum);
                                            triplet.Add(0);
                                        }
                                        else
                                        {
                                            triplet.Add(int.Parse(numbers[num - 1]));
                                            triplet.Add(seqNum);
                                            triplet.Add(int.Parse(numbers[num + 1]));
                                        }

                                        positionOfNumbers.Add(triplet);
                                    }
                                }
                            }

                            noOfTestCases.Add(copies);
                        }
                    }
                }

                List<int> totalSeq = new List<int>();
                List<int> biggestSequence = new List<int>();
                int count = 0;
                foreach (List<int> seq in noOfTestCases)
                {
                    if(seq.Count > count)
                    {
                        biggestSequence.Clear();
                        biggestSequence.AddRange(seq);
                    }
                    totalSeq.AddRange(seq);
                }

                totalSeq.Sort();
                List<int> distinct = totalSeq.Distinct().ToList();

                List<int> missingNumbers = new List<int>();
                missingNumbers.AddRange(distinct.Except(biggestSequence).ToList());

                List<List<int>> missingTriplet = new List<List<int>>();
                foreach (int missing in missingNumbers)
                {
                    foreach (List<int> seq in noOfTestCases)
                    {
                        if (seq[1] == missing)
                        {
                            missingTriplet.Add(seq);
                        }
                    }
                }

                List<int> actualSquence = new List<int>();
                actualSquence.AddRange(biggestSequence);
                foreach (List<int> seq in missingTriplet)
                {
                    int first = seq[0];
                    int second = seq[1];
                    int third = seq[2];

                    foreach (int num in biggestSequence)
                    {
                        
                    }


                }




                //int highestNumSeq = distinct.OrderBy(i => i).Last();
                //PrintNumbersInDictionaryOrder(highestNumSeq);

                //List<int> uniqueLex = new List<int>();
                //foreach (int seq in lex)
                //{
                //    if (distinct.Contains(seq))
                //        uniqueLex.Add(seq);
                //}

                System.Text.StringBuilder output = new System.Text.StringBuilder();
                foreach (int seq in distinct)
                {
                    output.Append(seq + " ");
                }

                Console.WriteLine(output.ToString().TrimEnd());
            }

            Console.ReadLine();
        }

        static List<int> lex = new List<int>();
        public static void PrintNumbersInDictionaryOrder(int N)
        {
            //StringBuilder output = new StringBuilder();

            // straight forward
            if (N < 9)
            {
                for (int i = 1; i <= N; i++)
                {
                    lex.Add(i);
                    //output.Append(i + " ");
                }

                //Console.WriteLine(output.ToString());
                return;
            }

            int startingDigit, multiplyingFactor, loopCount, max;

            // dangerous code with lot of math :-)
            for (int index = 1; index <= 9; index++)
            {
                // prints single digit numbers
                startingDigit = index;

                //output.Append(startingDigit + " ");
                //Console.WriteLine(startingDigit);
                lex.Add(startingDigit);

                // reset variables
                multiplyingFactor = 1;
                loopCount = 1;

                while (startingDigit * 10 < N)
                {
                    // 10, 100, 1000 and so on
                    // 20, 200, 2000 and so on
                    startingDigit = startingDigit * (int)Math.Pow(10, 1);

                    // 9, 99, 999, 9999 and so on
                    max = 9 * multiplyingFactor;

                    // max value depends on N
                    // for example, if N is 25 then max will become 5 instead of 9
                    // another example, if N is 256 then max will become 56 instead of 99
                    if (N - startingDigit < Math.Pow(10, loopCount))
                    {
                        max = N - startingDigit;
                    }

                    // prints 10 - 19, 100 - 199 and so on
                    for (int j = 0; j <= max; j++)
                    {
                        //output.Append((startingDigit + j) + " ");
                        //Console.WriteLine(startingDigit + j);
                        lex.Add(startingDigit + j);
                    }

                    // 1, 11, 111, 1111 and so on
                    multiplyingFactor = (multiplyingFactor * 10) + 1;

                    loopCount++;
                }

                // corner case to print
                // for example, if N = 10/100/1000 while loop fails to print the number
                if (startingDigit * 10 == N)
                {
                    //output.Append(N + " ");
                    //Console.WriteLine(N);
                    lex.Add(N);
                }
            }

            //Console.WriteLine(output.ToString());
        }
    }
}
