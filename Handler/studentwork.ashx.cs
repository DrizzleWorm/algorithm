using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.BLL;
using algorithmclass.Model;

namespace algorithmclass.Handler
{
    /// <summary>
    /// studentwork 的摘要说明
    /// </summary>
    public class studentwork : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StuworkBll sb = new StuworkBll();
            string stuworkList = "";
            switch (action)
            {
                case "select":
                    stuworkList = sb.select();
                    context.Response.Write(stuworkList);
                    break;
                default: break;
            }
        }
        public string action
        {
            get
            {
                return HttpContext.Current.Request["action"].ToString();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}