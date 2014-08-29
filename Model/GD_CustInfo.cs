using System;
namespace Citic.Model
{
    /// <summary>
    /// GD_CustInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GD_CustInfo
    {
        public GD_CustInfo()
        { }
        #region Model
        private decimal _cust_id;
        private string _cust_name;
        private string _org_code;
        private string _cust_type;
        private string _cm_name;
        private string _office_phone_no;
        private string _cellphone_no;
        private string _email;
        private string _reserve1;
        private string _reserve2;
        private string _reserve3;
        private DateTime? _createtime;
        /// <summary>
        /// 
        /// </summary>
        public decimal CUST_ID
        {
            set { _cust_id = value; }
            get { return _cust_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUST_NAME
        {
            set { _cust_name = value; }
            get { return _cust_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ORG_CODE
        {
            set { _org_code = value; }
            get { return _org_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CUST_TYPE
        {
            set { _cust_type = value; }
            get { return _cust_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CM_NAME
        {
            set { _cm_name = value; }
            get { return _cm_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OFFICE_PHONE_NO
        {
            set { _office_phone_no = value; }
            get { return _office_phone_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CELLPHONE_NO
        {
            set { _cellphone_no = value; }
            get { return _cellphone_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RESERVE1
        {
            set { _reserve1 = value; }
            get { return _reserve1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RESERVE2
        {
            set { _reserve2 = value; }
            get { return _reserve2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RESERVE3
        {
            set { _reserve3 = value; }
            get { return _reserve3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

