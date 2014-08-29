using System;
namespace Citic.Model
{
    /// <summary>
    /// CarMasterplate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CarMasterplate
    {
        public CarMasterplate()
        { }
        #region Model
        private int _id;
        private int? _dealerid;
        private string _dealername;
        private int? _bankid;
        private string _bankname;
        private string _filename1;
        private string _filename2;
        private string _filename3;
        private string _filename4;
        private string _filename5;
        private string _filename6;
        private int? _countcar;
        private int? _createid;
        private string _createname;
        private DateTime? _createtime;
        private int? _typeid;
        private int? _isdel;
        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 经销商id
        /// </summary>
        public int? DealerID
        {
            set { _dealerid = value; }
            get { return _dealerid; }
        }
        /// <summary>
        /// 经销商名称
        /// </summary>
        public string DealerName
        {
            set { _dealername = value; }
            get { return _dealername; }
        }
        /// <summary>
        /// 银行id
        /// </summary>
        public int? BankID
        {
            set { _bankid = value; }
            get { return _bankid; }
        }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 入库确认书
        /// </summary>
        public string FileName1
        {
            set { _filename1 = value; }
            get { return _filename1; }
        }
        /// <summary>
        /// 手工台帐
        /// </summary>
        public string FileName2
        {
            set { _filename2 = value; }
            get { return _filename2; }
        }
        /// <summary>
        /// 钥匙交接
        /// </summary>
        public string FileName3
        {
            set { _filename3 = value; }
            get { return _filename3; }
        }
        /// <summary>
        /// 钥匙借用登记
        /// </summary>
        public string FileName4
        {
            set { _filename4 = value; }
            get { return _filename4; }
        }
        /// <summary>
        /// 申领书或释放书
        /// </summary>
        public string FileName5
        {
            set { _filename5 = value; }
            get { return _filename5; }
        }
        /// <summary>
        /// 二级网点移动申请书
        /// </summary>
        public string FileName6
        {
            set { _filename6 = value; }
            get { return _filename6; }
        }
        /// <summary>
        /// 车辆总数
        /// </summary>
        public int? CountCar
        {
            set { _countcar = value; }
            get { return _countcar; }
        }
        /// <summary>
        /// 添加id
        /// </summary>
        public int? CreateID
        {
            set { _createid = value; }
            get { return _createid; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public string CreateName
        {
            set { _createname = value; }
            get { return _createname; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 1.入库，2.出库，3.移库
        /// </summary>
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? isDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        #endregion Model

    }
}

