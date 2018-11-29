using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCP_demo
{
    public class GLException : Exception
    {


        public int ErrorCode { get; private set; } = -1;

        public GLException()
        {

        }

        public GLException(string msg) : base(msg)
        {
        }

        public GLException(string msg, int code) : base(msg) { ErrorCode = code; }

        public GLException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
