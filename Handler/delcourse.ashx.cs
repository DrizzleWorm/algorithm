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
using System.IO;

namespace algorithmclass.Handler
{
    /// <summary>
    /// deletecourse 的摘要说明
    /// </summary>
    public class deletecourse : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "";
            try
            {
                bool flag = false;
                DelcourseBll dc = new DelcourseBll();
                flag=dc.deletecour(Cpath);
                if (flag == true)
                {
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
        public string Cpath
        {
            get
            {
                return HttpContext.Current.Request["Cpath"].ToString();
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