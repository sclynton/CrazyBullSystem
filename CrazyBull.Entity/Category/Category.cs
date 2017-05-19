using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
