using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_Expression
    {
        public void test()
        {
            List<int> listint = new List<int>() { 1, 2, 3 };
            double[] array = { 1.0, 2.0, 3.0 };
            var x = array[1];
            Console.WriteLine(x.GetType());

        }
    }
}
