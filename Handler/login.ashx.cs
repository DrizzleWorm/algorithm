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
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "";
            try
            {
                LoginBll lb = new LoginBll();
                bool flag = false;
                User um = new User();
                um.Uname = username;
                um.Upassword = password;
                flag = lb.loginSys(username, password);
                if (flag == true)
                {
                    context.Session["username"] = um.Uname;//保存UserNum 
                    msg = "1";
                }
                else
                {
                    msg = "0";
                }
            }
            catch
            {
                msg = "88";
            }
            context.Response.Write(msg);
        }

        public string username
        {
            get
            {
                return HttpContext.Current.Request["username"].ToString();
            }
        }
        public string password
        {
            get
            {
                return HttpContext.Current.Request["password"].ToString();
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