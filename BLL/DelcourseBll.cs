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
    public class DelcourseBll
    {
        public DelcourseBll() { }
        public bool deletecour(string str)
        {
            string sql = string.Format("delete from [Classes] where Cpath=\'"+ str + "\'");
            DBOperator dbo = new DBOperator();
            return dbo.ExecuteInsertOrUpdateSql(sql);
        }
    }
}