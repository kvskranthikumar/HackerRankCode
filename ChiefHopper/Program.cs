using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int val1 = int.Parse(Console.ReadLine());
        if (val1 >= 1 && val1 <= 100000)
        {
            List<int> noOfTestCases = new List<int>();

            string input = Convert.ToString(Console.ReadLine());
            string[] heights = input.Split(' ');

            if (heights.Length > 0)
            {
                foreach (string str in heights)
                {
                    int ht = int.Parse(str);
                    if (ht >= 1 && ht <= 100000)
                        noOfTestCases.Add(ht);
                }

                int highest = noOfTestCases[0];
                int lowest = noOfTestCases[0];
                for (int i = 0; i < noOfTestCases.Count - 1; i++)
                {
                    if (noOfTestCases[i] > highest)
                        highest = noOfTestCases[i];

                    if (noOfTestCases[i] < lowest)
                        lowest = noOfTestCases[i];
                }

                bool consider = false;
                int minEnergy = lowest;
                for (int energy = minEnergy; energy <= highest; energy++)
                {
                    int inputEngery = energy;
                    for (int i = 0; i < noOfTestCases.Count; i++)
                    {
                        if (inputEngery > noOfTestCases[i])
                        {
                            inputEngery += (inputEngery - noOfTestCases[i]);
                        }
                        else
                        {
                            inputEngery -= (noOfTestCases[i] - inputEngery);
                        }

                        if (inputEngery <= 0 || inputEngery >= highest)
                        {
                            if (i == noOfTestCases.Count - 1)
                                consider = true;

                            break;
                        }
                    }

                    if ((inputEngery > 0 && (inputEngery >= highest || energy > 0)) || consider)
                    {
                        minEnergy = energy;
                        break;
                    }
                }

                Console.WriteLine(minEnergy);
            }
        }
    }
}














//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ChiefHopper
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int val1 = int.Parse(Console.ReadLine());
//            if (val1 >= 1 && val1 <= 100000)
//            {
//                List<int> noOfTestCases = new List<int>();

//                string input = Convert.ToString(Console.ReadLine());
//                string[] heights = input.Split(' ');

//                if (heights.Length > 0)
//                {
//                    foreach (string str in heights)
//                    {
//                        int ht = int.Parse(str);
//                        if (ht >= 1 && ht <= 100000)
//                            noOfTestCases.Add(ht);
//                    }

//                    Random getrandom = new Random();
//                    StringBuilder sb = new StringBuilder();
//                    noOfTestCases.Clear();
//                    for (int i = 0; i < 50; i++)
//                    {
//                        int rnd = getrandom.Next(1, 1000);
//                        sb.Append(rnd + " ");
//                        noOfTestCases.Add(rnd);
//                    }
//                    Console.WriteLine(sb.ToString());

//                    int highest = noOfTestCases[0];
//                    int lowest = noOfTestCases[0];
//                    for (int i = 0; i < noOfTestCases.Count - 1; i++)
//                    {
//                        if (noOfTestCases[i] > highest)
//                            highest = noOfTestCases[i];

//                        if(noOfTestCases[i] < lowest)
//                            lowest = noOfTestCases[i];
//                    }

//                    Console.WriteLine("Highest is " + highest);
//                    Console.WriteLine("Lowest is " + lowest);

//                    bool consider = false;
//                    int minEnergy = lowest;//noOfTestCases[0];
//                    for (int energy = minEnergy; energy <= highest; energy++)
//                    {
//                        int inputEngery = energy;
//                        Console.WriteLine("Start Energy--> " + inputEngery);
//                        for (int i = 0; i < noOfTestCases.Count; i++)
//                        {
//                            string line = inputEngery + "_" + " + (" + inputEngery + "-" + noOfTestCases[i] + ")";

//                            inputEngery += (inputEngery - noOfTestCases[i]);

//                            Console.WriteLine(line + "--> " + inputEngery);

//                            if (inputEngery <= 0 || inputEngery >= highest)
//                            {
//                                if (i == noOfTestCases.Count - 1)
//                                    consider = true;

//                                Console.WriteLine("-----------------------------------------");

//                                break;
//                            }
//                        }

//                        if ((inputEngery > 0 && (inputEngery >= highest || energy > 0)) || consider)
//                        {
//                            minEnergy = energy;
//                            break;
//                        }
//                    }

//                    Console.WriteLine("Output is " + minEnergy);
//                }
//            }

//            Console.ReadLine();
//        }
//    }
//}
