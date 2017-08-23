using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.DAL;
using System.Data;

namespace algorithmclass.BLL
{
    public class LoginBll
    {
        public bool loginSys(string userName, string Password)
        {
            string sql = string.Format("select * from [User] where Uname='{0}' and Upassword='{1}'",userName,Password);
            DBOperator dbo = new DBOperator();
            DataTable dt = new DataTable();
            dt = dbo.GetTable(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}