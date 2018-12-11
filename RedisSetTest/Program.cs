using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisSetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                //增加元素
                db.SetAdd("Name", "abc");
                db.SetAdd("Name", "abc");
                db.SetAdd("Name", "a");
                db.SetAdd("Name", "b");
                db.SetAdd("Name", "c");
                //元素个数
                Console.WriteLine(db.SetLength("Name"));
                //是否存在
                Console.WriteLine(db.SetContains("Name","abc"));
                Console.WriteLine(db.SetContains("Name", "a"));
                Console.WriteLine(db.SetContains("Name", "d"));
                //遍历元素
                foreach (var item in db.SetMembers("Name"))
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }
    }
}
