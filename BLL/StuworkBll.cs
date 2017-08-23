using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.DAL;
using System.Data;
using algorithmclass.Model;

namespace algorithmclass.BLL
{
    public class StuworkBll
    {
        public StuworkBll(){ }
        public string select()
        {
            DBOperator dbo = new DBOperator();
            DataTable dt = new DataTable();
            dt = dbo.GetTable("select S_name,Tname,Stitle,Spath from [Student],[Teacher],[Studentwork] where Student.S_Uname=Studentwork.S_SUname and Teacher.TUname=Studentwork.S_TUname");
            string json = ConvertJson.ToJson(dt);
            return json;
        }
    }
}