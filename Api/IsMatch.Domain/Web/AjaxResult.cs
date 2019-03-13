using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsMatch.Domain.Web
{
    /// <summary>Ajax返回结果</summary>
    /// <typeparam name="T"></typeparam>
    public class AjaxResult<T>
    {
        /// <summary>状态 1表示成功 0表示失败</summary>
        public int Status { get; set; }

        /// <summary>数据</summary>
        public T Data { get; set; }

        /// <summary>信息</summary>
        public string Message { get; set; }

    }
    /// <summary>Ajax返回结果</summary>
    public class AjaxResult : AjaxResult<Object> { }
}