using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetMemoryCache
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemoryCache.Default.Add("age", 18, DateTimeOffset.Now.AddMinutes(1));
            MemoryCache.Default.Add("name", "dalong", DateTimeOffset.Now.AddMinutes(1));
            MessageBox.Show("set successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int age = 0;
            string name = null;
            if (MemoryCache.Default.Contains("name"))
            {
                 age = (int)MemoryCache.Default["age"];
                name = (string)MemoryCache.Default["name"];
            }
            MessageBox.Show(name+":"+ age.ToString());
        }
    }
}
