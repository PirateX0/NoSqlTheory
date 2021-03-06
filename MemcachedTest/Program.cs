﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace MemcachedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MemcachedClientConfiguration mcConfig = new MemcachedClientConfiguration();
            mcConfig.AddServer("127.0.0.1:11211");//必须指定端口
            using (MemcachedClient client = new MemcachedClient(mcConfig))
            {
                //client.Store(Enyim.Caching.Memcached.StoreMode.Set, "name", "yzk");
                //string name=(string) client.Get("name");

                //client.Store(Enyim.Caching.Memcached.StoreMode.Set, "p1", new Person { Name="dalong",Age=18});

                //Person person=(Person) client.Get("p1");

                //Console.WriteLine(person.Name+","+person.Age);

                var cas = client.GetWithCas("name");
                Console.WriteLine("按任意键继续");
                Console.ReadKey();
                var res = client.Cas(Enyim.Caching.Memcached.StoreMode.Set, "name", cas.Result + "1",
                cas.Cas);
                if (res.Result)
                {
                    Console.WriteLine("修改成功"+cas.Result);
                }
                else
                {
                    Console.WriteLine("被别人改了" + cas.Result);
                }


            }

            Console.ReadKey();
        }
    }

    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
