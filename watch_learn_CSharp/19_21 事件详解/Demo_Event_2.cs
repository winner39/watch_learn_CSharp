using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace watch_learn_CSharp
{
    class Demo_Event_2
    {
        public void test()
        {
            Form form = new Form();
            Controller controller = new Controller(form);
            form.Register_ClickEvent();
            form.ShowDialog();

            MyForm myForm = new MyForm();
            myForm.Click += myForm.FormClicked;
            myForm.ShowDialog();
        }

    }

    class Controller
    {
        private Form form;
        public Controller(Form form)
        {
            this.form = form;
            form.Click += Form_Click;
        }

        private void Form_Click(object sender, EventArgs e)
        {
            form.Text = DateTime.Now.ToString();

        }
    }

    static class Form_Controller
    {
        public static void Register_ClickEvent(this Form form)
        {
            form.Click += Form_Click;
        }

        private static void Form_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Form_Controller");
        }
    }

    class MyForm : Form
    {
        private TextBox textBox;
        private Button button1;
        private Button button2;
        public MyForm()
        {
            textBox = new TextBox();
            textBox.Width = 250;
            textBox.Location = new System.Drawing.Point(20, 20);

            button1 = new Button();
            button1.Top = textBox.Location.Y + textBox.Height;
            button1.Left = textBox.Location.X;
            button1.Click += (sender, e) =>
            {
                textBox.Text = "Click button at:";
            };
            button1.Click += this.FormClicked;

            button2 = new Button();
            button2.Top = button1.Top;
            button2.Left = button1.Width + button1.Location.X;
            button2.Click += this.FormClicked;

            this.Controls.Add(textBox);
            this.Controls.Add(button1);
            this.Controls.Add(button2);
        }


        internal void FormClicked(object sender ,EventArgs e)
        {
            if(sender == button1)
            {
                textBox.Text += DateTime.Now.ToString();
            }
            else
            {
                textBox.Text = "Click Button2";
            }
        }
    }
}
