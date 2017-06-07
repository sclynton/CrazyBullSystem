using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Core.Customers
{
    public class Customer : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Head { get; set; }
    }
}
