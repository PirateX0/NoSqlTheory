using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedisSortedSetDemo.Models;

namespace RedisSortedSetDemo.Controllers
{
    public class SearchController : Controller
    {
        string key = "www_serach_hotWords";

        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {
            return View(GetSortedSetEntries());
        }

        [HttpPost]
        public ActionResult Search(string searchWord)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                db.SortedSetIncrement(key, searchWord, 1);
            }
            return Redirect("~/Search/Index");
        }

        SortedSetEntry[] GetSortedSetEntries()
        {
            SortedSetEntry[] hotWords = null;
            hotWords = (SortedSetEntry[])HttpContext.Cache[key];
            if (hotWords==null)
            {
                using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
                {
                    IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                    hotWords = db.SortedSetRangeByRankWithScores(key, 0, -1, Order.Descending);
                    HttpContext.Cache.Insert(key,hotWords,null,DateTime.Now.AddMinutes(5),TimeSpan.Zero);
                }
            }
            return hotWords;
        }
    }
}