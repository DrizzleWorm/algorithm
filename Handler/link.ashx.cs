using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.BLL;
using algorithmclass.Model;

namespace algorithmclass.Handler
{
    /// <summary>
    /// link 的摘要说明
    /// </summary>
    public class link : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            LinkBll lb = new LinkBll();
            string linkList = "";
            switch (action)
            {
                case "select":
                    linkList = lb.select();
                    context.Response.Write(linkList);
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