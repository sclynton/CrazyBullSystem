using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedTime { get; set; }
    }
    public class BaseEntity : BaseEntity<int>
    {
        
    }
}
