using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Supervisor_History
    /// </summary>
    public partial class Supervisor_History
    {
        public Supervisor_History()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Supervisor_History");
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
        public int Add(Citic.Model.Supervisor_History model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Supervisor_History(");
            strSql.Append("DealerID,DealerName,SupervisorID,SupervisorName,Time_Start,Time_End)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@SupervisorID,@SupervisorName,@Time_Start,@Time_End)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@SupervisorID", SqlDbType.Int,4),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,200),
					new SqlParameter("@Time_Start", SqlDbType.DateTime),
					new SqlParameter("@Time_End", SqlDbType.DateTime)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.SupervisorID;
            parameters[3].Value = model.SupervisorName;
            parameters[4].Value = model.Time_Start;
            parameters[5].Value = model.Time_End;

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
        public bool Update(Citic.Model.Supervisor_History model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Supervisor_History set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("SupervisorID=@SupervisorID,");
            strSql.Append("SupervisorName=@SupervisorName,");
            strSql.Append("Time_Start=@Time_Start,");
            strSql.Append("Time_End=@Time_End");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@SupervisorID", SqlDbType.Int,4),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,200),
					new SqlParameter("@Time_Start", SqlDbType.DateTime),
					new SqlParameter("@Time_End", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.SupervisorID;
            parameters[3].Value = model.SupervisorName;
            parameters[4].Value = model.Time_Start;
            parameters[5].Value = model.Time_End;
            parameters[6].Value = model.ID;

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
            strSql.Append("delete from tb_Supervisor_History ");
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
            strSql.Append("delete from tb_Supervisor_History ");
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
        public Citic.Model.Supervisor_History GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DealerID,DealerName,SupervisorID,SupervisorName,Time_Start,Time_End from tb_Supervisor_History ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.Supervisor_History model = new Citic.Model.Supervisor_History();
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
        public Citic.Model.Supervisor_History DataRowToModel(DataRow row)
        {
            Citic.Model.Supervisor_History model = new Citic.Model.Supervisor_History();
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
                if (row["SupervisorID"] != null && row["SupervisorID"].ToString() != "")
                {
                    model.SupervisorID = int.Parse(row["SupervisorID"].ToString());
                }
                if (row["SupervisorName"] != null)
                {
                    model.SupervisorName = row["SupervisorName"].ToString();
                }
                if (row["Time_Start"] != null && row["Time_Start"].ToString() != "")
                {
                    model.Time_Start = DateTime.Parse(row["Time_Start"].ToString());
                }
                if (row["Time_End"] != null && row["Time_End"].ToString() != "")
                {
                    model.Time_End = DateTime.Parse(row["Time_End"].ToString());
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
            strSql.Append("select ID,DealerID,DealerName,SupervisorID,SupervisorName,Time_Start,Time_End ");
            strSql.Append(" FROM tb_Supervisor_History ");
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
            strSql.Append(" ID,DealerID,DealerName,SupervisorID,SupervisorName,Time_Start,Time_End ");
            strSql.Append(" FROM tb_Supervisor_History ");
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
            strSql.Append("select count(1) FROM tb_Supervisor_History ");
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
            strSql.Append(")AS Row, T.*  from tb_Supervisor_History T ");
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

        #region 根据条件获得一个ID最大的实体--乔春羽
        /// <summary>
        /// 根据条件获得一个ID最大的实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Citic.Model.Supervisor_History GetModelByMaxID(string where)
        {
            DataSet ds = null;
            Citic.Model.Supervisor_History model = new Model.Supervisor_History();
            try
            {
                StringBuilder sql = new System.Text.StringBuilder("select top 1 * from tb_Supervisor_History ");
                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append("where " + where);
                }
                sql.Append(" order by ID Desc");
                ds = DbHelperSQL.Query(sql.ToString());
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        model = DataRowToModel(ds.Tables[0].Rows[0]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return model;
        }
        #endregion


        #endregion  ExtensionMethod
    }
}

