using Dora.Interception;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyBull.Util.Exceptions;

namespace CrazyBull.Util.Validations
{
    public class ValidationInterceptor
    {
        private InterceptDelegate _next;
        public ValidationInterceptor(InterceptDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(InvocationContext context, IValidation validation)
        {
            var inputParameters = context.Method.GetParameters();
            for (int i=0;i< inputParameters.Length; i++)
            {
                if (inputParameters[i].IsIn && inputParameters[i].Name.EndsWith("InputDto"))
                {
                    var result = validation.Validate(context.Arguments[i]);
                    if (!result.IsValid)
                    {
                        throw new ValidationException(result.First().ErrorMessage);
                    }
                }
            }
            await _next(context);
        }
    }
}
