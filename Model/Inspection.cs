using System;
using System.Collections.Generic;
using System.Text;

namespace Citic.Model
{
    /// <summary>
    /// tb_Inspection:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Inspection
    {
        public Inspection()
		{}
        #region Model
        private int _id;
        private string _area;
        private string _rummager;
        private string _dealername;
        private string _bank;
        private string _brandname;
        private string _supervisorname;
        private string _model;
        private string _inventory;
        private string _quartersledger;
        private int? _quartersledgerstatu;
        private string _mainproblem;
        private int? _mainproblemstatu;
        private DateTime? _historydate;
        private int? _continuestatu;
        private string _quartersledger_1_results;
        private string _quartersledger_1_people;
        private DateTime? _quartersledger_1_date;
        private string _quartersledger_2_results;
        private string _quartersledger_2_people;
        private DateTime? _quartersledger_2_date;
        private string _quartersledger_3_results;
        private string _quartersledger_3_people;
        private DateTime? _quartersledger_3_date;
        private string _mainproblem_1_results;
        private string _mainproblem_1_people;
        private DateTime? _mainproblem_1_date;
        private string _mainproblem_2_results;
        private string _mainproblem_2_people;
        private DateTime? _mainproblem_2_date;
        private string _mainproblem_3_results;
        private string _mainproblem_3_people;
        private DateTime? _mainproblem_3_date;
        private string _continue_1_results;
        private string _continue_1_people;
        private DateTime? _continue_1_date;
        private string _continue_2_results;
        private string _continue_2_people;
        private DateTime? _continue_2_date;
        private string _continue_3_results;
        private string _continue_3_people;
        private DateTime? _continue_3_date;
        private string _remark;
        private DateTime? _createtime;
        private int? _createid;
        private int? _isconform;
        private int? _isdel;
        private int? _delid;
        private DateTime? _deltime;
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
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Rummager
        {
            set { _rummager = value; }
            get { return _rummager; }
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
        public string Bank
        {
            set { _bank = value; }
            get { return _bank; }
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
        public string SupervisorName
        {
            set { _supervisorname = value; }
            get { return _supervisorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Model
        {
            set { _model = value; }
            get { return _model; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Inventory
        {
            set { _inventory = value; }
            get { return _inventory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger
        {
            set { _quartersledger = value; }
            get { return _quartersledger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? QuartersLedgerStatu
        {
            set { _quartersledgerstatu = value; }
            get { return _quartersledgerstatu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProblem
        {
            set { _mainproblem = value; }
            get { return _mainproblem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MainProblemStatu
        {
            set { _mainproblemstatu = value; }
            get { return _mainproblemstatu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? HistoryDate
        {
            set { _historydate = value; }
            get { return _historydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ContinueStatu
        {
            set { _continuestatu = value; }
            get { return _continuestatu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger_1_Results
        {
            set { _quartersledger_1_results = value; }
            get { return _quartersledger_1_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger_1_People
        {
            set { _quartersledger_1_people = value; }
            get { return _quartersledger_1_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? QuartersLedger_1_Date
        {
            set { _quartersledger_1_date = value; }
            get { return _quartersledger_1_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger_2_Results
        {
            set { _quartersledger_2_results = value; }
            get { return _quartersledger_2_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger_2_People
        {
            set { _quartersledger_2_people = value; }
            get { return _quartersledger_2_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? QuartersLedger_2_Date
        {
            set { _quartersledger_2_date = value; }
            get { return _quartersledger_2_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger_3_Results
        {
            set { _quartersledger_3_results = value; }
            get { return _quartersledger_3_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuartersLedger_3_People
        {
            set { _quartersledger_3_people = value; }
            get { return _quartersledger_3_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? QuartersLedger_3_Date
        {
            set { _quartersledger_3_date = value; }
            get { return _quartersledger_3_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProblem_1_Results
        {
            set { _mainproblem_1_results = value; }
            get { return _mainproblem_1_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProblem_1_People
        {
            set { _mainproblem_1_people = value; }
            get { return _mainproblem_1_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MainProblem_1_Date
        {
            set { _mainproblem_1_date = value; }
            get { return _mainproblem_1_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProblem_2_Results
        {
            set { _mainproblem_2_results = value; }
            get { return _mainproblem_2_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProblem_2_People
        {
            set { _mainproblem_2_people = value; }
            get { return _mainproblem_2_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MainProblem_2_Date
        {
            set { _mainproblem_2_date = value; }
            get { return _mainproblem_2_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProblem_3_Results
        {
            set { _mainproblem_3_results = value; }
            get { return _mainproblem_3_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainProblem_3_People
        {
            set { _mainproblem_3_people = value; }
            get { return _mainproblem_3_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? MainProblem_3_Date
        {
            set { _mainproblem_3_date = value; }
            get { return _mainproblem_3_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Continue_1_Results
        {
            set { _continue_1_results = value; }
            get { return _continue_1_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Continue_1_People
        {
            set { _continue_1_people = value; }
            get { return _continue_1_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Continue_1_Date
        {
            set { _continue_1_date = value; }
            get { return _continue_1_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Continue_2_Results
        {
            set { _continue_2_results = value; }
            get { return _continue_2_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Continue_2_People
        {
            set { _continue_2_people = value; }
            get { return _continue_2_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Continue_2_Date
        {
            set { _continue_2_date = value; }
            get { return _continue_2_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Continue_3_Results
        {
            set { _continue_3_results = value; }
            get { return _continue_3_results; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Continue_3_People
        {
            set { _continue_3_people = value; }
            get { return _continue_3_people; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Continue_3_Date
        {
            set { _continue_3_date = value; }
            get { return _continue_3_date; }
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
        public int? CreateId
        {
            set { _createid = value; }
            get { return _createid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsConform
        {
            set { _isconform = value; }
            get { return _isconform; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DelId
        {
            set { _delid = value; }
            get { return _delid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DelTime
        {
            set { _deltime = value; }
            get { return _deltime; }
        }
        #endregion Model
    }
}
