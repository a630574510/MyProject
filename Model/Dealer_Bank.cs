using System;
namespace Citic.Model
{
    /// <summary>
    /// Dealer_Bank:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Dealer_Bank
    {
        public Dealer_Bank()
        { }
        #region Model
        private int _id;
        private int? _dealerid;
        private string _dealername;
        private int? _bankid;
        private string _bankname;
        private int? _brandid;
        private string _brandname;
        private int? _businessmode;
        private string _financingmode;
        private int? _collaboratetype;
        private decimal? _ssmoney;
        private decimal? _ysmoney;
        private int? _paymentcycle;
        private DateTime? _dispatchtime;
        private int? _createid;
        private DateTime? _createtime;
        private bool _isdelete;
        private DateTime? _stoptime;
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
        /// 经销商ID
        /// </summary>
        public int? DealerID
        {
            set { _dealerid = value; }
            get { return _dealerid; }
        }
        /// <summary>
        /// 经销商名
        /// </summary>
        public string DealerName
        {
            set { _dealername = value; }
            get { return _dealername; }
        }
        /// <summary>
        /// 银行ID
        /// </summary>
        public int? BankID
        {
            set { _bankid = value; }
            get { return _bankid; }
        }
        /// <summary>
        /// 银行名
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int? BrandID
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName
        {
            set { _brandname = value; }
            get { return _brandname; }
        }
        /// <summary>
        /// 业务模式	1：车证模式，2：合格证模式，3：巡库模式
        /// </summary>
        public int? BusinessMode
        {
            set { _businessmode = value; }
            get { return _businessmode; }
        }
        /// <summary>
        /// 融资模式
        /// </summary>
        public string FinancingMode
        {
            set { _financingmode = value; }
            get { return _financingmode; }
        }
        /// <summary>
        /// 合作状态，1-正常合作，0-停止合作
        /// </summary>
        public int? CollaborateType
        {
            set { _collaboratetype = value; }
            get { return _collaboratetype; }
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal? SSMoney
        {
            set { _ssmoney = value; }
            get { return _ssmoney; }
        }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal? YSMoney
        {
            set { _ysmoney = value; }
            get { return _ysmoney; }
        }
        /// <summary>
        /// 支付周期
        /// </summary>
        public int? PaymentCycle
        {
            set { _paymentcycle = value; }
            get { return _paymentcycle; }
        }
        /// <summary>
        /// 驻店日期
        /// </summary>
        public DateTime? DispatchTime
        {
            set { _dispatchtime = value; }
            get { return _dispatchtime; }
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
        public bool IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 停止合作时间
        /// </summary>
        public DateTime? StopTime
        {
            set { _stoptime = value; }
            get { return _stoptime; }
        }
        /// <summary>
        /// 光大直联ID
        /// </summary>
        public string GD_ID
        {
            set { _gd_id = value; }
            get { return _gd_id; }
        }
        /// <summary>
        /// 中信直联ID
        /// </summary>
        public string ZX_ID
        {
            set { _zx_id = value; }
            get { return _zx_id; }
        }
        #endregion Model

        public override bool Equals(object obj)
        {
            Dealer_Bank db = obj as Dealer_Bank;
            if (db != null)
            {
                return db.BankName.Equals(this.BankName) && db.BrandName.Equals(this.BrandName);
            }
            return false;
        }
    }
}

