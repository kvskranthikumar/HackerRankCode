using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximizingXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            int res;
            int _l;
            _l = Convert.ToInt32(Console.ReadLine());

            int _r;
            _r = Convert.ToInt32(Console.ReadLine());

            res = maxXor(_l, _r);
            Console.WriteLine(res);
        }

        static int maxXor(int l, int r)
        {
            int maxVal = 0;
            if (l >= 1 && r <= 1000)
            {
                for (int x = l; x <= r; x++)
                {
                    for (int y = x; y <= r; y++)
                    {
                        int result = x ^ y;
                        //Console.WriteLine(x + " XOR " + y + "= " + result);
                        if (result > maxVal)
                            maxVal = result;
                    }
                }
            }
            return maxVal;
        }
    }
}
