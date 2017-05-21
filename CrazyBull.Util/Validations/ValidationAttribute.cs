using Dora.Interception;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBull.Util.Validations
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class|AttributeTargets.Interface)]
    public class ValidationAttribute : InterceptorAttribute
    {
        public override void Use(IInterceptorChainBuilder builder)
        {
            builder.Use<ValidationInterceptor>(this.Order);
        }
    }
}
