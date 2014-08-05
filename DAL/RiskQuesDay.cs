using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:RiskQuesDay
    /// </summary>
    public partial class RiskQuesDay
    {
        public RiskQuesDay()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_RiskQuesDay");
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
        public int Add(Citic.Model.RiskQuesDay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_RiskQuesDay(");
            strSql.Append("Status,WorkContent,Area,Checkman,DealerID,DealerName,BankID,BankName,BrandID,BrandName,SID,SName,DescProb,Result,CY_Market,CY_Business,QC_Market,QC_Business,ManCenter,XZ,Remark,CreateID,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@Status,@WorkContent,@Area,@Checkman,@DealerID,@DealerName,@BankID,@BankName,@BrandID,@BrandName,@SID,@SName,@DescProb,@Result,@CY_Market,@CY_Business,@QC_Market,@QC_Business,@ManCenter,@XZ,@Remark,@CreateID,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@WorkContent", SqlDbType.NVarChar,50),
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@Checkman", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@DescProb", SqlDbType.NVarChar,200),
					new SqlParameter("@Result", SqlDbType.NVarChar,100),
					new SqlParameter("@CY_Market", SqlDbType.NVarChar,100),
					new SqlParameter("@CY_Business", SqlDbType.NVarChar,100),
					new SqlParameter("@QC_Market", SqlDbType.NVarChar,100),
					new SqlParameter("@QC_Business", SqlDbType.NVarChar,100),
					new SqlParameter("@ManCenter", SqlDbType.NVarChar,100),
					new SqlParameter("@XZ", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Status;
            parameters[1].Value = model.WorkContent;
            parameters[2].Value = model.Area;
            parameters[3].Value = model.Checkman;
            parameters[4].Value = model.DealerID;
            parameters[5].Value = model.DealerName;
            parameters[6].Value = model.BankID;
            parameters[7].Value = model.BankName;
            parameters[8].Value = model.BrandID;
            parameters[9].Value = model.BrandName;
            parameters[10].Value = model.SID;
            parameters[11].Value = model.SName;
            parameters[12].Value = model.DescProb;
            parameters[13].Value = model.Result;
            parameters[14].Value = model.CY_Market;
            parameters[15].Value = model.CY_Business;
            parameters[16].Value = model.QC_Market;
            parameters[17].Value = model.QC_Business;
            parameters[18].Value = model.ManCenter;
            parameters[19].Value = model.XZ;
            parameters[20].Value = model.Remark;
            parameters[21].Value = model.CreateID;
            parameters[22].Value = model.CreateTime;

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
        public bool Update(Citic.Model.RiskQuesDay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_RiskQuesDay set ");
            strSql.Append("Status=@Status,");
            strSql.Append("WorkContent=@WorkContent,");
            strSql.Append("Area=@Area,");
            strSql.Append("Checkman=@Checkman,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("SID=@SID,");
            strSql.Append("SName=@SName,");
            strSql.Append("DescProb=@DescProb,");
            strSql.Append("Result=@Result,");
            strSql.Append("CY_Market=@CY_Market,");
            strSql.Append("CY_Business=@CY_Business,");
            strSql.Append("QC_Market=@QC_Market,");
            strSql.Append("QC_Business=@QC_Business,");
            strSql.Append("ManCenter=@ManCenter,");
            strSql.Append("XZ=@XZ,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@WorkContent", SqlDbType.NVarChar,50),
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@Checkman", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@DescProb", SqlDbType.NVarChar,200),
					new SqlParameter("@Result", SqlDbType.NVarChar,100),
					new SqlParameter("@CY_Market", SqlDbType.NVarChar,100),
					new SqlParameter("@CY_Business", SqlDbType.NVarChar,100),
					new SqlParameter("@QC_Market", SqlDbType.NVarChar,100),
					new SqlParameter("@QC_Business", SqlDbType.NVarChar,100),
					new SqlParameter("@ManCenter", SqlDbType.NVarChar,100),
					new SqlParameter("@XZ", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Status;
            parameters[1].Value = model.WorkContent;
            parameters[2].Value = model.Area;
            parameters[3].Value = model.Checkman;
            parameters[4].Value = model.DealerID;
            parameters[5].Value = model.DealerName;
            parameters[6].Value = model.BankID;
            parameters[7].Value = model.BankName;
            parameters[8].Value = model.BrandID;
            parameters[9].Value = model.BrandName;
            parameters[10].Value = model.SID;
            parameters[11].Value = model.SName;
            parameters[12].Value = model.DescProb;
            parameters[13].Value = model.Result;
            parameters[14].Value = model.CY_Market;
            parameters[15].Value = model.CY_Business;
            parameters[16].Value = model.QC_Market;
            parameters[17].Value = model.QC_Business;
            parameters[18].Value = model.ManCenter;
            parameters[19].Value = model.XZ;
            parameters[20].Value = model.Remark;
            parameters[21].Value = model.CreateID;
            parameters[22].Value = model.CreateTime;
            parameters[23].Value = model.ID;

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
            strSql.Append("delete from tb_RiskQuesDay ");
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
            strSql.Append("delete from tb_RiskQuesDay ");
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
        public Citic.Model.RiskQuesDay GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Status,WorkContent,Area,Checkman,DealerID,DealerName,BankID,BankName,BrandID,BrandName,SID,SName,DescProb,Result,CY_Market,CY_Business,QC_Market,QC_Business,ManCenter,XZ,Remark,CreateID,CreateTime from tb_RiskQuesDay ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.RiskQuesDay model = new Citic.Model.RiskQuesDay();
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
        public Citic.Model.RiskQuesDay DataRowToModel(DataRow row)
        {
            Citic.Model.RiskQuesDay model = new Citic.Model.RiskQuesDay();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["WorkContent"] != null)
                {
                    model.WorkContent = row["WorkContent"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["Checkman"] != null)
                {
                    model.Checkman = row["Checkman"].ToString();
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
                if (row["SID"] != null && row["SID"].ToString() != "")
                {
                    model.SID = int.Parse(row["SID"].ToString());
                }
                if (row["SName"] != null)
                {
                    model.SName = row["SName"].ToString();
                }
                if (row["DescProb"] != null)
                {
                    model.DescProb = row["DescProb"].ToString();
                }
                if (row["Result"] != null)
                {
                    model.Result = row["Result"].ToString();
                }
                if (row["CY_Market"] != null)
                {
                    model.CY_Market = row["CY_Market"].ToString();
                }
                if (row["CY_Business"] != null)
                {
                    model.CY_Business = row["CY_Business"].ToString();
                }
                if (row["QC_Market"] != null)
                {
                    model.QC_Market = row["QC_Market"].ToString();
                }
                if (row["QC_Business"] != null)
                {
                    model.QC_Business = row["QC_Business"].ToString();
                }
                if (row["ManCenter"] != null)
                {
                    model.ManCenter = row["ManCenter"].ToString();
                }
                if (row["XZ"] != null)
                {
                    model.XZ = row["XZ"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
            strSql.Append("select ID,Status,WorkContent,Area,Checkman,DealerID,DealerName,BankID,BankName,BrandID,BrandName,SID,SName,DescProb,Result,CY_Market,CY_Business,QC_Market,QC_Business,ManCenter,XZ,Remark,CreateID,CreateTime ");
            strSql.Append(" FROM tb_RiskQuesDay ");
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
            strSql.Append(" ID,Status,WorkContent,Area,Checkman,DealerID,DealerName,BankID,BankName,BrandID,BrandName,SID,SName,DescProb,Result,CY_Market,CY_Business,QC_Market,QC_Business,ManCenter,XZ,Remark,CreateID,CreateTime ");
            strSql.Append(" FROM tb_RiskQuesDay ");
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
            strSql.Append("select count(1) FROM tb_RiskQuesDay ");
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
            strSql.Append(")AS Row, T.*  from tb_RiskQuesDay T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_RiskQuesDay";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        #region 批量添加--乔春羽(2013.12.11)
        public int AddRange(params Citic.Model.RiskQuesDay[] models)
        {
            int num = 0;
            System.Collections.Generic.List<CommandInfo> cInfos = new System.Collections.Generic.List<CommandInfo>();
            string sql = @"INSERT INTO [tb_RiskQuesDay]
                           ([Status],[WorkContent],[Area],[Checkman],[DealerID],[DealerName],[BankID],[BankName]
                           ,[BrandID],[BrandName],[SID],[SName],[DescProb],[Result],[CY_Market],[CY_Business]
                           ,[QC_Market],[QC_Business],[ManCenter],[XZ],[Remark],[CreateID],[CreateTime])
                         VALUES (@Status,@WorkContent,@Area,@Checkman,@DealerID,@DealerName,@BankID,@BankName
                           ,@BrandID,@BrandName,@SID,@SName,@DescProb,@Result,'','','','','','','',@CreateID,@CreateTime)";
            foreach (Citic.Model.RiskQuesDay model in models)
            {
                cInfos.Add(new CommandInfo()
                {
                    CommandText = sql,
                    Parameters = new SqlParameter[]{
                        new SqlParameter("@Status",model.Status),
                        new SqlParameter("@WorkContent",model.WorkContent),
                        new SqlParameter("@Area",model.Area),
                        new SqlParameter("@Checkman",model.Checkman),
                        new SqlParameter("@DealerID",model.DealerID),
                        new SqlParameter("@DealerName",model.DealerName),
                        new SqlParameter("@BankID",model.BankID),
                        new SqlParameter("@BankName",model.BankName),
                        new SqlParameter("@BrandID",model.BrandID),
                        new SqlParameter("@BrandName",model.BrandName),
                        new SqlParameter("@SID",model.SID),
                        new SqlParameter("@SName",model.SName),
                        new SqlParameter("@DescProb",model.DescProb),
                        new SqlParameter("@Result",model.Result),
                        new SqlParameter("@CreateID",model.CreateID),
                        new SqlParameter("@CreateTime",model.CreateTime),
                    }
                });
            }
            try
            {
                DbHelperSQL.ExecuteSqlTran(cInfos);
                num = 1;
            }
            catch (SqlException se)
            {
                num = -1;
                throw se;
            }
            return num;
        }
        #endregion
        #region 批量更新--乔春羽(2013.12.11)
        public int UpdateRange(params Citic.Model.RiskQuesDay[] models)
        {
            int num = 0;
            string sql = @"UPDATE tb_RiskQuesDay SET 
                           [Status] = 1
                          ,[CY_Market] = @CY_Market
                          ,[CY_Business] = @CY_Business
                          ,[QC_Market] = @QC_Market
                          ,[QC_Business] = @QC_Business
                          ,[ManCenter] = @ManCenter
                          ,[XZ] = @XZ
                          ,[Remark] = @Remark WHERE ID=@ID";

            System.Collections.Generic.List<CommandInfo> cInfos = new System.Collections.Generic.List<CommandInfo>();
            foreach (Citic.Model.RiskQuesDay model in models)
            {
                cInfos.Add(new CommandInfo()
                {
                    CommandText = sql,
                    Parameters = new SqlParameter[]{
                        new SqlParameter("@CY_Market",model.CY_Market),
                        new SqlParameter("@CY_Business",model.CY_Business),
                        new SqlParameter("@QC_Market",model.QC_Market),
                        new SqlParameter("@QC_Business",model.QC_Business),
                        new SqlParameter("@ManCenter",model.ManCenter),
                        new SqlParameter("@XZ",model.XZ),
                        new SqlParameter("@Remark",model.Remark),
                        new SqlParameter("@ID",model.ID)
                    }
                });
            }
            try
            {
                DbHelperSQL.ExecuteSqlTran(cInfos);
                num = 1;
            }
            catch (SqlException se)
            {
                num = 0;
                throw se;
            }
            return num;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

