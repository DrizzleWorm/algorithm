using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.DAL;
using System.Data;
using algorithmclass.Model;
using System.Web.UI.HtmlControls;
using System.IO;

namespace algorithmclass.BLL
{
    public class FileUploadBll
    {
        public FileUploadBll() { }
        public bool FileUpload(Classes classes)
        {
            string sql = string.Format("insert into [Classes] (Cname,Cpath) values ('{0}','{1}')", classes.Cname, classes.Cpath);
            DBOperator dbo = new DBOperator();
            return dbo.ExecuteInsertOrUpdateSql(sql);
        }
        //public FileUpload UpLoadFile(HtmlInputFile InputFile, string filePath, string myfileName, bool isRandom)
        //{
        //    FileUpload fp = new FileUpload();
        //    string fileName, fileExtension;
        //    string saveName;
        //    //
        //    //建立上传对象
        //    //
        //    HttpPostedFile postedFile = InputFile.PostedFile;

        //    fileName = System.IO.Path.GetFileName(postedFile.FileName);
        //    fileExtension = System.IO.Path.GetExtension(fileName);

        //    //
        //    //根据类型确定文件格式
        //    //
        //    //AppConfig app = new AppConfig();
        //    //string format = app.GetPath("FileUpLoad/Format");

        //    ////
        //    ////如果格式都不符合则返回
        //    ////
        //    //if (format.IndexOf(fileExtension) == -1)
        //    //{
        //    //    throw new ApplicationException("上传数据格式不合法");
        //    //}

        //    //
        //    //根据日期和随机数生成随机的文件名
        //    //
        //    if (myfileName != string.Empty)
        //    {
        //        fileName = myfileName;
        //    }

        //    if (isRandom)
        //    {
        //        Random objRand = new Random();
        //        System.DateTime date = DateTime.Now;
        //        //生成随机文件名
        //        saveName = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString()+ date.Second.ToString() + Convert.ToString(objRand.Next(99) * 97 + 100);
        //        fileName = saveName + fileExtension;
        //    }

        //    string phyPath = HttpContext.Current.Request.MapPath(filePath);


        //    //判断路径是否存在,若不存在则创建路径
        //    DirectoryInfo upDir = new DirectoryInfo(phyPath);
        //    if (!upDir.Exists)
        //    {
        //        upDir.Create();
        //    }

        //    //
        //    //保存文件
        //    //
        //    try
        //    {
        //        postedFile.SaveAs(phyPath + fileName);
        //        fp.FilePath = filePath + fileName;
        //        fp.FileExtension = fileExtension;
        //        fp.FileName = fileName;
        //    }
        //    catch
        //    {
        //        throw new ApplicationException("上传失败!");
        //    }

        //    //返回上传文件的信息
        //    return fp;
        //}
    }
}