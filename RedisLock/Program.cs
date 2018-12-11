﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisLock
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisValue token = Environment.MachineName;
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();
                if (db.LockTake("mylock", token, TimeSpan.FromSeconds(10)))//第三个参数为锁超时时间，锁占用最多10秒钟，超过10秒钟如果还没有LockRelease，则也自动释放锁，避免了死锁
                {
                    try
                    {
                        Console.WriteLine("操作中");
                        Thread.Sleep(3000);
                        Console.WriteLine("操作完成");
                    }
                    finally
                    {
                        db.LockRelease("mylock", token);
                    }
                }
                else
                {
                    Console.WriteLine("获得锁失败");
                }
            }
            Console.ReadKey();

        }
    }
}
