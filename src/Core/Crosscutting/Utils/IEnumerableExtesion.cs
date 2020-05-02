using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamEye.Core.Crosscutting.Utils
{
    public static class IEnumerableExtesion
    {
        public static string ElementAtOneBased(this IEnumerable<string> value, int index)
        {
            return value.ElementAt(index - 1).ToString();
        }
    }
}
