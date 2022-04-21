using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    class Demo_Delegate
    {
        public delegate double Func_Double (double x,double y);
        public void test()
        {
            Demo19_Calculator demo19_Calculator = new Demo19_Calculator();
            Action action = new Action(demo19_Calculator.Report);
            action.Invoke();
            action();

            Func<int,int,int> func = new Func<int, int, int>(demo19_Calculator.Add);
            Console.WriteLine(func(1, 1));

            Console.WriteLine(typeof(Action).IsClass);

            Func_Double multi = demo19_Calculator.Mul;
            Console.WriteLine(multi(3, 3));
            Func_Double devide = new Func_Double(demo19_Calculator.Div);//这样更有可读性？？
            Console.WriteLine(devide(3, 1));

            WrapFactory wrapFactory = new WrapFactory();
            ProductFactory productFactory = new ProductFactory();

            Box box1 = wrapFactory.WrapProduct(productFactory.Produce, "apple", Logger.Log);
            Box box2 = wrapFactory.WrapProduct(productFactory, "banana", Logger.Log);
        }
    }

    class Demo19_Calculator
    {
        public void Report()
        {
            Console.WriteLine("I have 3 methods");
        }

        public int Add(int a,int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public double Mul(double a,double b)
        {
            return a * b;
        }

        public double Div(double a,double b)
        {
            return a / b;
        }
    }

    class Product
    {
        public string name { get; set; }
        public double price { get; set; }
    }
    class Box
    {
        public Product product { get; set; }
    }
    class WrapFactory
    {
        public Box WrapProduct(Func<string,Product> getProduct,string productName ,Action<Product> logCallBack)
        {
            Box box = new Box();
            box.product = getProduct.Invoke(productName);
            if(box.product.price > 30)
            {
                logCallBack(box.product);
            }
            return box;
        }

        public Box WrapProduct(IProductFactory productFactory, string productName, Action<Product> logCallBack)
        {
            Box box = new Box();
            box.product = productFactory.Make(productName);
            if (box.product.price > 30)
            {
                logCallBack(box.product);
            }
            return box;
        }
    }
    class ProductFactory:IProductFactory
    {
        public Product Produce(string productName)
        {
            Console.WriteLine("made a " + productName);
            return new Product() { name = productName, price = productName[0] - ' ' };
        }

        public Product Make(string productName)
        {
            return new Product() { name = productName, price = productName[0] - ' ' };
        }
    }

    class Logger
    {
        public static void Log(Product product)
        {
            Console.WriteLine("Product {0} created at {1}.Price is {2}", product.name, DateTime.Now, product.price);
        }
    }

    interface IProductFactory
    {
        Product Make(string name);
    }
}
