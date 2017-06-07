using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core.Comments
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int BookId { get; set; }
    }
}
