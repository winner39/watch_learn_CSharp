using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watch_learn_CSharp
{
    class Demo_Timer
    {
        public static int alarmCounter = 1;
        public static Timer timer = new Timer();
        static bool exitFlag = false;
        static Form form = new Form();
        public int a;
        public Demo_Timer()
        {
            a = 0;

            Button button = new Button();
            button.Text = "OK";
            button.Location = new Point(20, 20);
            button.Click += (sender, e) =>
            {
                Console.WriteLine("!");
            };
            button.Click += (sender, e) =>
            {
                Console.WriteLine("!!");
            };//可以叠层数
            Button button1 = new Button();
            button1.Text = "Cancel";
            button1.Location = new Point(button.Location.X + button.Size.Width, button.Location.Y + button.Size.Height);
            button1.Click += Button1_Click;

            form.Text = "";
            form.Controls.Add(button);
            form.Controls.Add(button1);
            form.HelpButton = true;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.Show();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            while (!exitFlag)
            {
                // Processes all the events in the queue.
                Application.DoEvents();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("?");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            // Displays a message box asking whether to continue running the timer.
            if (MessageBox.Show("Continue running?", "Count is: " + alarmCounter,
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Restarts the timer and increments the counter.
                timer.Start();
                form.Text = DateTime.Now.ToString();
                alarmCounter += 1;
                timer.Enabled = true;
            }
            else
            {
                // Stops the timer.
                /*exitFlag = true;*/
            }
        }
    }
}
