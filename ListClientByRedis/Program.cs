using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListClientByRedis
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                while (true)
                {
                     string email = db.ListRightPop("www_register_emails");
                    if (email != null)
                    {
                        Console.WriteLine("开始发送email给：" + email);
                        Thread.Sleep(3000);
                        Console.WriteLine("完成发送email给：" + email);
                        continue;
                    }
                    Console.WriteLine("无邮件可以发送");
                    Thread.Sleep(3000);
                }
                
            }
        }
    }
}
