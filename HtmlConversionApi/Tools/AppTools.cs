using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConversionApi.Tools
{
    public class AppTools
    {
        /// <summary>
        /// 获取网络请求中的请求体内容，并转换为对应的实体类
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="context">请求上下文</param>
        /// <returns></returns>
        public static T GetRequestBodyEntity<T>(HttpContext context)
        {
            string content = GetRequestBodyString(context);
            if (!string.IsNullOrEmpty(content))
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(content);
                }
                catch (Exception)
                {
                }
            }
            return default(T);
        }

        /// <summary>
        /// 获取网络请求中的请求体内容
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <returns></returns>
        public static string GetRequestBodyString(HttpContext context)
        {
            var stream = context.Request.Body;
            byte[] buffer = new byte[context.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string content = Encoding.UTF8.GetString(buffer);
            return content;
        }
    }
}
