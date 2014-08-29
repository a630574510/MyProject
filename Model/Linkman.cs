using System;
namespace Citic.Model
{
    /// <summary>
    /// Linkman:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Linkman
    {
        public Linkman()
        { }
        #region Model
        private int _linkmanid;
        private string _linkmanname;
        private string _phone;
        private string _fax;
        private string _email;
        private string _post;
        private int? _linktype;
        private int? _relationid;
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
        public int LinkmanID
        {
            set { _linkmanid = value; }
            get { return _linkmanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkmanName
        {
            set { _linkmanname = value; }
            get { return _linkmanname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 联系人类型
        /// </summary>
        public int? LinkType
        {
            set { _linktype = value; }
            get { return _linktype; }
        }
        /// <summary>
        /// 关联ID
        /// </summary>
        public int? RelationID
        {
            set { _relationid = value; }
            get { return _relationid; }
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

