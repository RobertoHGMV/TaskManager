using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Shared
{
    public class Verify : IVerify
    {
        public bool IsNull(object value) => value == null;

        public bool IsNullOrEmpty(string value) => string.IsNullOrEmpty(value);

        public bool IsInvalidDate(DateTime date) => IsNull(date) || date <= DateTime.MinValue || date >= DateTime.MaxValue;

        public bool IsListEmpty(IEnumerable<object> list) => IsNull(list) || !list.Any();
    }
}
