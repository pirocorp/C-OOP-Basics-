namespace Document_System
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;

    public static class StringExtensions
    {
        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
    }
}