using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.BLL;
using algorithmclass.Model;

namespace algorithmclass.Handler
{
    /// <summary>
    /// classes 的摘要说明
    /// </summary>
    public class classes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ClassesBll cb = new ClassesBll();
            //Classes course = new Classes();
            string courseList = "";
            switch (action)
            {
                case "select":
                    courseList = cb.select();
                    context.Response.Write(courseList);
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