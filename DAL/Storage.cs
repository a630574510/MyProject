using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Storage
    /// </summary>
    public partial class Storage
    {
        public Storage()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StorageID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Storage_List ");
            strSql.Append(" where StorageID=@StorageID");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4)
			};
            parameters[0].Value = StorageID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Storage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Storage_List(");
            strSql.Append("StorageName,Address,DealerID,DealerName,Distence,IsLocalStorage,StorageProp,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@StorageName,@Address,@DealerID,@DealerName,@Distence,@IsLocalStorage,@StorageProp,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@Distence", SqlDbType.Decimal,9),
					new SqlParameter("@IsLocalStorage", SqlDbType.Bit,1),
					new SqlParameter("@StorageProp", SqlDbType.NVarChar,10),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.StorageName;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.Distence;
            parameters[5].Value = model.IsLocalStorage;
            parameters[6].Value = model.StorageProp;
            parameters[7].Value = model.CreateID;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.UpdateID;
            parameters[10].Value = model.UpdateTime;
            parameters[11].Value = model.DeleteID;
            parameters[12].Value = model.DeleteTime;
            parameters[13].Value = model.IsDelete;
            parameters[14].Value = model.IsPort;
            parameters[15].Value = model.ConnectID;

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
        public bool Update(Citic.Model.Storage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Storage_List set ");
            strSql.Append("StorageName=@StorageName,");
            strSql.Append("Address=@Address,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("Distence=@Distence,");
            strSql.Append("IsLocalStorage=@IsLocalStorage,");
            strSql.Append("StorageProp=@StorageProp,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where StorageID=@StorageID");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@Distence", SqlDbType.Decimal,9),
					new SqlParameter("@IsLocalStorage", SqlDbType.Bit,1),
					new SqlParameter("@StorageProp", SqlDbType.NVarChar,10),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@StorageID", SqlDbType.Int,4)};
            parameters[0].Value = model.StorageName;
            parameters[1].Value = model.Address;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.Distence;
            parameters[5].Value = model.IsLocalStorage;
            parameters[6].Value = model.StorageProp;
            parameters[7].Value = model.CreateID;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.UpdateID;
            parameters[10].Value = model.UpdateTime;
            parameters[11].Value = model.DeleteID;
            parameters[12].Value = model.DeleteTime;
            parameters[13].Value = model.IsDelete;
            parameters[14].Value = model.IsPort;
            parameters[15].Value = model.ConnectID;
            parameters[16].Value = model.StorageID;

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
        public bool Delete(int StorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Storage_List");
            strSql.Append(" where StorageID=@StorageID");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4)
			};
            parameters[0].Value = StorageID;

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
        public bool DeleteList(string StorageIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Storage_List ");
            strSql.Append(" where StorageID in (" + StorageIDlist + ")  ");
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
        public Citic.Model.Storage GetModel(int StorageID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StorageID,StorageName,Address,DealerID,DealerName,Distence,IsLocalStorage,StorageProp,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Storage_List ");
            strSql.Append(" where StorageID=@StorageID");
            SqlParameter[] parameters = {
					new SqlParameter("@StorageID", SqlDbType.Int,4)
			};
            parameters[0].Value = StorageID;

            Citic.Model.Storage model = new Citic.Model.Storage();
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
        public Citic.Model.Storage DataRowToModel(DataRow row)
        {
            Citic.Model.Storage model = new Citic.Model.Storage();
            if (row != null)
            {
                if (row["StorageID"] != null && row["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(row["StorageID"].ToString());
                }
                if (row["StorageName"] != null)
                {
                    model.StorageName = row["StorageName"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["DealerID"] != null && row["DealerID"].ToString() != "")
                {
                    model.DealerID = int.Parse(row["DealerID"].ToString());
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["Distence"] != null && row["Distence"].ToString() != "")
                {
                    model.Distence = decimal.Parse(row["Distence"].ToString());
                }
                if (row["IsLocalStorage"] != null && row["IsLocalStorage"].ToString() != "")
                {
                    if ((row["IsLocalStorage"].ToString() == "1") || (row["IsLocalStorage"].ToString().ToLower() == "true"))
                    {
                        model.IsLocalStorage = true;
                    }
                    else
                    {
                        model.IsLocalStorage = false;
                    }
                }
                if (row["StorageProp"] != null)
                {
                    model.StorageProp = row["StorageProp"].ToString();
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
            strSql.Append(" select StorageID,StorageName,Address,DealerID,DealerName,Distence,IsLocalStorage,StorageProp,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Storage_List T");
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
            strSql.Append(" StorageID,StorageName,Address,DealerID,DealerName,Distence,IsLocalStorage,StorageProp,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Storage_List ");
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
            strSql.Append("select count(1) FROM tb_Storage_List T ");
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
                strSql.Append("order by T.StorageID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Storage_List T ");
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
        #region 批量逻辑删除--乔春羽（2013.11.29）
        public bool DeletesOnLogic(string IDList, Citic.Model.Storage model)
        {
            bool flag = false;
            try
            {
                string sql = string.Format(@"UPDATE tb_Storage_List SET IsDelete=1,DeleteID={0},DeleteTime=GETDATE() 
                           WHERE StorageID in ({1})", model.DeleteID, IDList);
                flag = DbHelperSQL.ExecuteSql(sql) > 0;
            }
            catch (SqlException se)
            {
                throw se;
            }
            return flag;
        }
        #endregion

        #region 添加二网信息，顺便带上二网的联系人--乔春羽(2013.11.29)
        public int CreateStorage(Citic.Model.Storage model)
        {
            int result = 0;
            int returnValue;
            try
            {
                string proc_Name = "proc_CreateStorage";
                SqlParameter[] param_Storage ={
                    new SqlParameter("@ReturnValue",SqlDbType.Int,4),
                    new SqlParameter("@StorageName",SqlDbType.NVarChar,200),
                    new SqlParameter("@Address",SqlDbType.NVarChar,200),
                    new SqlParameter("@DealerID",SqlDbType.Int,4),
                    new SqlParameter("@DealerName",SqlDbType.NVarChar,200),
                    new SqlParameter("@Distence",SqlDbType.Decimal,18),
                    new SqlParameter("@IsLocalStorage",SqlDbType.Bit),
                    new SqlParameter("@StorageProp",SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateID",SqlDbType.Int,4),
                    new SqlParameter("@CreateTime",SqlDbType.DateTime),
                    new SqlParameter("@UpdateID",SqlDbType.Int,4),
                    new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime),
                    new SqlParameter("@IsDelete",SqlDbType.Bit),
                    new SqlParameter("@IsPort",SqlDbType.Bit),
                    new SqlParameter("@ConnectID",SqlDbType.NVarChar,100),
                    new SqlParameter("@LinkmanName",SqlDbType.NVarChar,100),
                    new SqlParameter("@LinkPhone",SqlDbType.NVarChar,100),
                    new SqlParameter("@LinkType",SqlDbType.Int,4)
                };
                param_Storage[0].Direction = ParameterDirection.Output;
                param_Storage[1].Value = model.StorageName;
                param_Storage[2].Value = model.Address;
                param_Storage[3].Value = model.DealerID;
                param_Storage[4].Value = model.DealerName;
                param_Storage[5].Value = model.Distence;
                param_Storage[6].Value = model.IsLocalStorage;
                param_Storage[7].Value = model.StorageProp;
                param_Storage[8].Value = model.CreateID;
                param_Storage[9].Value = model.CreateTime;
                param_Storage[10].Value = model.UpdateID;
                param_Storage[11].Value = model.UpdateTime;
                param_Storage[12].Value = model.DeleteID;
                param_Storage[13].Value = model.DeleteTime;
                param_Storage[14].Value = model.IsDelete;
                param_Storage[15].Value = model.IsPort;
                param_Storage[16].Value = model.ConnectID;
                param_Storage[17].Value = model.LinkManName;
                param_Storage[18].Value = model.LinkPhone;
                param_Storage[19].Value = model.LinkType;
                result = DbHelperSQL.RunProcedure(proc_Name, param_Storage, out returnValue);
            }
            catch (SqlException se)
            {
                throw se;
            }
            return result;
        }
        #endregion

        #region 获得一个二网信息，该二网信息中还带有联系人的信息--乔春羽(2013.11.29)
        public Citic.Model.Storage GetStorageWithLinkman(int storageID)
        {
            Citic.Model.Storage model = null;
            try
            {
                string sql = string.Format("SELECT T.*,ll.LinkmanName,ll.Phone FROM tb_Storage_List T left join tb_Linkman_List ll on T.StorageID=ll.RelationID WHERE T.StorageID={0}", storageID);
                SqlDataReader reader = DbHelperSQL.ExecuteReader(sql);
                if (reader.Read())
                {
                    model = new Model.Storage();
                    model.StorageID = storageID;
                    model.Address = reader["Address"].ToString();
                    model.ConnectID = reader["ConnectID"].ToString();
                    model.CreateID = Convert.ToInt32(reader["CreateID"]);
                    model.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                    model.DealerID = Convert.ToInt32(reader["DealerID"]);
                    model.DealerName = reader["DealerName"].ToString();
                    model.Distence = Convert.ToDecimal(reader["Distence"].ToString() == string.Empty ? 0 : reader["Distence"]);
                    model.IsDelete = Convert.ToBoolean(reader["IsDelete"]);
                    model.IsLocalStorage = Convert.ToBoolean(reader["IsLocalStorage"]);
                    model.IsPort = Convert.ToBoolean(reader["IsPort"]);
                    model.LinkManName = reader["LinkmanName"].ToString();
                    model.LinkPhone = reader["Phone"].ToString();
                    model.StorageName = reader["StorageName"].ToString();
                    model.StorageProp = reader["StorageProp"].ToString();
                }
                reader.Close();
            }
            catch (SqlException se)
            {
                throw se;
            }
            return model;
        }
        #endregion

        #region 修改二网信息，顺带修改二网的联系人信息--乔春羽(2013.11.29)
        public int ModifyStorage(Citic.Model.Storage model)
        {
            int result = 0;
            int returnValue = 0;
            try
            {
                string proc_Name = "proc_ModifyStorage";
                SqlParameter[] param_Storage ={
                    new SqlParameter("@ReturnValue",SqlDbType.Int,4),
                    new SqlParameter("@StorageName",SqlDbType.NVarChar,200),
                    new SqlParameter("@Address",SqlDbType.NVarChar,200),
                    new SqlParameter("@DealerID",SqlDbType.Int,4),
                    new SqlParameter("@DealerName",SqlDbType.NVarChar,200),
                    new SqlParameter("@Distence",SqlDbType.Decimal,18),
                    new SqlParameter("@IsLocalStorage",SqlDbType.Bit),
                    new SqlParameter("@StorageProp",SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateID",SqlDbType.Int,4),
                    new SqlParameter("@CreateTime",SqlDbType.DateTime),
                    new SqlParameter("@UpdateID",SqlDbType.Int,4),
                    new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime),
                    new SqlParameter("@IsDelete",SqlDbType.Bit),
                    new SqlParameter("@IsPort",SqlDbType.Bit),
                    new SqlParameter("@ConnectID",SqlDbType.NVarChar,100),
                    new SqlParameter("@LinkmanName",SqlDbType.NVarChar,100),
                    new SqlParameter("@LinkPhone",SqlDbType.NVarChar,100),
                    new SqlParameter("@LinkType",SqlDbType.Int,4),
                    new SqlParameter("@StorageID",SqlDbType.Int,4)
                };
                param_Storage[0].Direction = ParameterDirection.Output;
                param_Storage[1].Value = model.StorageName;
                param_Storage[2].Value = model.Address;
                param_Storage[3].Value = model.DealerID;
                param_Storage[4].Value = model.DealerName;
                param_Storage[5].Value = model.Distence;
                param_Storage[6].Value = model.IsLocalStorage;
                param_Storage[7].Value = model.StorageProp;
                param_Storage[8].Value = model.CreateID;
                param_Storage[9].Value = model.CreateTime;
                param_Storage[10].Value = model.UpdateID;
                param_Storage[11].Value = model.UpdateTime;
                param_Storage[12].Value = model.DeleteID;
                param_Storage[13].Value = model.DeleteTime;
                param_Storage[14].Value = model.IsDelete;
                param_Storage[15].Value = model.IsPort;
                param_Storage[16].Value = model.ConnectID;
                param_Storage[17].Value = model.LinkManName;
                param_Storage[18].Value = model.LinkPhone;
                param_Storage[19].Value = model.LinkType;
                param_Storage[20].Value = model.StorageID;
                result = DbHelperSQL.RunProcedure(proc_Name, param_Storage, out returnValue);
            }
            catch (SqlException se)
            {
                throw se;
            }
            return result;
        }
        #endregion

        #region 获得二网的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess(string where, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM ( SELECT ROW_NUMBER() OVER(Order By StorageID) Row, StorageID,StorageName,Address,DealerID,DealerName,ISNULL(Distence,0.00) Distence,
CASE IsLocalStorage WHEN 0 THEN '二网' WHEN 1 THEN '本库' END IsLocalStorage,
dbo.changeFinancingMode(StorageProp,'storage') StorageProp,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Storage_List ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.AppendFormat(" WHERE {0}", where);
            }
            strSql.Append(" ) T");
            if (startIndex != 0 && endIndex != 0)
            {
                strSql.AppendFormat(" WHERE T.Row BETWEEN {0} AND {1}", startIndex, endIndex);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

