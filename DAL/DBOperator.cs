using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace algorithmclass.DAL
{
    public class DBOperator
    {
        public DBOperator()
        {
        }
        /// <summary>
        /// 读取连接字符串
        /// </summary>
        //public static string ConnString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
       // public static string ConnString = System.Configuration.ConfigurationManager.AppSettings["SQLConnection"];   //连接数据库的语句在Web.config的AppSettings中
  //连接数据库的语句在Web.config的AppSettings中
        public static string ConnString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;


        #region 执行SQL语句，返回一个DataTable对象
        /// <summary>
        /// 返回一个DataTable对象
        /// </summary>
        /// <param name="strSql">需要执行 的SQL语句</param>
        /// <returns>DataTable对象</returns>
        public DataTable GetTable(string strSql)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
            DataTable dt = new System.Data.DataTable();
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + strSql);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 执行SQL语句，返回一个DataSet对象
        /// <summary>
        /// 返回一个DataSet对象
        /// </summary>
        /// <param name="strSql">需要执行的SQL语句</param>
        /// <returns>DataSet对象</returns>
        public System.Data.DataSet GetDataSet(string strSql)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSql, conn);

            DataSet ds = new System.Data.DataSet();
            try
            {
                da.Fill(ds, "MyTable");
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + strSql);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 执行SQL语句，返回一个字符串
        /// <summary>
        /// 返回一个字符串
        /// </summary>
        /// <param name="strSql">需要执行的SQL语句</param>
        /// <param name="key"></param>
        /// <returns>返回数据库对象中某个结果集中的某个字段的值</returns>
        public string getString(string strSql, string key)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
            DataTable dt = new System.Data.DataTable();
            try
            {
                da.Fill(dt);
		        if (dt.Rows.Count > 0)
                {
                	return dt.Rows[0][key].ToString();
		        }
                else 
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + strSql);
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion

        #region 执行添加,修改，删除的时候进行验证的方法,针对单条SQL语句的操作
        /// <summary>
        /// 执行添加的时候进行验证的方法，返回结果的sql更新语句
        /// </summary>
        /// <param name="strSql">需要执行的sql语句</param>
        /// 返回一个boolean型的值
        public Boolean ExecuteInsertOrUpdateSql(string strSql)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + strSql);

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
        }
        #endregion

        #region 更新数据库，针对DataTable的操作
        /// <summary>
        /// 更新数据库，将DataTable中修改过的数据及时更新到数据库中
        /// </summary>
        /// <param name="strSql">需要执行的sql语句</param>
        /// <param name="dtUpdate">需要修改的DataTable</param>
        /// 返回值为空
        public void UpdateDB(string strSql, DataTable dtUpdate) 
        {
           
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            try
            {
                SqlDataAdapter sdAdapter = new SqlDataAdapter(strSql, conn);
                SqlCommandBuilder scb = new SqlCommandBuilder(sdAdapter);
                sdAdapter.Update(dtUpdate);
            }
            catch (Exception e)
            {

                throw new Exception("执行任务失败:" + e.Message + "   " + strSql);
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region 获取表的字段名集合
        /// <summary>
        /// 返回查询的表的字段名集合
        /// </summary>
        /// <param name="strSql">需要执行的sql语句</param>
        /// <returns>返回查询的表的字段名集合</returns>
        public string[] GetFieldName(string strSql)
        {
            int count;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            try
            {
                SqlDataReader sdr = cmd.ExecuteReader();
                count = sdr.FieldCount;
                string[] strFieldName = new string[count];
                for (int i = 0; i < count; i++)
                {
                    strFieldName[i] = sdr.GetName(i);
                }
                return strFieldName;
            }
            catch (Exception e)
            {
                
                throw new Exception("执行任务失败:" + e.Message + "   " + strSql);
            }
            finally
            {
                conn.Close();

            }

        }
        #endregion

        #region 在数据库中连接相同表名前缀的表
        /// <summary>
        /// 在数据库中连接相同表名前缀的表
        /// </summary>
        /// <param name="sqlGetTableName">表名前缀</param>
        /// <returns>连接表</returns>
        public DataTable GetLinkedTable(string sqlGetTableName)
        {
            DataTable dt_TableName = GetTable(sqlGetTableName);
            string getLinkedTable = string.Format("select * from [{0}] ",dt_TableName.Rows[0]["name"]);
            for (int i = 1; i < dt_TableName.Rows.Count; i++)
            {
                getLinkedTable += string.Format("join [{0}] on [{1}].responseid = [{0}].responseid ",
                    dt_TableName.Rows[i]["name"].ToString(), dt_TableName.Rows[0]["name"]);
            }
            string sqlGetLinkedTable = getLinkedTable + string.Format("order by [{0}].responseid asc",dt_TableName.Rows[0]["name"].ToString());
            DataTable dt_LinkedTable = GetTable(sqlGetLinkedTable);
            return dt_LinkedTable;
        }
        #endregion

        #region 从数据库中获取相同表名前缀的表的集合
        /// <summary>
        /// 从数据库中获取相同表名前缀的表的集合
        /// </summary>
        /// <param name="sqlGetTableName">表名前缀</param>
        /// <returns>相同表名前缀的表的集合</returns>
        public DataSet GetDataSetByTableNamePrefix(string sqlGetTableName)
        {
            DataTable dt_TableName = GetTable(sqlGetTableName);
            DataSet ds_SourceTableSet = new DataSet();
            string sqlGetSourceTable = string.Empty;
            for (int i = 0; i < dt_TableName.Rows.Count; i++)
            {
                DataTable dt_SourceTable = new DataTable();
                sqlGetSourceTable = string.Format("select * from [{0}]", dt_TableName.Rows[i]["name"].ToString());
                dt_SourceTable = GetTable(sqlGetSourceTable);
                if (i > 0)
                {
                    dt_SourceTable.Columns.Remove("responseid");
                }
                ds_SourceTableSet.Tables.Add(dt_SourceTable);
            }
            return ds_SourceTableSet;
        }
        #endregion

        /********************************************************************************/
        //存储过程的使用的方法

        #region 存储过程执行更新
        ///<summary>
        ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
        /// 使用参数数组形式提供参数列表 
        /// </summary>
        /// <remarks>
        /// 使用示例：
        ///  int result = ExcStoreNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>返回一个数据值表示此SqlCommand命令执行后影响的行数</returns>
        public int ExcStoreNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                //通过PrePareCommand方法将参数逐个传入到SqlCommand的参数集合中
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
                return val;
                
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + cmdText);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn = null;
            }
        }
        #endregion

        #region 存储过程执行查询--数据表
        /// <summary>
        /// 执行一条返回结果集的SqlCommand，通过一个已经存在的数据库连接
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// DataTable table=StoreGetTable(conn,CommandType.StoredProcedure,"PublishOrders");
        /// </remarks>
        /// <param name="connecttionString">一个现有的数据库连接</param>
        /// <param name="cmdTye">SqlCommand命令类型</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <returns>返回一个表(DataTable)表示查询得到的数据集</returns>
        public DataTable StroreGetTable(CommandType cmdTye, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable ds = new DataTable();
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdTye, cmdText, commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                //返回一个表集
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + cmdText);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn = null;
            }
        }
        #endregion

        #region 存储过程准备参数
        ///<summary>
        ///为执行命令准备参数
        ///</summary>
        ///<param name="cmd">Sqlcommang命令</param>
        ///<param name="conn">已经存在的数据库连接</param>
        ///<param name="trans">数据库事物处理</param>
        ///<param name="cmdType">SqlCommand命令类型（存储过程，T-Sql语句，等等。）</param>
        ///<param name="cmdText">Command text,T-Sql语句，例如：Select * from sufei</param>
        ///<param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //判断是否需要事物处理
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion


        #region 存储过程执行查询--数据集
        /// <summary>
        /// 执行一条返回结果集的SqlCommand，通过一个已经存在的数据库连接
        /// 使用参数数组提供参数
        /// </summary>
        /// <remarks>
        /// 使用示例：
        /// DataTable table=StoreGetTable(conn,CommandType.StoredProcedure,"PublishOrders");
        /// </remarks>
        /// <param name="connecttionString">一个现有的数据库连接</param>
        /// <param name="cmdTye">SqlCommand命令类型</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <returns>返回一个表(DataTable)表示查询得到的数据集</returns>
        public DataSet StroreGetTableSet(CommandType cmdTye, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdTye, cmdText, commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                //返回一个表集
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + cmdText);

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn = null;
            }
        }
        #endregion

    }
}