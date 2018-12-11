using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisSortedSetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                db.SortedSetIncrement("Hotwords", "如鹏网", 1);
                db.SortedSetIncrement("Hotwords", "如鹏网", 1);
                db.SortedSetIncrement("Hotwords", "如鹏网", 1);
                db.SortedSetIncrement("Hotwords", "杨中科", 1);
                db.SortedSetIncrement("Hotwords", "侯宝林", 1);
                db.SortedSetIncrement("Hotwords", "侯宝林", 1);
                SortedSetEntry[] items = db.SortedSetRangeByRankWithScores("Hotwords",0,1,Order.Descending);
                
                foreach (var item in items)
                {
                    Console.WriteLine(item.Element + "=" + item.Score);
                }
            }
            Console.Read();
        }
    }
}
