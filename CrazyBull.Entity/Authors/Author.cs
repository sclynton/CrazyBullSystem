using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core.Author
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Sex { get; set; }
    }
}
