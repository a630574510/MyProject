using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:UserMapping
    /// </summary>
    public partial class UserMapping
    {
        public UserMapping()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_UserMapping");
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
        public int Add(Citic.Model.UserMapping model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_UserMapping(");
            strSql.Append("UserID,RoleID,MappingID,MappingType)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@RoleID,@MappingID,@MappingType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@MappingID", SqlDbType.Int,4),
					new SqlParameter("@MappingType", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.MappingID;
            parameters[3].Value = model.MappingType;

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
        public bool Update(Citic.Model.UserMapping model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserMapping set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("MappingID=@MappingID,");
            strSql.Append("MappingType=@MappingType");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@MappingID", SqlDbType.Int,4),
					new SqlParameter("@MappingType", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.MappingID;
            parameters[3].Value = model.MappingType;
            parameters[4].Value = model.ID;

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
            strSql.Append("delete from tb_UserMapping ");
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
            strSql.Append("delete from tb_UserMapping ");
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
        public Citic.Model.UserMapping GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserID,RoleID,MappingID,MappingType from tb_UserMapping ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.UserMapping model = new Citic.Model.UserMapping();
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
        public Citic.Model.UserMapping DataRowToModel(DataRow row)
        {
            Citic.Model.UserMapping model = new Citic.Model.UserMapping();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["MappingID"] != null && row["MappingID"].ToString() != "")
                {
                    model.MappingID = int.Parse(row["MappingID"].ToString());
                }
                if (row["MappingType"] != null)
                {
                    model.MappingType = row["MappingType"].ToString();
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
            strSql.Append("select ID,UserID,RoleID,MappingID,MappingType ");
            strSql.Append(" FROM tb_UserMapping ");
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
            strSql.Append(" ID,UserID,RoleID,MappingID,MappingType ");
            strSql.Append(" FROM tb_UserMapping ");
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
            strSql.Append("select count(1) FROM tb_UserMapping ");
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
            strSql.Append(")AS Row, T.*  from tb_UserMapping T ");
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

        #region 批量添加--乔春羽(2014.3.5)
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int AddRange(Citic.Model.UserMapping[] models)
        {
            int result = 0;
            try
            {
                List<CommandInfo> cInfos = new List<CommandInfo>();
                if (models != null && models.Length > 0)
                {
                    foreach (Citic.Model.UserMapping model in models)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into tb_UserMapping(");
                        strSql.AppendLine("UserID,RoleID,MappingID,MappingType)");
                        strSql.AppendLine("values (@UserID,@RoleID,@MappingID,@MappingType)");
                        SqlParameter[] param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID",model.UserID),
                        new SqlParameter("@RoleID",model.RoleID),
                        new SqlParameter("@MappingID",model.MappingID),
                        new SqlParameter("@MappingType",model.MappingType)
                    };
                        cInfos.Add(new CommandInfo(strSql.ToString(), param));
                    }
                }
                result = DbHelperSQL.ExecuteSqlTran(cInfos);
            }
            catch (Exception)
            {
            }
            return result;
        }
        #endregion

        #region 根据条件删除--乔春羽(2014.3.5)
        public int DeleteByCondition(string where)
        {
            int num = 0;
            try
            {
                StringBuilder strSql = new StringBuilder("Delete tb_UserMapping Where ");
                strSql.Append(where);
                num = DbHelperSQL.ExecuteSql(strSql.ToString());
            }
            catch (Exception)
            {

            }
            return num;
        }
        #endregion

        #region 根据条件查询一个实体对象--乔春羽(2014.3.7)
        public Citic.Model.UserMapping GetModelByCondition(string where)
        {
            Citic.Model.UserMapping model = null;
            StringBuilder strSql = new StringBuilder("Select top 1 * from tb_UserMapping ");
            try
            {
                if (!string.IsNullOrEmpty(where))
                {
                    strSql.AppendFormat(" where {0}", where);
                }
                SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString());
                if (reader.Read()) 
                {
                    model = new Model.UserMapping();
                    model.ID = (int)reader["ID"];
                    model.MappingID = (int)reader["MappingID"];
                    model.MappingType = reader["MappingType"].ToString();
                    model.RoleID = (int)reader["RoleID"];
                    model.UserID = (int)reader["UserID"];
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion

        #endregion  ExtensionMethod
    }
}

