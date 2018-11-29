using System;
using System.Collections.Generic;
using System.Text;

namespace WCP_demo
{
    public static class StringAttribute
    {
        public static int GetCode(this string code)
        {
            var Errorcode = 10000;
            if (!string.IsNullOrWhiteSpace(code))
            {
                Errorcode = int.Parse(code.Substring(1));
            }
            return Errorcode;
        }
    }
}
