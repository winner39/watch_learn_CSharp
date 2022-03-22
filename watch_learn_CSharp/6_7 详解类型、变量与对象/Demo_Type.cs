using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watch_learn_CSharp
{
    class Demo_Type
    {
        int a;
        public Demo_Type()
        {
            dynamic variable = a;
            Console.WriteLine(variable);
            variable = "Goodbye world";
            Console.WriteLine(variable);

            PropertyInfo[] propertyInfos = typeof(Form).GetProperties(),propertyInfos1 = typeof(Demo_Timer).GetProperties();
            MethodInfo[] methodInfos = typeof(Form).GetMethods(),methodInfos1 = typeof(Demo_Timer).GetMethods();
            foreach(dynamic a in propertyInfos1)
            {
                Console.WriteLine(a);
                /*Console.WriteLine(methodInfos);*/
            }
            Console.WriteLine(typeof(Form).BaseType.FullName);

            List<int> vs = new List<int>();
            for(int i = 0; i < 15000; i++)
            {
                vs.Add(i);
            }
            vs.Clear();//系统并不会立即释放该内存
        }
    }
}
