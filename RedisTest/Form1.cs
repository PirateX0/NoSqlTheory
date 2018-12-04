using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedisTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKey.Text)||string.IsNullOrWhiteSpace(txtValue.Text))
            {
                MessageBox.Show("key or value can't be null.");
            }
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                db.StringSet(txtKey.Text, txtValue.Text);
                MessageBox.Show("set successfully.");
            }

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("key or value can't be null.");
            }
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                txtValue.Text=db.StringGet(txtKey.Text);
            }
        }
    }
}
