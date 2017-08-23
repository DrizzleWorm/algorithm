using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace algorithmclass.Model
{
    public class User
    {
        public User() { }
        #region 属性定义
        public string Uname
        {
            get;
            set;
        }
        public string Upassword
        {
            get;
            set;
        }
        public int Urole
        {
            get;
            set;
        }
        public string Uphone
        {
            get;
            set;
        }
        public string Uemail
        {
            get;
            set;
        }
        public string Udept
        {
            get;
            set;
        }
        #endregion 属性定义
    }
}