using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:XDBG_Record
    /// 巡店报告操作记录
    /// </summary>
    public partial class XDBG_Record
    {
        public XDBG_Record()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_XDBG_Record");
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
        public int Add(Citic.Model.XDBG_Record model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_XDBG_Record(");
            strSql.Append("PID,RecordContent,OperateID,OperateName,TrueName,OperateTime)");
            strSql.Append(" values (");
            strSql.Append("@PID,@RecordContent,@OperateID,@OperateName,@TrueName,@OperateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@RecordContent", SqlDbType.NVarChar,300),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.PID;
            parameters[1].Value = model.RecordContent;
            parameters[2].Value = model.OperateID;
            parameters[3].Value = model.OperateName;
            parameters[4].Value = model.TrueName;
            parameters[5].Value = model.OperateTime;

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
        public bool Update(Citic.Model.XDBG_Record model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_XDBG_Record set ");
            strSql.Append("PID=@PID,");
            strSql.Append("RecordContent=@RecordContent,");
            strSql.Append("OperateID=@OperateID,");
            strSql.Append("OperateName=@OperateName,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("OperateTime=@OperateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@RecordContent", SqlDbType.NVarChar,300),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateName", SqlDbType.NVarChar,50),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PID;
            parameters[1].Value = model.RecordContent;
            parameters[2].Value = model.OperateID;
            parameters[3].Value = model.OperateName;
            parameters[4].Value = model.TrueName;
            parameters[5].Value = model.OperateTime;
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
            strSql.Append("delete from tb_XDBG_Record ");
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
            strSql.Append("delete from tb_XDBG_Record ");
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
        public Citic.Model.XDBG_Record GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PID,RecordContent,OperateID,OperateName,TrueName,OperateTime from tb_XDBG_Record ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.XDBG_Record model = new Citic.Model.XDBG_Record();
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
        public Citic.Model.XDBG_Record DataRowToModel(DataRow row)
        {
            Citic.Model.XDBG_Record model = new Citic.Model.XDBG_Record();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PID"] != null && row["PID"].ToString() != "")
                {
                    model.PID = int.Parse(row["PID"].ToString());
                }
                if (row["RecordContent"] != null)
                {
                    model.RecordContent = row["RecordContent"].ToString();
                }
                if (row["OperateID"] != null && row["OperateID"].ToString() != "")
                {
                    model.OperateID = int.Parse(row["OperateID"].ToString());
                }
                if (row["OperateName"] != null)
                {
                    model.OperateName = row["OperateName"].ToString();
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
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
            strSql.Append("select ID,PID,RecordContent,OperateID,OperateName,TrueName,OperateTime ");
            strSql.Append(" FROM tb_XDBG_Record ");
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
            strSql.Append(" ID,PID,RecordContent,OperateID,OperateName,TrueName,OperateTime ");
            strSql.Append(" FROM tb_XDBG_Record ");
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
            strSql.Append("select count(1) FROM tb_XDBG_Record ");
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
            strSql.Append(")AS Row, T.*  from tb_XDBG_Record T ");
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

