using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Factory
    /// </summary>
    public partial class Factory
    {
        public Factory()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FactoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Factory_List");
            strSql.Append(" where FactoryID=@FactoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@FactoryID", SqlDbType.Int,4)
			};
            parameters[0].Value = FactoryID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Factory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Factory_List(");
            strSql.Append("FactoryName,Address,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@FactoryName,@Address,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FactoryName", SqlDbType.NVarChar,50),
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
            parameters[0].Value = model.FactoryName;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.CreateID;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.UpdateID;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.DeleteID;
            parameters[7].Value = model.DeleteTime;
            parameters[8].Value = model.IsDelete;
            parameters[9].Value = model.IsPort;
            parameters[10].Value = model.ConnectID;

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
        public bool Update(Citic.Model.Factory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Factory_List set ");
            strSql.Append("FactoryName=@FactoryName,");
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
            strSql.Append(" where FactoryID=@FactoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@FactoryName", SqlDbType.NVarChar,50),
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
					new SqlParameter("@FactoryID", SqlDbType.Int,4)};
            parameters[0].Value = model.FactoryName;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.CreateID;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.UpdateID;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.DeleteID;
            parameters[7].Value = model.DeleteTime;
            parameters[8].Value = model.IsDelete;
            parameters[9].Value = model.IsPort;
            parameters[10].Value = model.ConnectID;
            parameters[11].Value = model.FactoryID;

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
        public bool Delete(int FactoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Factory_List ");
            strSql.Append(" where FactoryID=@FactoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@FactoryID", SqlDbType.Int,4)
			};
            parameters[0].Value = FactoryID;

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
        public bool DeleteList(string FactoryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Factory_List ");
            strSql.Append(" where FactoryID in (" + FactoryIDlist + ")  ");
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
        public bool DeleteOnLogic(Citic.Model.Factory model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tb_Factory_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where FactoryID=@FactoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@FactoryID", SqlDbType.Int,4),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.FactoryID;
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
        public bool DeleteListOnLogic(string IDList, Citic.Model.Factory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Factory_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where FactoryID in (" + IDList + ")  ");
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
        public Citic.Model.Factory GetModel(int FactoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FactoryID,FactoryName,Address,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Factory_List ");
            strSql.Append(" where FactoryID=@FactoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@FactoryID", SqlDbType.Int,4)
			};
            parameters[0].Value = FactoryID;

            Citic.Model.Factory model = new Citic.Model.Factory();
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
        public Citic.Model.Factory DataRowToModel(DataRow row)
        {
            Citic.Model.Factory model = new Citic.Model.Factory();
            if (row != null)
            {
                if (row["FactoryID"] != null && row["FactoryID"].ToString() != "")
                {
                    model.FactoryID = int.Parse(row["FactoryID"].ToString());
                }
                if (row["FactoryName"] != null)
                {
                    model.FactoryName = row["FactoryName"].ToString();
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
            strSql.Append("select FactoryID,FactoryName,Address,CreateID,CreateName=(select UserName from tb_User where UserId=CreateID),CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Factory_List ");
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
            strSql.Append(" FactoryID,FactoryName,Address,CreateID,CreateName=(select UserName from tb_User where UserId=CreateID),CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Factory_List ");
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
            strSql.Append("select count(1) FROM tb_Factory_List T");
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
                strSql.Append("order by T.FactoryID desc");
            }
            strSql.Append(")AS Row, T.FactoryID,T.FactoryName,T.Address,T.CreateID,CreateName=(select UserName from tb_User where UserId=T.CreateID),T.CreateTime,T.UpdateID,T.UpdateTime,T.DeleteID,T.DeleteTime,T.IsDelete,T.IsPort,T.ConnectID  from tb_Factory_List T ");
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
        #region 根据条件过滤出厂商信息--乔春羽(2013.1.14)
        //        public DataSet GetFactoryByFilter(string where) 
        //        {
        //            DataSet ds = null;
        //            StringBuilder strSql = new StringBuilder(@"SELECT * FROM tb_Factory_List(NOLOCK) 
        //WHERE FactoryID IN 
        //(SELECT FactoryID FROM tb_Brand_List WHERE BrandID IN 
        //(SELECT BrandID FROM tb_Dealer_Bank_List ");
        //            if (!string.IsNullOrEmpty(where)) 
        //            {
        //                strSql.Append(where);
        //            }
        //            strSql.Append(" GROUP BY BrandID))");
        //            try
        //            {
        //                ds = DbHelperSQL.Query(strSql.ToString());
        //            }
        //            catch (SqlException se)
        //            {
        //                throw se;
        //            }
        //            return ds;
        //        }
        #endregion
        #region 获得厂商的所有信息，替换了所有的数字字段--乔春羽(2014.6.6)
        public DataSet GetAllListByProcess(string where, int startIndex, int endIndex)
        {
            DataSet ds = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY FactoryID) Row,FactoryID,FactoryName,Address,CreateID,CreateName =  (SELECT UserName FROM tb_User WHERE UserId = T.CreateID),CreateTime FROM tb_Factory_List T ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.AppendFormat(" WHERE {0}", where);
            }
            strSql.Append(")TT ");
            if (startIndex != 0 && endIndex != 0)
            {
                strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);
            }

            ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

