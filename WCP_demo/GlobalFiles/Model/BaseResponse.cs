using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCP_demo
{
    public class BaseResponse
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        public string errorMessage { get; set; } = "未知错误";

        /// <summary>
        /// 错误代码
        /// </summary>
        public int errorCode { get; set; } = -1;

        /// <summary>
        /// 是否请求成功
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 数据对象
        /// </summary>
        public object data { get; set; }
    }
}
