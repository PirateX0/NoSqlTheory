using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListServerByRedis.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.Result = "get";
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Register(string email)
        {
            ViewBag.Result = "ok";
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数字访问不同的数据库
                db.ListLeftPush("www_register_emails", email);
            }
            return View();
        }
    }
}