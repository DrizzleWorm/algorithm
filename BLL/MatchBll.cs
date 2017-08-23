using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.DAL;
using System.Data;
using algorithmclass.Model;

namespace algorithmclass.BLL
{
    public class MatchBll
    {
        public MatchBll() { }
        public string select()
        {
            DBOperator dbo = new DBOperator();
            DataTable dt = new DataTable();
            dt = dbo.GetTable("select * from [Match] Order by Mtime Desc");
            string json = ConvertJson.ToJson(dt);
            return json;
        }
    }
}