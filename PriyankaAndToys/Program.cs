using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriyankaAndToys
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = int.Parse(Console.ReadLine());
            if (val1 >= 1 && val1 <= 100000)
            {
                List<int> noOfTestCases = new List<int>();

                string input = Convert.ToString(Console.ReadLine());
                string[] toyWeights = input.Split(' ');

                foreach (string str in toyWeights)
                {
                    noOfTestCases.Add(int.Parse(str));
                }

                noOfTestCases.Sort();

                int firstWeight = noOfTestCases[0];
                int lastWeight = firstWeight + 4;
                int amount = 1;

                for (int i = 0; i < noOfTestCases.Count; i++)
                {
                    if (lastWeight < noOfTestCases[i])
                    {
                        amount++;

                        firstWeight = noOfTestCases[i];
                        lastWeight = firstWeight + 4;
                    }
                }

                Console.WriteLine(amount);
            }

            //Console.ReadLine();
        }
    }
}
