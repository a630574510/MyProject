using System;
namespace Citic.Model
{
    /// <summary>
    /// Storage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Storage
    {
        public Storage()
        { }
        #region Model
        private int _storageid;
        private string _storagename;
        private string _address;
        private int? _dealerid;
        private string _dealername;
        private decimal? _distence;
        private bool _islocalstorage;
        private string _storageprop;
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
        public int StorageID
        {
            set { _storageid = value; }
            get { return _storageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StorageName
        {
            set { _storagename = value; }
            get { return _storagename; }
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
        public decimal? Distence
        {
            set { _distence = value; }
            get { return _distence; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLocalStorage
        {
            set { _islocalstorage = value; }
            get { return _islocalstorage; }
        }
        /// <summary>
        /// 二网性质，目前有四个性质（1.直营、2.控股、3.合作、4.其他）
        /// </summary>
        public string StorageProp
        {
            set { _storageprop = value; }
            get { return _storageprop; }
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

        #region 扩展字段
        private string linkManName;

        public string LinkManName
        {
            get { return linkManName; }
            set { linkManName = value; }
        }

        private string linkPhone;

        public string LinkPhone
        {
            get { return linkPhone; }
            set { linkPhone = value; }
        }

        private int linkType;

        public int LinkType
        {
            get { return linkType; }
            set { linkType = value; }
        }
        #endregion
    }
}

