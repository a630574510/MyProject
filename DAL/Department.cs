using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Department
    /// </summary>
    public partial class Department
    {
        public Department()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Department");
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
        public int Add(Citic.Model.Department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Department(");
            strSql.Append("DName,PDID,Description,Type,CID)");
            strSql.Append(" values (");
            strSql.Append("@DName,@PDID,@Description,@Type,@CID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DName", SqlDbType.VarChar,50),
					new SqlParameter("@PDID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,200),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@CID", SqlDbType.Int,4)};
            parameters[0].Value = model.DName;
            parameters[1].Value = model.PDID;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.CID;

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
        public bool Update(Citic.Model.Department model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Department set ");
            strSql.Append("DName=@DName,");
            strSql.Append("PDID=@PDID,");
            strSql.Append("Description=@Description,");
            strSql.Append("Type=@Type,");
            strSql.Append("CID=@CID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DName", SqlDbType.VarChar,50),
					new SqlParameter("@PDID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,200),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DName;
            parameters[1].Value = model.PDID;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.CID;
            parameters[5].Value = model.ID;

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
            strSql.Append("delete from tb_Department ");
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
            strSql.Append("delete from tb_Department ");
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
        public Citic.Model.Department GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DName,PDID,Description,Type,CID from tb_Department ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.Department model = new Citic.Model.Department();
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
        public Citic.Model.Department DataRowToModel(DataRow row)
        {
            Citic.Model.Department model = new Citic.Model.Department();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DName"] != null)
                {
                    model.DName = row["DName"].ToString();
                }
                if (row["PDID"] != null && row["PDID"].ToString() != "")
                {
                    model.PDID = int.Parse(row["PDID"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["CID"] != null && row["CID"].ToString() != "")
                {
                    model.CID = int.Parse(row["CID"].ToString());
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
            strSql.Append("select ID,DName,PDID,Description,Type,CID ");
            strSql.Append(" FROM tb_Department ");
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
            strSql.Append(" ID,DName,PDID,Description,Type,CID ");
            strSql.Append(" FROM tb_Department ");
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
            strSql.Append("select count(1) FROM tb_Department ");
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
            strSql.Append(")AS Row, T.*  from tb_Department T ");
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
        #region 根据ID获取部门的类型--乔春羽(2013.8.28)
        public int GetDepTypeByID(int id)
        {
            int type = 0;
            string sql = "select Type from tb_Department where ID=@ID";
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int, 4);
            param.Value = id;
            try
            {
                type = Convert.ToInt32(DbHelperSQL.GetSingle(sql, param));
            }
            catch (Exception)
            {
            }
            return type;
        }
        #endregion

        #region 根据父ID获取子部门ID--乔春羽(2013.8.28)
        public int[] GetDepartmentsByPID(int pid)
        {
            List<int> ds = new List<int>();
            string sql = "select ID from tb_Department where PDID=@PID or (PDID=0 and Type=0)";
            SqlParameter param = new SqlParameter("@PID", SqlDbType.Int, 4);
            param.Value = pid;
            try
            {
                DataTable dt = DbHelperSQL.Query(sql, param).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ds.Add(Convert.ToInt32(row["ID"]));
                    }
                }
            }
            catch (Exception)
            {
            }
            return ds.ToArray();
        }
        #endregion

        #endregion  ExtensionMethod
    }
}

