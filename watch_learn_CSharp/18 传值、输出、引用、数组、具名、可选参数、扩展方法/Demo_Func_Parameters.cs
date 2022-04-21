using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_Func_Parameters
    {
        public void test()
        {
            int x = 10;
            ChangeInt(ref x);
            Demo_18_Student demo_18_Student = new Demo_18_Student();
            Console.WriteLine(demo_18_Student.Age);//10
            ChangeStudent_ref(ref demo_18_Student);
            Console.WriteLine(demo_18_Student.Age);//15
            ChangeStudent(demo_18_Student);
            Console.WriteLine(demo_18_Student.Age);//15

            double d = 10;
            d.Add();//扩展方法

            int a = 10, b = 20, c = 30;
            try
            {
                b = 30;
                c = 40;
                a = int.Parse("123.5");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(b);
            Console.WriteLine(c);

            Demo_Params.test();
        }
        static void ChangeInt(ref int x)
        {
            x++;
        }
        static void ChangeStudent_ref(ref Demo_18_Student demo_18_Student)
        {
            demo_18_Student = new Demo_18_Student(15);
            Console.WriteLine(demo_18_Student.Age);//15
        }
        static void ChangeStudent(Demo_18_Student demo_18_Student)
        {
            demo_18_Student = new Demo_18_Student(20);
            Console.WriteLine(demo_18_Student.Age);//20
        }
        static void alternative_params(int a=10,int b=20)
        {
            
        }
    }

    static class Extensive_Function
    {
        public static double Add(this double a)
        {
            return a++;
        }
    }

    class Demo_18_Student
    {
        private int age=10;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Demo_18_Student(int a)
        {
            Age = a;
        }
        public Demo_18_Student(){ }
    }

    class Demo_Params
    {
        public static void test()
        {
            int result = CalculateSum(1, 2, 3);
            Console.WriteLine(result);
        }

        static int CalculateSum(params int[] intArray)//必须作为最后一个参数
        {
            int sum = 0;
            foreach (var item in intArray)
            {
                sum += item;
            }

            return sum;
        }
    }
    
}
