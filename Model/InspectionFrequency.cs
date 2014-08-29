using System;
namespace Citic.Model
{
    /// <summary>
    /// InspectionFrequency:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class InspectionFrequency
    {
        public InspectionFrequency()
        { }
        #region Model
        private int _id;
        private string _area;
        private string _dealername;
        private string _bank;
        private string _brandname;
        private string _supervisorname;
        private string _checkproblem;
        private string _financialcenter;
        private string _riskcontrol;
        private string _admindepartment;
        private string _quartersledger;
        private DateTime? _historytime;
        private int? _createid;
        private DateTime? _createtime;
        private int? _statu;
        private int? _isdel;
        private int? _delid;
        private DateTime? _deltime;
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
        public string Area
        {
            set { _area = value; }
            get { return _area; }
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
        public string Bank
        {
            set { _bank = value; }
            get { return _bank; }
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
        public string SupervisorName
        {
            set { _supervisorname = value; }
            get { return _supervisorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CheckProblem
        {
            set { _checkproblem = value; }
            get { return _checkproblem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FinancialCenter
        {
            set { _financialcenter = value; }
            get { return _financialcenter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RiskControl
        {
            set { _riskcontrol = value; }
            get { return _riskcontrol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdminDepartment
        {
            set { _admindepartment = value; }
            get { return _admindepartment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger
        {
            set { _quartersledger = value; }
            get { return _quartersledger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? HistoryTime
        {
            set { _historytime = value; }
            get { return _historytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreateId
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
        public int? Statu
        {
            set { _statu = value; }
            get { return _statu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DelId
        {
            set { _delid = value; }
            get { return _delid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DelTime
        {
            set { _deltime = value; }
            get { return _deltime; }
        }
        #endregion Model

    }
}

