using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:RisksSolveDocuments
    /// </summary>
    public partial class RisksSolveDocuments
    {
        public RisksSolveDocuments()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_RisksSolveDocuments");
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
        public int Add(Citic.Model.RisksSolveDocuments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_RisksSolveDocuments(");
            strSql.Append("No,Status,QDMRoleID,C_Date,C_AP,C_Unit,C_P,C_Post,C_PPhone,C_Content,SQ_ShopID,SQ_Shop,SQ_BankID,SQ_Bank,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,OPFD,OPFDPIC,ORCD,ORCDPIC,OBD,OBDPIC,Result,ResultPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,OPFD_OptionID,OPFD_OptionTime,OPFDPIC_OptionID,OPFDPIC_OptionTime,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime,Result_OptionID,Result_OptionTime,ResultPIC_OptionID,ResultPIC_OptionTime)");
            strSql.Append(" values (");
            strSql.Append("@No,@Status,@QDMRoleID,@C_Date,@C_AP,@C_Unit,@C_P,@C_Post,@C_PPhone,@C_Content,@SQ_ShopID,@SQ_Shop,@SQ_BankID,@SQ_Bank,@SQ_BrandID,@SQ_Brand,@SQ_Name,@SQ_Phone,@SQ_FBP,@SQ_FBPP,@SQ_Content,@OPFD,@OPFDPIC,@ORCD,@ORCDPIC,@OBD,@OBDPIC,@Result,@ResultPIC,@CreateID,@CreateTime,@DeleteID,@DeleteTime,@IsDelete,@OPFD_OptionID,@OPFD_OptionTime,@OPFDPIC_OptionID,@OPFDPIC_OptionTime,@ORCD_OptionID,@ORCD_OptionTime,@ORCDPIC_OptionID,@ORCDPIC_OptionTime,@OBD_OptionID,@OBD_OptionTime,@OBDPIC_OptionID,@OBDPIC_OptionTime,@Result_OptionID,@Result_OptionTime,@ResultPIC_OptionID,@ResultPIC_OptionTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@No", SqlDbType.NVarChar,30),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@QDMRoleID", SqlDbType.Int,4),
					new SqlParameter("@C_Date", SqlDbType.DateTime),
					new SqlParameter("@C_AP", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@C_P", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Post", SqlDbType.NVarChar,50),
					new SqlParameter("@C_PPhone", SqlDbType.NVarChar,11),
					new SqlParameter("@C_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@SQ_ShopID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Shop", SqlDbType.NVarChar,300),
					new SqlParameter("@SQ_BankID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Bank", SqlDbType.NVarChar,100),
					new SqlParameter("@SQ_BrandID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@SQ_FBP", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_FBPP", SqlDbType.NVarChar,20),
					new SqlParameter("@SQ_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@OPFD", SqlDbType.NVarChar,300),
					new SqlParameter("@OPFDPIC", SqlDbType.Bit,1),
					new SqlParameter("@ORCD", SqlDbType.NVarChar,300),
					new SqlParameter("@ORCDPIC", SqlDbType.Bit,1),
					new SqlParameter("@OBD", SqlDbType.NVarChar,300),
					new SqlParameter("@OBDPIC", SqlDbType.Bit,1),
					new SqlParameter("@Result", SqlDbType.NVarChar,500),
					new SqlParameter("@ResultPIC", SqlDbType.Bit,1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@OPFD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OPFD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OPFDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OPFDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ORCD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ORCDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@Result_OptionID", SqlDbType.Int,4),
					new SqlParameter("@Result_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ResultPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ResultPIC_OptionTime", SqlDbType.DateTime)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.QDMRoleID;
            parameters[3].Value = model.C_Date;
            parameters[4].Value = model.C_AP;
            parameters[5].Value = model.C_Unit;
            parameters[6].Value = model.C_P;
            parameters[7].Value = model.C_Post;
            parameters[8].Value = model.C_PPhone;
            parameters[9].Value = model.C_Content;
            parameters[10].Value = model.SQ_ShopID;
            parameters[11].Value = model.SQ_Shop;
            parameters[12].Value = model.SQ_BankID;
            parameters[13].Value = model.SQ_Bank;
            parameters[14].Value = model.SQ_BrandID;
            parameters[15].Value = model.SQ_Brand;
            parameters[16].Value = model.SQ_Name;
            parameters[17].Value = model.SQ_Phone;
            parameters[18].Value = model.SQ_FBP;
            parameters[19].Value = model.SQ_FBPP;
            parameters[20].Value = model.SQ_Content;
            parameters[21].Value = model.OPFD;
            parameters[22].Value = model.OPFDPIC;
            parameters[23].Value = model.ORCD;
            parameters[24].Value = model.ORCDPIC;
            parameters[25].Value = model.OBD;
            parameters[26].Value = model.OBDPIC;
            parameters[27].Value = model.Result;
            parameters[28].Value = model.ResultPIC;
            parameters[29].Value = model.CreateID;
            parameters[30].Value = model.CreateTime;
            parameters[31].Value = model.DeleteID;
            parameters[32].Value = model.DeleteTime;
            parameters[33].Value = model.IsDelete;
            parameters[34].Value = model.OPFD_OptionID;
            parameters[35].Value = model.OPFD_OptionTime;
            parameters[36].Value = model.OPFDPIC_OptionID;
            parameters[37].Value = model.OPFDPIC_OptionTime;
            parameters[38].Value = model.ORCD_OptionID;
            parameters[39].Value = model.ORCD_OptionTime;
            parameters[40].Value = model.ORCDPIC_OptionID;
            parameters[41].Value = model.ORCDPIC_OptionTime;
            parameters[42].Value = model.OBD_OptionID;
            parameters[43].Value = model.OBD_OptionTime;
            parameters[44].Value = model.OBDPIC_OptionID;
            parameters[45].Value = model.OBDPIC_OptionTime;
            parameters[46].Value = model.Result_OptionID;
            parameters[47].Value = model.Result_OptionTime;
            parameters[48].Value = model.ResultPIC_OptionID;
            parameters[49].Value = model.ResultPIC_OptionTime;

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
        public bool Update(Citic.Model.RisksSolveDocuments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_RisksSolveDocuments set ");
            strSql.Append("No=@No,");
            strSql.Append("Status=@Status,");
            strSql.Append("QDMRoleID=@QDMRoleID,");
            strSql.Append("C_Date=@C_Date,");
            strSql.Append("C_AP=@C_AP,");
            strSql.Append("C_Unit=@C_Unit,");
            strSql.Append("C_P=@C_P,");
            strSql.Append("C_Post=@C_Post,");
            strSql.Append("C_PPhone=@C_PPhone,");
            strSql.Append("C_Content=@C_Content,");
            strSql.Append("SQ_ShopID=@SQ_ShopID,");
            strSql.Append("SQ_Shop=@SQ_Shop,");
            strSql.Append("SQ_BankID=@SQ_BankID,");
            strSql.Append("SQ_Bank=@SQ_Bank,");
            strSql.Append("SQ_BrandID=@SQ_BrandID,");
            strSql.Append("SQ_Brand=@SQ_Brand,");
            strSql.Append("SQ_Name=@SQ_Name,");
            strSql.Append("SQ_Phone=@SQ_Phone,");
            strSql.Append("SQ_FBP=@SQ_FBP,");
            strSql.Append("SQ_FBPP=@SQ_FBPP,");
            strSql.Append("SQ_Content=@SQ_Content,");
            strSql.Append("OPFD=@OPFD,");
            strSql.Append("OPFDPIC=@OPFDPIC,");
            strSql.Append("ORCD=@ORCD,");
            strSql.Append("ORCDPIC=@ORCDPIC,");
            strSql.Append("OBD=@OBD,");
            strSql.Append("OBDPIC=@OBDPIC,");
            strSql.Append("Result=@Result,");
            strSql.Append("ResultPIC=@ResultPIC,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("OPFD_OptionID=@OPFD_OptionID,");
            strSql.Append("OPFD_OptionTime=@OPFD_OptionTime,");
            strSql.Append("OPFDPIC_OptionID=@OPFDPIC_OptionID,");
            strSql.Append("OPFDPIC_OptionTime=@OPFDPIC_OptionTime,");
            strSql.Append("ORCD_OptionID=@ORCD_OptionID,");
            strSql.Append("ORCD_OptionTime=@ORCD_OptionTime,");
            strSql.Append("ORCDPIC_OptionID=@ORCDPIC_OptionID,");
            strSql.Append("ORCDPIC_OptionTime=@ORCDPIC_OptionTime,");
            strSql.Append("OBD_OptionID=@OBD_OptionID,");
            strSql.Append("OBD_OptionTime=@OBD_OptionTime,");
            strSql.Append("OBDPIC_OptionID=@OBDPIC_OptionID,");
            strSql.Append("OBDPIC_OptionTime=@OBDPIC_OptionTime,");
            strSql.Append("Result_OptionID=@Result_OptionID,");
            strSql.Append("Result_OptionTime=@Result_OptionTime,");
            strSql.Append("ResultPIC_OptionID=@ResultPIC_OptionID,");
            strSql.Append("ResultPIC_OptionTime=@ResultPIC_OptionTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@No", SqlDbType.NVarChar,30),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@QDMRoleID", SqlDbType.Int,4),
					new SqlParameter("@C_Date", SqlDbType.DateTime),
					new SqlParameter("@C_AP", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@C_P", SqlDbType.NVarChar,50),
					new SqlParameter("@C_Post", SqlDbType.NVarChar,50),
					new SqlParameter("@C_PPhone", SqlDbType.NVarChar,11),
					new SqlParameter("@C_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@SQ_ShopID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Shop", SqlDbType.NVarChar,300),
					new SqlParameter("@SQ_BankID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Bank", SqlDbType.NVarChar,100),
					new SqlParameter("@SQ_BrandID", SqlDbType.Int,4),
					new SqlParameter("@SQ_Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@SQ_FBP", SqlDbType.NVarChar,50),
					new SqlParameter("@SQ_FBPP", SqlDbType.NVarChar,20),
					new SqlParameter("@SQ_Content", SqlDbType.NVarChar,300),
					new SqlParameter("@OPFD", SqlDbType.NVarChar,300),
					new SqlParameter("@OPFDPIC", SqlDbType.Bit,1),
					new SqlParameter("@ORCD", SqlDbType.NVarChar,300),
					new SqlParameter("@ORCDPIC", SqlDbType.Bit,1),
					new SqlParameter("@OBD", SqlDbType.NVarChar,300),
					new SqlParameter("@OBDPIC", SqlDbType.Bit,1),
					new SqlParameter("@Result", SqlDbType.NVarChar,500),
					new SqlParameter("@ResultPIC", SqlDbType.Bit,1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@OPFD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OPFD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OPFDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OPFDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ORCD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ORCDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@Result_OptionID", SqlDbType.Int,4),
					new SqlParameter("@Result_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ResultPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ResultPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.No;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.QDMRoleID;
            parameters[3].Value = model.C_Date;
            parameters[4].Value = model.C_AP;
            parameters[5].Value = model.C_Unit;
            parameters[6].Value = model.C_P;
            parameters[7].Value = model.C_Post;
            parameters[8].Value = model.C_PPhone;
            parameters[9].Value = model.C_Content;
            parameters[10].Value = model.SQ_ShopID;
            parameters[11].Value = model.SQ_Shop;
            parameters[12].Value = model.SQ_BankID;
            parameters[13].Value = model.SQ_Bank;
            parameters[14].Value = model.SQ_BrandID;
            parameters[15].Value = model.SQ_Brand;
            parameters[16].Value = model.SQ_Name;
            parameters[17].Value = model.SQ_Phone;
            parameters[18].Value = model.SQ_FBP;
            parameters[19].Value = model.SQ_FBPP;
            parameters[20].Value = model.SQ_Content;
            parameters[21].Value = model.OPFD;
            parameters[22].Value = model.OPFDPIC;
            parameters[23].Value = model.ORCD;
            parameters[24].Value = model.ORCDPIC;
            parameters[25].Value = model.OBD;
            parameters[26].Value = model.OBDPIC;
            parameters[27].Value = model.Result;
            parameters[28].Value = model.ResultPIC;
            parameters[29].Value = model.CreateID;
            parameters[30].Value = model.CreateTime;
            parameters[31].Value = model.DeleteID;
            parameters[32].Value = model.DeleteTime;
            parameters[33].Value = model.IsDelete;
            parameters[34].Value = model.OPFD_OptionID;
            parameters[35].Value = model.OPFD_OptionTime;
            parameters[36].Value = model.OPFDPIC_OptionID;
            parameters[37].Value = model.OPFDPIC_OptionTime;
            parameters[38].Value = model.ORCD_OptionID;
            parameters[39].Value = model.ORCD_OptionTime;
            parameters[40].Value = model.ORCDPIC_OptionID;
            parameters[41].Value = model.ORCDPIC_OptionTime;
            parameters[42].Value = model.OBD_OptionID;
            parameters[43].Value = model.OBD_OptionTime;
            parameters[44].Value = model.OBDPIC_OptionID;
            parameters[45].Value = model.OBDPIC_OptionTime;
            parameters[46].Value = model.Result_OptionID;
            parameters[47].Value = model.Result_OptionTime;
            parameters[48].Value = model.ResultPIC_OptionID;
            parameters[49].Value = model.ResultPIC_OptionTime;
            parameters[50].Value = model.ID;

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
            strSql.Append("delete from tb_RisksSolveDocuments ");
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
            strSql.Append("delete from tb_RisksSolveDocuments ");
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
        public Citic.Model.RisksSolveDocuments GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,No,Status,QDMRoleID,C_Date,C_AP,C_Unit,C_P,C_Post,C_PPhone,C_Content,SQ_ShopID,SQ_Shop,SQ_BankID,SQ_Bank,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,OPFD,OPFDPIC,ORCD,ORCDPIC,OBD,OBDPIC,Result,ResultPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,OPFD_OptionID,OPFD_OptionTime,OPFDPIC_OptionID,OPFDPIC_OptionTime,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime,Result_OptionID,Result_OptionTime,ResultPIC_OptionID,ResultPIC_OptionTime from tb_RisksSolveDocuments ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.RisksSolveDocuments model = new Citic.Model.RisksSolveDocuments();
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
        public Citic.Model.RisksSolveDocuments DataRowToModel(DataRow row)
        {
            Citic.Model.RisksSolveDocuments model = new Citic.Model.RisksSolveDocuments();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["No"] != null)
                {
                    model.No = row["No"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["QDMRoleID"] != null && row["QDMRoleID"].ToString() != "")
                {
                    model.QDMRoleID = int.Parse(row["QDMRoleID"].ToString());
                }
                if (row["C_Date"] != null && row["C_Date"].ToString() != "")
                {
                    model.C_Date = DateTime.Parse(row["C_Date"].ToString());
                }
                if (row["C_AP"] != null)
                {
                    model.C_AP = row["C_AP"].ToString();
                }
                if (row["C_Unit"] != null)
                {
                    model.C_Unit = row["C_Unit"].ToString();
                }
                if (row["C_P"] != null)
                {
                    model.C_P = row["C_P"].ToString();
                }
                if (row["C_Post"] != null)
                {
                    model.C_Post = row["C_Post"].ToString();
                }
                if (row["C_PPhone"] != null)
                {
                    model.C_PPhone = row["C_PPhone"].ToString();
                }
                if (row["C_Content"] != null)
                {
                    model.C_Content = row["C_Content"].ToString();
                }
                if (row["SQ_ShopID"] != null && row["SQ_ShopID"].ToString() != "")
                {
                    model.SQ_ShopID = int.Parse(row["SQ_ShopID"].ToString());
                }
                if (row["SQ_Shop"] != null)
                {
                    model.SQ_Shop = row["SQ_Shop"].ToString();
                }
                if (row["SQ_BankID"] != null && row["SQ_BankID"].ToString() != "")
                {
                    model.SQ_BankID = int.Parse(row["SQ_BankID"].ToString());
                }
                if (row["SQ_Bank"] != null)
                {
                    model.SQ_Bank = row["SQ_Bank"].ToString();
                }
                if (row["SQ_BrandID"] != null && row["SQ_BrandID"].ToString() != "")
                {
                    model.SQ_BrandID = int.Parse(row["SQ_BrandID"].ToString());
                }
                if (row["SQ_Brand"] != null)
                {
                    model.SQ_Brand = row["SQ_Brand"].ToString();
                }
                if (row["SQ_Name"] != null)
                {
                    model.SQ_Name = row["SQ_Name"].ToString();
                }
                if (row["SQ_Phone"] != null)
                {
                    model.SQ_Phone = row["SQ_Phone"].ToString();
                }
                if (row["SQ_FBP"] != null)
                {
                    model.SQ_FBP = row["SQ_FBP"].ToString();
                }
                if (row["SQ_FBPP"] != null)
                {
                    model.SQ_FBPP = row["SQ_FBPP"].ToString();
                }
                if (row["SQ_Content"] != null)
                {
                    model.SQ_Content = row["SQ_Content"].ToString();
                }
                if (row["OPFD"] != null)
                {
                    model.OPFD = row["OPFD"].ToString();
                }
                if (row["OPFDPIC"] != null && row["OPFDPIC"].ToString() != "")
                {
                    if ((row["OPFDPIC"].ToString() == "1") || (row["OPFDPIC"].ToString().ToLower() == "true"))
                    {
                        model.OPFDPIC = true;
                    }
                    else
                    {
                        model.OPFDPIC = false;
                    }
                }
                if (row["ORCD"] != null)
                {
                    model.ORCD = row["ORCD"].ToString();
                }
                if (row["ORCDPIC"] != null && row["ORCDPIC"].ToString() != "")
                {
                    if ((row["ORCDPIC"].ToString() == "1") || (row["ORCDPIC"].ToString().ToLower() == "true"))
                    {
                        model.ORCDPIC = true;
                    }
                    else
                    {
                        model.ORCDPIC = false;
                    }
                }
                if (row["OBD"] != null)
                {
                    model.OBD = row["OBD"].ToString();
                }
                if (row["OBDPIC"] != null && row["OBDPIC"].ToString() != "")
                {
                    if ((row["OBDPIC"].ToString() == "1") || (row["OBDPIC"].ToString().ToLower() == "true"))
                    {
                        model.OBDPIC = true;
                    }
                    else
                    {
                        model.OBDPIC = false;
                    }
                }
                if (row["Result"] != null)
                {
                    model.Result = row["Result"].ToString();
                }
                if (row["ResultPIC"] != null && row["ResultPIC"].ToString() != "")
                {
                    if ((row["ResultPIC"].ToString() == "1") || (row["ResultPIC"].ToString().ToLower() == "true"))
                    {
                        model.ResultPIC = true;
                    }
                    else
                    {
                        model.ResultPIC = false;
                    }
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["DeleteID"] != null && row["DeleteID"].ToString() != "")
                {
                    model.DeleteID = int.Parse(row["DeleteID"].ToString());
                }
                if (row["DeleteTime"] != null && row["DeleteTime"].ToString() != "")
                {
                    model.DeleteTime = DateTime.Parse(row["DeleteTime"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    if ((row["IsDelete"].ToString() == "1") || (row["IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.IsDelete = true;
                    }
                    else
                    {
                        model.IsDelete = false;
                    }
                }
                if (row["OPFD_OptionID"] != null && row["OPFD_OptionID"].ToString() != "")
                {
                    model.OPFD_OptionID = int.Parse(row["OPFD_OptionID"].ToString());
                }
                if (row["OPFD_OptionTime"] != null && row["OPFD_OptionTime"].ToString() != "")
                {
                    model.OPFD_OptionTime = DateTime.Parse(row["OPFD_OptionTime"].ToString());
                }
                if (row["OPFDPIC_OptionID"] != null && row["OPFDPIC_OptionID"].ToString() != "")
                {
                    model.OPFDPIC_OptionID = int.Parse(row["OPFDPIC_OptionID"].ToString());
                }
                if (row["OPFDPIC_OptionTime"] != null && row["OPFDPIC_OptionTime"].ToString() != "")
                {
                    model.OPFDPIC_OptionTime = DateTime.Parse(row["OPFDPIC_OptionTime"].ToString());
                }
                if (row["ORCD_OptionID"] != null && row["ORCD_OptionID"].ToString() != "")
                {
                    model.ORCD_OptionID = int.Parse(row["ORCD_OptionID"].ToString());
                }
                if (row["ORCD_OptionTime"] != null && row["ORCD_OptionTime"].ToString() != "")
                {
                    model.ORCD_OptionTime = DateTime.Parse(row["ORCD_OptionTime"].ToString());
                }
                if (row["ORCDPIC_OptionID"] != null && row["ORCDPIC_OptionID"].ToString() != "")
                {
                    model.ORCDPIC_OptionID = int.Parse(row["ORCDPIC_OptionID"].ToString());
                }
                if (row["ORCDPIC_OptionTime"] != null && row["ORCDPIC_OptionTime"].ToString() != "")
                {
                    model.ORCDPIC_OptionTime = DateTime.Parse(row["ORCDPIC_OptionTime"].ToString());
                }
                if (row["OBD_OptionID"] != null && row["OBD_OptionID"].ToString() != "")
                {
                    model.OBD_OptionID = int.Parse(row["OBD_OptionID"].ToString());
                }
                if (row["OBD_OptionTime"] != null && row["OBD_OptionTime"].ToString() != "")
                {
                    model.OBD_OptionTime = DateTime.Parse(row["OBD_OptionTime"].ToString());
                }
                if (row["OBDPIC_OptionID"] != null && row["OBDPIC_OptionID"].ToString() != "")
                {
                    model.OBDPIC_OptionID = int.Parse(row["OBDPIC_OptionID"].ToString());
                }
                if (row["OBDPIC_OptionTime"] != null && row["OBDPIC_OptionTime"].ToString() != "")
                {
                    model.OBDPIC_OptionTime = DateTime.Parse(row["OBDPIC_OptionTime"].ToString());
                }
                if (row["Result_OptionID"] != null && row["Result_OptionID"].ToString() != "")
                {
                    model.Result_OptionID = int.Parse(row["Result_OptionID"].ToString());
                }
                if (row["Result_OptionTime"] != null && row["Result_OptionTime"].ToString() != "")
                {
                    model.Result_OptionTime = DateTime.Parse(row["Result_OptionTime"].ToString());
                }
                if (row["ResultPIC_OptionID"] != null && row["ResultPIC_OptionID"].ToString() != "")
                {
                    model.ResultPIC_OptionID = int.Parse(row["ResultPIC_OptionID"].ToString());
                }
                if (row["ResultPIC_OptionTime"] != null && row["ResultPIC_OptionTime"].ToString() != "")
                {
                    model.ResultPIC_OptionTime = DateTime.Parse(row["ResultPIC_OptionTime"].ToString());
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
            strSql.Append("select ID,No,Status,QDMRoleID,C_Date,C_AP,C_Unit,C_P,C_Post,C_PPhone,C_Content,SQ_ShopID,SQ_Shop,SQ_BankID,SQ_Bank,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,OPFD,OPFDPIC,ORCD,ORCDPIC,OBD,OBDPIC,Result,ResultPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,OPFD_OptionID,OPFD_OptionTime,OPFDPIC_OptionID,OPFDPIC_OptionTime,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime,Result_OptionID,Result_OptionTime,ResultPIC_OptionID,ResultPIC_OptionTime ");
            strSql.Append(" FROM tb_RisksSolveDocuments ");
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
            strSql.Append(" ID,No,Status,QDMRoleID,C_Date,C_AP,C_Unit,C_P,C_Post,C_PPhone,C_Content,SQ_ShopID,SQ_Shop,SQ_BankID,SQ_Bank,SQ_BrandID,SQ_Brand,SQ_Name,SQ_Phone,SQ_FBP,SQ_FBPP,SQ_Content,OPFD,OPFDPIC,ORCD,ORCDPIC,OBD,OBDPIC,Result,ResultPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,OPFD_OptionID,OPFD_OptionTime,OPFDPIC_OptionID,OPFDPIC_OptionTime,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime,Result_OptionID,Result_OptionTime,ResultPIC_OptionID,ResultPIC_OptionTime ");
            strSql.Append(" FROM tb_RisksSolveDocuments ");
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
            strSql.Append("select count(1) FROM tb_RisksSolveDocuments ");
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
            strSql.Append(")AS Row, T.*  from tb_RisksSolveDocuments T ");
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

        #region 批量添加--乔春羽(2014.4.22)
        public int AddRange(Citic.Model.RisksSolveDocuments[] models)
        {
            int num = 0;
            StringBuilder strSql = new StringBuilder();
            string proc_Name = "exec proc_CreateRisks @No,@Status,@C_Date,@C_AP,@C_Unit,@C_P,@C_Post,@C_PPhone,@C_Content,@SQ_ShopID,@SQ_Shop,@SQ_BankID,@SQ_Bank,@SQ_BrandID,@SQ_Brand,@SQ_FBP,@SQ_FBPP,@SQ_Content,@CreateID;";
            if (models != null && models.Length > 0)
            {
                System.Collections.Generic.List<CommandInfo> cInfos = new System.Collections.Generic.List<CommandInfo>();
                foreach (Citic.Model.RisksSolveDocuments model in models)
                {
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@No",DateTime.Now.ToString("yyyyMMddHHmmss")),
                        new SqlParameter("@Status",model.Status),
                        new SqlParameter("@C_Date",model.C_Date),
                        new SqlParameter("@C_AP",model.C_AP),
                        new SqlParameter("@C_Unit",model.C_Unit),
                        new SqlParameter("@C_P",model.C_P),
                        new SqlParameter("@C_Post",model.C_Post),
                        new SqlParameter("@C_PPhone",model.C_PPhone),
                        new SqlParameter("@C_Content",model.C_Content),
                        new SqlParameter("@SQ_ShopID",model.SQ_ShopID),
                        new SqlParameter("@SQ_Shop",model.SQ_Shop),
                        new SqlParameter("@SQ_BankID",model.SQ_BankID),
                        new SqlParameter("@SQ_Bank",model.SQ_Bank),
                        new SqlParameter("@SQ_BrandID",model.SQ_BrandID),
                        new SqlParameter("@SQ_Brand",model.SQ_Brand),
                        new SqlParameter("@SQ_FBP",model.SQ_FBP),
                        new SqlParameter("@SQ_FBPP",model.SQ_FBPP),
                        new SqlParameter("@SQ_Content",model.SQ_Content),
                        new SqlParameter("@CreateID",model.CreateID)
                    };
                    cInfos.Add(new CommandInfo(proc_Name, parameters));
                }
                num = DbHelperSQL.ExecuteSqlTran(cInfos);
            }
            return num;
        }
        #endregion

        #region 批量修改--乔春羽(2014.4.23)
        /// <summary>
        /// 批量修改数据，不固定数据列数
        /// </summary>
        /// <param name="models">要修改的数据</param>
        /// <param name="columns">要修改数据的列</param>
        /// <returns></returns>
        public int UpdateRange(Citic.Model.RisksSolveDocuments[] models, params string[] columns)
        {
            int num = 0;
            System.Collections.Generic.List<CommandInfo> cInfos = null;
            System.Collections.Generic.List<SqlParameter> parameters = null;
            StringBuilder strSql = null;
            StringBuilder temp = new StringBuilder("Update tb_RisksSolveDocuments Set ");
            if (columns != null && columns.Length > 0)
            {
                foreach (string col in columns)
                {
                    if (col.LastIndexOf("OptionTime") > 0)
                    {
                        temp.AppendFormat("{0} = GETDATE(),", col);
                    }
                    else
                    {
                        temp.AppendFormat("{0} = @{0},", col);
                    }
                }
                temp.Remove(temp.Length - 1, 1);
                temp.Remove(temp.ToString().LastIndexOf(','), temp.Length - temp.ToString().LastIndexOf(','));
                temp.Append(" Where ID = @ID");
            }
            if (models != null && models.Length > 0)
            {
                cInfos = new System.Collections.Generic.List<CommandInfo>();
                foreach (Citic.Model.RisksSolveDocuments model in models)
                {
                    strSql = new StringBuilder();
                    strSql.Append(temp);

                    parameters = new System.Collections.Generic.List<SqlParameter>();
                    foreach (string col in columns)
                    {
                        switch (col)
                        {
                            case "SQ_Content":
                                parameters.Add(new SqlParameter("@SQ_Content", model.SQ_Content));
                                break;
                            case "OPFD":
                                parameters.Add(new SqlParameter("@OPFD", model.OPFD));
                                break;
                            case "OPFD_OptionID":
                                parameters.Add(new SqlParameter("@OPFD_OptionID", model.OPFD_OptionID));
                                break;
                            //case "OPFD_OptionTime":
                            //    parameters.Add(new SqlParameter("@OPFD_OptionTime", "GETDATE()"));
                            //    break;
                            case "OPFDPIC":
                                parameters.Add(new SqlParameter("@OPFDPIC", model.OPFDPIC));
                                break;
                            case "OPFDPIC_OptionID":
                                parameters.Add(new SqlParameter("@OPFDPIC_OptionID", model.OPFDPIC_OptionID));
                                break;
                            //case "OPFDPIC_OptionTime":
                            //    parameters.Add(new SqlParameter("@OPFDPIC_OptionTime", "GETDATE()"));
                            //    break;
                            case "ORCD":
                                parameters.Add(new SqlParameter("@ORCD", model.ORCD));
                                break;
                            case "ORCD_OptionID":
                                parameters.Add(new SqlParameter("@ORCD_OptionID", model.ORCD_OptionID));
                                break;
                            //case "ORCD_OptionTime":
                            //    parameters.Add(new SqlParameter("@ORCD_OptionTime", "GETDATE()"));
                            //    break;
                            case "ORCDPIC":
                                parameters.Add(new SqlParameter("@ORCDPIC", model.ORCDPIC));
                                break;
                            case "ORCDPIC_OptionID":
                                parameters.Add(new SqlParameter("@ORCDPIC_OptionID", model.ORCDPIC_OptionID));
                                break;
                            //case "ORCDPIC_OptionTime":
                            //    parameters.Add(new SqlParameter("@ORCDPIC_OptionTime", "GETDATE()"));
                            //    break;
                            case "OBD":
                                parameters.Add(new SqlParameter("@OBD", model.OBD));
                                break;
                            case "OBD_OptionID":
                                parameters.Add(new SqlParameter("@OBD_OptionID", model.OBD_OptionID));
                                break;
                            //case "OBD_OptionTime":
                            //    parameters.Add(new SqlParameter("@OBD_OptionTime", "GETDATE()"));
                            //    break;
                            case "OBDPIC":
                                parameters.Add(new SqlParameter("@OBDPIC", model.OBDPIC));
                                break;
                            case "OBDPIC_OptionID":
                                parameters.Add(new SqlParameter("@OBDPIC_OptionID", model.OBDPIC_OptionID));
                                break;
                            //case "OBDPIC_OptionTime":
                            //    parameters.Add(new SqlParameter("@OBDPIC_OptionTime", "GETDATE()"));
                            //    break;
                            case "Result":
                                parameters.Add(new SqlParameter("@Result", model.Result));
                                break;
                            case "Result_OptionID":
                                parameters.Add(new SqlParameter("@Result_OptionID", model.Result_OptionID));
                                break;
                            //case "Result_OptionTime":
                            //    parameters.Add(new SqlParameter("@Result_OptionTime", "GETDATE()"));
                            //    break;
                            case "ResultPIC":
                                parameters.Add(new SqlParameter("@ResultPIC", model.ResultPIC));
                                break;
                            case "ResultPIC_OptionID":
                                parameters.Add(new SqlParameter("@ResultPIC_OptionID", model.ResultPIC_OptionID));
                                break;
                            //case "ResultPIC_OptionTime":
                            //    parameters.Add(new SqlParameter("@ResultPIC_OptionTime", "GETDATE()"));
                            //    break;
                        }
                    }
                    parameters.Add(new SqlParameter("@ID", model.ID));

                    cInfos.Add(new CommandInfo(strSql.ToString(), parameters.ToArray()));
                }
            }
            try
            {
                num = DbHelperSQL.ExecuteSqlTran(cInfos);
            }
            catch
            {

            }
            return num;
        }
        #endregion

        #endregion  ExtensionMethod
    }
}

