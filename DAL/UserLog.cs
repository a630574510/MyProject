using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:UserLog
    /// </summary>
    public partial class UserLog
    {
        public UserLog()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("LogID", "tb_UserLog");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_UserLog");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.UserLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_UserLog(");
            strSql.Append("UserID,ActionID,ActionDescription,URL,IPAddress,ActionTime,CompanyID,DeptID,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@ActionID,@ActionDescription,@URL,@IPAddress,@ActionTime,@CompanyID,@DeptID,@RoleID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ActionID", SqlDbType.Int,4),
					new SqlParameter("@ActionDescription", SqlDbType.NVarChar,200),
					new SqlParameter("@URL", SqlDbType.NVarChar,500),
					new SqlParameter("@IPAddress", SqlDbType.VarChar,100),
					new SqlParameter("@ActionTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ActionID;
            parameters[2].Value = model.ActionDescription;
            parameters[3].Value = model.URL;
            parameters[4].Value = model.IPAddress;
            parameters[5].Value = model.ActionTime;
            parameters[6].Value = model.CompanyID;
            parameters[7].Value = model.DeptID;
            parameters[8].Value = model.RoleID;

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
        public bool Update(Citic.Model.UserLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserLog set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("ActionID=@ActionID,");
            strSql.Append("ActionDescription=@ActionDescription,");
            strSql.Append("URL=@URL,");
            strSql.Append("IPAddress=@IPAddress,");
            strSql.Append("ActionTime=@ActionTime,");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("DeptID=@DeptID,");
            strSql.Append("RoleID=@RoleID");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@ActionID", SqlDbType.Int,4),
					new SqlParameter("@ActionDescription", SqlDbType.NVarChar,200),
					new SqlParameter("@URL", SqlDbType.NVarChar,500),
					new SqlParameter("@IPAddress", SqlDbType.VarChar,100),
					new SqlParameter("@ActionTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@LogID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.ActionID;
            parameters[2].Value = model.ActionDescription;
            parameters[3].Value = model.URL;
            parameters[4].Value = model.IPAddress;
            parameters[5].Value = model.ActionTime;
            parameters[6].Value = model.CompanyID;
            parameters[7].Value = model.DeptID;
            parameters[8].Value = model.RoleID;
            parameters[9].Value = model.LogID;

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
        public bool Delete(int LogID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserLog ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogID;

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
        public bool DeleteList(string LogIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserLog ");
            strSql.Append(" where LogID in (" + LogIdlist + ")  ");
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
        public Citic.Model.UserLog GetModel(int LogId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LogId,UserId,MenuId,IPAddress,ActionTime,CompanyId,DepartmentId,RoleId from tb_UserLog ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.Int,4)
			};
            parameters[0].Value = LogId;

            Citic.Model.UserLog model = new Citic.Model.UserLog();
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
        public Citic.Model.UserLog DataRowToModel(DataRow row)
        {
            Citic.Model.UserLog model = new Citic.Model.UserLog();
            if (row != null)
            {
                if (row["LogID"] != null && row["LogID"].ToString() != "")
                {
                    model.LogID = int.Parse(row["LogID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["ActionID"] != null && row["ActionID"].ToString() != "")
                {
                    model.ActionID = int.Parse(row["ActionID"].ToString());
                }
                if (row["ActionDescription"] != null)
                {
                    model.ActionDescription = row["ActionDescription"].ToString();
                }
                if (row["URL"] != null)
                {
                    model.URL = row["URL"].ToString();
                }
                if (row["IPAddress"] != null)
                {
                    model.IPAddress = row["IPAddress"].ToString();
                }
                if (row["ActionTime"] != null && row["ActionTime"].ToString() != "")
                {
                    model.ActionTime = DateTime.Parse(row["ActionTime"].ToString());
                }
                if (row["CompanyID"] != null && row["CompanyID"].ToString() != "")
                {
                    model.CompanyID = int.Parse(row["CompanyID"].ToString());
                }
                if (row["DeptID"] != null && row["DeptID"].ToString() != "")
                {
                    model.DeptID = int.Parse(row["DeptID"].ToString());
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
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
            strSql.Append("select LogID,UserID,ActionID,ActionDescription,URL,IPAddress,ActionTime,CompanyID,DeptID,RoleID ");
            strSql.Append(" FROM tb_UserLog ");
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
            strSql.Append(" LogID,UserID,ActionID,ActionDescription,URL,IPAddress,ActionTime,CompanyID,DeptID,RoleID ");
            strSql.Append(" FROM tb_UserLog ");
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
            strSql.Append("select count(1) FROM tb_UserLog ");
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
                strSql.Append("order by T.LogID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_UserLog T ");
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
            parameters[0].Value = "tb_UserLog";
            parameters[1].Value = "LogId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

