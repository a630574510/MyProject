using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Car_Status
    /// </summary>
    public partial class Car_Status
    {
        public Car_Status()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Car_Status");
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
        public int Add(Citic.Model.Car_Status model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Car_Status(");
            strSql.Append("Vin,StatusType,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@Vin,@StatusType,@CreateID,@CreateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Vin", SqlDbType.NVarChar,50),
					new SqlParameter("@StatusType", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Vin;
            parameters[1].Value = model.StatusType;
            parameters[2].Value = model.CreateID;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.DeleteID;
            parameters[5].Value = model.DeleteTime;
            parameters[6].Value = model.IsDelete;
            parameters[7].Value = model.IsPort;
            parameters[8].Value = model.ConnectID;

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
        public bool Update(Citic.Model.Car_Status model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Car_Status set ");
            strSql.Append("Vin=@Vin,");
            strSql.Append("StatusType=@StatusType,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Vin", SqlDbType.NVarChar,50),
					new SqlParameter("@StatusType", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Vin;
            parameters[1].Value = model.StatusType;
            parameters[2].Value = model.CreateID;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.DeleteID;
            parameters[5].Value = model.DeleteTime;
            parameters[6].Value = model.IsDelete;
            parameters[7].Value = model.IsPort;
            parameters[8].Value = model.ConnectID;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from tb_Car_Status ");
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
            strSql.Append("delete from tb_Car_Status ");
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
        public Citic.Model.Car_Status GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Vin,StatusType,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Car_Status ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.Car_Status model = new Citic.Model.Car_Status();
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
        public Citic.Model.Car_Status DataRowToModel(DataRow row)
        {
            Citic.Model.Car_Status model = new Citic.Model.Car_Status();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Vin"] != null)
                {
                    model.Vin = row["Vin"].ToString();
                }
                if (row["StatusType"] != null && row["StatusType"].ToString() != "")
                {
                    model.StatusType = int.Parse(row["StatusType"].ToString());
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
            strSql.Append("select ID,Vin,StatusType,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Car_Status ");
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
            strSql.Append(" ID,Vin,StatusType,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Car_Status ");
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
            strSql.Append("select count(1) FROM tb_Car_Status ");
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
            strSql.Append(")AS Row, T.*  from tb_Car_Status T ");
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

