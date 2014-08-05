using System;
namespace Citic.Model
{
    /// <summary>
    /// 查库频率表
    /// </summary>
    [Serializable]
    public partial class QueryWH
    {
        public QueryWH()
        { }
        #region Model
        private int _id;
        private string _db_id;
        private string _checkfrequency = "";
        private string _description = "";
        private string _remark = "";
        private int? _createid;
        private DateTime? _createtime;
        private DateTime? _applytime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// Dealer_BankID，银行与经销商映射表的ID列
        /// </summary>
        public string DB_ID
        {
            set { _db_id = value; }
            get { return _db_id; }
        }
        /// <summary>
        /// 查库频率
        /// </summary>
        public string CheckFrequency
        {
            set { _checkfrequency = value; }
            get { return _checkfrequency; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
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
        /// 创建人ID，此表中也当“修改人ID”来使用，CreateTime一样。
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
        /// “申请时间”
        /// </summary>
        public DateTime? ApplyTime
        {
            set { _applytime = value; }
            get { return _applytime; }
        }
        #endregion Model

    }
}

