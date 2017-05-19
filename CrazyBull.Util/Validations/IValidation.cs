using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Util.Validations
{
    public interface IValidation
    {
        ValidationResultCollection Validate(object target);
    }
}
