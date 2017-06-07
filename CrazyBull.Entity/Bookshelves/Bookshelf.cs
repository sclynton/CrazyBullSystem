using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core.Bookshelves
{
    public class Bookshelf : BaseEntity
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }
    }
}
