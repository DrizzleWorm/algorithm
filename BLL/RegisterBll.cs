using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using algorithmclass.DAL;
using System.Data;
using algorithmclass.Model;

namespace algorithmclass.BLL
{
    public class RegisterBll
    {
        public RegisterBll() { }
        //public bool registerSys(string uname, string upass, string urole, string uphone, string uemail, string udepartment)
        //{
        //    //读取插入数据后的表格，所有变量首字母小写
        //    //string sql = string.Format("insert into [User] (Uname, Upassword, Urole, Uphone, Uemail, Udept) values ('{0}','{1}', {2}, '{3}', '{4}', '{5}')", uname, upass, urole, uphone, uemail, udepartment);
        //    //DBOperator dbo = new DBOperator();
        //    //return dbo.ExecuteInsertOrUpdateSql(sql);
        //}
        public bool register(User user)
        {
            string sql = string.Format("insert into [User] (Uname, Upassword, Urole, Uphone, Uemail, Udept) values ('{0}','{1}', {2}, '{3}', '{4}', '{5}')", user.Uname, user.Upassword, user.Urole, user.Uphone, user.Uemail, user.Udept);
            DBOperator dbo = new DBOperator();
            return dbo.ExecuteInsertOrUpdateSql(sql);
        }
        //public int count()
        //{
        //    DBOperator dbo = new DBOperator();
        //    DataTable dt = new DataTable();
        //    dt = dbo.GetTable("select * from [User]");
        //    int rows = dt.Rows.Count;
        //    return rows;
        //}
        public string select()
        {
            DBOperator dbo = new DBOperator();
            DataTable dt = new DataTable();
            dt = dbo.GetTable("select * from [User]");
            string json = ConvertJson.ToJson(dt);
            
            //int l = json.Length;
            //int a = l;
            return json;
        }
    }
}