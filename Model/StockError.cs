using System;
namespace Citic.Model
{
    /// <summary>
    /// 日查库信息
    /// </summary>
    [Serializable]
    public partial class StockError
    {
        public StockError()
        { }
        #region Model
        private int _id;
        private string _bankid;
        private string _bankname;
        private string _dealerid;
        private string _dealername;
        private string _draftno;
        private string _vin;
        private decimal? _carcost;
        private int? _brandid;
        private string _errortype;
        private int? _carstatusold;
        private string _errorother;
        private bool _status;
        private int? _createid;
        private DateTime? _createtime;
        private int? _operateid;
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
        /// 银行ID
        /// </summary>
        public string BankID
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
        /// 经销商ID
        /// </summary>
        public string DealerID
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
        /// 汇票ID
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
        /// 
        /// </summary>
        public decimal? CarCost
        {
            set { _carcost = value; }
            get { return _carcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BrandID
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 异常情况，也就是类型（cl车辆异常或者hgz合格证异常）
        /// </summary>
        public string ErrorType
        {
            set { _errortype = value; }
            get { return _errortype; }
        }
        /// <summary>
        /// 车辆异常前的状态
        /// </summary>
        public int? CarStatusOld
        {
            set { _carstatusold = value; }
            get { return _carstatusold; }
        }
        /// <summary>
        /// 具体内容
        /// </summary>
        public string ErrorOther
        {
            set { _errorother = value; }
            get { return _errorother; }
        }
        /// <summary>
        /// 0-待解除，1-已解除
        /// </summary>
        public bool Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public int? CreateID
        {
            set { _createid = value; }
            get { return _createid; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 处理人
        /// </summary>
        public int? OperateID
        {
            set { _operateid = value; }
            get { return _operateid; }
        }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        #endregion Model

    }
}

