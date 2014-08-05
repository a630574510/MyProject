using System;
namespace Citic.Model
{
    /// <summary>
    /// tb_Bank_List:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Bank
    {
        public Bank()
        { }
        #region Model
        private int _bankid;
        private string _bankname;
        private int? _banktype;
        private int? _parentid;
        private string _address;
        private int? _createid;
        private DateTime? _createtime;
        private int? _updateid;
        private DateTime? _updatetime;
        private int? _deleteid;
        private DateTime? _deletetime;
        private bool _isdelete;
        private bool _isport;
        private string _connectid;
        /// <summary>
        /// 
        /// </summary>
        public int BankID
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
        public int? BankType
        {
            set { _banktype = value; }
            get { return _banktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
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
        #endregion Model

    }
}

