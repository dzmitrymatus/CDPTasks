using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests.Infrastructure
{
    public static class Helpers
    {
        public static string ToDoubleString(this string value)
        {
            if(value.Contains("."))
            {
                return value;
            }
            else
            {
                return $"{value}.0";
            }
        }
    }
}
