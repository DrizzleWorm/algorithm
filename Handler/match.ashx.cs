using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.BLL;
using algorithmclass.Model;

namespace algorithmclass.Handler
{
    /// <summary>
    /// match 的摘要说明
    /// </summary>
    public class match : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            MatchBll mb = new MatchBll();
            string matchList = "";
            switch (action)
            {
                case "select":
                    matchList = mb.select();
                    context.Response.Write(matchList);
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