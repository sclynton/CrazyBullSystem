using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrazyBull.Util
{
    /// <summary>
    /// 验证结果集合
    /// </summary>
    public class ValidationResultCollection : IEnumerable<ValidationResult>
    {
        /// <summary>
        /// 验证结果
        /// </summary>
        private readonly List<ValidationResult> _results;
        public ValidationResultCollection()
        {
            _results = new List<ValidationResult>();
        }
        public bool IsValid {
            get { return _results.Count == 0; }
        }
        public int Count {
            get { return _results.Count; }
        }
        /// <summary>
        /// 添加验证结果
        /// </summary>
        /// <param name="result"></param>
        public void Add(ValidationResult result)
        {
            if (result == null)
                return;
            _results.Add(result);
        }
        /// <summary>
        /// 添加验证结果集合
        /// </summary>
        /// <param name="results"></param>
        public void AddResults(IEnumerable<ValidationResult> results)
        {
            if (results == null) return;
            foreach (var result in results)
                Add(result);
        }
        public IEnumerator<ValidationResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
}
