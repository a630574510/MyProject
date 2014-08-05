using System;
namespace Citic.Model
{
    /// <summary>
    /// Draft:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Draft
    {
        public Draft()
        { }
        #region Model
        private int _id;
        private string _draftno;
        private int? _bankid;
        private string _bankname;
        private int? _dealerid;
        private string _dealername;
        private int? _brandid;
        private string _brandname;
        private string _darftmoney;
        private DateTime? _begintime;
        private DateTime? _endtime;
        private string _pledgeno;
        private string _guaranteeno;
        private decimal? _ratio;
        private string _rguaranteeno;
        private string _remarks;
        private bool _drafttype;
        private int? _carallcount;
        private decimal? _carallmoney;
        private int? _carilcount;
        private decimal? _carilmoney;
        private int? _caritcount;
        private decimal? _caritmoney;
        private int? _carmovecount;
        private decimal? _carmovemoney;
        private decimal? _hkmoney;
        private decimal? _ckmoney;
        private int? _createid;
        private DateTime? _createtime;
        private int? _updateid;
        private DateTime? _updatetime;
        private int? _deleteid;
        private DateTime? _deletetime;
        private bool _isdelete;
        private bool _isport;
        private string _connectid;
        private string _gd_id;
        private string _zx_id;
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
        public string DraftNo
        {
            set { _draftno = value; }
            get { return _draftno; }
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
        /// 
        /// </summary>
        public int? BrandID
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
        public string DarftMoney
        {
            set { _darftmoney = value; }
            get { return _darftmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PledgeNo
        {
            set { _pledgeno = value; }
            get { return _pledgeno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GuaranteeNo
        {
            set { _guaranteeno = value; }
            get { return _guaranteeno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Ratio
        {
            set { _ratio = value; }
            get { return _ratio; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RGuaranteeNo
        {
            set { _rguaranteeno = value; }
            get { return _rguaranteeno; }
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
        public bool DraftType
        {
            set { _drafttype = value; }
            get { return _drafttype; }
        }
        /// <summary>
        /// “非出库”汽车总数量
        /// </summary>
        public int? CarAllCount
        {
            set { _carallcount = value; }
            get { return _carallcount; }
        }
        /// <summary>
        /// “非出库”汽车总金额
        /// </summary>
        public decimal? CarAllMoney
        {
            set { _carallmoney = value; }
            get { return _carallmoney; }
        }
        /// <summary>
        /// 在库车辆台数（状态为“在库”）
        /// </summary>
        public int? CarILCount
        {
            set { _carilcount = value; }
            get { return _carilcount; }
        }
        /// <summary>
        /// 在库车辆金额（状态为“在库”）
        /// </summary>
        public decimal? CarILMoney
        {
            set { _carilmoney = value; }
            get { return _carilmoney; }
        }
        /// <summary>
        /// 在途车辆数量（状态为“在途”）
        /// </summary>
        public int? CarITCount
        {
            set { _caritcount = value; }
            get { return _caritcount; }
        }
        /// <summary>
        /// 在途车辆金额（状态为“在途”）
        /// </summary>
        public decimal? CarITMoney
        {
            set { _caritmoney = value; }
            get { return _caritmoney; }
        }
        /// <summary>
        /// 移动车辆数量（状态为“移动”）
        /// </summary>
        public int? CarMoveCount
        {
            set { _carmovecount = value; }
            get { return _carmovecount; }
        }
        /// <summary>
        /// 移动车辆金额（状态为“移动”）
        /// </summary>
        public decimal? CarMoveMoney
        {
            set { _carmovemoney = value; }
            get { return _carmovemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HKMoney
        {
            set { _hkmoney = value; }
            get { return _hkmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CKMoney
        {
            set { _ckmoney = value; }
            get { return _ckmoney; }
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
        /// <summary>
        /// 
        /// </summary>
        public string GD_ID
        {
            set { _gd_id = value; }
            get { return _gd_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZX_ID
        {
            set { _zx_id = value; }
            get { return _zx_id; }
        }
        #endregion Model

    }
}

