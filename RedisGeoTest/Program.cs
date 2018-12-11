using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisGeoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                //db.GeoAdd("ShopsGeo", new GeoEntry(116.34039, 39.94218, "1"));
                //db.GeoAdd("ShopsGeo", new GeoEntry(116.340934, 39.942221, "2"));
                //db.GeoAdd("ShopsGeo", new GeoEntry(116.341082, 39.941025, "3"));
                //db.GeoAdd("ShopsGeo", new GeoEntry(116.340848, 39.937758, "4"));
                //db.GeoAdd("ShopsGeo", new GeoEntry(116.342982, 39.937325, "5"));
                //db.GeoAdd("ShopsGeo", new GeoEntry(116.340866, 39.936827, "6"));

                //double? dist = db.GeoDistance("ShopsGeo", "1", "5", GeoUnit.Meters);
                //Console.WriteLine(dist);

                //GeoPosition? pos = db.GeoPosition("ShopsGeo", "1");
                //Console.WriteLine(pos.Value.Latitude+","+pos.Value.Longitude);

                //GeoRadiusResult[] results = db.GeoRadius("ShopsGeo", "2", 200, GeoUnit.Meters);//获取”2”这个周边200米范围内的POI
                //foreach (GeoRadiusResult result in results)
                //{
                //    Console.WriteLine("Id=" + result.Member + ",位置" + result.Position + "，距离" + result.Distance);
                //}

                //GeoRadiusResult[] results = db.GeoRadius("ShopsGeo", 116.34092, 39.94223, 200, GeoUnit.Meters);// 获取(116.34092, 39.94223)这个周边200米范围内的POI
                //foreach (GeoRadiusResult result in results)
                //{
                //    Console.WriteLine("Id=" + result.Member + ",位置" + result.Position + "，距离" + result.Distance);
                //}
            }

            Console.WriteLine(Environment.MachineName);

            Console.ReadKey();
        }
    }
}
