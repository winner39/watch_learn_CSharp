using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace watch_learn_CSharp
{
    delegate void OrderEventHandler(Customer customer, OrderEventArgs e);
    delegate void PayBillEventHandler(Waiter waiter, PayBillEventArgs e);
    class Demo_Event_3
    {
        public void test()
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter("waiter1");
            Waiter waiter2 = new Waiter("waiter2");
            customer.orderEventHandler += waiter.Action;
            customer.Order += waiter2.Action;//这种情况只能用"+="
            customer.Simple_Order += waiter.Action;
            waiter.Kick += customer.PaytheBill;
            customer.Action();
        }
    }
    
    class Customer
    {
        public OrderEventHandler orderEventHandler;//订阅者
        public event OrderEventHandler Order//把这个想象成字段就好理解了(但事件绝不是字段，作用类似属性)
        {
            add
            {
                this.orderEventHandler += value;
            }
            remove
            {
                this.orderEventHandler -= value;
            }
        }

        public event OrderEventHandler Simple_Order;//语法糖

        public double bill { get; set; }
        public void PaytheBill(Waiter waiter, PayBillEventArgs e)
        {
            Console.WriteLine("Customer:I will pay {0} for my bill.", bill);
            Console.WriteLine("Customer:Okay,{0} go!", e.customerName);
        }
        public void WalkIn()
        {
            Console.WriteLine("Customer:Walk into the restaurant.");
        }
        public void SitDown()
        {
            Console.WriteLine("Customer:Sit down.");
        }
        public void Think()
        {
            Console.WriteLine("Customer:Let me think");
            Thread.Sleep(2000);

            if(orderEventHandler != null)
            {
                OnOrder("kongpaochicken", "large");
            }
            if(Simple_Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "manhanquanxi";
                e.Size = "large";
                this.Simple_Order.Invoke(this, e);
            }
        }
        public void Action()
        {
            Console.ReadLine();
            WalkIn();
            SitDown();
            Think();
        }

        protected void OnOrder(string dishName,string size)
        {
            OrderEventArgs e = new OrderEventArgs();
            e.DishName = dishName;
            e.Size = size;
            this.orderEventHandler.Invoke(this, e);
        }
    }

    class OrderEventArgs:EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }
    class PayBillEventArgs
    {
        public string customerName { get; set; }
    }

    class Waiter
    {
        private PayBillEventHandler payBillEventHandler;
        public event PayBillEventHandler Kick
        {
            add
            {
                payBillEventHandler += value;
            }
            remove
            {
                payBillEventHandler -= value;
            }
        }
        public Waiter(string name)
        {
            this.name = name;
        }

        public string name { get; set; }

        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("{0}:I will serve you {1}", name, e.DishName);
            double price = 10d;
            switch (e.Size)
            {
                case "small":
                    price *= 0.5;
                    break;
                case "large":
                    price *= 1.5;
                    break;
                default:
                    break;
            }
            customer.bill += price;
            OnPayBill("Mr.Okay");
        }
        protected void OnPayBill(string customerName)
        {
            PayBillEventArgs payBillEventArgs = new PayBillEventArgs();
            payBillEventArgs.customerName = customerName;
            Console.WriteLine("{0}:Somebody should go!", name);
            if (payBillEventHandler != null)
            {
                payBillEventHandler.Invoke(this, payBillEventArgs);
            }
        }
    }
}
