using System;
namespace Citic.Model
{
    /// <summary>
    /// Department:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Department
    {
        public Department()
        { }
        #region Model
        private int _id;
        private string _dname;
        private int _pdid;
        private string _description;
        private int? _type;
        private int _cid;
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
        public string DName
        {
            set { _dname = value; }
            get { return _dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PDID
        {
            set { _pdid = value; }
            get { return _pdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 类型，0、通用，1、汽车， 2、产业 
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        #endregion Model

    }
}

