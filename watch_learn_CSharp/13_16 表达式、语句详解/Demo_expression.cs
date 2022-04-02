using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watch_learn_CSharp
{
    class Demo_Expression
    {
        public void test()
        {
            /*List<int> listint = new List<int>() { 1, 2, 3 };
            double[] array = { 1.0, 2.0, 3.0 };
            var x = array[1];
            Console.WriteLine(x.GetType());

            var y = 5 / 3 > 5 / 4 ? 0 : 1.0;//冒号后的数值进行隐式转化，冒号前的数值并没有转换，否则返回值是1
            Console.WriteLine(y.GetType().Name);
            Console.WriteLine(y);

            Action action = () => { Console.WriteLine("hello"); };
            action();

            Form form = new Form();
            form.Load += Form_Load;
            form.ShowDialog();*/

            //input_double();

            block_statement();

            Console.WriteLine(Calculator.Add(null, null));
            Console.WriteLine(Calculator.Add("151.3", null));
            Console.WriteLine(Calculator.Add("100", "999999999999999"));

            int[] a = { 1, 2, 3, 4, 5 };
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            IEnumerator enumerator_int = a.GetEnumerator();
            while (enumerator_int.MoveNext())
            {
                Console.WriteLine(enumerator_int.Current);
            }
        }

        public void input_double()
        {
            string s = Console.ReadLine();
            double d;
            if (double.TryParse(s, out d))
            {
                Console.WriteLine(d);
            }
            else
            {
                Console.WriteLine("not a number");
            }
        }

        public void block_statement()
        {
            {
                {
                hello:
                    {
                        Console.WriteLine("hello");
                        Console.WriteLine("world");
                    }
                    //goto hello;
                }
            }

            int? a = 100;
            switch (a)
            {
                case 10:
                    if (a == 100)
                    {
                        goto case 9;
                    }
                    else
                    {
                        goto default;
                    }
                case 9:
                    Console.WriteLine("A");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Form form = sender as Form;
            if(form != null)
            {
                form.Text = "hello";
            }
        }
    }

    class Calculator
    {
        static public int Add(string s1, string s2)
        {
            int a = 0, b = 0;
            bool hasError = false;
            try
            {
                a = int.Parse(s1);
                b = int.Parse(s2);
            }
            catch(ArgumentNullException)
            {
                hasError = true;
                Console.WriteLine("Argument null error!");
            }
            catch (FormatException)
            {
                hasError = true;
                Console.WriteLine("Format error!");
            }
            catch (OverflowException)
            {
                hasError = true;
                Console.WriteLine("Out of range!");
            }
            finally
            {
                Console.Write("error result:");
            }
            int result = checked(a + b);
            return a + b;
        }
    }
}
