using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze.Shared.Common
{
    public class UriHelper
    {
        public static string GetUrlParameterValue(string url, string parameter) 
        {
            if(string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }
            var index = url.IndexOf("?");
            //判断是否携带参数
            if (index > -1) 
            {
                //为了去掉问号
                index++;
                //截取 参数部分
                var targetUrl = url.Substring(index,url.Length-index);
                //按‘&’分成N个数组
                string[] Param = targetUrl.Split('&');
                //循环匹配
                foreach (var parm in Param)
                {
                    //再按等号分组
                    var values = parm.Split('=');
                    //统一按小写 去匹配
                    if (values[0].ToLower().Equals(parameter.ToLower())) 
                    {
                        //返回匹配成功的值
                        return values[1];
                    }
                }
            }
            return null;
        }
    }
}
