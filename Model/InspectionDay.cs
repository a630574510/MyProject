using System;
namespace Citic.Model
{
    /// <summary>
    /// InspectionDay:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class InspectionDay
    {
        public InspectionDay()
        { }
        #region Model
        private int _id;
        private string _area;
        private string _rummager;
        private string _dealername;
        private string _bank;
        private string _brandname;
        private string _supervisorname;
        private string _model;
        private string _inventory;
        private string _quartersledger;
        private string _mainproblem;
        private string _remark;
        private DateTime? _createtime;
        private int? _createid;
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
        public string Rummager
        {
            set { _rummager = value; }
            get { return _rummager; }
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
        public string Model
        {
            set { _model = value; }
            get { return _model; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Inventory
        {
            set { _inventory = value; }
            get { return _inventory; }
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
        public string MainProblem
        {
            set { _mainproblem = value; }
            get { return _mainproblem; }
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
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
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
        public int? isDel
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

