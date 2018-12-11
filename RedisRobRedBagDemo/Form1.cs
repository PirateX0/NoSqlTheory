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

namespace RedisRobRedBagDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] bags = GetRedBags(textBox1.Text,Convert.ToInt32(textBox2.Text));
            foreach (var bag in bags)
            {
                double bagExact = ((double)bag) / 100;
                listView1.Items.Add(bagExact.ToString());
            }
            double sumExact = ((double)bags.Sum()) / 100;
            textBox3.Text = sumExact.ToString();

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                foreach (var bag in bags)
                {
                    double bagExact = ((double)bag) / 100;
                    db.ListLeftPush("RedBag", bagExact.ToString());
                }
                
            }
        }

        int[] GetRedBags(string total, int num)
        {
            int n = num;//发给几个人
            int m = (int)(Convert.ToDouble(total) * 100);//转换为分
            int[] bags = new int[n];//n个红包
            int avg = m / n;//算平均值
            for (int i = 0; i < n; i++)
            {
                bags[i] = avg;//先给每个红包平均分配
            }
            Random rand = new Random();

            int leftM = m - avg * n;//平均分配后可能会剩几分钱，随机发给一个人
            bags[rand.Next(0, n)] += leftM;
            for (int i = 0; i < n; i++)
            {
                int i1 = rand.Next(0, n);//随机生成i1、i2两个位置
                int i2 = rand.Next(0, n);
                int delta = rand.Next(0, bags[i1]);//生成不高于第i1个红包目前余额一半的随机数
                bags[i1] -= delta;//从第i1个红包减掉delta钱
                bags[i2] += delta;//把钱加到第i2个红包上
            }
            if (bags.Sum() != m)
            {
                throw new Exception("红包总金额不符");
            }
            return bags;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                var money=db.ListRightPop("RedBag");
                textBox4.Text = money;

            }
        }
    }
}
