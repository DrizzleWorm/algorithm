using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.BLL;
using algorithmclass.Model;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;


namespace algorithmclass.Handler
{
    /// <summary>
    /// classInfo 的摘要说明
    /// </summary>
    public class classInfo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "";
            try
            {
                if (context.Session["username"]==null)
                {
                    msg = "-1";
                    context.Response.Write(msg);
                    context.Response.End();
                    //context.Response.Write(msg);
                }
                else
                {
                    msg = "1";
                }
            }
            catch
            {
                msg = "88";
            }
            context.Response.Write(msg);
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