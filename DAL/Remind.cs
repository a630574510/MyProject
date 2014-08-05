using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Remind
    /// </summary>
    public partial class Remind
    {
        public Remind()
        { }
        #region  BasicMethod
        /// <summary>
        /// 提醒信息银行id查询银行 张繁 2013年11月19日
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetRemindByBankId(string strSql)
        {
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Remind");
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
        public int Add(Citic.Model.Remind model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Remind(");
            strSql.Append("BankID,BankName,DealerID,DealerName,BrandID,BrandName,EnteringDate,SupervisionFeeMoney,Remark,DueDate,SupervisionFeeAsDate,OutboundDate,StoreCount,DraftNo,DraftMoney,BeginDraftDate,PledgeMoney,NotMoney,StoreMoney,BusinessModel,ReplaceDate,OriginalSupervision,NowSupervision,CreateDate,DeterminePeople,DetermineDate,Status)");
            strSql.Append(" values (");
            strSql.Append("@BankID,@BankName,@DealerID,@DealerName,@BrandID,@BrandName,@EnteringDate,@SupervisionFeeMoney,@Remark,@DueDate,@SupervisionFeeAsDate,@OutboundDate,@StoreCount,@DraftNo,@DraftMoney,@BeginDraftDate,@PledgeMoney,@NotMoney,@StoreMoney,@BusinessModel,@ReplaceDate,@OriginalSupervision,@NowSupervision,@CreateDate,@DeterminePeople,@DetermineDate,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.NVarChar,50),
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerID", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandID", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnteringDate", SqlDbType.DateTime),
					new SqlParameter("@SupervisionFeeMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@DueDate", SqlDbType.DateTime),
					new SqlParameter("@SupervisionFeeAsDate", SqlDbType.DateTime),
					new SqlParameter("@OutboundDate", SqlDbType.DateTime),
					new SqlParameter("@StoreCount", SqlDbType.NVarChar,50),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,200),
					new SqlParameter("@DraftMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDraftDate", SqlDbType.DateTime),
					new SqlParameter("@PledgeMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@NotMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessModel", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplaceDate", SqlDbType.DateTime),
					new SqlParameter("@OriginalSupervision", SqlDbType.NVarChar,50),
					new SqlParameter("@NowSupervision", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@DeterminePeople", SqlDbType.NVarChar,50),
					new SqlParameter("@DetermineDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4)};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.EnteringDate;
            parameters[7].Value = model.SupervisionFeeMoney;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.DueDate;
            parameters[10].Value = model.SupervisionFeeAsDate;
            parameters[11].Value = model.OutboundDate;
            parameters[12].Value = model.StoreCount;
            parameters[13].Value = model.DraftNo;
            parameters[14].Value = model.DraftMoney;
            parameters[15].Value = model.BeginDraftDate;
            parameters[16].Value = model.PledgeMoney;
            parameters[17].Value = model.NotMoney;
            parameters[18].Value = model.StoreMoney;
            parameters[19].Value = model.BusinessModel;
            parameters[20].Value = model.ReplaceDate;
            parameters[21].Value = model.OriginalSupervision;
            parameters[22].Value = model.NowSupervision;
            parameters[23].Value = model.CreateDate;
            parameters[24].Value = model.DeterminePeople;
            parameters[25].Value = model.DetermineDate;
            parameters[26].Value = model.Status;

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
        public bool Update(Citic.Model.Remind model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Remind set ");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("EnteringDate=@EnteringDate,");
            strSql.Append("SupervisionFeeMoney=@SupervisionFeeMoney,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("DueDate=@DueDate,");
            strSql.Append("SupervisionFeeAsDate=@SupervisionFeeAsDate,");
            strSql.Append("OutboundDate=@OutboundDate,");
            strSql.Append("StoreCount=@StoreCount,");
            strSql.Append("DraftNo=@DraftNo,");
            strSql.Append("DraftMoney=@DraftMoney,");
            strSql.Append("BeginDraftDate=@BeginDraftDate,");
            strSql.Append("PledgeMoney=@PledgeMoney,");
            strSql.Append("NotMoney=@NotMoney,");
            strSql.Append("StoreMoney=@StoreMoney,");
            strSql.Append("BusinessModel=@BusinessModel,");
            strSql.Append("ReplaceDate=@ReplaceDate,");
            strSql.Append("OriginalSupervision=@OriginalSupervision,");
            strSql.Append("NowSupervision=@NowSupervision,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("DeterminePeople=@DeterminePeople,");
            strSql.Append("DetermineDate=@DetermineDate,");
            strSql.Append("Status=@Status");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.NVarChar,50),
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerID", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandID", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnteringDate", SqlDbType.DateTime),
					new SqlParameter("@SupervisionFeeMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@DueDate", SqlDbType.DateTime),
					new SqlParameter("@SupervisionFeeAsDate", SqlDbType.DateTime),
					new SqlParameter("@OutboundDate", SqlDbType.DateTime),
					new SqlParameter("@StoreCount", SqlDbType.NVarChar,50),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,200),
					new SqlParameter("@DraftMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDraftDate", SqlDbType.DateTime),
					new SqlParameter("@PledgeMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@NotMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessModel", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplaceDate", SqlDbType.DateTime),
					new SqlParameter("@OriginalSupervision", SqlDbType.NVarChar,50),
					new SqlParameter("@NowSupervision", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@DeterminePeople", SqlDbType.NVarChar,50),
					new SqlParameter("@DetermineDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.EnteringDate;
            parameters[7].Value = model.SupervisionFeeMoney;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.DueDate;
            parameters[10].Value = model.SupervisionFeeAsDate;
            parameters[11].Value = model.OutboundDate;
            parameters[12].Value = model.StoreCount;
            parameters[13].Value = model.DraftNo;
            parameters[14].Value = model.DraftMoney;
            parameters[15].Value = model.BeginDraftDate;
            parameters[16].Value = model.PledgeMoney;
            parameters[17].Value = model.NotMoney;
            parameters[18].Value = model.StoreMoney;
            parameters[19].Value = model.BusinessModel;
            parameters[20].Value = model.ReplaceDate;
            parameters[21].Value = model.OriginalSupervision;
            parameters[22].Value = model.NowSupervision;
            parameters[23].Value = model.CreateDate;
            parameters[24].Value = model.DeterminePeople;
            parameters[25].Value = model.DetermineDate;
            parameters[26].Value = model.Status;
            parameters[27].Value = model.ID;

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
            strSql.Append("delete from tb_Remind ");
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

            strSql.Append("delete from tb_Remind ");
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
        public Citic.Model.Remind GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BankID,BankName,DealerID,DealerName,BrandID,BrandName,EnteringDate,SupervisionFeeMoney,Remark,DueDate,SupervisionFeeAsDate,OutboundDate,StoreCount,DraftNo,DraftMoney,BeginDraftDate,PledgeMoney,NotMoney,StoreMoney,BusinessModel,ReplaceDate,OriginalSupervision,NowSupervision,CreateDate,DeterminePeople,DetermineDate,Status from tb_Remind ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.Remind model = new Citic.Model.Remind();
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
        public Citic.Model.Remind DataRowToModel(DataRow row)
        {
            Citic.Model.Remind model = new Citic.Model.Remind();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["BankID"] != null)
                {
                    model.BankID = row["BankID"].ToString();
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["DealerID"] != null)
                {
                    model.DealerID = row["DealerID"].ToString();
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["BrandID"] != null)
                {
                    model.BrandID = row["BrandID"].ToString();
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
                }
                if (row["EnteringDate"] != null && row["EnteringDate"].ToString() != "")
                {
                    model.EnteringDate = DateTime.Parse(row["EnteringDate"].ToString());
                }
                if (row["SupervisionFeeMoney"] != null)
                {
                    model.SupervisionFeeMoney = row["SupervisionFeeMoney"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["DueDate"] != null && row["DueDate"].ToString() != "")
                {
                    model.DueDate = DateTime.Parse(row["DueDate"].ToString());
                }
                if (row["SupervisionFeeAsDate"] != null && row["SupervisionFeeAsDate"].ToString() != "")
                {
                    model.SupervisionFeeAsDate = DateTime.Parse(row["SupervisionFeeAsDate"].ToString());
                }
                if (row["OutboundDate"] != null && row["OutboundDate"].ToString() != "")
                {
                    model.OutboundDate = DateTime.Parse(row["OutboundDate"].ToString());
                }
                if (row["StoreCount"] != null)
                {
                    model.StoreCount = row["StoreCount"].ToString();
                }
                if (row["DraftNo"] != null)
                {
                    model.DraftNo = row["DraftNo"].ToString();
                }
                if (row["DraftMoney"] != null)
                {
                    model.DraftMoney = row["DraftMoney"].ToString();
                }
                if (row["BeginDraftDate"] != null && row["BeginDraftDate"].ToString() != "")
                {
                    model.BeginDraftDate = DateTime.Parse(row["BeginDraftDate"].ToString());
                }
                if (row["PledgeMoney"] != null)
                {
                    model.PledgeMoney = row["PledgeMoney"].ToString();
                }
                if (row["NotMoney"] != null)
                {
                    model.NotMoney = row["NotMoney"].ToString();
                }
                if (row["StoreMoney"] != null)
                {
                    model.StoreMoney = row["StoreMoney"].ToString();
                }
                if (row["BusinessModel"] != null)
                {
                    model.BusinessModel = row["BusinessModel"].ToString();
                }
                if (row["ReplaceDate"] != null && row["ReplaceDate"].ToString() != "")
                {
                    model.ReplaceDate = DateTime.Parse(row["ReplaceDate"].ToString());
                }
                if (row["OriginalSupervision"] != null)
                {
                    model.OriginalSupervision = row["OriginalSupervision"].ToString();
                }
                if (row["NowSupervision"] != null)
                {
                    model.NowSupervision = row["NowSupervision"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["DeterminePeople"] != null)
                {
                    model.DeterminePeople = row["DeterminePeople"].ToString();
                }
                if (row["DetermineDate"] != null && row["DetermineDate"].ToString() != "")
                {
                    model.DetermineDate = DateTime.Parse(row["DetermineDate"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
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
            strSql.Append("select ID,BankID,BankName,DealerID,DealerName,BrandID,BrandName,EnteringDate,SupervisionFeeMoney,Remark,DueDate,SupervisionFeeAsDate,OutboundDate,StoreCount,DraftNo,DraftMoney,BeginDraftDate,PledgeMoney,NotMoney,StoreMoney,BusinessModel,ReplaceDate,OriginalSupervision,NowSupervision,CreateDate,DeterminePeople,DetermineDate,Status ");
            strSql.Append(" FROM tb_Remind ");
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
            strSql.Append(" ID,BankID,BankName,DealerID,DealerName,BrandID,BrandName,EnteringDate,SupervisionFeeMoney,Remark,DueDate,SupervisionFeeAsDate,OutboundDate,StoreCount,DraftNo,DraftMoney,BeginDraftDate,PledgeMoney,NotMoney,StoreMoney,BusinessModel,ReplaceDate,OriginalSupervision,NowSupervision,CreateDate,DeterminePeople,DetermineDate,Status ");
            strSql.Append(" FROM tb_Remind ");
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
            strSql.Append("select count(1) FROM tb_Remind ");
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
            strSql.Append(")AS Row, T.*  from tb_Remind T ");
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

