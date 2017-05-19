using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CrazyBull.Util.Validations
{
    /// <summary>
    /// 自己实现的验证类，本来是用微软企业库来实现的，但是暂时不支持.net core
    /// 自定义实现的性能没有微软的好
    /// </summary>
    public class Validation : IValidation
    {
        private object _target;
        private readonly ValidationResultCollection _results;

        public Validation()
        {
            _results = new ValidationResultCollection();
        }
        public ValidationResultCollection Validate(object target)
        {
            if (target is null) return _results;
            _target = target;
            Type type = target.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
                ValidateProperty(property);
            return _results;
        }

        private void ValidateProperty(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(ValidationAttribute), true);
            foreach (var attribute in attributes)
            {
                var validationAttribute = attribute as ValidationAttribute;
                if (attribute == null)
                    continue;
                ValidateAttribute(property, validationAttribute);
            }
        }

        private void ValidateAttribute(PropertyInfo property, ValidationAttribute attribute)
        {
            bool isValid = attribute.IsValid(property.GetValue(_target));
            if (isValid)
                return;
            _results.Add(new ValidationResult(GetErrorMessage(attribute)));
        }

        private string GetErrorMessage(ValidationAttribute attribute)
        {
            if (!string.IsNullOrEmpty(attribute.ErrorMessage))
                return attribute.ErrorMessage;
            return string.Concat("没有设置错误消息：",attribute.ErrorMessageResourceName);
        }
    }
}
