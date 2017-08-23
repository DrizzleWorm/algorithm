using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace algorithmclass.Model
{
    public class Match
    {
        public Match() { }
        #region 属性定义
        public string Mtitle
        {
            get;
            set;
        }
        public string Mtime
        {
            get;
            set;
        }
        
        public string Mregister
        {
            get;
            set;
        }
        public string Murl
        {
            get;
            set;
        }
        #endregion 属性定义
    }
}