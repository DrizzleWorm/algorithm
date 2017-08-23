using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.DAL;
using System.Data;
using algorithmclass.Model;

namespace algorithmclass.BLL
{
    public class ClassesBll
    {
        public ClassesBll(){ }
        public string select()
        {
            DBOperator dbo = new DBOperator();
            DataTable dt = new DataTable();
            //dt = dbo.GetTable("select Tname,Cname,Cpath from [Teacher],[Classes] where Teacher.TUname=Classes.C_TUname");
            dt = dbo.GetTable("select Cname,Cpath from [Classes]");
            string json = ConvertJson.ToJson(dt);
            return json;
        }
    }
}