using System;
namespace Citic.Model
{
    /// <summary>
    /// Supervisor:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Supervisor
    {
        public Supervisor()
        { }
        #region Model
        private int _supervisorid;
        private string _supervisorname;
        private int? _age;
        private int? _gender;
        private string _idcard;
        private string _linkphone;
        private DateTime? _entrytime;
        private string _education;
        private string _qq;
        private string _urgencyman;
        private string _urgencyconnect;
        private string _urgencyphone;
        private int? _worktype;
        private int? _worksource;
        private int? _createid;
        private DateTime? _createtime;
        private int? _updateid;
        private DateTime? _updatetime;
        private int? _deleteid;
        private DateTime? _deletetime;
        private bool _isdelete;
        private bool _isport;
        private string _connectid;
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
        public int? Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkPhone
        {
            set { _linkphone = value; }
            get { return _linkphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EntryTime
        {
            set { _entrytime = value; }
            get { return _entrytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UrgencyMan
        {
            set { _urgencyman = value; }
            get { return _urgencyman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UrgencyConnect
        {
            set { _urgencyconnect = value; }
            get { return _urgencyconnect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UrgencyPhone
        {
            set { _urgencyphone = value; }
            get { return _urgencyphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? WorkType
        {
            set { _worktype = value; }
            get { return _worktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? WorkSource
        {
            set { _worksource = value; }
            get { return _worksource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreateID
        {
            set { _createid = value; }
            get { return _createid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UpdateID
        {
            set { _updateid = value; }
            get { return _updateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DeleteID
        {
            set { _deleteid = value; }
            get { return _deleteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeleteTime
        {
            set { _deletetime = value; }
            get { return _deletetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPort
        {
            set { _isport = value; }
            get { return _isport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConnectID
        {
            set { _connectid = value; }
            get { return _connectid; }
        }
        #endregion Model

        #region 扩展字段
        private string passwor;

        public string Password
        {
            get { return passwor; }
            set { passwor = value; }
        }
        #endregion
    }
}

