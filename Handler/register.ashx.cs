using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.BLL;
using algorithmclass.Model;

namespace algorithmclass.Handler
{
    /// <summary>
    /// register 的摘要说明
    /// </summary>
    public class register : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            RegisterBll rb = new RegisterBll();
            bool flag = false;
            User user = new User();
            string str = "";
            switch (action)
            {
                case "register":
                    //flag = rb.registerSys(Uname, Upass, Urole, Uphone, Uemail, Udepartment);
                    user.Uname = Uname;
                    user.Upassword = Upass;
                    user.Urole = Convert.ToInt16(Urole);
                    user.Uphone = Uphone;
                    user.Uemail = Uemail;
                    user.Udept = Udepartment;
                    flag = rb.register(user);
                    context.Response.Write(flag.ToString());
                    break;
                case "select":
                    str = rb.select();
                    context.Response.Write(str);
                    break;
                default: break;
            }
        }

        public string Uname
        {
            get
            {
                return HttpContext.Current.Request["Uname"].ToString();
            }
        }
        public string Upass
        {
            get
            {
                return HttpContext.Current.Request["Upass"].ToString();
            }
        }
        public string Urole
        {
            get
            {
                return HttpContext.Current.Request["Urole"].ToString();
            }
        }
        public string Uphone
        {
            get
            {
                return HttpContext.Current.Request["Uphone"].ToString();
            }
        }
        public string Uemail
        {
            get
            {
                return HttpContext.Current.Request["Uemail"].ToString();
            }
        }
        public string Udepartment
        {
            get
            {
                return HttpContext.Current.Request["Udepartment"].ToString();
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