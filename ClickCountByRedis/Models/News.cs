using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClickCountByRedis.Models
{
    public class News
    {
        public int ClickCount { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}