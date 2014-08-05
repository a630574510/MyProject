using System;
namespace Citic.Model
{
    /// <summary>
    /// Car:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Car
    {
        public Car()
        { }
        #region Model
        private int _id;
        private string _vin;
        private string _draftno;
        private int? _bankid;
        private string _bankname;
        private int? _statu;
        private DateTime? _qualifiednodate;
        private int? _dealerid;
        private string _dealername;
        private int? _brandid;
        private string _brandname;
        private int? _storageid;
        private string _storagename;
        private string _carcolor;
        private string _carmodel;
        private string _engineno;
        private string _qualifiedno;
        private int? _keycount;
        private string _keynumber;
        private string _carcost;
        private string _returncost;
        private string _remarks;
        private DateTime? _transittime;
        private DateTime? _movetime;
        private DateTime? _outtime;
        private int? _createid;
        private DateTime? _createtime;
        private int? _updateid;
        private DateTime? _updatetime;
        private int? _deleteid;
        private DateTime? _deletetime;
        private bool _isdelete;
        private bool _isport;
        private string _gd_id;
        private string _zx_id;
        private string _carclass;
        private string _displacement;
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
        public string Vin
        {
            set { _vin = value; }
            get { return _vin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DraftNo
        {
            set { _draftno = value; }
            get { return _draftno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BankID
        {
            set { _bankid = value; }
            get { return _bankid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Statu
        {
            set { _statu = value; }
            get { return _statu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? QualifiedNoDate
        {
            set { _qualifiednodate = value; }
            get { return _qualifiednodate; }
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
        public int? BrandID
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BrandName
        {
            set { _brandname = value; }
            get { return _brandname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? StorageID
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
        public string CarColor
        {
            set { _carcolor = value; }
            get { return _carcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CarModel
        {
            set { _carmodel = value; }
            get { return _carmodel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EngineNo
        {
            set { _engineno = value; }
            get { return _engineno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QualifiedNo
        {
            set { _qualifiedno = value; }
            get { return _qualifiedno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? KeyCount
        {
            set { _keycount = value; }
            get { return _keycount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KeyNumber
        {
            set { _keynumber = value; }
            get { return _keynumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CarCost
        {
            set { _carcost = value; }
            get { return _carcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnCost
        {
            set { _returncost = value; }
            get { return _returncost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TransitTime
        {
            set { _transittime = value; }
            get { return _transittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MoveTime
        {
            set { _movetime = value; }
            get { return _movetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OutTime
        {
            set { _outtime = value; }
            get { return _outtime; }
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
        public string GD_ID
        {
            set { _gd_id = value; }
            get { return _gd_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZX_ID
        {
            set { _zx_id = value; }
            get { return _zx_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CarClass
        {
            set { _carclass = value; }
            get { return _carclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Displacement
        {
            set { _displacement = value; }
            get { return _displacement; }
        }
        #endregion Model

        #region 扩展字段--乔春羽(2013.12.30)
        public string TableName { get; set; }
        #endregion
    }
}

