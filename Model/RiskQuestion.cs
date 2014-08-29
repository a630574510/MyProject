using System;
namespace Citic.Model
{
    /// <summary>
    /// RiskQuestion:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RiskQuestion
    {
        public RiskQuestion()
        { }
        #region Model
        private int _id;
        private string _no;
        private DateTime? _cc_date;
        private string _cc_ap;
        private string _cc_unit;
        private string _cc_p;
        private string _cc_post;
        private string _cc_pphone;
        private string _cc_content;
        private int? _sq_shopid;
        private string _sq_shop;
        private int? _sq_brandid;
        private string _sq_brand;
        private string _sq_name;
        private string _sq_phone;
        private string _sq_fbp;
        private string _sq_fbpp;
        private string _sq_content;
        private string _s_p;
        private string _s_phone;
        private string _s_result;
        private string _gd;
        private string _wtclbf;
        private string _fxwtbmqz;
        private string _qcjrzxyj;
        private string _qcjrzxqz;
        private string _glzxyj;
        private string _glzxqz;
        private int? _createid;
        private DateTime? _createtime;
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
        public string No
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// CC-Customer Complaints，客户投诉
        /// </summary>
        public DateTime? CC_Date
        {
            set { _cc_date = value; }
            get { return _cc_date; }
        }
        /// <summary>
        /// Accept Person，接受人
        /// </summary>
        public string CC_AP
        {
            set { _cc_ap = value; }
            get { return _cc_ap; }
        }
        /// <summary>
        /// 投诉单位
        /// </summary>
        public string CC_Unit
        {
            set { _cc_unit = value; }
            get { return _cc_unit; }
        }
        /// <summary>
        /// 投诉人
        /// </summary>
        public string CC_P
        {
            set { _cc_p = value; }
            get { return _cc_p; }
        }
        /// <summary>
        /// 投诉人职务
        /// </summary>
        public string CC_Post
        {
            set { _cc_post = value; }
            get { return _cc_post; }
        }
        /// <summary>
        /// 投诉人联系方式
        /// </summary>
        public string CC_PPhone
        {
            set { _cc_pphone = value; }
            get { return _cc_pphone; }
        }
        /// <summary>
        /// 投诉内容
        /// </summary>
        public string CC_Content
        {
            set { _cc_content = value; }
            get { return _cc_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SQ_ShopID
        {
            set { _sq_shopid = value; }
            get { return _sq_shopid; }
        }
        /// <summary>
        /// （SQ-Supervisor Question，监管员问题）监管店
        /// </summary>
        public string SQ_Shop
        {
            set { _sq_shop = value; }
            get { return _sq_shop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SQ_BrandID
        {
            set { _sq_brandid = value; }
            get { return _sq_brandid; }
        }
        /// <summary>
        /// 监管品牌
        /// </summary>
        public string SQ_Brand
        {
            set { _sq_brand = value; }
            get { return _sq_brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SQ_Name
        {
            set { _sq_name = value; }
            get { return _sq_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SQ_Phone
        {
            set { _sq_phone = value; }
            get { return _sq_phone; }
        }
        /// <summary>
        /// （FBP,Feedback People）问题反馈人
        /// </summary>
        public string SQ_FBP
        {
            set { _sq_fbp = value; }
            get { return _sq_fbp; }
        }
        /// <summary>
        /// 问题反馈人联系方式
        /// </summary>
        public string SQ_FBPP
        {
            set { _sq_fbpp = value; }
            get { return _sq_fbpp; }
        }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string SQ_Content
        {
            set { _sq_content = value; }
            get { return _sq_content; }
        }
        /// <summary>
        /// S-Survey，调查人
        /// </summary>
        public string S_P
        {
            set { _s_p = value; }
            get { return _s_p; }
        }
        /// <summary>
        /// 调查人联系方式
        /// </summary>
        public string S_Phone
        {
            set { _s_phone = value; }
            get { return _s_phone; }
        }
        /// <summary>
        /// 调查结果
        /// </summary>
        public string S_Result
        {
            set { _s_result = value; }
            get { return _s_result; }
        }
        /// <summary>
        /// 规定内容
        /// </summary>
        public string GD
        {
            set { _gd = value; }
            get { return _gd; }
        }
        /// <summary>
        /// 问题处理办法
        /// </summary>
        public string WTCLBF
        {
            set { _wtclbf = value; }
            get { return _wtclbf; }
        }
        /// <summary>
        /// 发现问题部门签字
        /// </summary>
        public string FXWTBMQZ
        {
            set { _fxwtbmqz = value; }
            get { return _fxwtbmqz; }
        }
        /// <summary>
        /// 汽车金融中心意见
        /// </summary>
        public string QCJRZXYJ
        {
            set { _qcjrzxyj = value; }
            get { return _qcjrzxyj; }
        }
        /// <summary>
        /// 汽车金融中心负责人签字
        /// </summary>
        public string QCJRZXQZ
        {
            set { _qcjrzxqz = value; }
            get { return _qcjrzxqz; }
        }
        /// <summary>
        /// 管理中心意见
        /// </summary>
        public string GLZXYJ
        {
            set { _glzxyj = value; }
            get { return _glzxyj; }
        }
        /// <summary>
        /// 管理中心签字
        /// </summary>
        public string GLZXQZ
        {
            set { _glzxqz = value; }
            get { return _glzxqz; }
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
        #endregion Model

    }
}

