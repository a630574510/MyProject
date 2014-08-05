using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.IO;
using System.Xml;
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:StockError
    /// </summary>
    public partial class StockError
    {
        public StockError()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_StockError_List");
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
        public int Add(Citic.Model.StockError model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_StockError_List(");
            strSql.Append("BankID,BankName,DealerID,DealerName,DraftNo,Vin,CarCost,BrandID,ErrorType,CarStatusOld,ErrorOther,Status,CreateID,CreateTime,OperateID,OperateTime)");
            strSql.Append(" values (");
            strSql.Append("@BankID,@BankName,@DealerID,@DealerName,@DraftNo,@Vin,@CarCost,@BrandID,@ErrorType,@CarStatusOld,@ErrorOther,@Status,@CreateID,@CreateTime,@OperateID,@OperateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.NVarChar,20),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@DealerID", SqlDbType.NVarChar,20),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Vin", SqlDbType.NVarChar,50),
					new SqlParameter("@CarCost", SqlDbType.Money,8),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@ErrorType", SqlDbType.NVarChar,50),
					new SqlParameter("@CarStatusOld", SqlDbType.Int,4),
					new SqlParameter("@ErrorOther", SqlDbType.NVarChar,200),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.DraftNo;
            parameters[5].Value = model.Vin;
            parameters[6].Value = model.CarCost;
            parameters[7].Value = model.BrandID;
            parameters[8].Value = model.ErrorType;
            parameters[9].Value = model.CarStatusOld;
            parameters[10].Value = model.ErrorOther;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.CreateID;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.OperateID;
            parameters[15].Value = model.OperateTime;

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
        public bool Update(Citic.Model.StockError model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_StockError_List set ");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("DraftNo=@DraftNo,");
            strSql.Append("Vin=@Vin,");
            strSql.Append("CarCost=@CarCost,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("ErrorType=@ErrorType,");
            strSql.Append("CarStatusOld=@CarStatusOld,");
            strSql.Append("ErrorOther=@ErrorOther,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("OperateID=@OperateID,");
            strSql.Append("OperateTime=@OperateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.NVarChar,20),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@DealerID", SqlDbType.NVarChar,20),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Vin", SqlDbType.NVarChar,50),
					new SqlParameter("@CarCost", SqlDbType.Money,8),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@ErrorType", SqlDbType.NVarChar,50),
					new SqlParameter("@CarStatusOld", SqlDbType.Int,4),
					new SqlParameter("@ErrorOther", SqlDbType.NVarChar,200),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.DraftNo;
            parameters[5].Value = model.Vin;
            parameters[6].Value = model.CarCost;
            parameters[7].Value = model.BrandID;
            parameters[8].Value = model.ErrorType;
            parameters[9].Value = model.CarStatusOld;
            parameters[10].Value = model.ErrorOther;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.CreateID;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.OperateID;
            parameters[15].Value = model.OperateTime;
            parameters[16].Value = model.ID;

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
            strSql.Append("delete from tb_StockError_List ");
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
            strSql.Append("delete from tb_StockError_List ");
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
        public Citic.Model.StockError GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BankID,BankName,DealerID,DealerName,DraftNo,Vin,CarCost,BrandID,ErrorType,CarStatusOld,ErrorOther,Status,CreateID,CreateTime,OperateID,OperateTime from tb_StockError_List ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.StockError model = new Citic.Model.StockError();
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
        public Citic.Model.StockError DataRowToModel(DataRow row)
        {
            Citic.Model.StockError model = new Citic.Model.StockError();
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
                if (row["DraftNo"] != null)
                {
                    model.DraftNo = row["DraftNo"].ToString();
                }
                if (row["Vin"] != null)
                {
                    model.Vin = row["Vin"].ToString();
                }
                if (row["CarCost"] != null && row["CarCost"].ToString() != "")
                {
                    model.CarCost = decimal.Parse(row["CarCost"].ToString());
                }
                if (row["BrandID"] != null && row["BrandID"].ToString() != "")
                {
                    model.BrandID = int.Parse(row["BrandID"].ToString());
                }
                if (row["ErrorType"] != null)
                {
                    model.ErrorType = row["ErrorType"].ToString();
                }
                if (row["CarStatusOld"] != null && row["CarStatusOld"].ToString() != "")
                {
                    model.CarStatusOld = int.Parse(row["CarStatusOld"].ToString());
                }
                if (row["ErrorOther"] != null)
                {
                    model.ErrorOther = row["ErrorOther"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    if ((row["Status"].ToString() == "1") || (row["Status"].ToString().ToLower() == "true"))
                    {
                        model.Status = true;
                    }
                    else
                    {
                        model.Status = false;
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
                if (row["OperateID"] != null && row["OperateID"].ToString() != "")
                {
                    model.OperateID = int.Parse(row["OperateID"].ToString());
                }
                if (row["OperateTime"] != null && row["OperateTime"].ToString() != "")
                {
                    model.OperateTime = DateTime.Parse(row["OperateTime"].ToString());
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
            strSql.Append("select ID,BankID,BankName,DealerID,DealerName,DraftNo,Vin,CarCost,BrandID,ErrorType,CarStatusOld,ErrorOther,Status,CreateID,CreateTime,OperateID,OperateTime ");
            strSql.Append(" FROM tb_StockError_List ");
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
            strSql.Append(" ID,BankID,BankName,DealerID,DealerName,DraftNo,Vin,CarCost,BrandID,ErrorType,CarStatusOld,ErrorOther,Status,CreateID,CreateTime,OperateID,OperateTime ");
            strSql.Append(" FROM tb_StockError_List ");
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
            strSql.Append("select count(1) FROM tb_StockError_List T ");
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
        public DataSet GetListByPage(string strWhere, string tbName, string orderby, int startIndex, int endIndex)
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
            strSql.AppendFormat(@")AS Row, T.*,U.UserName CreateName,U1.UserName OperateName,B.BrandName
                                FROM tb_StockError_List(NOLOCK) T 
                                LEFT JOIN tb_User(NOLOCK) U ON T.CreateID=U.UserId
                                LEFT JOIN tb_User(NOLOCK) U1 ON T.OperateID=U1.UserId
                                LEFT JOIN tb_Brand_List(NOLOCK) B ON T.BrandID=B.BrandID ", tbName);
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
        #region 导出Excel--乔春羽(2014.1.17)
        public DataTable GetAllProcess(string where)
        {
            DataTable dt = null;
            try
            {
                StringBuilder sbuilder = new StringBuilder();
                sbuilder.Append(@"SELECT T.DealerName,T.DraftNo,T.Vin,T.CarCost,T.BankName,
                                CASE T.ErrorType WHEN 'cl' THEN '车辆异常' WHEN 'hgz' THEN '合格证异常' END ErrorType,T.ErrorOther,
                                CASE T.CarStatusOld WHEN 0 THEN '出库' WHEN 1 THEN '在库' WHEN 2 THEN '移动' WHEN 3 THEN '在途' WHEN 4 THEN '申请中' WHEN 5 THEN '异常' END CarStatusOld,
                                T.Status,T.CreateTime,T.OperateTime,U.UserName CreateName,U1.UserName OperateName,B.BrandName
                                FROM tb_StockError_List(NOLOCK) T 
                                LEFT JOIN tb_User(NOLOCK) U ON T.CreateID=U.UserId
                                LEFT JOIN tb_User(NOLOCK) U1 ON T.OperateID=U1.UserId
                                LEFT JOIN tb_Brand_List(NOLOCK) B ON T.BrandID=B.BrandID ");
                if (!string.IsNullOrEmpty(where))
                {
                    sbuilder.Append(" where " + where);
                }
                dt = DbHelperSQL.Query(sbuilder.ToString()).Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion
        #region 根据合作行ID与经销商ID查询车架号--乔春羽(2013.8.14)
        /// <summary>
        /// 根据合作行ID与经销商ID查询车架号
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetVinsByBankIDAndDealerID(string strWhere)
        {
            DataSet ds = null;
            try
            {
                StringBuilder sql = new StringBuilder("select Vin from tb_StockError_List ");
                if (!string.IsNullOrEmpty(strWhere))
                {
                    sql.Append("where " + strWhere);
                }
                ds = DbHelperSQL.Query(sql.ToString());
            }
            catch (Exception)
            {
            }
            return ds;
        }
        #endregion
        #region 车辆异常统计查询--乔春羽(2013.8.14)
        /// <summary>
        /// 车辆异常统计查询
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="sqlstr">SQL命令</param>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet CarErrorSearch(string path, string sqlstr, string strWhere)
        {
            DataSet ds = null;
            string sql = GetSQL(path, sqlstr);
            if (!string.IsNullOrEmpty(sql))
            {
                if (!string.IsNullOrEmpty(strWhere))
                {
                    sql = sql.Replace("{Where}", "Where " + strWhere);
                }
            }
            try
            {
                ds = DbHelperSQL.Query(sql);
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }
        #endregion
        #region 日车库异常汇总查询--乔春羽(2013.8.7)
        /// <summary>
        /// 日车库异常汇总查询
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="sqlstr">SQL命令</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">分页的开始下标</param>
        /// <param name="endIndex">分页的结束下标</param>
        /// <returns></returns>
        public DataSet StockErrorReportSearch(string path, string sqlstr, string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = null;
            string sql = GetSQL(path, sqlstr);
            if (!string.IsNullOrEmpty(sql))
            {
                if (sql.Contains("{Start}")) { sql = sql.Replace("{Start}", startIndex.ToString()); }
                if (sql.Contains("{End}")) { sql = sql.Replace("{End}", endIndex.ToString()); }
                if (sql.Contains("{Where}")) { sql = sql.Replace("{Where}", strWhere == string.Empty ? "1=1" : strWhere); }
            }
            try
            {
                ds = DbHelperSQL.Query(sql);
            }
            catch
            {
            }
            return ds;
        }
        #endregion
        #region 读取数据总数量--乔春羽(2013.8.7)
        public int GetRecordCount(string path, string sqlcmd, string where)
        {
            int num = 0;
            string sql = GetSQL(path, sqlcmd);
            if (!string.IsNullOrEmpty(sql))
            {
                sql = sql.Replace("{Where}", where == string.Empty ? "1=1" : where);
            }
            try
            {
                num = (int)DbHelperSQL.GetSingle(sql);
            }
            catch
            {
            }
            return num;
        }
        #endregion
        #region 读取配置文件，获取SQL语句--乔春羽(2013.8.7)
        /// <summary>
        /// 读取配置文件，获取SQL语句
        /// </summary>
        /// <returns></returns>
        private string GetSQL(string fileName, string id)
        {
            string sqlstr = string.Empty;
            XmlDocument document = new XmlDocument();
            if (File.Exists(fileName))
            {
                document.Load(fileName);
                XmlElement element = document.DocumentElement;
                foreach (XmlNode node in element.ChildNodes)
                {
                    if (node.Attributes["ID"].Value == id)
                    {
                        sqlstr = node.InnerText;
                        break;
                    }
                }
            }
            return sqlstr;
        }
        #endregion
        #region 批量更新，解除异常--乔春羽(2013.12.23)
        public int UpdateErrorStatusRange(string ids, int userid)
        {
            int num = 0;
            string sql = string.Format("Update tb_StockError_List set Status=1,OperateID='{0}',OperateTime=GETDATE() where ID in ({1})", userid, ids);
            try
            {
                num = DbHelperSQL.ExecuteSql(sql);
            }
            catch (SqlException se)
            {
                throw se;
            }
            return num;
        }
        #endregion
        #region 获得“日查库异常汇总”数据数量--乔春羽(2014.2.20)
        public int GetStockErrorCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" SELECT COUNT(1) FROM(
    SELECT T.BankID,T.BankName,T.DealerID,T.DealerName,T.BrandID FROM tb_StockError_List T
    GROUP BY T.BankID,T.BankName,T.DealerID,T.DealerName,T.BrandID) T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
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
        #endregion
        #endregion  ExtensionMethod
    }
}