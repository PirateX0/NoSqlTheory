using ClickCountByRedis.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClickCountByRedis.Controllers
{
    public class NewsController : Controller
    {
        private static string XinWen_Prefix = "WWW_XinWen_";

        // GET: News
        public ActionResult Index(int id)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问db0 数据库，可以通过方法参数指定数字访问不同的数据库

                //db.StringIncrementAsync(XinWen_Prefix + "XWClickCount" + id, 1);

                //以ip 地址和文章id 为key
                string hasClickKey = XinWen_Prefix + Request.UserHostAddress + "_" + id;
                //如果之前这个ip 给这个文章贡献过点击量，则不重复计算点击量
                if (db.KeyExists(hasClickKey) == false)
                {
                    db.StringIncrementAsync(XinWen_Prefix + "XWClickCount" + id, 1);
                    //记录一下这个ip 给这个文章贡献过点击量，有效期一天
                    db.StringSet(hasClickKey, "a", TimeSpan.FromDays(1));
                }

                RedisValue clickCount = db.StringGet(XinWen_Prefix + "XWClickCount" + id);
                News model = new News();
                model.Title = id.ToString();
                model.ClickCount = Convert.ToInt32(clickCount);
                return View(model);
            }
        }
    }
}