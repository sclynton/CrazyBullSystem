using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Util.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        { }
    }
}
