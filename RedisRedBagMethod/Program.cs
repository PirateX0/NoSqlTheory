using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisRedBagMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "6.66";//红包总金额
            int n = 10;//发给几个人
            int m = (int)(Convert.ToDouble(s) * 100);//转换为分
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
                int delta = rand.Next(0, bags[i1] );//生成不高于第i1个红包目前余额一半的随机数
                bags[i1] -= delta;//从第i1个红包减掉delta钱
                bags[i2] += delta;//把钱加到第i2个红包上
            }
            if (bags.Sum() != m)
            {
                throw new Exception("红包总金额不符");
            }

            Console.WriteLine(string.Join(",",bags));
            Console.ReadKey();
        }
    }
}
