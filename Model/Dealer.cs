using System;
namespace Citic.Model
{
    /// <summary>
    /// Dealer:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Dealer
    {
        public Dealer()
        {
            this._BankList = new System.Collections.Generic.List<Dealer_Bank>();
        }
        #region Model
        private int _dealerid;
        private string _dealername;
        private int? _supervisorid;
        private string _supervisorname;
        private DateTime? _supervisordispatchtime;
        private string _dealertype = "1";
        private bool _isgroup = true;
        private bool _issinglestore = true;
        private string _hasotherindustries;
        private string _gotoworktime;
        private string _goffworktime;
        private string _address;
        /// <summary>
        /// 组织机构代码
        /// </summary>
        private string _dealerpaycode;
        private string _remarks;
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
        public int? SupervisorID
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
        /// 监管员驻店日期
        /// </summary>
        public DateTime? SupervisorDispatchTime
        {
            set { _supervisordispatchtime = value; }
            get { return _supervisordispatchtime; }
        }
        /// <summary>
        /// 经销商属性（1.民营、2.国营、3.集团、4.单店）
        /// </summary>
        public string DealerType
        {
            set { _dealertype = value; }
            get { return _dealertype; }
        }
        /// <summary>
        /// 是否是集团性质
        /// </summary>
        public bool IsGroup
        {
            set { _isgroup = value; }
            get { return _isgroup; }
        }
        /// <summary>
        /// 是否是单店
        /// </summary>
        public bool IsSingleStore
        {
            set { _issinglestore = value; }
            get { return _issinglestore; }
        }
        /// <summary>
        /// 是否有其他产业
        /// </summary>
        public string HasOtherIndustries
        {
            set { _hasotherindustries = value; }
            get { return _hasotherindustries; }
        }
        /// <summary>
        /// 上班时间
        /// </summary>
        public string GotoworkTime
        {
            set { _gotoworktime = value; }
            get { return _gotoworktime; }
        }
        /// <summary>
        /// 下班时间
        /// </summary>
        public string GoffworkTime
        {
            set { _goffworktime = value; }
            get { return _goffworktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string DealerPayCode
        {
            set { _dealerpaycode = value; }
            get { return _dealerpaycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
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
        System.Collections.Generic.List<Citic.Model.Dealer_Bank> _BankList;

        /// <summary>
        /// 与该经销商合作的银行集合
        /// </summary>
        public System.Collections.Generic.List<Citic.Model.Dealer_Bank> BankList
        {
            get { return _BankList; }
            set { _BankList = value; }
        }
        #endregion
    }
}

