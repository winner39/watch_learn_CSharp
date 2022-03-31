using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watch_learn_CSharp
{
    class Student
    {
        public int a;
        public int b;
        public Student(int a,int b)
        {
            this.a = a;
            this.b = b;
        }
    }
    class Demo_Type
    {
        int a;
        public Demo_Type()
        {
            dynamic variable = 10;
            Console.WriteLine(variable);
            variable = "Goodbye world";
            Console.WriteLine(variable);

            PropertyInfo[] propertyInfos = typeof(Form).GetProperties(),propertyInfos1 = typeof(Demo_Timer).GetProperties();
            MethodInfo[] methodInfos = typeof(Form).GetMethods(),methodInfos1 = typeof(Demo_Timer).GetMethods();
            foreach(dynamic p in propertyInfos1)
            {
                Console.WriteLine(p);
                /*Console.WriteLine(methodInfos);*/
            }
            Console.WriteLine(typeof(Form).BaseType.FullName);

            /*List<int> vs = new List<int>();
            for(int i = 0; i < 15000; i++)
            {
                vs.Add(i);
            }
            vs.Clear();//系统并不会立即释放该内存*/

            Student a = new Student(3,4);
            Student b = a;
            b.a = 100;//引用变量
            Console.WriteLine(a.a);

            int x = 100;
            object obj = x;//对于存储在栈区的局部变量，obj进行深拷贝，存储到堆区
            int y = (int)obj;
            y = 101;
            x = 105;//因此改变x的值对于深拷贝的obj不会有影响
            
            Console.WriteLine(y);//y依然为101
            Console.WriteLine((int)obj);//obj依然为100，说明y和obj不是同一个对象
        }
    }
}
