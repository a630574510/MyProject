using System;
namespace Citic.Model
{
    /// <summary>
    /// DBSX:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DBSX
    {
        public DBSX()
        { }
        #region Model
        private int _id;
        private int? _bankid;
        private string _bankname;
        private int? _dealerid;
        private string _dealername;
        private string _draftno;
        private string _vin;
        private int? _reqtype;
        private string _content;
        private int? _status;
        private string _issupervisorlook;
        private string _isbmlook;
        private int? _createid;
        private DateTime? _createtime;
        private int? _operateid;
        private DateTime? _operatetime;
        private string _targetuser;
        private bool _isdelete = false;
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
        public int? BankID
        {
            set { _bankid = value; }
            get { return _bankid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
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
        /// 汇票号
        /// </summary>
        public string DraftNo
        {
            set { _draftno = value; }
            get { return _draftno; }
        }
        /// <summary>
        /// 车架号
        /// </summary>
        public string Vin
        {
            set { _vin = value; }
            get { return _vin; }
        }
        /// <summary>
        /// 车辆申请状态
        /// </summary>
        public int? ReqType
        {
            set { _reqtype = value; }
            get { return _reqtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 处理状态，1.通过，2.处理中，3.未通过
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 监管员是否查看该信息
        /// </summary>
        public string IsSupervisorLook
        {
            set { _issupervisorlook = value; }
            get { return _issupervisorlook; }
        }
        /// <summary>
        /// 业务经理是否已查看这条数据
        /// </summary>
        public string IsBMLook
        {
            set { _isbmlook = value; }
            get { return _isbmlook; }
        }
        /// <summary>
        /// 提交人ID
        /// </summary>
        public int? CreateID
        {
            set { _createid = value; }
            get { return _createid; }
        }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
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
        /// 操作时间
        /// </summary>
        public DateTime? OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        /// <summary>
        /// 目标人
        /// </summary>
        public string TargetUser
        {
            set { _targetuser = value; }
            get { return _targetuser; }
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

