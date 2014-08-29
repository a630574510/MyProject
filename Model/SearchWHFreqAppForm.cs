using System;
namespace Citic.Model
{
    /// <summary>
    /// SearchWarehouseFrequencyApplicationForm-日差库频次申请书
    /// </summary>
    [Serializable]
    public partial class SearchWHFreqAppForm
    {
        public SearchWHFreqAppForm()
        { }
        #region Model
        private int _id;
        private int? _orcdstatus;
        private int? _obdstatus;
        private int? _dealerid;
        private string _dealername;
        private string _banks;
        private string _brands;
        private string _regulatorymode;
        private string _searchfrequency;
        private int? _sid;
        private string _sname;
        private DateTime? _applytime;
        private string _linkphone;
        private string _applyresult;
        private string _orcd;
        private bool _orcdpic;
        private string _obd;
        private bool _obdpic;
        private int? _createid;
        private DateTime? _createtime;
        private int? _deleteid;
        private DateTime? _deletetime;
        private bool _isdelete;
        private int? _orcd_optionid;
        private DateTime? _orcd_optiontime;
        private int? _orcdpic_optionid;
        private DateTime? _orcdpic_optiontime;
        private int? _obd_optionid;
        private DateTime? _obd_optiontime;
        private int? _obdpic_optionid;
        private DateTime? _obdpic_optiontime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 风控部审核状态，0-未处理，1-通过审核，-1 - 为通过审核
        /// </summary>
        public int? ORCDStatus
        {
            set { _orcdstatus = value; }
            get { return _orcdstatus; }
        }
        /// <summary>
        /// 业务部部审核状态，0-未处理，1-通过审核，-1 - 为通过审核
        /// </summary>
        public int? OBDStatus
        {
            set { _obdstatus = value; }
            get { return _obdstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DealerID
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
        /// 合作行，如有多个合作行则一并存入，各式：BankID_BankName,BankID_BankName,....
        /// </summary>
        public string Banks
        {
            set { _banks = value; }
            get { return _banks; }
        }
        /// <summary>
        /// 品牌，如若多个品牌，则一并存入，各式与合作行一样。
        /// </summary>
        public string Brands
        {
            set { _brands = value; }
            get { return _brands; }
        }
        /// <summary>
        /// （Regulatory-监管，Mode-模式）监管模式，录入人员手填
        /// </summary>
        public string RegulatoryMode
        {
            set { _regulatorymode = value; }
            get { return _regulatorymode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SearchFrequency
        {
            set { _searchfrequency = value; }
            get { return _searchfrequency; }
        }
        /// <summary>
        /// 监管员ID
        /// </summary>
        public int? SID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 监管员姓名
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? ApplyTime
        {
            set { _applytime = value; }
            get { return _applytime; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone
        {
            set { _linkphone = value; }
            get { return _linkphone; }
        }
        /// <summary>
        /// 申请日差库的原因
        /// </summary>
        public string ApplyResult
        {
            set { _applyresult = value; }
            get { return _applyresult; }
        }
        /// <summary>
        /// （ORCD-Opinions Risk Control Department）风控部意见
        /// </summary>
        public string ORCD
        {
            set { _orcd = value; }
            get { return _orcd; }
        }
        /// <summary>
        /// （ORCDPIC-Opinions Risk Control Department，Person in Charge）风控部负责人签字
        /// </summary>
        public bool ORCDPIC
        {
            set { _orcdpic = value; }
            get { return _orcdpic; }
        }
        /// <summary>
        /// （OBD-Opinions Business Department）业务部意见
        /// </summary>
        public string OBD
        {
            set { _obd = value; }
            get { return _obd; }
        }
        /// <summary>
        /// （OBDPIC-Opinions Business Department，Person in Charge）业务部负责人签字
        /// </summary>
        public bool OBDPIC
        {
            set { _obdpic = value; }
            get { return _obdpic; }
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
        /// 风控部意见--修改人
        /// </summary>
        public int? ORCD_OptionID
        {
            set { _orcd_optionid = value; }
            get { return _orcd_optionid; }
        }
        /// <summary>
        /// 风控部意见--修改时间
        /// </summary>
        public DateTime? ORCD_OptionTime
        {
            set { _orcd_optiontime = value; }
            get { return _orcd_optiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ORCDPIC_OptionID
        {
            set { _orcdpic_optionid = value; }
            get { return _orcdpic_optionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ORCDPIC_OptionTime
        {
            set { _orcdpic_optiontime = value; }
            get { return _orcdpic_optiontime; }
        }
        /// <summary>
        /// 业务部意见--修改人
        /// </summary>
        public int? OBD_OptionID
        {
            set { _obd_optionid = value; }
            get { return _obd_optionid; }
        }
        /// <summary>
        /// 业务部意见--修改时间
        /// </summary>
        public DateTime? OBD_OptionTime
        {
            set { _obd_optiontime = value; }
            get { return _obd_optiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OBDPIC_OptionID
        {
            set { _obdpic_optionid = value; }
            get { return _obdpic_optionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OBDPIC_OptionTime
        {
            set { _obdpic_optiontime = value; }
            get { return _obdpic_optiontime; }
        }
        #endregion Model

    }
}

