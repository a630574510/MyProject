using System;
namespace Citic.Model
{
    /// <summary>
    /// XDBG_Record:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class XDBG_Record
    {
        public XDBG_Record()
        { }
        #region Model
        private int _id;
        private int? _pid;
        private string _recordcontent;
        private int? _operateid;
        private string _operatename;
        private string _truename;
        private DateTime? _operatetime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 巡店报告的ID
        /// </summary>
        public int? PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 操作记录内容
        /// </summary>
        public string RecordContent
        {
            set { _recordcontent = value; }
            get { return _recordcontent; }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public int? OperateID
        {
            set { _operateid = value; }
            get { return _operateid; }
        }
        /// <summary>
        /// 操作人的登录名
        /// </summary>
        public string OperateName
        {
            set { _operatename = value; }
            get { return _operatename; }
        }
        /// <summary>
        /// 操作人的真实姓名
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        #endregion Model

    }
}

