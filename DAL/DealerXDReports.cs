using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:DealerXDReports
    /// </summary>
    public partial class DealerXDReports
    {
        public DealerXDReports()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DealerXDReports");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DealerXDReports(");
            strSql.Append("DealerID,DealerName,BankID,BankName,BrandID,BrandName,DispatchTime,Address,FinBankCount,FinBankMoney)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@BankID,@BankName,@BrandID,@BrandName,@DispatchTime,@Address,@FinBankCount,@FinBankMoney)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@BankID", SqlDbType.NVarChar,50),
					new SqlParameter("@BankName", SqlDbType.NVarChar,400),
					new SqlParameter("@BrandID", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@DispatchTime", SqlDbType.DateTime),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@FinBankCount", SqlDbType.Int,4),
					new SqlParameter("@FinBankMoney", SqlDbType.Money,8)
                                        };

            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.DispatchTime;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.FinBankCount;
            parameters[9].Value = model.FinBankMoney;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("DispatchTime=@DispatchTime,");
            strSql.Append("OperationMode=@OperationMode,");
            strSql.Append("Address=@Address,");
            strSql.Append("CheckDate=@CheckDate,");
            strSql.Append("CheckInTime=@CheckInTime,");
            strSql.Append("FinBankCount=@FinBankCount,");
            strSql.Append("FinBankMoney=@FinBankMoney,");
            strSql.Append("CCS_1_1=@CCS_1_1,");
            strSql.Append("CCS_1_2=@CCS_1_2,");
            strSql.Append("CCS_1_3=@CCS_1_3,");
            strSql.Append("CCS_1_4=@CCS_1_4,");
            strSql.Append("CCS_2_1=@CCS_2_1,");
            strSql.Append("CCS_2_2=@CCS_2_2,");
            strSql.Append("CCS_2_3=@CCS_2_3,");
            strSql.Append("CCS_3_1=@CCS_3_1,");
            strSql.Append("CCS_3_2=@CCS_3_2,");
            strSql.Append("CCS_3_3=@CCS_3_3,");
            strSql.Append("CCS_4_1=@CCS_4_1,");
            strSql.Append("CCS_4_2=@CCS_4_2,");
            strSql.Append("CCS_4_3=@CCS_4_3,");
            strSql.Append("CCS_5_1=@CCS_5_1,");
            strSql.Append("CCS_5_2=@CCS_5_2,");
            strSql.Append("CCS_5_3=@CCS_5_3,");
            strSql.Append("CCS_6_1=@CCS_6_1,");
            strSql.Append("CCS_6_2=@CCS_6_2,");
            strSql.Append("CCS_6_3=@CCS_6_3,");
            strSql.Append("CCS_7_1=@CCS_7_1,");
            strSql.Append("CCS_7_2=@CCS_7_2,");
            strSql.Append("CCS_7_3=@CCS_7_3,");
            strSql.Append("CCS_8_1=@CCS_8_1,");
            strSql.Append("CCS_8_2=@CCS_8_2,");
            strSql.Append("CCS_8_3=@CCS_8_3,");
            strSql.Append("CCS_9_1=@CCS_9_1,");
            strSql.Append("CCS_10_1=@CCS_10_1,");
            strSql.Append("CCS_11_1=@CCS_11_1,");
            strSql.Append("CCS_12_1=@CCS_12_1,");
            strSql.Append("CCS_12_2=@CCS_12_2,");
            strSql.Append("CCS_12_3=@CCS_12_3,");
            strSql.Append("CCS_13_1=@CCS_13_1,");
            strSql.Append("CCS_13_3=@CCS_13_3,");
            strSql.Append("CCS_14_1=@CCS_14_1,");
            strSql.Append("CCS_14_2=@CCS_14_2,");
            strSql.Append("CCS_14_3=@CCS_14_3,");
            strSql.Append("CCS_15_3=@CCS_15_3,");
            strSql.Append("CCS_16_1=@CCS_16_1,");
            strSql.Append("CCS_16_2=@CCS_16_2,");
            strSql.Append("CCS_16_3=@CCS_16_3,");
            strSql.Append("CCS_17_1=@CCS_17_1,");
            strSql.Append("CCS_17_2=@CCS_17_2,");
            strSql.Append("CCS_17_3=@CCS_17_3,");
            strSql.Append("CCS_18_1=@CCS_18_1,");
            strSql.Append("CCS_18_2=@CCS_18_2,");
            strSql.Append("CCS_18_3=@CCS_18_3,");
            strSql.Append("CCS_19_1=@CCS_19_1,");
            strSql.Append("CCS_19_2=@CCS_19_2,");
            strSql.Append("CCS_19_3=@CCS_19_3,");
            strSql.Append("CCS_20_1=@CCS_20_1,");
            strSql.Append("CCS_20_2=@CCS_20_2,");
            strSql.Append("CCS_20_3=@CCS_20_3,");
            strSql.Append("PIC_1_1=@PIC_1_1,");
            strSql.Append("PIC_1_2=@PIC_1_2,");
            strSql.Append("PIC_2_1=@PIC_2_1,");
            strSql.Append("PIC_2_2=@PIC_2_2,");
            strSql.Append("PIC_3_1=@PIC_3_1,");
            strSql.Append("PIC_3_2=@PIC_3_2,");
            strSql.Append("PIC_4_1=@PIC_4_1,");
            strSql.Append("PIC_4_2=@PIC_4_2,");
            strSql.Append("PIC_5_1=@PIC_5_1,");
            strSql.Append("PIC_5_2=@PIC_5_2,");
            strSql.Append("PIC_6_1=@PIC_6_1,");
            strSql.Append("PIC_6_2=@PIC_6_2,");
            strSql.Append("PIC_7_1=@PIC_7_1,");
            strSql.Append("PIC_7_2=@PIC_7_2,");
            strSql.Append("SGAB_1=@SGAB_1,");
            strSql.Append("SGAB_2=@SGAB_2,");
            strSql.Append("CWS_Name=@CWS_Name,");
            strSql.Append("CWS_Post=@CWS_Post,");
            strSql.Append("CWS_Content=@CWS_Content,");
            strSql.Append("CheckResults=@CheckResults,");
            strSql.Append("BIS_Name=@BIS_Name,");
            strSql.Append("BIS_Phone_PF=@BIS_Phone_PF,");
            strSql.Append("BIS_Phone_JJ=@BIS_Phone_JJ,");
            strSql.Append("BIS_Sex=@BIS_Sex,");
            strSql.Append("BIS_Edu=@BIS_Edu,");
            strSql.Append("BIS_Age=@BIS_Age,");
            strSql.Append("BIS_GSRKSX=@BIS_GSRKSX,");
            strSql.Append("BIS_HA=@BIS_HA,");
            strSql.Append("BIS_BRSJSX=@BIS_BRSJSX,");
            strSql.Append("BIS_Stay=@BIS_Stay,");
            strSql.Append("BIS_Eat=@BIS_Eat,");
            strSql.Append("BIS_CS=@BIS_CS,");
            strSql.Append("BIS_WS=@BIS_WS,");
            strSql.Append("BIS_WB=@BIS_WB,");
            strSql.Append("BIS_SGTime=@BIS_SGTime,");
            strSql.Append("BIS_JGSTime=@BIS_JGSTime,");
            strSql.Append("BIS_WE=@BIS_WE,");
            strSql.Append("BIS_EFS=@BIS_EFS,");
            strSql.Append("P_S=@P_S,");
            strSql.Append("P_SB=@P_SB,");
            strSql.Append("P_WP=@P_WP,");
            strSql.Append("P_HGZ=@P_HGZ,");
            strSql.Append("P_Keys=@P_Keys,");
            strSql.Append("P_Forms=@P_Forms,");
            strSql.Append("P_Shop=@P_Shop,");
            strSql.Append("P_SR=@P_SR,");
            strSql.Append("P_CK=@P_CK,");
            strSql.Append("P_CK2=@P_CK2,");
            strSql.Append("P_SS=@P_SS,");
            strSql.Append("P_DFRY=@P_DFRY,");
            strSql.Append("Checkman=@Checkman,");
            strSql.Append("CheckDate2=@CheckDate2");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@BankID", SqlDbType.NVarChar,50),
					new SqlParameter("@BankName", SqlDbType.NVarChar,400),
					new SqlParameter("@BrandID", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@DispatchTime", SqlDbType.DateTime),
					new SqlParameter("@OperationMode", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@CheckInTime", SqlDbType.Decimal,9),
					new SqlParameter("@FinBankCount", SqlDbType.Int,4),
					new SqlParameter("@FinBankMoney", SqlDbType.Money,8),
					new SqlParameter("@CCS_1_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_1_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_1_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_1_4", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_2_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_2_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_2_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_3_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_3_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_3_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_4_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_4_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_4_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_5_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_5_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_5_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_6_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_6_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_6_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_7_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_7_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_7_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_8_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_8_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_8_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_9_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_10_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_11_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_12_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_12_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_12_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_13_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_13_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_14_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_14_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_14_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_15_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_16_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_16_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_16_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_17_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_17_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_17_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_18_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_18_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_18_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_19_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_19_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_19_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_20_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_20_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_20_3", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_1_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_1_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_2_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_2_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_3_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_3_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_4_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_4_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_5_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_5_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_6_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_6_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_7_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_7_2", SqlDbType.NVarChar,200),
					new SqlParameter("@SGAB_1", SqlDbType.NVarChar,200),
					new SqlParameter("@SGAB_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CWS_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@CWS_Post", SqlDbType.NVarChar,50),
					new SqlParameter("@CWS_Content", SqlDbType.NVarChar,1000),
					new SqlParameter("@CheckResults", SqlDbType.NVarChar,1000),
					new SqlParameter("@BIS_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@BIS_Phone_PF", SqlDbType.NVarChar,20),
					new SqlParameter("@BIS_Phone_JJ", SqlDbType.NVarChar,20),
					new SqlParameter("@BIS_Sex", SqlDbType.NVarChar,5),
					new SqlParameter("@BIS_Edu", SqlDbType.NVarChar,20),
					new SqlParameter("@BIS_Age", SqlDbType.Int,4),
					new SqlParameter("@BIS_GSRKSX", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_HA", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_BRSJSX", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_Stay", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_Eat", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_CS", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_WS", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_WB", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_SGTime", SqlDbType.DateTime),
					new SqlParameter("@BIS_JGSTime", SqlDbType.DateTime),
					new SqlParameter("@BIS_WE", SqlDbType.NVarChar,500),
					new SqlParameter("@BIS_EFS", SqlDbType.NVarChar,200),
					new SqlParameter("@P_S", SqlDbType.NVarChar,500),
					new SqlParameter("@P_SB", SqlDbType.NVarChar,500),
					new SqlParameter("@P_WP", SqlDbType.NVarChar,500),
					new SqlParameter("@P_HGZ", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Keys", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Forms", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Shop", SqlDbType.NVarChar,500),
					new SqlParameter("@P_SR", SqlDbType.NVarChar,500),
					new SqlParameter("@P_CK", SqlDbType.NVarChar,500),
					new SqlParameter("@P_CK2", SqlDbType.NVarChar,500),
					new SqlParameter("@P_SS", SqlDbType.NVarChar,500),
					new SqlParameter("@P_DFRY", SqlDbType.NVarChar,500),
					new SqlParameter("@Checkman", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate2", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.DispatchTime;
            parameters[7].Value = model.OperationMode;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.CheckDate;
            parameters[10].Value = model.CheckInTime;
            parameters[11].Value = model.FinBankCount;
            parameters[12].Value = model.FinBankMoney;
            parameters[13].Value = model.CCS_1_1;
            parameters[14].Value = model.CCS_1_2;
            parameters[15].Value = model.CCS_1_3;
            parameters[16].Value = model.CCS_1_4;
            parameters[17].Value = model.CCS_2_1;
            parameters[18].Value = model.CCS_2_2;
            parameters[19].Value = model.CCS_2_3;
            parameters[20].Value = model.CCS_3_1;
            parameters[21].Value = model.CCS_3_2;
            parameters[22].Value = model.CCS_3_3;
            parameters[23].Value = model.CCS_4_1;
            parameters[24].Value = model.CCS_4_2;
            parameters[25].Value = model.CCS_4_3;
            parameters[26].Value = model.CCS_5_1;
            parameters[27].Value = model.CCS_5_2;
            parameters[28].Value = model.CCS_5_3;
            parameters[29].Value = model.CCS_6_1;
            parameters[30].Value = model.CCS_6_2;
            parameters[31].Value = model.CCS_6_3;
            parameters[32].Value = model.CCS_7_1;
            parameters[33].Value = model.CCS_7_2;
            parameters[34].Value = model.CCS_7_3;
            parameters[35].Value = model.CCS_8_1;
            parameters[36].Value = model.CCS_8_2;
            parameters[37].Value = model.CCS_8_3;
            parameters[38].Value = model.CCS_9_1;
            parameters[39].Value = model.CCS_10_1;
            parameters[40].Value = model.CCS_11_1;
            parameters[41].Value = model.CCS_12_1;
            parameters[42].Value = model.CCS_12_2;
            parameters[43].Value = model.CCS_12_3;
            parameters[44].Value = model.CCS_13_1;
            parameters[45].Value = model.CCS_13_3;
            parameters[46].Value = model.CCS_14_1;
            parameters[47].Value = model.CCS_14_2;
            parameters[48].Value = model.CCS_14_3;
            parameters[49].Value = model.CCS_15_3;
            parameters[50].Value = model.CCS_16_1;
            parameters[51].Value = model.CCS_16_2;
            parameters[52].Value = model.CCS_16_3;
            parameters[53].Value = model.CCS_17_1;
            parameters[54].Value = model.CCS_17_2;
            parameters[55].Value = model.CCS_17_3;
            parameters[56].Value = model.CCS_18_1;
            parameters[57].Value = model.CCS_18_2;
            parameters[58].Value = model.CCS_18_3;
            parameters[59].Value = model.CCS_19_1;
            parameters[60].Value = model.CCS_19_2;
            parameters[61].Value = model.CCS_19_3;
            parameters[62].Value = model.CCS_20_1;
            parameters[63].Value = model.CCS_20_2;
            parameters[64].Value = model.CCS_20_3;
            parameters[65].Value = model.PIC_1_1;
            parameters[66].Value = model.PIC_1_2;
            parameters[67].Value = model.PIC_2_1;
            parameters[68].Value = model.PIC_2_2;
            parameters[69].Value = model.PIC_3_1;
            parameters[70].Value = model.PIC_3_2;
            parameters[71].Value = model.PIC_4_1;
            parameters[72].Value = model.PIC_4_2;
            parameters[73].Value = model.PIC_5_1;
            parameters[74].Value = model.PIC_5_2;
            parameters[75].Value = model.PIC_6_1;
            parameters[76].Value = model.PIC_6_2;
            parameters[77].Value = model.PIC_7_1;
            parameters[78].Value = model.PIC_7_2;
            parameters[79].Value = model.SGAB_1;
            parameters[80].Value = model.SGAB_2;
            parameters[81].Value = model.CWS_Name;
            parameters[82].Value = model.CWS_Post;
            parameters[83].Value = model.CWS_Content;
            parameters[84].Value = model.CheckResults;
            parameters[85].Value = model.BIS_Name;
            parameters[86].Value = model.BIS_Phone_PF;
            parameters[87].Value = model.BIS_Phone_JJ;
            parameters[88].Value = model.BIS_Sex;
            parameters[89].Value = model.BIS_Edu;
            parameters[90].Value = model.BIS_Age;
            parameters[91].Value = model.BIS_GSRKSX;
            parameters[92].Value = model.BIS_HA;
            parameters[93].Value = model.BIS_BRSJSX;
            parameters[94].Value = model.BIS_Stay;
            parameters[95].Value = model.BIS_Eat;
            parameters[96].Value = model.BIS_CS;
            parameters[97].Value = model.BIS_WS;
            parameters[98].Value = model.BIS_WB;
            parameters[99].Value = model.BIS_SGTime;
            parameters[100].Value = model.BIS_JGSTime;
            parameters[101].Value = model.BIS_WE;
            parameters[102].Value = model.BIS_EFS;
            parameters[103].Value = model.P_S;
            parameters[104].Value = model.P_SB;
            parameters[105].Value = model.P_WP;
            parameters[106].Value = model.P_HGZ;
            parameters[107].Value = model.P_Keys;
            parameters[108].Value = model.P_Forms;
            parameters[109].Value = model.P_Shop;
            parameters[110].Value = model.P_SR;
            parameters[111].Value = model.P_CK;
            parameters[112].Value = model.P_CK2;
            parameters[113].Value = model.P_SS;
            parameters[114].Value = model.P_DFRY;
            parameters[115].Value = model.Checkman;
            parameters[116].Value = model.CheckDate2;
            parameters[117].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_DealerXDReports ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_DealerXDReports ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.DealerXDReports GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 T.ID,T.DealerID,T.DealerName,T.BankID,T.BankName,T.BrandID,T.BrandName,dl.DealerType,dl.IsGroup,dl.IsSingleStore,T.DispatchTime,T.OperationMode,T.Address,T.CheckDate,T.CheckInTime,T.FinBankCount,T.FinBankMoney,T.CCS_1_1,T.CCS_1_2,T.CCS_1_3,T.CCS_1_4,T.CCS_2_1,T.CCS_2_2,T.CCS_2_3,T.CCS_3_1,T.CCS_3_2,T.CCS_3_3,T.CCS_4_1,T.CCS_4_2,T.CCS_4_3,T.CCS_5_1,T.CCS_5_2,T.CCS_5_3,T.CCS_6_1,T.CCS_6_2,T.CCS_6_3,T.CCS_7_1,T.CCS_7_2,T.CCS_7_3,T.CCS_8_1,T.CCS_8_2,T.CCS_8_3,T.CCS_9_1,T.CCS_10_1,T.CCS_11_1,T.CCS_12_1,T.CCS_12_2,T.CCS_12_3,T.CCS_13_1,T.CCS_13_3,T.CCS_14_1,T.CCS_14_2,T.CCS_14_3,T.CCS_15_3,T.CCS_16_1,T.CCS_16_2,T.CCS_16_3,T.CCS_17_1,T.CCS_17_2,T.CCS_17_3,T.CCS_18_1,T.CCS_18_2,T.CCS_18_3,T.CCS_19_1,T.CCS_19_2,T.CCS_19_3,T.CCS_20_1,T.CCS_20_2,T.CCS_20_3,T.PIC_1_1,T.PIC_1_2,T.PIC_2_1,T.PIC_2_2,T.PIC_3_1,T.PIC_3_2,T.PIC_4_1,T.PIC_4_2,T.PIC_5_1,T.PIC_5_2,T.PIC_6_1,T.PIC_6_2,T.PIC_7_1,T.PIC_7_2,T.SGAB_1,T.SGAB_2,T.CWS_Name,T.CWS_Post,T.CWS_Content,T.CheckResults,T.BIS_Name,T.BIS_Phone_PF,T.BIS_Phone_JJ,T.BIS_Sex,T.BIS_Edu,T.BIS_Age,T.BIS_GSRKSX,T.BIS_HA,T.BIS_BRSJSX,T.BIS_Stay,T.BIS_Eat,T.BIS_CS,T.BIS_WS,T.BIS_WB,T.BIS_SGTime,T.BIS_JGSTime,T.BIS_WE,T.BIS_EFS,T.P_S,T.P_SB,T.P_WP,T.P_HGZ,T.P_Keys,T.P_Forms,T.P_Shop,T.P_SR,T.P_CK,T.P_CK2,T.P_SS,T.P_DFRY,T.Checkman,T.CheckDate2 from tb_DealerXDReports T");
            strSql.AppendLine(" left join tb_Dealer_List dl on T.DealerID=dl.DealerID");
            strSql.Append(" where T.ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.DealerXDReports DataRowToModel(DataRow row)
        {
            Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DealerID"] != null && row["DealerID"].ToString() != "")
                {
                    model.DealerID = int.Parse(row["DealerID"].ToString());
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["BankID"] != null)
                {
                    model.BankID = row["BankID"].ToString();
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["BrandID"] != null)
                {
                    model.BrandID = row["BrandID"].ToString();
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
                }
                if (row["DealerType"] != null)
                {
                    model.DealerType = row["DealerType"].ToString();
                }
                if (row["IsGroup"] != null)
                {
                    model.IsGroup = Convert.ToBoolean(row["IsGroup"]);
                }
                if (row["IsSingleStore"] != null)
                {
                    model.IsSingleStore = Convert.ToBoolean(row["IsSingleStore"]);
                }
                if (row["DispatchTime"] != null && row["DispatchTime"].ToString() != "")
                {
                    model.DispatchTime = DateTime.Parse(row["DispatchTime"].ToString());
                }
                if (row["OperationMode"] != null)
                {
                    model.OperationMode = row["OperationMode"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["CheckDate"] != null && row["CheckDate"].ToString() != "")
                {
                    model.CheckDate = DateTime.Parse(row["CheckDate"].ToString());
                }
                if (row["CheckInTime"] != null && row["CheckInTime"].ToString() != "")
                {
                    model.CheckInTime = decimal.Parse(row["CheckInTime"].ToString());
                }
                if (row["FinBankCount"] != null && row["FinBankCount"].ToString() != "")
                {
                    model.FinBankCount = int.Parse(row["FinBankCount"].ToString());
                }
                if (row["FinBankMoney"] != null && row["FinBankMoney"].ToString() != "")
                {
                    model.FinBankMoney = decimal.Parse(row["FinBankMoney"].ToString());
                }
                if (row["CCS_1_1"] != null)
                {
                    model.CCS_1_1 = row["CCS_1_1"].ToString();
                }
                if (row["CCS_1_2"] != null)
                {
                    model.CCS_1_2 = row["CCS_1_2"].ToString();
                }
                if (row["CCS_1_3"] != null)
                {
                    model.CCS_1_3 = row["CCS_1_3"].ToString();
                }
                if (row["CCS_1_4"] != null)
                {
                    model.CCS_1_4 = row["CCS_1_4"].ToString();
                }
                if (row["CCS_2_1"] != null)
                {
                    model.CCS_2_1 = row["CCS_2_1"].ToString();
                }
                if (row["CCS_2_2"] != null)
                {
                    model.CCS_2_2 = row["CCS_2_2"].ToString();
                }
                if (row["CCS_2_3"] != null)
                {
                    model.CCS_2_3 = row["CCS_2_3"].ToString();
                }
                if (row["CCS_3_1"] != null)
                {
                    model.CCS_3_1 = row["CCS_3_1"].ToString();
                }
                if (row["CCS_3_2"] != null)
                {
                    model.CCS_3_2 = row["CCS_3_2"].ToString();
                }
                if (row["CCS_3_3"] != null)
                {
                    model.CCS_3_3 = row["CCS_3_3"].ToString();
                }
                if (row["CCS_4_1"] != null)
                {
                    model.CCS_4_1 = row["CCS_4_1"].ToString();
                }
                if (row["CCS_4_2"] != null)
                {
                    model.CCS_4_2 = row["CCS_4_2"].ToString();
                }
                if (row["CCS_4_3"] != null)
                {
                    model.CCS_4_3 = row["CCS_4_3"].ToString();
                }
                if (row["CCS_5_1"] != null)
                {
                    model.CCS_5_1 = row["CCS_5_1"].ToString();
                }
                if (row["CCS_5_2"] != null)
                {
                    model.CCS_5_2 = row["CCS_5_2"].ToString();
                }
                if (row["CCS_5_3"] != null)
                {
                    model.CCS_5_3 = row["CCS_5_3"].ToString();
                }
                if (row["CCS_6_1"] != null)
                {
                    model.CCS_6_1 = row["CCS_6_1"].ToString();
                }
                if (row["CCS_6_2"] != null)
                {
                    model.CCS_6_2 = row["CCS_6_2"].ToString();
                }
                if (row["CCS_6_3"] != null)
                {
                    model.CCS_6_3 = row["CCS_6_3"].ToString();
                }
                if (row["CCS_7_1"] != null)
                {
                    model.CCS_7_1 = row["CCS_7_1"].ToString();
                }
                if (row["CCS_7_2"] != null)
                {
                    model.CCS_7_2 = row["CCS_7_2"].ToString();
                }
                if (row["CCS_7_3"] != null)
                {
                    model.CCS_7_3 = row["CCS_7_3"].ToString();
                }
                if (row["CCS_8_1"] != null)
                {
                    model.CCS_8_1 = row["CCS_8_1"].ToString();
                }
                if (row["CCS_8_2"] != null)
                {
                    model.CCS_8_2 = row["CCS_8_2"].ToString();
                }
                if (row["CCS_8_3"] != null)
                {
                    model.CCS_8_3 = row["CCS_8_3"].ToString();
                }
                if (row["CCS_9_1"] != null)
                {
                    model.CCS_9_1 = row["CCS_9_1"].ToString();
                }
                if (row["CCS_10_1"] != null)
                {
                    model.CCS_10_1 = row["CCS_10_1"].ToString();
                }
                if (row["CCS_11_1"] != null)
                {
                    model.CCS_11_1 = row["CCS_11_1"].ToString();
                }
                if (row["CCS_12_1"] != null)
                {
                    model.CCS_12_1 = row["CCS_12_1"].ToString();
                }
                if (row["CCS_12_2"] != null)
                {
                    model.CCS_12_2 = row["CCS_12_2"].ToString();
                }
                if (row["CCS_12_3"] != null)
                {
                    model.CCS_12_3 = row["CCS_12_3"].ToString();
                }
                if (row["CCS_13_1"] != null)
                {
                    model.CCS_13_1 = row["CCS_13_1"].ToString();
                }
                if (row["CCS_13_3"] != null)
                {
                    model.CCS_13_3 = row["CCS_13_3"].ToString();
                }
                if (row["CCS_14_1"] != null)
                {
                    model.CCS_14_1 = row["CCS_14_1"].ToString();
                }
                if (row["CCS_14_2"] != null)
                {
                    model.CCS_14_2 = row["CCS_14_2"].ToString();
                }
                if (row["CCS_14_3"] != null)
                {
                    model.CCS_14_3 = row["CCS_14_3"].ToString();
                }
                if (row["CCS_15_3"] != null)
                {
                    model.CCS_15_3 = row["CCS_15_3"].ToString();
                }
                if (row["CCS_16_1"] != null)
                {
                    model.CCS_16_1 = row["CCS_16_1"].ToString();
                }
                if (row["CCS_16_2"] != null)
                {
                    model.CCS_16_2 = row["CCS_16_2"].ToString();
                }
                if (row["CCS_16_3"] != null)
                {
                    model.CCS_16_3 = row["CCS_16_3"].ToString();
                }
                if (row["CCS_17_1"] != null)
                {
                    model.CCS_17_1 = row["CCS_17_1"].ToString();
                }
                if (row["CCS_17_2"] != null)
                {
                    model.CCS_17_2 = row["CCS_17_2"].ToString();
                }
                if (row["CCS_17_3"] != null)
                {
                    model.CCS_17_3 = row["CCS_17_3"].ToString();
                }
                if (row["CCS_18_1"] != null)
                {
                    model.CCS_18_1 = row["CCS_18_1"].ToString();
                }
                if (row["CCS_18_2"] != null)
                {
                    model.CCS_18_2 = row["CCS_18_2"].ToString();
                }
                if (row["CCS_18_3"] != null)
                {
                    model.CCS_18_3 = row["CCS_18_3"].ToString();
                }
                if (row["CCS_19_1"] != null)
                {
                    model.CCS_19_1 = row["CCS_19_1"].ToString();
                }
                if (row["CCS_19_2"] != null)
                {
                    model.CCS_19_2 = row["CCS_19_2"].ToString();
                }
                if (row["CCS_19_3"] != null)
                {
                    model.CCS_19_3 = row["CCS_19_3"].ToString();
                }
                if (row["CCS_20_1"] != null)
                {
                    model.CCS_20_1 = row["CCS_20_1"].ToString();
                }
                if (row["CCS_20_2"] != null)
                {
                    model.CCS_20_2 = row["CCS_20_2"].ToString();
                }
                if (row["CCS_20_3"] != null)
                {
                    model.CCS_20_3 = row["CCS_20_3"].ToString();
                }
                if (row["PIC_1_1"] != null)
                {
                    model.PIC_1_1 = row["PIC_1_1"].ToString();
                }
                if (row["PIC_1_2"] != null)
                {
                    model.PIC_1_2 = row["PIC_1_2"].ToString();
                }
                if (row["PIC_2_1"] != null)
                {
                    model.PIC_2_1 = row["PIC_2_1"].ToString();
                }
                if (row["PIC_2_2"] != null)
                {
                    model.PIC_2_2 = row["PIC_2_2"].ToString();
                }
                if (row["PIC_3_1"] != null)
                {
                    model.PIC_3_1 = row["PIC_3_1"].ToString();
                }
                if (row["PIC_3_2"] != null)
                {
                    model.PIC_3_2 = row["PIC_3_2"].ToString();
                }
                if (row["PIC_4_1"] != null)
                {
                    model.PIC_4_1 = row["PIC_4_1"].ToString();
                }
                if (row["PIC_4_2"] != null)
                {
                    model.PIC_4_2 = row["PIC_4_2"].ToString();
                }
                if (row["PIC_5_1"] != null)
                {
                    model.PIC_5_1 = row["PIC_5_1"].ToString();
                }
                if (row["PIC_5_2"] != null)
                {
                    model.PIC_5_2 = row["PIC_5_2"].ToString();
                }
                if (row["PIC_6_1"] != null)
                {
                    model.PIC_6_1 = row["PIC_6_1"].ToString();
                }
                if (row["PIC_6_2"] != null)
                {
                    model.PIC_6_2 = row["PIC_6_2"].ToString();
                }
                if (row["PIC_7_1"] != null)
                {
                    model.PIC_7_1 = row["PIC_7_1"].ToString();
                }
                if (row["PIC_7_2"] != null)
                {
                    model.PIC_7_2 = row["PIC_7_2"].ToString();
                }
                if (row["SGAB_1"] != null)
                {
                    model.SGAB_1 = row["SGAB_1"].ToString();
                }
                if (row["SGAB_2"] != null)
                {
                    model.SGAB_2 = row["SGAB_2"].ToString();
                }
                if (row["CWS_Name"] != null)
                {
                    model.CWS_Name = row["CWS_Name"].ToString();
                }
                if (row["CWS_Post"] != null)
                {
                    model.CWS_Post = row["CWS_Post"].ToString();
                }
                if (row["CWS_Content"] != null)
                {
                    model.CWS_Content = row["CWS_Content"].ToString();
                }
                if (row["CheckResults"] != null)
                {
                    model.CheckResults = row["CheckResults"].ToString();
                }
                if (row["BIS_Name"] != null)
                {
                    model.BIS_Name = row["BIS_Name"].ToString();
                }
                if (row["BIS_Phone_PF"] != null)
                {
                    model.BIS_Phone_PF = row["BIS_Phone_PF"].ToString();
                }
                if (row["BIS_Phone_JJ"] != null)
                {
                    model.BIS_Phone_JJ = row["BIS_Phone_JJ"].ToString();
                }
                if (row["BIS_Sex"] != null)
                {
                    model.BIS_Sex = row["BIS_Sex"].ToString();
                }
                if (row["BIS_Edu"] != null)
                {
                    model.BIS_Edu = row["BIS_Edu"].ToString();
                }
                if (row["BIS_Age"] != null && row["BIS_Age"].ToString() != "")
                {
                    model.BIS_Age = int.Parse(row["BIS_Age"].ToString());
                }
                if (row["BIS_GSRKSX"] != null)
                {
                    model.BIS_GSRKSX = row["BIS_GSRKSX"].ToString();
                }
                if (row["BIS_HA"] != null)
                {
                    model.BIS_HA = row["BIS_HA"].ToString();
                }
                if (row["BIS_BRSJSX"] != null)
                {
                    model.BIS_BRSJSX = row["BIS_BRSJSX"].ToString();
                }
                if (row["BIS_Stay"] != null)
                {
                    model.BIS_Stay = row["BIS_Stay"].ToString();
                }
                if (row["BIS_Eat"] != null)
                {
                    model.BIS_Eat = row["BIS_Eat"].ToString();
                }
                if (row["BIS_CS"] != null)
                {
                    model.BIS_CS = row["BIS_CS"].ToString();
                }
                if (row["BIS_WS"] != null)
                {
                    model.BIS_WS = row["BIS_WS"].ToString();
                }
                if (row["BIS_WB"] != null)
                {
                    model.BIS_WB = row["BIS_WB"].ToString();
                }
                if (row["BIS_SGTime"] != null && row["BIS_SGTime"].ToString() != "")
                {
                    model.BIS_SGTime = DateTime.Parse(row["BIS_SGTime"].ToString());
                }
                if (row["BIS_JGSTime"] != null && row["BIS_JGSTime"].ToString() != "")
                {
                    model.BIS_JGSTime = DateTime.Parse(row["BIS_JGSTime"].ToString());
                }
                if (row["BIS_WE"] != null)
                {
                    model.BIS_WE = row["BIS_WE"].ToString();
                }
                if (row["BIS_EFS"] != null)
                {
                    model.BIS_EFS = row["BIS_EFS"].ToString();
                }
                if (row["P_S"] != null)
                {
                    model.P_S = row["P_S"].ToString();
                }
                if (row["P_SB"] != null)
                {
                    model.P_SB = row["P_SB"].ToString();
                }
                if (row["P_WP"] != null)
                {
                    model.P_WP = row["P_WP"].ToString();
                }
                if (row["P_HGZ"] != null)
                {
                    model.P_HGZ = row["P_HGZ"].ToString();
                }
                if (row["P_Keys"] != null)
                {
                    model.P_Keys = row["P_Keys"].ToString();
                }
                if (row["P_Forms"] != null)
                {
                    model.P_Forms = row["P_Forms"].ToString();
                }
                if (row["P_Shop"] != null)
                {
                    model.P_Shop = row["P_Shop"].ToString();
                }
                if (row["P_SR"] != null)
                {
                    model.P_SR = row["P_SR"].ToString();
                }
                if (row["P_CK"] != null)
                {
                    model.P_CK = row["P_CK"].ToString();
                }
                if (row["P_CK2"] != null)
                {
                    model.P_CK2 = row["P_CK2"].ToString();
                }
                if (row["P_SS"] != null)
                {
                    model.P_SS = row["P_SS"].ToString();
                }
                if (row["P_DFRY"] != null)
                {
                    model.P_DFRY = row["P_DFRY"].ToString();
                }
                if (row["Checkman"] != null)
                {
                    model.Checkman = row["Checkman"].ToString();
                }
                if (row["CheckDate2"] != null && row["CheckDate2"].ToString() != "")
                {
                    model.CheckDate2 = DateTime.Parse(row["CheckDate2"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,DispatchTime,OperationMode,Address,CheckDate,CheckInTime,FinBankCount,FinBankMoney,CCS_1_1,CCS_1_2,CCS_1_3,CCS_1_4,CCS_2_1,CCS_2_2,CCS_2_3,CCS_3_1,CCS_3_2,CCS_3_3,CCS_4_1,CCS_4_2,CCS_4_3,CCS_5_1,CCS_5_2,CCS_5_3,CCS_6_1,CCS_6_2,CCS_6_3,CCS_7_1,CCS_7_2,CCS_7_3,CCS_8_1,CCS_8_2,CCS_8_3,CCS_9_1,CCS_10_1,CCS_11_1,CCS_12_1,CCS_12_2,CCS_12_3,CCS_13_1,CCS_13_3,CCS_14_1,CCS_14_2,CCS_14_3,CCS_15_3,CCS_16_1,CCS_16_2,CCS_16_3,CCS_17_1,CCS_17_2,CCS_17_3,CCS_18_1,CCS_18_2,CCS_18_3,CCS_19_1,CCS_19_2,CCS_19_3,CCS_20_1,CCS_20_2,CCS_20_3,PIC_1_1,PIC_1_2,PIC_2_1,PIC_2_2,PIC_3_1,PIC_3_2,PIC_4_1,PIC_4_2,PIC_5_1,PIC_5_2,PIC_6_1,PIC_6_2,PIC_7_1,PIC_7_2,SGAB_1,SGAB_2,CWS_Name,CWS_Post,CWS_Content,CheckResults,BIS_Name,BIS_Phone_PF,BIS_Phone_JJ,BIS_Sex,BIS_Edu,BIS_Age,BIS_GSRKSX,BIS_HA,BIS_BRSJSX,BIS_Stay,BIS_Eat,BIS_CS,BIS_WS,BIS_WB,BIS_SGTime,BIS_JGSTime,BIS_WE,BIS_EFS,P_S,P_SB,P_WP,P_HGZ,P_Keys,P_Forms,P_Shop,P_SR,P_CK,P_CK2,P_SS,P_DFRY,Checkman,CheckDate2 ");
            strSql.Append(" FROM tb_DealerXDReports ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,DispatchTime,OperationMode,Address,CheckDate,CheckInTime,FinBankCount,FinBankMoney,CCS_1_1,CCS_1_2,CCS_1_3,CCS_1_4,CCS_2_1,CCS_2_2,CCS_2_3,CCS_3_1,CCS_3_2,CCS_3_3,CCS_4_1,CCS_4_2,CCS_4_3,CCS_5_1,CCS_5_2,CCS_5_3,CCS_6_1,CCS_6_2,CCS_6_3,CCS_7_1,CCS_7_2,CCS_7_3,CCS_8_1,CCS_8_2,CCS_8_3,CCS_9_1,CCS_10_1,CCS_11_1,CCS_12_1,CCS_12_2,CCS_12_3,CCS_13_1,CCS_13_3,CCS_14_1,CCS_14_2,CCS_14_3,CCS_15_3,CCS_16_1,CCS_16_2,CCS_16_3,CCS_17_1,CCS_17_2,CCS_17_3,CCS_18_1,CCS_18_2,CCS_18_3,CCS_19_1,CCS_19_2,CCS_19_3,CCS_20_1,CCS_20_2,CCS_20_3,PIC_1_1,PIC_1_2,PIC_2_1,PIC_2_2,PIC_3_1,PIC_3_2,PIC_4_1,PIC_4_2,PIC_5_1,PIC_5_2,PIC_6_1,PIC_6_2,PIC_7_1,PIC_7_2,SGAB_1,SGAB_2,CWS_Name,CWS_Post,CWS_Content,CheckResults,BIS_Name,BIS_Phone_PF,BIS_Phone_JJ,BIS_Sex,BIS_Edu,BIS_Age,BIS_GSRKSX,BIS_HA,BIS_BRSJSX,BIS_Stay,BIS_Eat,BIS_CS,BIS_WS,BIS_WB,BIS_SGTime,BIS_JGSTime,BIS_WE,BIS_EFS,P_S,P_SB,P_WP,P_HGZ,P_Keys,P_Forms,P_Shop,P_SR,P_CK,P_CK2,P_SS,P_DFRY,Checkman,CheckDate2 ");
            strSql.Append(" FROM tb_DealerXDReports ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_DealerXDReports ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_DealerXDReports T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        #region 更新基本信息--乔春羽(2013.7.30)
        /// <summary>
        /// 更新基本信息
        /// </summary>
        public bool UpdateBasic(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("OperationMode=@OperationMode,");
            strSql.Append("CheckDate=@CheckDate,");
            strSql.Append("CheckInTime=@CheckInTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@OperationMode", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@CheckInTime", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.OperationMode;
            parameters[1].Value = model.CheckDate;
            parameters[2].Value = model.CheckInTime;
            parameters[3].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region 更新检查内容信息--乔春羽(2013.7.30)
        /// <summary>
        /// 更新检查内容信息
        /// </summary>
        public bool UpdateCCS(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("CCS_1_1=@CCS_1_1,");
            strSql.Append("CCS_1_2=@CCS_1_2,");
            strSql.Append("CCS_1_3=@CCS_1_3,");
            strSql.Append("CCS_1_4=@CCS_1_4,");
            strSql.Append("CCS_2_1=@CCS_2_1,");
            strSql.Append("CCS_2_2=@CCS_2_2,");
            strSql.Append("CCS_2_3=@CCS_2_3,");
            strSql.Append("CCS_3_1=@CCS_3_1,");
            strSql.Append("CCS_3_2=@CCS_3_2,");
            strSql.Append("CCS_3_3=@CCS_3_3,");
            strSql.Append("CCS_4_1=@CCS_4_1,");
            strSql.Append("CCS_4_2=@CCS_4_2,");
            strSql.Append("CCS_4_3=@CCS_4_3,");
            strSql.Append("CCS_5_1=@CCS_5_1,");
            strSql.Append("CCS_5_2=@CCS_5_2,");
            strSql.Append("CCS_5_3=@CCS_5_3,");
            strSql.Append("CCS_6_1=@CCS_6_1,");
            strSql.Append("CCS_6_2=@CCS_6_2,");
            strSql.Append("CCS_6_3=@CCS_6_3,");
            strSql.Append("CCS_7_1=@CCS_7_1,");
            strSql.Append("CCS_7_2=@CCS_7_2,");
            strSql.Append("CCS_7_3=@CCS_7_3,");
            strSql.Append("CCS_8_1=@CCS_8_1,");
            strSql.Append("CCS_8_2=@CCS_8_2,");
            strSql.Append("CCS_8_3=@CCS_8_3,");
            strSql.Append("CCS_9_1=@CCS_9_1,");
            strSql.Append("CCS_10_1=@CCS_10_1,");
            strSql.Append("CCS_11_1=@CCS_11_1,");
            strSql.Append("CCS_12_1=@CCS_12_1,");
            strSql.Append("CCS_12_2=@CCS_12_2,");
            strSql.Append("CCS_12_3=@CCS_12_3,");
            strSql.Append("CCS_13_1=@CCS_13_1,");
            strSql.Append("CCS_13_3=@CCS_13_3,");
            strSql.Append("CCS_14_1=@CCS_14_1,");
            strSql.Append("CCS_14_2=@CCS_14_2,");
            strSql.Append("CCS_14_3=@CCS_14_3,");
            strSql.Append("CCS_15_3=@CCS_15_3,");
            strSql.Append("CCS_16_1=@CCS_16_1,");
            strSql.Append("CCS_16_2=@CCS_16_2,");
            strSql.Append("CCS_16_3=@CCS_16_3,");
            strSql.Append("CCS_17_1=@CCS_17_1,");
            strSql.Append("CCS_17_2=@CCS_17_2,");
            strSql.Append("CCS_17_3=@CCS_17_3,");
            strSql.Append("CCS_18_1=@CCS_18_1,");
            strSql.Append("CCS_18_2=@CCS_18_2,");
            strSql.Append("CCS_18_3=@CCS_18_3,");
            strSql.Append("CCS_19_1=@CCS_19_1,");
            strSql.Append("CCS_19_2=@CCS_19_2,");
            strSql.Append("CCS_19_3=@CCS_19_3,");
            strSql.Append("CCS_20_1=@CCS_20_1,");
            strSql.Append("CCS_20_2=@CCS_20_2,");
            strSql.Append("CCS_20_3=@CCS_20_3");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CCS_1_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_1_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_1_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_1_4", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_2_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_2_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_2_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_3_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_3_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_3_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_4_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_4_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_4_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_5_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_5_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_5_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_6_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_6_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_6_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_7_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_7_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_7_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_8_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_8_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_8_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_9_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_10_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_11_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_12_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_12_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_12_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_13_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_13_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_14_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_14_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_14_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_15_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_16_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_16_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_16_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_17_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_17_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_17_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_18_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_18_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_18_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_19_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_19_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_19_3", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_20_1", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_20_2", SqlDbType.NVarChar,200),
					new SqlParameter("@CCS_20_3", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CCS_1_1;
            parameters[1].Value = model.CCS_1_2;
            parameters[2].Value = model.CCS_1_3;
            parameters[3].Value = model.CCS_1_4;
            parameters[4].Value = model.CCS_2_1;
            parameters[5].Value = model.CCS_2_2;
            parameters[6].Value = model.CCS_2_3;
            parameters[7].Value = model.CCS_3_1;
            parameters[8].Value = model.CCS_3_2;
            parameters[9].Value = model.CCS_3_3;
            parameters[10].Value = model.CCS_4_1;
            parameters[11].Value = model.CCS_4_2;
            parameters[12].Value = model.CCS_4_3;
            parameters[13].Value = model.CCS_5_1;
            parameters[14].Value = model.CCS_5_2;
            parameters[15].Value = model.CCS_5_3;
            parameters[16].Value = model.CCS_6_1;
            parameters[17].Value = model.CCS_6_2;
            parameters[18].Value = model.CCS_6_3;
            parameters[19].Value = model.CCS_7_1;
            parameters[20].Value = model.CCS_7_2;
            parameters[21].Value = model.CCS_7_3;
            parameters[22].Value = model.CCS_8_1;
            parameters[23].Value = model.CCS_8_2;
            parameters[24].Value = model.CCS_8_3;
            parameters[25].Value = model.CCS_9_1;
            parameters[26].Value = model.CCS_10_1;
            parameters[27].Value = model.CCS_11_1;
            parameters[28].Value = model.CCS_12_1;
            parameters[29].Value = model.CCS_12_2;
            parameters[30].Value = model.CCS_12_3;
            parameters[31].Value = model.CCS_13_1;
            parameters[32].Value = model.CCS_13_3;
            parameters[33].Value = model.CCS_14_1;
            parameters[34].Value = model.CCS_14_2;
            parameters[35].Value = model.CCS_14_3;
            parameters[36].Value = model.CCS_15_3;
            parameters[37].Value = model.CCS_16_1;
            parameters[38].Value = model.CCS_16_2;
            parameters[39].Value = model.CCS_16_3;
            parameters[40].Value = model.CCS_17_1;
            parameters[41].Value = model.CCS_17_2;
            parameters[42].Value = model.CCS_17_3;
            parameters[43].Value = model.CCS_18_1;
            parameters[44].Value = model.CCS_18_2;
            parameters[45].Value = model.CCS_18_3;
            parameters[46].Value = model.CCS_19_1;
            parameters[47].Value = model.CCS_19_2;
            parameters[48].Value = model.CCS_19_3;
            parameters[49].Value = model.CCS_20_1;
            parameters[50].Value = model.CCS_20_2;
            parameters[51].Value = model.CCS_20_3;
            parameters[52].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region 更新检查过程中发现的问题--乔春羽(2013.7.30)
        /// <summary>
        /// 更新检查过程中发现的问题
        /// </summary>
        public bool UpdatePIC(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("PIC_1_1=@PIC_1_1,");
            strSql.Append("PIC_1_2=@PIC_1_2,");
            strSql.Append("PIC_2_1=@PIC_2_1,");
            strSql.Append("PIC_2_2=@PIC_2_2,");
            strSql.Append("PIC_3_1=@PIC_3_1,");
            strSql.Append("PIC_3_2=@PIC_3_2,");
            strSql.Append("PIC_4_1=@PIC_4_1,");
            strSql.Append("PIC_4_2=@PIC_4_2,");
            strSql.Append("PIC_5_1=@PIC_5_1,");
            strSql.Append("PIC_5_2=@PIC_5_2,");
            strSql.Append("PIC_6_1=@PIC_6_1,");
            strSql.Append("PIC_6_2=@PIC_6_2,");
            strSql.Append("PIC_7_1=@PIC_7_1,");
            strSql.Append("PIC_7_2=@PIC_7_2");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PIC_1_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_1_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_2_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_2_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_3_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_3_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_4_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_4_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_5_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_5_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_6_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_6_2", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_7_1", SqlDbType.NVarChar,200),
					new SqlParameter("@PIC_7_2", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PIC_1_1;
            parameters[1].Value = model.PIC_1_2;
            parameters[2].Value = model.PIC_2_1;
            parameters[3].Value = model.PIC_2_2;
            parameters[4].Value = model.PIC_3_1;
            parameters[5].Value = model.PIC_3_2;
            parameters[6].Value = model.PIC_4_1;
            parameters[7].Value = model.PIC_4_2;
            parameters[8].Value = model.PIC_5_1;
            parameters[9].Value = model.PIC_5_2;
            parameters[10].Value = model.PIC_6_1;
            parameters[11].Value = model.PIC_6_2;
            parameters[12].Value = model.PIC_7_1;
            parameters[13].Value = model.PIC_7_2;
            parameters[14].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region 更新监管员优缺点--乔春羽(2013.7.30)
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSGAB(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("SGAB_1=@SGAB_1,");
            strSql.Append("SGAB_2=@SGAB_2");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@SGAB_1", SqlDbType.NVarChar,200),
					new SqlParameter("@SGAB_2", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.SGAB_1;
            parameters[1].Value = model.SGAB_2;
            parameters[2].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region 更新与店方沟通情况--乔春羽(2013.7.30)
        /// <summary>
        /// 更新与店方沟通情况
        /// </summary>
        public bool UpdateCWS(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("CWS_Name=@CWS_Name,");
            strSql.Append("CWS_Post=@CWS_Post,");
            strSql.Append("CWS_Content=@CWS_Content");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CWS_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@CWS_Post", SqlDbType.NVarChar,50),
					new SqlParameter("@CWS_Content", SqlDbType.NVarChar,1000),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CWS_Name;
            parameters[1].Value = model.CWS_Post;
            parameters[2].Value = model.CWS_Content;
            parameters[3].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region 更新检查结果--乔春羽(2013.7.30)
        /// <summary>
        /// 更新检查结果
        /// </summary>
        public bool UpdateCheckResult(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("CheckResults=@CheckResults");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CheckResults", SqlDbType.NVarChar,1000),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.CheckResults;
            parameters[1].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region 更新监管员基本情况--乔春羽(2013.7.30)
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateBIS(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("BIS_Name=@BIS_Name,");
            strSql.Append("BIS_Phone_PF=@BIS_Phone_PF,");
            strSql.Append("BIS_Phone_JJ=@BIS_Phone_JJ,");
            strSql.Append("BIS_Sex=@BIS_Sex,");
            strSql.Append("BIS_Edu=@BIS_Edu,");
            strSql.Append("BIS_Age=@BIS_Age,");
            strSql.Append("BIS_GSRKSX=@BIS_GSRKSX,");
            strSql.Append("BIS_HA=@BIS_HA,");
            strSql.Append("BIS_BRSJSX=@BIS_BRSJSX,");
            strSql.Append("BIS_Stay=@BIS_Stay,");
            strSql.Append("BIS_Eat=@BIS_Eat,");
            strSql.Append("BIS_CS=@BIS_CS,");
            strSql.Append("BIS_WS=@BIS_WS,");
            strSql.Append("BIS_WB=@BIS_WB,");
            strSql.Append("BIS_SGTime=@BIS_SGTime,");
            strSql.Append("BIS_JGSTime=@BIS_JGSTime,");
            strSql.Append("BIS_WE=@BIS_WE,");
            strSql.Append("BIS_EFS=@BIS_EFS");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BIS_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@BIS_Phone_PF", SqlDbType.NVarChar,20),
					new SqlParameter("@BIS_Phone_JJ", SqlDbType.NVarChar,20),
					new SqlParameter("@BIS_Sex", SqlDbType.NVarChar,5),
					new SqlParameter("@BIS_Edu", SqlDbType.NVarChar,20),
					new SqlParameter("@BIS_Age", SqlDbType.Int,4),
					new SqlParameter("@BIS_GSRKSX", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_HA", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_BRSJSX", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_Stay", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_Eat", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_CS", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_WS", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_WB", SqlDbType.NVarChar,100),
					new SqlParameter("@BIS_SGTime", SqlDbType.DateTime),
					new SqlParameter("@BIS_JGSTime", SqlDbType.DateTime),
					new SqlParameter("@BIS_WE", SqlDbType.NVarChar,500),
					new SqlParameter("@BIS_EFS", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.BIS_Name;
            parameters[1].Value = model.BIS_Phone_PF;
            parameters[2].Value = model.BIS_Phone_JJ;
            parameters[3].Value = model.BIS_Sex;
            parameters[4].Value = model.BIS_Edu;
            parameters[5].Value = model.BIS_Age;
            parameters[6].Value = model.BIS_GSRKSX;
            parameters[7].Value = model.BIS_HA;
            parameters[8].Value = model.BIS_BRSJSX;
            parameters[9].Value = model.BIS_Stay;
            parameters[10].Value = model.BIS_Eat;
            parameters[11].Value = model.BIS_CS;
            parameters[12].Value = model.BIS_WS;
            parameters[13].Value = model.BIS_WB;
            parameters[14].Value = model.BIS_SGTime;
            parameters[15].Value = model.BIS_JGSTime;
            parameters[16].Value = model.BIS_WE;
            parameters[17].Value = model.BIS_EFS;
            parameters[18].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region 更新店面照片--乔春羽(2013.8.5)
        /// <summary>
        /// 更新店面照片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateP(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("P_S=@P_S,");
            strSql.Append("P_SB=@P_SB,");
            strSql.Append("P_WP=@P_WP,");
            strSql.Append("P_HGZ=@P_HGZ,");
            strSql.Append("P_Keys=@P_Keys,");
            strSql.Append("P_Forms=@P_Forms,");
            strSql.Append("P_Shop=@P_Shop,");
            strSql.Append("P_SR=@P_SR,");
            strSql.Append("P_CK=@P_CK,");
            strSql.Append("P_CK2=@P_CK2,");
            strSql.Append("P_SS=@P_SS,");
            strSql.Append("P_DFRY=@P_DFRY");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@P_S", SqlDbType.NVarChar,500),
					new SqlParameter("@P_SB", SqlDbType.NVarChar,500),
					new SqlParameter("@P_WP", SqlDbType.NVarChar,500),
					new SqlParameter("@P_HGZ", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Keys", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Forms", SqlDbType.NVarChar,500),
					new SqlParameter("@P_Shop", SqlDbType.NVarChar,500),
					new SqlParameter("@P_SR", SqlDbType.NVarChar,500),
					new SqlParameter("@P_CK", SqlDbType.NVarChar,500),
					new SqlParameter("@P_CK2", SqlDbType.NVarChar,500),
					new SqlParameter("@P_SS", SqlDbType.NVarChar,500),
					new SqlParameter("@P_DFRY", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.P_S;
            parameters[1].Value = model.P_SB;
            parameters[2].Value = model.P_WP;
            parameters[3].Value = model.P_HGZ;
            parameters[4].Value = model.P_Keys;
            parameters[5].Value = model.P_Forms;
            parameters[6].Value = model.P_Shop;
            parameters[7].Value = model.P_SR;
            parameters[8].Value = model.P_CK;
            parameters[9].Value = model.P_CK2;
            parameters[10].Value = model.P_SS;
            parameters[11].Value = model.P_DFRY;
            parameters[12].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region 提交巡店报告--乔春羽（2013.8.5）
        /// <summary>
        /// 提交巡店报告
        /// </summary>
        public bool UpdateEnd(Citic.Model.DealerXDReports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DealerXDReports set ");
            strSql.Append("Checkman=@Checkman,");
            strSql.Append("CheckDate2=@CheckDate2");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Checkman", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate2", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Checkman;
            parameters[1].Value = model.CheckDate2;
            parameters[2].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region 分页获得数据列表--乔春羽(2013.8.5)
        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">开始下表</param>
        /// <param name="endIndex">结束下表</param>
        /// <param name="cols">要查询的列</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, params string[] cols)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, ");
            for (int i = 0; i < cols.Length; i++)
            {
                if (i == cols.Length - 1)
                {
                    strSql.Append(" T." + cols[i]);
                }
                else
                {
                    strSql.Append(" T." + cols[i] + ",");
                }
            }
            strSql.Append(" from tb_DealerXDReports T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

