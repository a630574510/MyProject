using System;
namespace Citic.Model
{
    /// <summary>
    /// UserLog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UserLog
    {
        public UserLog()
        { }
        #region Model
        private int _logid;
        private int _userid;
        private int _actionid;
        private string _actiondescription;
        private string _url;
        private string _ipaddress;
        private DateTime? _actiontime;
        private int? _companyid;
        private int? _deptid;
        private int? _roleid;
        /// <summary>
        /// 
        /// </summary>
        public int LogID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 模块ID
        /// </summary>
        public int ActionID
        {
            set { _actionid = value; }
            get { return _actionid; }
        }
        /// <summary>
        /// 模块描述
        /// </summary>
        public string ActionDescription
        {
            set { _actiondescription = value; }
            get { return _actiondescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string URL
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IPAddress
        {
            set { _ipaddress = value; }
            get { return _ipaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ActionTime
        {
            set { _actiontime = value; }
            get { return _actiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DeptID
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model

    }
}

