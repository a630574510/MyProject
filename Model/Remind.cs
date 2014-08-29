using System;
namespace Citic.Model
{
    /// <summary>
    /// Remind:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Remind
    {
        public Remind()
        { }
        #region Model
        private int _id;
        private string _bankid;
        private string _bankname;
        private string _dealerid;
        private string _dealername;
        private string _brandid;
        private string _brandname;
        private DateTime? _enteringdate;
        private string _supervisionfeemoney;
        private string _remark;
        private DateTime? _duedate;
        private DateTime? _supervisionfeeasdate;
        private DateTime? _outbounddate;
        private string _storecount;
        private string _draftno;
        private string _draftmoney;
        private DateTime? _begindraftdate;
        private string _pledgemoney;
        private string _notmoney;
        private string _storemoney;
        private string _businessmodel;
        private DateTime? _replacedate;
        private string _originalsupervision;
        private string _nowsupervision;
        private DateTime? _createdate;
        private string _determinepeople;
        private DateTime? _determinedate;
        private int? _status;
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
        /// 
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
        /// 
        /// </summary>
        public string BrandID
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BrandName
        {
            set { _brandname = value; }
            get { return _brandname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EnteringDate
        {
            set { _enteringdate = value; }
            get { return _enteringdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SupervisionFeeMoney
        {
            set { _supervisionfeemoney = value; }
            get { return _supervisionfeemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DueDate
        {
            set { _duedate = value; }
            get { return _duedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SupervisionFeeAsDate
        {
            set { _supervisionfeeasdate = value; }
            get { return _supervisionfeeasdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OutboundDate
        {
            set { _outbounddate = value; }
            get { return _outbounddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreCount
        {
            set { _storecount = value; }
            get { return _storecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DraftNo
        {
            set { _draftno = value; }
            get { return _draftno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DraftMoney
        {
            set { _draftmoney = value; }
            get { return _draftmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BeginDraftDate
        {
            set { _begindraftdate = value; }
            get { return _begindraftdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PledgeMoney
        {
            set { _pledgemoney = value; }
            get { return _pledgemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NotMoney
        {
            set { _notmoney = value; }
            get { return _notmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreMoney
        {
            set { _storemoney = value; }
            get { return _storemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessModel
        {
            set { _businessmodel = value; }
            get { return _businessmodel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReplaceDate
        {
            set { _replacedate = value; }
            get { return _replacedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OriginalSupervision
        {
            set { _originalsupervision = value; }
            get { return _originalsupervision; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowSupervision
        {
            set { _nowsupervision = value; }
            get { return _nowsupervision; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeterminePeople
        {
            set { _determinepeople = value; }
            get { return _determinepeople; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DetermineDate
        {
            set { _determinedate = value; }
            get { return _determinedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

