using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core
{
    public class Chapter : BaseEntity
    {
        public string Name { get; set; }
        public bool IsVip { get; set; }
        public int WordCount { get; set; }
        public int BookId { get; set; }
    }
}
