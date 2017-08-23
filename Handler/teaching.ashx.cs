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
    /// teaching 的摘要说明
    /// </summary>
    public class teaching : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "";
            try
            {
                bool flag = false;
                HttpPostedFile upload = HttpContext.Current.Request.Files["inputfile"];
                string uploadFileName = upload.FileName;
                if (uploadFileName.Contains("\\"))      //如果获取的是路径（浏览器设置的不同），则截取文件名
                {
                    uploadFileName = uploadFileName.Substring(uploadFileName.LastIndexOf("\\") + 1);
                }
                string saveuploadPath =System.Web.HttpContext.Current.Server.MapPath("~/Docs/" + uploadFileName);//文件要上传到服务器的路径
                FileInfo uploadFile = new FileInfo(saveuploadPath);
                if (uploadFile.Exists)
                {
                    uploadFile.Delete();
                }
                upload.SaveAs(saveuploadPath);//相当于从本地上把要上传的文件下载到服务器
                Classes cl = new Classes();
                cl.Cname = uploadFileName;
                cl.Cpath = "../Docs/" + uploadFileName;
                FileUploadBll fb = new FileUploadBll();
                flag = fb.FileUpload(cl);
                if (flag == true)
                {
                    //context.Session["username"] = um.Uname;//保存UserNum 
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
        
        public string fileName
        {
            get
            {
                return HttpContext.Current.Request["fileName"].ToString();
            }
        }
        public string filePath
        {
            get
            {
                return HttpContext.Current.Request["filePath"].ToString();
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