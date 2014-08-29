using System;
namespace Citic.Model
{
    /// <summary>
    /// 风险问题处理单表
    /// </summary>
    [Serializable]
    public partial class RisksSolveDocuments
    {
        public RisksSolveDocuments()
        { }
        #region Model
        private int _id;
        private string _no;
        private int? _status;
        private int? _qdmroleid = 0;
        private DateTime? _c_date;
        private string _c_ap;
        private string _c_unit;
        private string _c_p;
        private string _c_post;
        private string _c_pphone;
        private string _c_content;
        private int? _sq_shopid;
        private string _sq_shop;
        private int? _sq_bankid;
        private string _sq_bank;
        private int? _sq_brandid;
        private string _sq_brand;
        private string _sq_name;
        private string _sq_phone;
        private string _sq_fbp;
        private string _sq_fbpp;
        private string _sq_content;
        private string _opfd;
        private bool _opfdpic;
        private string _orcd;
        private bool _orcdpic;
        private string _obd;
        private bool _obdpic;
        private string _result;
        private bool _resultpic;
        private int? _createid;
        private DateTime? _createtime;
        private int? _deleteid;
        private DateTime? _deletetime;
        private bool _isdelete;
        private int? _opfd_optionid;
        private DateTime? _opfd_optiontime;
        private int? _opfdpic_optionid;
        private DateTime? _opfdpic_optiontime;
        private int? _orcd_optionid;
        private DateTime? _orcd_optiontime;
        private int? _orcdpic_optionid;
        private DateTime? _orcdpic_optiontime;
        private int? _obd_optionid;
        private DateTime? _obd_optiontime;
        private int? _obdpic_optionid;
        private DateTime? _obdpic_optiontime;
        private int? _result_optionid;
        private DateTime? _result_optiontime;
        private int? _resultpic_optionid;
        private DateTime? _resultpic_optiontime;
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
        /// 状态（0.未审批  1.已审批）
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// Question-DepartmentManager-RoleID（问题所在部门的部门经理角色ID）
        /// </summary>
        public int? QDMRoleID
        {
            set { _qdmroleid = value; }
            get { return _qdmroleid; }
        }
        /// <summary>
        /// （C-Complaints，投诉）投诉时间
        /// </summary>
        public DateTime? C_Date
        {
            set { _c_date = value; }
            get { return _c_date; }
        }
        /// <summary>
        /// （C_AP-Complaints Accept Person）投诉接收人
        /// </summary>
        public string C_AP
        {
            set { _c_ap = value; }
            get { return _c_ap; }
        }
        /// <summary>
        /// 投诉单位
        /// </summary>
        public string C_Unit
        {
            set { _c_unit = value; }
            get { return _c_unit; }
        }
        /// <summary>
        /// 投诉人
        /// </summary>
        public string C_P
        {
            set { _c_p = value; }
            get { return _c_p; }
        }
        /// <summary>
        /// 投诉人职务
        /// </summary>
        public string C_Post
        {
            set { _c_post = value; }
            get { return _c_post; }
        }
        /// <summary>
        /// 投诉人联系方式
        /// </summary>
        public string C_PPhone
        {
            set { _c_pphone = value; }
            get { return _c_pphone; }
        }
        /// <summary>
        /// 投诉内容
        /// </summary>
        public string C_Content
        {
            set { _c_content = value; }
            get { return _c_content; }
        }
        /// <summary>
        /// （SQ-Supervisor Question，监管员问题）监管店ID
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
        public int? SQ_BankID
        {
            set { _sq_bankid = value; }
            get { return _sq_bankid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SQ_Bank
        {
            set { _sq_bank = value; }
            get { return _sq_bank; }
        }
        /// <summary>
        /// （SQ-Supervisor Question，监管员问题）监管品牌ID
        /// </summary>
        public int? SQ_BrandID
        {
            set { _sq_brandid = value; }
            get { return _sq_brandid; }
        }
        /// <summary>
        /// （SQ-Supervisor Question，监管员问题）监管品牌
        /// </summary>
        public string SQ_Brand
        {
            set { _sq_brand = value; }
            get { return _sq_brand; }
        }
        /// <summary>
        /// （SQ-Supervisor Question，监管员问题）监管员姓名
        /// </summary>
        public string SQ_Name
        {
            set { _sq_name = value; }
            get { return _sq_name; }
        }
        /// <summary>
        /// （SQ-Supervisor Question，监管员问题）监管员联系方式
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
        /// （FBP,Feedback People）问题反馈人联系方式
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
        /// （OPFD-Opinions Problems Found Department）发现问题部门意见
        /// </summary>
        public string OPFD
        {
            set { _opfd = value; }
            get { return _opfd; }
        }
        /// <summary>
        /// （OPFDPIC-Opinions Problems Found Department，Person In Charge）发现问题部门的负责人
        /// </summary>
        public bool OPFDPIC
        {
            set { _opfdpic = value; }
            get { return _opfdpic; }
        }
        /// <summary>
        /// （ORCD-Opinions Risk Control Department）风控部意见
        /// </summary>
        public string ORCD
        {
            set { _orcd = value; }
            get { return _orcd; }
        }
        /// <summary>
        /// （ORCDPIC-Opinions Risk Control Department，Person in Charge）风控部负责人签字
        /// </summary>
        public bool ORCDPIC
        {
            set { _orcdpic = value; }
            get { return _orcdpic; }
        }
        /// <summary>
        /// （OBD-Opinions Business Department）业务部意见
        /// </summary>
        public string OBD
        {
            set { _obd = value; }
            get { return _obd; }
        }
        /// <summary>
        /// （OBDPIC-Opinions Business Department，Person in Charge）业务部负责人签字
        /// </summary>
        public bool OBDPIC
        {
            set { _obdpic = value; }
            get { return _obdpic; }
        }
        /// <summary>
        /// 运营部处理结果
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 运营部负责人签字
        /// </summary>
        public bool ResultPIC
        {
            set { _resultpic = value; }
            get { return _resultpic; }
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
        /// 发现问题部门意见--修改人
        /// </summary>
        public int? OPFD_OptionID
        {
            set { _opfd_optionid = value; }
            get { return _opfd_optionid; }
        }
        /// <summary>
        /// 发现问题部门意见--修改时间
        /// </summary>
        public DateTime? OPFD_OptionTime
        {
            set { _opfd_optiontime = value; }
            get { return _opfd_optiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OPFDPIC_OptionID
        {
            set { _opfdpic_optionid = value; }
            get { return _opfdpic_optionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OPFDPIC_OptionTime
        {
            set { _opfdpic_optiontime = value; }
            get { return _opfdpic_optiontime; }
        }
        /// <summary>
        /// 风控部意见--修改人
        /// </summary>
        public int? ORCD_OptionID
        {
            set { _orcd_optionid = value; }
            get { return _orcd_optionid; }
        }
        /// <summary>
        /// 风控部意见--修改时间
        /// </summary>
        public DateTime? ORCD_OptionTime
        {
            set { _orcd_optiontime = value; }
            get { return _orcd_optiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ORCDPIC_OptionID
        {
            set { _orcdpic_optionid = value; }
            get { return _orcdpic_optionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ORCDPIC_OptionTime
        {
            set { _orcdpic_optiontime = value; }
            get { return _orcdpic_optiontime; }
        }
        /// <summary>
        /// 业务部意见--修改人
        /// </summary>
        public int? OBD_OptionID
        {
            set { _obd_optionid = value; }
            get { return _obd_optionid; }
        }
        /// <summary>
        /// 业务部意见--修改时间
        /// </summary>
        public DateTime? OBD_OptionTime
        {
            set { _obd_optiontime = value; }
            get { return _obd_optiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OBDPIC_OptionID
        {
            set { _obdpic_optionid = value; }
            get { return _obdpic_optionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OBDPIC_OptionTime
        {
            set { _obdpic_optiontime = value; }
            get { return _obdpic_optiontime; }
        }
        /// <summary>
        /// 运营部处理结果--修改人ID
        /// </summary>
        public int? Result_OptionID
        {
            set { _result_optionid = value; }
            get { return _result_optionid; }
        }
        /// <summary>
        /// 运营部处理结果--修改时间
        /// </summary>
        public DateTime? Result_OptionTime
        {
            set { _result_optiontime = value; }
            get { return _result_optiontime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ResultPIC_OptionID
        {
            set { _resultpic_optionid = value; }
            get { return _resultpic_optionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ResultPIC_OptionTime
        {
            set { _resultpic_optiontime = value; }
            get { return _resultpic_optiontime; }
        }
        #endregion Model

    }
}

