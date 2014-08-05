using System;
namespace Citic.Model
{
    /// <summary>
    /// 每日风控问题追踪表
    /// </summary>
    [Serializable]
    public partial class RiskQuesDay
    {
        public RiskQuesDay()
        { }
        #region Model
        private int _id;
        private int? _status;
        private string _workcontent;
        private string _area;
        private string _checkman;
        private int? _dealerid;
        private string _dealername;
        private int? _bankid;
        private string _bankname;
        private int? _brandid;
        private string _brandname;
        private int? _sid;
        private string _sname;
        private string _descprob;
        private string _result;
        private string _cy_market;
        private string _cy_business;
        private string _qc_market;
        private string _qc_business;
        private string _mancenter;
        private string _xz;
        private string _remark;
        private int? _createid;
        private DateTime? _createtime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 状态（0.待审核，1.已审核）
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 工作内容
        /// </summary>
        public string WorkContent
        {
            set { _workcontent = value; }
            get { return _workcontent; }
        }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 检查人员
        /// </summary>
        public string Checkman
        {
            set { _checkman = value; }
            get { return _checkman; }
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
        /// 
        /// </summary>
        public int? SID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 监管员名
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string DescProb
        {
            set { _descprob = value; }
            get { return _descprob; }
        }
        /// <summary>
        /// 检查时处理结果
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CY_Market
        {
            set { _cy_market = value; }
            get { return _cy_market; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CY_Business
        {
            set { _cy_business = value; }
            get { return _cy_business; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QC_Market
        {
            set { _qc_market = value; }
            get { return _qc_market; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QC_Business
        {
            set { _qc_business = value; }
            get { return _qc_business; }
        }
        /// <summary>
        /// 管理中心
        /// </summary>
        public string ManCenter
        {
            set { _mancenter = value; }
            get { return _mancenter; }
        }
        /// <summary>
        /// 行政
        /// </summary>
        public string XZ
        {
            set { _xz = value; }
            get { return _xz; }
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
        #endregion Model

    }
}

