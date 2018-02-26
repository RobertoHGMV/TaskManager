using System;
using System.Collections.Generic;

namespace TaskManager.Shared
{
    public interface IVerify
    {
        bool IsNull(object value);

        bool IsNullOrEmpty(string value);

        bool IsInvalidDate(DateTime date);

        bool IsListEmpty(IEnumerable<object> list);
    }
}
