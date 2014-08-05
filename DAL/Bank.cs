using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Bank
    /// </summary>
    public partial class Bank
    {
        public Bank()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BankID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Bank_List");
            strSql.Append(" where BankID=@BankID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4)
			};
            parameters[0].Value = BankID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Bank_List(");
            strSql.Append("BankName,BankType,ParentID,Address,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@BankName,@BankType,@ParentID,@Address,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@BankType", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.BankName;
            parameters[1].Value = model.BankType;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.CreateID;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.UpdateID;
            parameters[7].Value = model.UpdateTime;
            parameters[8].Value = model.DeleteID;
            parameters[9].Value = model.DeleteTime;
            parameters[10].Value = model.IsDelete;
            parameters[11].Value = model.IsPort;
            parameters[12].Value = model.ConnectID;

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
        public bool Update(Citic.Model.Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Bank_List set ");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankType=@BankType,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Address=@Address,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where BankID=@BankID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@BankType", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@BankID", SqlDbType.Int,4)};
            parameters[0].Value = model.BankName;
            parameters[1].Value = model.BankType;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.CreateID;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.UpdateID;
            parameters[7].Value = model.UpdateTime;
            parameters[8].Value = model.DeleteID;
            parameters[9].Value = model.DeleteTime;
            parameters[10].Value = model.IsDelete;
            parameters[11].Value = model.IsPort;
            parameters[12].Value = model.ConnectID;
            parameters[13].Value = model.BankID;

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
        public bool Delete(int BankID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Bank_List ");
            strSql.Append(" where BankID=@BankID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4)
			};
            parameters[0].Value = BankID;

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
        public bool DeleteList(string BankIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Bank_List ");
            strSql.Append(" where BankID in (" + BankIDlist + ")  ");
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
        /// 逻辑删除--乔春羽
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Bank model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tb_Bank_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where BankID=@BankID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.DeleteID;
            parameters[2].Value = model.DeleteTime;

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
        /// 批量逻辑删除--乔春羽
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string BankIDList, Citic.Model.Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Bank_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where BankID in (" + BankIDList + ")  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.DeleteID;
            parameters[1].Value = model.DeleteTime;
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
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Bank GetModel(int BankID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BankID,BankName,BankType,ParentID,Address,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Bank_List ");
            strSql.Append(" where BankID=@BankID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4)
			};
            parameters[0].Value = BankID;

            Citic.Model.Bank model = new Citic.Model.Bank();
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
        public Citic.Model.Bank DataRowToModel(DataRow row)
        {
            Citic.Model.Bank model = new Citic.Model.Bank();
            if (row != null)
            {
                if (row["BankID"] != null && row["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(row["BankID"].ToString());
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["BankType"] != null && row["BankType"].ToString() != "")
                {
                    model.BankType = int.Parse(row["BankType"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateID"] != null && row["UpdateID"].ToString() != "")
                {
                    model.UpdateID = int.Parse(row["UpdateID"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["DeleteID"] != null && row["DeleteID"].ToString() != "")
                {
                    model.DeleteID = int.Parse(row["DeleteID"].ToString());
                }
                if (row["DeleteTime"] != null && row["DeleteTime"].ToString() != "")
                {
                    model.DeleteTime = DateTime.Parse(row["DeleteTime"].ToString());
                }
                if (row["IsDelete"] != null && row["IsDelete"].ToString() != "")
                {
                    if ((row["IsDelete"].ToString() == "1") || (row["IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.IsDelete = true;
                    }
                    else
                    {
                        model.IsDelete = false;
                    }
                }
                if (row["IsPort"] != null && row["IsPort"].ToString() != "")
                {
                    if ((row["IsPort"].ToString() == "1") || (row["IsPort"].ToString().ToLower() == "true"))
                    {
                        model.IsPort = true;
                    }
                    else
                    {
                        model.IsPort = false;
                    }
                }
                if (row["ConnectID"] != null)
                {
                    model.ConnectID = row["ConnectID"].ToString();
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
            strSql.Append("select BankID,BankName,BankType,ParentID,Address,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Bank_List T");
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
            strSql.Append(" BankID,BankName,BankType,ParentID,Address,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Bank_List ");
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
            strSql.Append("select count(1) FROM tb_Bank_List T");
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
                strSql.Append("order by T.BankID desc");
            }
            strSql.Append(")AS Row, T.*,ISNULL(B.BankName,'') ParentName from tb_Bank_List T left join tb_Bank_List B on T.ParentID=B.BankID ");
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

        #region 只查询银行的ID与名称--乔春羽
        /// <summary>
        /// 只查询银行的名称与ID
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetBankIDAndBankName(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BankID,BankName");
            strSql.Append(" FROM tb_Bank_List ");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

        #region 执行一条SQL语句--乔春羽(2013.12.11)
        public DataTable Query(string sql)
        {
            DataTable dt = null;
            try
            {
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion

        #region 获得监管员的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT T.BankID,T.BankName,CASE T.BankType WHEN 0 THEN '总行' WHEN 1 THEN '分行' WHEN 2 THEN '支行' END BankType,T.ParentID,ISNULL(B.BankName,'') ParentName,T.Address,T.CreateID,T.CreateTime,T.UpdateID,T.UpdateTime,T.DeleteID,T.DeleteTime,T.IsDelete,T.IsPort,T.ConnectID ");
            strSql.Append(" FROM tb_Bank_List T LEFT JOIN tb_Bank_List B ON T.ParentID=B.BankID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

