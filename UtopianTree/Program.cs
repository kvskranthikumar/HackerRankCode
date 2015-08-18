using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtopianTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            //Number of Test Cases.
            int val1 = Convert.ToInt32(Console.ReadLine());
            List<int> noOfCycles = new List<int>();
            for (int x = 0; x < val1; x++)
            {
                noOfCycles.Add(Convert.ToInt32(Console.ReadLine()));
            }

            int turns = 0;
            int growth = 1;
            foreach (int cycle in noOfCycles)
            {
                if (cycle == 0)
                {
                    Console.WriteLine(growth);
                }
                else
                {
                    for (int y = 1; y <= cycle; y++)
                    {
                        if (turns < cycle)
                        {
                            growth = growth * 2;
                            turns++;
                        }
                        else
                        {
                            Console.WriteLine(growth);
                            turns = 0;
                            growth = 1;
                            break;
                        }

                        if (turns < cycle)
                        {
                            growth += 1;
                            turns++;
                        }
                        else
                        {
                            Console.WriteLine(growth);
                            turns = 0;
                            growth = 1;
                            break;
                        }

                        if (turns == cycle)
                        {
                            Console.WriteLine(growth);
                            turns = 0;
                            growth = 1;
                            break;
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
