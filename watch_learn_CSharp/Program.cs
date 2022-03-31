using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace watch_learn_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var demo_Timer = new Demo_Timer();*/

            /*Demo_Type demo_Type = new Demo_Type();

            Demo_Debug.GetConeVolume(10, 5);*/

            /*Demo_Operator demo_Operator = new Demo_Operator();
            demo_Operator.test();*/

            //Demo_Type_Transfer demo_Type_Transfer = new Demo_Type_Transfer();

            Demo_Expression demo_Expression = new Demo_Expression();
            demo_Expression.test();
            Console.ReadLine();
        }
    }
}
