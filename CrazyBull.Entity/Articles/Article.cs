using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core.Articles
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Publisher { get; set; }
        public bool IsHot { get; set; }
    }
}
