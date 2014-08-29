using System;
namespace Citic.Model
{
    /// <summary>
    /// DealerXDReports:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DealerXDReports
    {
        public DealerXDReports()
        { }
        #region Model
        private int _id;
        private int? _dealerid;
        private string _dealername;
        private string _bankid;
        private string _bankname;
        private string _brandid;
        private string _brandname;
        private DateTime? _dispatchtime;
        private string _operationmode;
        private string _address;
        private DateTime? _checkdate;
        private decimal? _checkintime;
        private int? _finbankcount;
        private decimal? _finbankmoney;
        private string _ccs_1_1;
        private string _ccs_1_2;
        private string _ccs_1_3;
        private string _ccs_1_4;
        private string _ccs_2_1;
        private string _ccs_2_2;
        private string _ccs_2_3;
        private string _ccs_3_1;
        private string _ccs_3_2;
        private string _ccs_3_3;
        private string _ccs_4_1;
        private string _ccs_4_2;
        private string _ccs_4_3;
        private string _ccs_5_1;
        private string _ccs_5_2;
        private string _ccs_5_3;
        private string _ccs_6_1;
        private string _ccs_6_2;
        private string _ccs_6_3;
        private string _ccs_7_1;
        private string _ccs_7_2;
        private string _ccs_7_3;
        private string _ccs_8_1;
        private string _ccs_8_2;
        private string _ccs_8_3;
        private string _ccs_9_1;
        private string _ccs_10_1;
        private string _ccs_11_1;
        private string _ccs_12_1;
        private string _ccs_12_2;
        private string _ccs_12_3;
        private string _ccs_13_1;
        private string _ccs_13_3;
        private string _ccs_14_1;
        private string _ccs_14_2;
        private string _ccs_14_3;
        private string _ccs_15_3;
        private string _ccs_16_1;
        private string _ccs_16_2;
        private string _ccs_16_3;
        private string _ccs_17_1;
        private string _ccs_17_2;
        private string _ccs_17_3;
        private string _ccs_18_1;
        private string _ccs_18_2;
        private string _ccs_18_3;
        private string _ccs_19_1;
        private string _ccs_19_2;
        private string _ccs_19_3;
        private string _ccs_20_1;
        private string _ccs_20_2;
        private string _ccs_20_3;
        private string _pic_1_1;
        private string _pic_1_2;
        private string _pic_2_1;
        private string _pic_2_2;
        private string _pic_3_1;
        private string _pic_3_2;
        private string _pic_4_1;
        private string _pic_4_2;
        private string _pic_5_1;
        private string _pic_5_2;
        private string _pic_6_1;
        private string _pic_6_2;
        private string _pic_7_1;
        private string _pic_7_2;
        private string _sgab_1;
        private string _sgab_2;
        private string _cws_name;
        private string _cws_post;
        private string _cws_content;
        private string _checkresults;
        private string _bis_name;
        private string _bis_phone_pf;
        private string _bis_phone_jj;
        private string _bis_sex;
        private string _bis_edu;
        private int? _bis_age;
        private string _bis_gsrksx;
        private string _bis_ha;
        private string _bis_brsjsx;
        private string _bis_stay;
        private string _bis_eat;
        private string _bis_cs;
        private string _bis_ws;
        private string _bis_wb;
        private DateTime? _bis_sgtime;
        private DateTime? _bis_jgstime;
        private string _bis_we;
        private string _bis_efs;
        private string _p_s;
        private string _p_sb;
        private string _p_wp;
        private string _p_hgz;
        private string _p_keys;
        private string _p_forms;
        private string _p_shop;
        private string _p_sr;
        private string _p_ck;
        private string _p_ck2;
        private string _p_ss;
        private string _p_dfry;
        private string _checkman;
        private DateTime? _checkdate2;
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
        public string BankID
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
        public string BrandID
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
        /// 营业时间
        /// </summary>
        public DateTime? DispatchTime
        {
            set { _dispatchtime = value; }
            get { return _dispatchtime; }
        }
        /// <summary>
        /// 操作模式
        /// </summary>
        public string OperationMode
        {
            set { _operationmode = value; }
            get { return _operationmode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 检查日期
        /// </summary>
        public DateTime? CheckDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// 检查用时
        /// </summary>
        public decimal? CheckInTime
        {
            set { _checkintime = value; }
            get { return _checkintime; }
        }
        /// <summary>
        /// 融资行数量（即合作行的数量）
        /// </summary>
        public int? FinBankCount
        {
            set { _finbankcount = value; }
            get { return _finbankcount; }
        }
        /// <summary>
        /// 合作融资行总额
        /// </summary>
        public decimal? FinBankMoney
        {
            set { _finbankmoney = value; }
            get { return _finbankmoney; }
        }
        /// <summary>
        /// （CCS——CheckContents，检查内容信息）两个数字分别表示行与列
        /// </summary>
        public string CCS_1_1
        {
            set { _ccs_1_1 = value; }
            get { return _ccs_1_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_1_2
        {
            set { _ccs_1_2 = value; }
            get { return _ccs_1_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_1_3
        {
            set { _ccs_1_3 = value; }
            get { return _ccs_1_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_1_4
        {
            set { _ccs_1_4 = value; }
            get { return _ccs_1_4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_2_1
        {
            set { _ccs_2_1 = value; }
            get { return _ccs_2_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_2_2
        {
            set { _ccs_2_2 = value; }
            get { return _ccs_2_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_2_3
        {
            set { _ccs_2_3 = value; }
            get { return _ccs_2_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_3_1
        {
            set { _ccs_3_1 = value; }
            get { return _ccs_3_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_3_2
        {
            set { _ccs_3_2 = value; }
            get { return _ccs_3_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_3_3
        {
            set { _ccs_3_3 = value; }
            get { return _ccs_3_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_4_1
        {
            set { _ccs_4_1 = value; }
            get { return _ccs_4_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_4_2
        {
            set { _ccs_4_2 = value; }
            get { return _ccs_4_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_4_3
        {
            set { _ccs_4_3 = value; }
            get { return _ccs_4_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_5_1
        {
            set { _ccs_5_1 = value; }
            get { return _ccs_5_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_5_2
        {
            set { _ccs_5_2 = value; }
            get { return _ccs_5_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_5_3
        {
            set { _ccs_5_3 = value; }
            get { return _ccs_5_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_6_1
        {
            set { _ccs_6_1 = value; }
            get { return _ccs_6_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_6_2
        {
            set { _ccs_6_2 = value; }
            get { return _ccs_6_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_6_3
        {
            set { _ccs_6_3 = value; }
            get { return _ccs_6_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_7_1
        {
            set { _ccs_7_1 = value; }
            get { return _ccs_7_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_7_2
        {
            set { _ccs_7_2 = value; }
            get { return _ccs_7_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_7_3
        {
            set { _ccs_7_3 = value; }
            get { return _ccs_7_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_8_1
        {
            set { _ccs_8_1 = value; }
            get { return _ccs_8_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_8_2
        {
            set { _ccs_8_2 = value; }
            get { return _ccs_8_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_8_3
        {
            set { _ccs_8_3 = value; }
            get { return _ccs_8_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_9_1
        {
            set { _ccs_9_1 = value; }
            get { return _ccs_9_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_10_1
        {
            set { _ccs_10_1 = value; }
            get { return _ccs_10_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_11_1
        {
            set { _ccs_11_1 = value; }
            get { return _ccs_11_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_12_1
        {
            set { _ccs_12_1 = value; }
            get { return _ccs_12_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_12_2
        {
            set { _ccs_12_2 = value; }
            get { return _ccs_12_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_12_3
        {
            set { _ccs_12_3 = value; }
            get { return _ccs_12_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_13_1
        {
            set { _ccs_13_1 = value; }
            get { return _ccs_13_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_13_3
        {
            set { _ccs_13_3 = value; }
            get { return _ccs_13_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_14_1
        {
            set { _ccs_14_1 = value; }
            get { return _ccs_14_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_14_2
        {
            set { _ccs_14_2 = value; }
            get { return _ccs_14_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_14_3
        {
            set { _ccs_14_3 = value; }
            get { return _ccs_14_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_15_3
        {
            set { _ccs_15_3 = value; }
            get { return _ccs_15_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_16_1
        {
            set { _ccs_16_1 = value; }
            get { return _ccs_16_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_16_2
        {
            set { _ccs_16_2 = value; }
            get { return _ccs_16_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_16_3
        {
            set { _ccs_16_3 = value; }
            get { return _ccs_16_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_17_1
        {
            set { _ccs_17_1 = value; }
            get { return _ccs_17_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_17_2
        {
            set { _ccs_17_2 = value; }
            get { return _ccs_17_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_17_3
        {
            set { _ccs_17_3 = value; }
            get { return _ccs_17_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_18_1
        {
            set { _ccs_18_1 = value; }
            get { return _ccs_18_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_18_2
        {
            set { _ccs_18_2 = value; }
            get { return _ccs_18_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_18_3
        {
            set { _ccs_18_3 = value; }
            get { return _ccs_18_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_19_1
        {
            set { _ccs_19_1 = value; }
            get { return _ccs_19_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_19_2
        {
            set { _ccs_19_2 = value; }
            get { return _ccs_19_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_19_3
        {
            set { _ccs_19_3 = value; }
            get { return _ccs_19_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_20_1
        {
            set { _ccs_20_1 = value; }
            get { return _ccs_20_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_20_2
        {
            set { _ccs_20_2 = value; }
            get { return _ccs_20_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCS_20_3
        {
            set { _ccs_20_3 = value; }
            get { return _ccs_20_3; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_1_1
        {
            set { _pic_1_1 = value; }
            get { return _pic_1_1; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_1_2
        {
            set { _pic_1_2 = value; }
            get { return _pic_1_2; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_2_1
        {
            set { _pic_2_1 = value; }
            get { return _pic_2_1; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_2_2
        {
            set { _pic_2_2 = value; }
            get { return _pic_2_2; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_3_1
        {
            set { _pic_3_1 = value; }
            get { return _pic_3_1; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_3_2
        {
            set { _pic_3_2 = value; }
            get { return _pic_3_2; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_4_1
        {
            set { _pic_4_1 = value; }
            get { return _pic_4_1; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_4_2
        {
            set { _pic_4_2 = value; }
            get { return _pic_4_2; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_5_1
        {
            set { _pic_5_1 = value; }
            get { return _pic_5_1; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_5_2
        {
            set { _pic_5_2 = value; }
            get { return _pic_5_2; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_6_1
        {
            set { _pic_6_1 = value; }
            get { return _pic_6_1; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_6_2
        {
            set { _pic_6_2 = value; }
            get { return _pic_6_2; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_7_1
        {
            set { _pic_7_1 = value; }
            get { return _pic_7_1; }
        }
        /// <summary>
        /// （PIC——Problem In Check，检查过程中发现的问题）
        /// </summary>
        public string PIC_7_2
        {
            set { _pic_7_2 = value; }
            get { return _pic_7_2; }
        }
        /// <summary>
        /// （SGAB——Supervisor Good And Bad，监管员的优缺点）
        /// </summary>
        public string SGAB_1
        {
            set { _sgab_1 = value; }
            get { return _sgab_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SGAB_2
        {
            set { _sgab_2 = value; }
            get { return _sgab_2; }
        }
        /// <summary>
        /// （CWS——Communication With Shop，与店方沟通）
        /// </summary>
        public string CWS_Name
        {
            set { _cws_name = value; }
            get { return _cws_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CWS_Post
        {
            set { _cws_post = value; }
            get { return _cws_post; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CWS_Content
        {
            set { _cws_content = value; }
            get { return _cws_content; }
        }
        /// <summary>
        /// 检查结果
        /// </summary>
        public string CheckResults
        {
            set { _checkresults = value; }
            get { return _checkresults; }
        }
        /// <summary>
        /// （BIS——Basic Information Supervisor，监管员基本信息）
        /// </summary>
        public string BIS_Name
        {
            set { _bis_name = value; }
            get { return _bis_name; }
        }
        /// <summary>
        /// 公司配发手机
        /// </summary>
        public string BIS_Phone_PF
        {
            set { _bis_phone_pf = value; }
            get { return _bis_phone_pf; }
        }
        /// <summary>
        /// 紧急联系电话
        /// </summary>
        public string BIS_Phone_JJ
        {
            set { _bis_phone_jj = value; }
            get { return _bis_phone_jj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BIS_Sex
        {
            set { _bis_sex = value; }
            get { return _bis_sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BIS_Edu
        {
            set { _bis_edu = value; }
            get { return _bis_edu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BIS_Age
        {
            set { _bis_age = value; }
            get { return _bis_age; }
        }
        /// <summary>
        /// 公司认可属性
        /// </summary>
        public string BIS_GSRKSX
        {
            set { _bis_gsrksx = value; }
            get { return _bis_gsrksx; }
        }
        /// <summary>
        /// 户口所在地
        /// </summary>
        public string BIS_HA
        {
            set { _bis_ha = value; }
            get { return _bis_ha; }
        }
        /// <summary>
        /// 本人实际属性
        /// </summary>
        public string BIS_BRSJSX
        {
            set { _bis_brsjsx = value; }
            get { return _bis_brsjsx; }
        }
        /// <summary>
        /// 住宿
        /// </summary>
        public string BIS_Stay
        {
            set { _bis_stay = value; }
            get { return _bis_stay; }
        }
        /// <summary>
        /// 用餐
        /// </summary>
        public string BIS_Eat
        {
            set { _bis_eat = value; }
            get { return _bis_eat; }
        }
        /// <summary>
        /// Computer Skills 电脑技能
        /// </summary>
        public string BIS_CS
        {
            set { _bis_cs = value; }
            get { return _bis_cs; }
        }
        /// <summary>
        /// Work Source，招聘来源
        /// </summary>
        public string BIS_WS
        {
            set { _bis_ws = value; }
            get { return _bis_ws; }
        }
        /// <summary>
        /// Weekend Break，周末休假
        /// </summary>
        public string BIS_WB
        {
            set { _bis_wb = value; }
            get { return _bis_wb; }
        }
        /// <summary>
        /// 初次上岗时间
        /// </summary>
        public DateTime? BIS_SGTime
        {
            set { _bis_sgtime = value; }
            get { return _bis_sgtime; }
        }
        /// <summary>
        /// 监管此店时间
        /// </summary>
        public DateTime? BIS_JGSTime
        {
            set { _bis_jgstime = value; }
            get { return _bis_jgstime; }
        }
        /// <summary>
        /// Work Experience，工作经历
        /// </summary>
        public string BIS_WE
        {
            set { _bis_we = value; }
            get { return _bis_we; }
        }
        /// <summary>
        /// Evaluation For Supervisors，对监管员的评价
        /// </summary>
        public string BIS_EFS
        {
            set { _bis_efs = value; }
            get { return _bis_efs; }
        }
        /// <summary>
        /// P-店面拍照-监管员的照片
        /// </summary>
        public string P_S
        {
            set { _p_s = value; }
            get { return _p_s; }
        }
        /// <summary>
        /// StrongBox 保险柜照片
        /// </summary>
        public string P_SB
        {
            set { _p_sb = value; }
            get { return _p_sb; }
        }
        /// <summary>
        /// StrongBox 保险柜照片
        /// </summary>
        public string P_WP
        {
            set { _p_wp = value; }
            get { return _p_wp; }
        }
        /// <summary>
        /// 合格证保存照
        /// </summary>
        public string P_HGZ
        {
            set { _p_hgz = value; }
            get { return _p_hgz; }
        }
        /// <summary>
        /// 钥匙保存照
        /// </summary>
        public string P_Keys
        {
            set { _p_keys = value; }
            get { return _p_keys; }
        }
        /// <summary>
        /// 表单保存照
        /// </summary>
        public string P_Forms
        {
            set { _p_forms = value; }
            get { return _p_forms; }
        }
        /// <summary>
        /// 店面照
        /// </summary>
        public string P_Shop
        {
            set { _p_shop = value; }
            get { return _p_shop; }
        }
        /// <summary>
        /// ShowRoom 展厅照
        /// </summary>
        public string P_SR
        {
            set { _p_sr = value; }
            get { return _p_sr; }
        }
        /// <summary>
        /// 车库照
        /// </summary>
        public string P_CK
        {
            set { _p_ck = value; }
            get { return _p_ck; }
        }
        /// <summary>
        /// 车库2照
        /// </summary>
        public string P_CK2
        {
            set { _p_ck2 = value; }
            get { return _p_ck2; }
        }
        /// <summary>
        /// 宿舍照
        /// </summary>
        public string P_SS
        {
            set { _p_ss = value; }
            get { return _p_ss; }
        }
        /// <summary>
        /// 店方荣誉证书照
        /// </summary>
        public string P_DFRY
        {
            set { _p_dfry = value; }
            get { return _p_dfry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Checkman
        {
            set { _checkman = value; }
            get { return _checkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CheckDate2
        {
            set { _checkdate2 = value; }
            get { return _checkdate2; }
        }
        #endregion Model

        #region 新增字段--乔春羽(2013.8.5)
        private string _DealerType;
        /// <summary>
        /// 经销商类型
        /// </summary>
        public string DealerType
        {
            get { return _DealerType; }
            set { _DealerType = value; }
        }
        private bool _IsGroup;
        /// <summary>
        /// 是否是集团性质
        /// </summary>
        public bool IsGroup
        {
            get { return _IsGroup; }
            set { _IsGroup = value; }
        }
        private bool _IsSingleStore;
        /// <summary>
        /// 是否是单店
        /// </summary>
        public bool IsSingleStore
        {
            get { return _IsSingleStore; }
            set { _IsSingleStore = value; }
        }
        #endregion
    }
}

