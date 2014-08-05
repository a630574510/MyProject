using System;
using System.Collections.Generic;
using System.Text;

namespace Citic.Model
{
    /// <summary>
    /// 汽车巡店报告模版类(2013.7.29)
    /// </summary>
    public class M_XunDianReport
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _DealerID;

        public int DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }
        private string _DealerName;
        /// <summary>
        /// 经销商名
        /// </summary>
        public string DealerName
        {
            get { return _DealerName; }
            set { _DealerName = value; }
        }
        private string _Address;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private int _BankID;

        public int BankID
        {
            get { return _BankID; }
            set { _BankID = value; }
        }
        private string _BankName;
        /// <summary>
        /// 与该经销商合作的所有银行名，逗号区分。
        /// </summary>
        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }
        private string _BrandIDs;

        public string BrandIDs
        {
            get { return _BrandIDs; }
            set { _BrandIDs = value; }
        }
        private string _BrandName;
        /// <summary>
        /// 与该经销商合作的所有品牌名，逗号区分。
        /// </summary>
        public string BrandName
        {
            get { return _BrandName; }
            set { _BrandName = value; }
        }
        private DateTime _DispatchTime;
        /// <summary>
        /// 营业时间
        /// </summary>
        public DateTime DispatchTime
        {
            get { return _DispatchTime; }
            set { _DispatchTime = value; }
        }
        private string _DealerType;
        /// <summary>
        /// 经销商类型
        /// </summary>
        public string DealerType
        {
            get { return _DealerType; }
            set { _DealerType = value; }
        }
        private string _IsGroup;
        /// <summary>
        /// 是否是集团性质
        /// </summary>
        public string IsGroup
        {
            get { return _IsGroup; }
            set { _IsGroup = value; }
        }
        private string _IsSingleStore;
        /// <summary>
        /// 是否是单店
        /// </summary>
        public string IsSingleStore
        {
            get { return _IsSingleStore; }
            set { _IsSingleStore = value; }
        }
        private int _Banks;
        /// <summary>
        /// 合作融资行总数
        /// </summary>
        public int Banks
        {
            get { return _Banks; }
            set { _Banks = value; }
        }
        private decimal _AllSSMoney;
        /// <summary>
        /// 合作融资行总额
        /// </summary>
        public decimal AllSSMoney
        {
            get { return _AllSSMoney; }
            set { _AllSSMoney = value; }
        }
    }
}
