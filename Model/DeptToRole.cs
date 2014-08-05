using System;
namespace Citic.Model
{
    /// <summary>
    /// 部门角色对应表
    /// </summary>
    [Serializable]
    public partial class DeptToRole
    {
        public DeptToRole()
        { }
        #region Model
        private int _id;
        private int? _deptid;
        private int? _roleid;
        private string _rolename;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int? DeptID
        {
            set { _deptid = value; }
            get { return _deptid; }
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
        /// 角色名
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        #endregion Model

    }
}

