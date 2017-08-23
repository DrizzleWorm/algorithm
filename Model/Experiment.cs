using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace algorithmclass.Model
{
    public class Experiment
    {
        public Experiment() { }
        #region 属性定义
        public string Etitle
        {
            get;
            set;
        }
        public string Econtent
        {
            get;
            set;
        }
        public string E_TUname
        {
            get;
            set;
        }
        public DateTime Eupload
        {
            get;
            set;
        }
        public int Ebrowse
        {
            get;
            set;
        }
        #endregion 属性定义
    }
}