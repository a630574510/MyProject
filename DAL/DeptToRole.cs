using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:DeptToRole
    /// </summary>
    public partial class DeptToRole
    {
        public DeptToRole()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DeptToRole");
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
        public int Add(Citic.Model.DeptToRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DeptToRole(");
            strSql.Append("DeptID,RoleID,RoleName)");
            strSql.Append(" values (");
            strSql.Append("@DeptID,@RoleID,@RoleName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.DeptID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.RoleName;

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
        public bool Update(Citic.Model.DeptToRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DeptToRole set ");
            strSql.Append("DeptID=@DeptID,");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("RoleName=@RoleName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DeptID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.RoleName;
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_DeptToRole ");
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
            strSql.Append("delete from tb_DeptToRole ");
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
        public Citic.Model.DeptToRole GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DeptID,RoleID,RoleName from tb_DeptToRole ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.DeptToRole model = new Citic.Model.DeptToRole();
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
        public Citic.Model.DeptToRole DataRowToModel(DataRow row)
        {
            Citic.Model.DeptToRole model = new Citic.Model.DeptToRole();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DeptID"] != null && row["DeptID"].ToString() != "")
                {
                    model.DeptID = int.Parse(row["DeptID"].ToString());
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
                }
                if (row["RoleName"] != null)
                {
                    model.RoleName = row["RoleName"].ToString();
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
            strSql.Append("select ID,DeptID,RoleID,RoleName ");
            strSql.Append(" FROM tb_DeptToRole ");
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
            strSql.Append(" ID,DeptID,RoleID,RoleName ");
            strSql.Append(" FROM tb_DeptToRole ");
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
            strSql.Append("select count(1) FROM tb_DeptToRole ");
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
            strSql.Append(")AS Row, T.*  from tb_DeptToRole T ");
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

        #region 批量添加--乔春羽(2014.3.24)
        public int AddRange(Citic.Model.DeptToRole[] models)
        {
            int num = 0;
            System.Collections.Generic.List<CommandInfo> cInfos = null;
            if (models != null && models.Length > 0)
            {
                cInfos = new System.Collections.Generic.List<CommandInfo>();
                StringBuilder strSql = null;
                foreach (Citic.Model.DeptToRole model in models)
                {
                    strSql = new StringBuilder("Insert into tb_DeptToRole (DeptID,RoleID) ");
                    strSql.Append(" Values (@DeptID,@RoleID)");

                    SqlParameter[] param = new SqlParameter[]
                    {
                        new  SqlParameter("@DeptID",model.DeptID),
                        new SqlParameter("@RoleID",model.RoleID)
                    };
                    cInfos.Add(new CommandInfo(strSql.ToString(), param));
                }
                try
                {
                    num = DbHelperSQL.ExecuteSqlTran(cInfos);
                }
                catch
                {
                    num = 0;
                }
            }
            return num;
        }
        #endregion

        #endregion  ExtensionMethod
    }
}

