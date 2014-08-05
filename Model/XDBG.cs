using System;
namespace Citic.Model
{
    /// <summary>
    /// XDBG:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class XDBG
    {
        public XDBG()
        { }
        #region Model
        private int _id;
        private int? _dealerid;
        private string _dealername;
        private int? _bankid;
        private string _bankname;
        private string _address;
        private string _area;
        private string _filepath;
        private string _filename;
        private int? _createid;
        private string _createname;
        private DateTime? _createtime;
        private DateTime? _inspecttime;
        private int? _updateid;
        private string _updatename;
        private DateTime? _updatetime;
        private string _remark;
        private string _field1;
        private string _field2;
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
        /// “店”的地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 文件路径（仅仅表示路径）
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 文件名（仅仅包含文件名与后缀名，不包含路径）
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
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
        public string CreateName
        {
            set { _createname = value; }
            get { return _createname; }
        }
        /// <summary>
        /// 该条数据的入库时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 该“巡店报告”的“巡店时间”
        /// </summary>
        public DateTime? InspectTime
        {
            set { _inspecttime = value; }
            get { return _inspecttime; }
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
        public string UpdateName
        {
            set { _updatename = value; }
            get { return _updatename; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Field1
        {
            set { _field1 = value; }
            get { return _field1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Field2
        {
            set { _field2 = value; }
            get { return _field2; }
        }
        #endregion Model


        #region 扩展字段--乔春羽(2013.12.25)
        public string TrueName { get; set; }
        #endregion
    }
}

