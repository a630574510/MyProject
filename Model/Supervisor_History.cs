using System;
namespace Citic.Model
{
    /// <summary>
    /// Supervisor_History:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Supervisor_History
    {
        public Supervisor_History()
        { }
        #region Model
        private int _id;
        private int _dealerid;
        private string _dealername;
        private int _supervisorid;
        private string _supervisorname;
        private DateTime? _time_start;
        private DateTime? _time_end;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DealerID
        {
            set { _dealerid = value; }
            get { return _dealerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DealerName
        {
            set { _dealername = value; }
            get { return _dealername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SupervisorID
        {
            set { _supervisorid = value; }
            get { return _supervisorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SupervisorName
        {
            set { _supervisorname = value; }
            get { return _supervisorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_Start
        {
            set { _time_start = value; }
            get { return _time_start; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_End
        {
            set { _time_end = value; }
            get { return _time_end; }
        }
        #endregion Model

    }
}

