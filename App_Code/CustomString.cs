using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extension
{
    public static class MyExtensions
    {
        public static string ReplaceQuote(this String str)
        {
            return str.Replace("'", "''");
        }
    }
}