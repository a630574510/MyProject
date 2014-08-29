using System;
namespace Citic.Model
{
    /// <summary>
    /// CarErrorCount:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CarErrorCount
    {
        public CarErrorCount()
        { }
        #region Model
        private int _id;
        private int? _dealerid;
        private string _dealername;
        private int? _bankid;
        private string _bankname;
        private int? _brandid;
        private string _brandname;
        private string _szsm;
        private string _xswhk;
        private string _szyd;
        private string _zscl;
        private string _zyczsjc;
        private string _zyclb;
        private string _other;
        private int? _szsmc;
        private int? _xswhkc;
        private int? _szydc;
        private int? _zsclc;
        private int? _zyczsjcc;
        private int? _zyclbc;
        private int? _otherc;
        private string _szsmr;
        private string _xswhkr;
        private string _szydr;
        private string _zsclr;
        private string _zyczsjcr;
        private string _zyclbr;
        private string _otherr;
        private DateTime? _createdate;
        private int? _createid;
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
        /// 私自售卖
        /// </summary>
        public string SZSM
        {
            set { _szsm = value; }
            get { return _szsm; }
        }
        /// <summary>
        /// 销售未还款
        /// </summary>
        public string XSWHK
        {
            set { _xswhk = value; }
            get { return _xswhk; }
        }
        /// <summary>
        /// 私自移动
        /// </summary>
        public string SZYD
        {
            set { _szyd = value; }
            get { return _szyd; }
        }
        /// <summary>
        /// 质损车辆
        /// </summary>
        public string ZSCL
        {
            set { _zscl = value; }
            get { return _zscl; }
        }
        /// <summary>
        /// 质押车做试驾车
        /// </summary>
        public string ZYCZSJC
        {
            set { _zyczsjc = value; }
            get { return _zyczsjc; }
        }
        /// <summary>
        /// 质押车零部件被拆卸
        /// </summary>
        public string ZYCLB
        {
            set { _zyclb = value; }
            get { return _zyclb; }
        }
        /// <summary>
        /// 其他
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
        }
        /// <summary>
        /// 私自售卖
        /// </summary>
        public int? SZSMC
        {
            set { _szsmc = value; }
            get { return _szsmc; }
        }
        /// <summary>
        /// 销售未还款
        /// </summary>
        public int? XSWHKC
        {
            set { _xswhkc = value; }
            get { return _xswhkc; }
        }
        /// <summary>
        /// 私自移动
        /// </summary>
        public int? SZYDC
        {
            set { _szydc = value; }
            get { return _szydc; }
        }
        /// <summary>
        /// 质损车辆
        /// </summary>
        public int? ZSCLC
        {
            set { _zsclc = value; }
            get { return _zsclc; }
        }
        /// <summary>
        /// 质押车做试驾车
        /// </summary>
        public int? ZYCZSJCC
        {
            set { _zyczsjcc = value; }
            get { return _zyczsjcc; }
        }
        /// <summary>
        /// 质押车零部件被拆卸
        /// </summary>
        public int? ZYCLBC
        {
            set { _zyclbc = value; }
            get { return _zyclbc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OtherC
        {
            set { _otherc = value; }
            get { return _otherc; }
        }
        /// <summary>
        /// 私自售卖
        /// </summary>
        public string SZSMR
        {
            set { _szsmr = value; }
            get { return _szsmr; }
        }
        /// <summary>
        /// 销售未还款
        /// </summary>
        public string XSWHKR
        {
            set { _xswhkr = value; }
            get { return _xswhkr; }
        }
        /// <summary>
        /// 私自移动
        /// </summary>
        public string SZYDR
        {
            set { _szydr = value; }
            get { return _szydr; }
        }
        /// <summary>
        /// 质损车辆
        /// </summary>
        public string ZSCLR
        {
            set { _zsclr = value; }
            get { return _zsclr; }
        }
        /// <summary>
        /// 质押车做试驾车
        /// </summary>
        public string ZYCZSJCR
        {
            set { _zyczsjcr = value; }
            get { return _zyczsjcr; }
        }
        /// <summary>
        /// 质押车零部件被拆卸
        /// </summary>
        public string ZYCLBR
        {
            set { _zyclbr = value; }
            get { return _zyclbr; }
        }
        /// <summary>
        /// 其他
        /// </summary>
        public string OtherR
        {
            set { _otherr = value; }
            get { return _otherr; }
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
        public int? CreateID
        {
            set { _createid = value; }
            get { return _createid; }
        }
        #endregion Model

    }
}

