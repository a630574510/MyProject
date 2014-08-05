using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:CarErrorCount
    /// </summary>
    public partial class CarErrorCount
    {
        public CarErrorCount()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_CarErrorCount");
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
        public int Add(Citic.Model.CarErrorCount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_CarErrorCount(");
            strSql.Append("DealerID,DealerName,BankID,BankName,BrandID,BrandName,SZSM,XSWHK,SZYD,ZSCL,ZYCZSJC,ZYCLB,Other,SZSMC,XSWHKC,SZYDC,ZSCLC,ZYCZSJCC,ZYCLBC,OtherC,SZSMR,XSWHKR,SZYDR,ZSCLR,ZYCZSJCR,ZYCLBR,OtherR,CreateDate,CreateID)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@BankID,@BankName,@BrandID,@BrandName,@SZSM,@XSWHK,@SZYD,@ZSCL,@ZYCZSJC,@ZYCLB,@Other,@SZSMC,@XSWHKC,@SZYDC,@ZSCLC,@ZYCZSJCC,@ZYCLBC,@OtherC,@SZSMR,@XSWHKR,@SZYDR,@ZSCLR,@ZYCZSJCR,@ZYCLBR,@OtherR,@CreateDate,@CreateID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SZSM", SqlDbType.NVarChar,500),
					new SqlParameter("@XSWHK", SqlDbType.NVarChar,500),
					new SqlParameter("@SZYD", SqlDbType.NVarChar,500),
					new SqlParameter("@ZSCL", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCZSJC", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCLB", SqlDbType.NVarChar,500),
					new SqlParameter("@Other", SqlDbType.NVarChar,500),
					new SqlParameter("@SZSMC", SqlDbType.Int,4),
					new SqlParameter("@XSWHKC", SqlDbType.Int,4),
					new SqlParameter("@SZYDC", SqlDbType.Int,4),
					new SqlParameter("@ZSCLC", SqlDbType.Int,4),
					new SqlParameter("@ZYCZSJCC", SqlDbType.Int,4),
					new SqlParameter("@ZYCLBC", SqlDbType.Int,4),
					new SqlParameter("@OtherC", SqlDbType.Int,4),
					new SqlParameter("@SZSMR", SqlDbType.NVarChar,500),
					new SqlParameter("@XSWHKR", SqlDbType.NVarChar,500),
					new SqlParameter("@SZYDR", SqlDbType.NVarChar,500),
					new SqlParameter("@ZSCLR", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCZSJCR", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCLBR", SqlDbType.NVarChar,500),
					new SqlParameter("@OtherR", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.SZSM;
            parameters[7].Value = model.XSWHK;
            parameters[8].Value = model.SZYD;
            parameters[9].Value = model.ZSCL;
            parameters[10].Value = model.ZYCZSJC;
            parameters[11].Value = model.ZYCLB;
            parameters[12].Value = model.Other;
            parameters[13].Value = model.SZSMC;
            parameters[14].Value = model.XSWHKC;
            parameters[15].Value = model.SZYDC;
            parameters[16].Value = model.ZSCLC;
            parameters[17].Value = model.ZYCZSJCC;
            parameters[18].Value = model.ZYCLBC;
            parameters[19].Value = model.OtherC;
            parameters[20].Value = model.SZSMR;
            parameters[21].Value = model.XSWHKR;
            parameters[22].Value = model.SZYDR;
            parameters[23].Value = model.ZSCLR;
            parameters[24].Value = model.ZYCZSJCR;
            parameters[25].Value = model.ZYCLBR;
            parameters[26].Value = model.OtherR;
            parameters[27].Value = model.CreateDate;
            parameters[28].Value = model.CreateID;

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
        public bool Update(Citic.Model.CarErrorCount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_CarErrorCount set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("SZSM=@SZSM,");
            strSql.Append("XSWHK=@XSWHK,");
            strSql.Append("SZYD=@SZYD,");
            strSql.Append("ZSCL=@ZSCL,");
            strSql.Append("ZYCZSJC=@ZYCZSJC,");
            strSql.Append("ZYCLB=@ZYCLB,");
            strSql.Append("Other=@Other,");
            strSql.Append("SZSMC=@SZSMC,");
            strSql.Append("XSWHKC=@XSWHKC,");
            strSql.Append("SZYDC=@SZYDC,");
            strSql.Append("ZSCLC=@ZSCLC,");
            strSql.Append("ZYCZSJCC=@ZYCZSJCC,");
            strSql.Append("ZYCLBC=@ZYCLBC,");
            strSql.Append("OtherC=@OtherC,");
            strSql.Append("SZSMR=@SZSMR,");
            strSql.Append("XSWHKR=@XSWHKR,");
            strSql.Append("SZYDR=@SZYDR,");
            strSql.Append("ZSCLR=@ZSCLR,");
            strSql.Append("ZYCZSJCR=@ZYCZSJCR,");
            strSql.Append("ZYCLBR=@ZYCLBR,");
            strSql.Append("OtherR=@OtherR,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("CreateID=@CreateID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SZSM", SqlDbType.NVarChar,500),
					new SqlParameter("@XSWHK", SqlDbType.NVarChar,500),
					new SqlParameter("@SZYD", SqlDbType.NVarChar,500),
					new SqlParameter("@ZSCL", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCZSJC", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCLB", SqlDbType.NVarChar,500),
					new SqlParameter("@Other", SqlDbType.NVarChar,500),
					new SqlParameter("@SZSMC", SqlDbType.Int,4),
					new SqlParameter("@XSWHKC", SqlDbType.Int,4),
					new SqlParameter("@SZYDC", SqlDbType.Int,4),
					new SqlParameter("@ZSCLC", SqlDbType.Int,4),
					new SqlParameter("@ZYCZSJCC", SqlDbType.Int,4),
					new SqlParameter("@ZYCLBC", SqlDbType.Int,4),
					new SqlParameter("@OtherC", SqlDbType.Int,4),
					new SqlParameter("@SZSMR", SqlDbType.NVarChar,500),
					new SqlParameter("@XSWHKR", SqlDbType.NVarChar,500),
					new SqlParameter("@SZYDR", SqlDbType.NVarChar,500),
					new SqlParameter("@ZSCLR", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCZSJCR", SqlDbType.NVarChar,500),
					new SqlParameter("@ZYCLBR", SqlDbType.NVarChar,500),
					new SqlParameter("@OtherR", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.SZSM;
            parameters[7].Value = model.XSWHK;
            parameters[8].Value = model.SZYD;
            parameters[9].Value = model.ZSCL;
            parameters[10].Value = model.ZYCZSJC;
            parameters[11].Value = model.ZYCLB;
            parameters[12].Value = model.Other;
            parameters[13].Value = model.SZSMC;
            parameters[14].Value = model.XSWHKC;
            parameters[15].Value = model.SZYDC;
            parameters[16].Value = model.ZSCLC;
            parameters[17].Value = model.ZYCZSJCC;
            parameters[18].Value = model.ZYCLBC;
            parameters[19].Value = model.OtherC;
            parameters[20].Value = model.SZSMR;
            parameters[21].Value = model.XSWHKR;
            parameters[22].Value = model.SZYDR;
            parameters[23].Value = model.ZSCLR;
            parameters[24].Value = model.ZYCZSJCR;
            parameters[25].Value = model.ZYCLBR;
            parameters[26].Value = model.OtherR;
            parameters[27].Value = model.CreateDate;
            parameters[28].Value = model.CreateID;
            parameters[29].Value = model.ID;

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
            strSql.Append("delete from tb_CarErrorCount ");
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
            strSql.Append("delete from tb_CarErrorCount ");
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
        public Citic.Model.CarErrorCount GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,SZSM,XSWHK,SZYD,ZSCL,ZYCZSJC,ZYCLB,Other,SZSMC,XSWHKC,SZYDC,ZSCLC,ZYCZSJCC,ZYCLBC,OtherC,SZSMR,XSWHKR,SZYDR,ZSCLR,ZYCZSJCR,ZYCLBR,OtherR,CreateDate,CreateID from tb_CarErrorCount ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.CarErrorCount model = new Citic.Model.CarErrorCount();
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
        public Citic.Model.CarErrorCount DataRowToModel(DataRow row)
        {
            Citic.Model.CarErrorCount model = new Citic.Model.CarErrorCount();
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
                if (row["BankID"] != null && row["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(row["BankID"].ToString());
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["BrandID"] != null && row["BrandID"].ToString() != "")
                {
                    model.BrandID = int.Parse(row["BrandID"].ToString());
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
                }
                if (row["SZSM"] != null)
                {
                    model.SZSM = row["SZSM"].ToString();
                }
                if (row["XSWHK"] != null)
                {
                    model.XSWHK = row["XSWHK"].ToString();
                }
                if (row["SZYD"] != null)
                {
                    model.SZYD = row["SZYD"].ToString();
                }
                if (row["ZSCL"] != null)
                {
                    model.ZSCL = row["ZSCL"].ToString();
                }
                if (row["ZYCZSJC"] != null)
                {
                    model.ZYCZSJC = row["ZYCZSJC"].ToString();
                }
                if (row["ZYCLB"] != null)
                {
                    model.ZYCLB = row["ZYCLB"].ToString();
                }
                if (row["Other"] != null)
                {
                    model.Other = row["Other"].ToString();
                }
                if (row["SZSMC"] != null && row["SZSMC"].ToString() != "")
                {
                    model.SZSMC = int.Parse(row["SZSMC"].ToString());
                }
                if (row["XSWHKC"] != null && row["XSWHKC"].ToString() != "")
                {
                    model.XSWHKC = int.Parse(row["XSWHKC"].ToString());
                }
                if (row["SZYDC"] != null && row["SZYDC"].ToString() != "")
                {
                    model.SZYDC = int.Parse(row["SZYDC"].ToString());
                }
                if (row["ZSCLC"] != null && row["ZSCLC"].ToString() != "")
                {
                    model.ZSCLC = int.Parse(row["ZSCLC"].ToString());
                }
                if (row["ZYCZSJCC"] != null && row["ZYCZSJCC"].ToString() != "")
                {
                    model.ZYCZSJCC = int.Parse(row["ZYCZSJCC"].ToString());
                }
                if (row["ZYCLBC"] != null && row["ZYCLBC"].ToString() != "")
                {
                    model.ZYCLBC = int.Parse(row["ZYCLBC"].ToString());
                }
                if (row["OtherC"] != null && row["OtherC"].ToString() != "")
                {
                    model.OtherC = int.Parse(row["OtherC"].ToString());
                }
                if (row["SZSMR"] != null)
                {
                    model.SZSMR = row["SZSMR"].ToString();
                }
                if (row["XSWHKR"] != null)
                {
                    model.XSWHKR = row["XSWHKR"].ToString();
                }
                if (row["SZYDR"] != null)
                {
                    model.SZYDR = row["SZYDR"].ToString();
                }
                if (row["ZSCLR"] != null)
                {
                    model.ZSCLR = row["ZSCLR"].ToString();
                }
                if (row["ZYCZSJCR"] != null)
                {
                    model.ZYCZSJCR = row["ZYCZSJCR"].ToString();
                }
                if (row["ZYCLBR"] != null)
                {
                    model.ZYCLBR = row["ZYCLBR"].ToString();
                }
                if (row["OtherR"] != null)
                {
                    model.OtherR = row["OtherR"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
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
            strSql.Append("select ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,SZSM,XSWHK,SZYD,ZSCL,ZYCZSJC,ZYCLB,Other,SZSMC,XSWHKC,SZYDC,ZSCLC,ZYCZSJCC,ZYCLBC,OtherC,SZSMR,XSWHKR,SZYDR,ZSCLR,ZYCZSJCR,ZYCLBR,OtherR,CreateDate,CreateID ");
            strSql.Append(" FROM tb_CarErrorCount ");
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
            strSql.Append(" ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,SZSM,XSWHK,SZYD,ZSCL,ZYCZSJC,ZYCLB,Other,SZSMC,XSWHKC,SZYDC,ZSCLC,ZYCZSJCC,ZYCLBC,OtherC,SZSMR,XSWHKR,SZYDR,ZSCLR,ZYCZSJCR,ZYCLBR,OtherR,CreateDate,CreateID ");
            strSql.Append(" FROM tb_CarErrorCount ");
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
            strSql.Append("select count(1) FROM tb_CarErrorCount ");
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
            strSql.Append(")AS Row, T.*  from tb_CarErrorCount T ");
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

        #endregion  ExtensionMethod
    }
}

