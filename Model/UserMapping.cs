using System;
namespace Citic.Model
{
    /// <summary>
    /// UserMapping:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class UserMapping
    {
        public UserMapping()
        { }
        #region Model
        private int _id;
        private int? _userid;
        private int? _roleid;
        private int? _mappingid;
        private string _mappingtype;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 映射ID
        /// </summary>
        public int? MappingID
        {
            set { _mappingid = value; }
            get { return _mappingid; }
        }
        /// <summary>
        /// 映射类型，包括“Bank--银行,Brand--品牌”
        /// </summary>
        public string MappingType
        {
            set { _mappingtype = value; }
            get { return _mappingtype; }
        }
        #endregion Model

    }
}

