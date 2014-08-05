using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Brand
    /// </summary>
    public partial class Brand
    {
        public Brand()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BrandID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Brand_List");
            strSql.Append(" where BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4)
			};
            parameters[0].Value = BrandID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Brand_List(");
            strSql.Append("BrandName,FactoryID,Remark,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@BrandName,@FactoryID,@Remark,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@FactoryID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.BrandName;
            parameters[1].Value = model.FactoryID;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.CreateID;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.UpdateID;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.DeleteID;
            parameters[8].Value = model.DeleteTime;
            parameters[9].Value = model.IsDelete;
            parameters[10].Value = model.IsPort;
            parameters[11].Value = model.ConnectID;

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
        public bool Update(Citic.Model.Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Brand_List set ");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("FactoryID=@FactoryID,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@FactoryID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandID", SqlDbType.Int,4)};
            parameters[0].Value = model.BrandName;
            parameters[1].Value = model.FactoryID;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.CreateID;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.UpdateID;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.DeleteID;
            parameters[8].Value = model.DeleteTime;
            parameters[9].Value = model.IsDelete;
            parameters[10].Value = model.IsPort;
            parameters[11].Value = model.ConnectID;
            parameters[12].Value = model.BrandID;

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
        public bool Delete(int BrandID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Brand_List ");
            strSql.Append(" where BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4)
			};
            parameters[0].Value = BrandID;

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
        public bool DeleteList(string BrandIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Brand_List ");
            strSql.Append(" where BrandID in (" + BrandIDlist + ")  ");
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
        public bool DeleteOnLogic(Citic.Model.Brand model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tb_Brand_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.BrandID;
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
        public bool DeleteListOnLogic(string IDList, Citic.Model.Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Brand_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where BrandID in (" + IDList + ")  ");
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
        public Citic.Model.Brand GetModel(int BrandID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BrandID,BrandName,FactoryID,Remark,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Brand_List ");
            strSql.Append(" where BrandID=@BrandID");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandID", SqlDbType.Int,4)
			};
            parameters[0].Value = BrandID;

            Citic.Model.Brand model = new Citic.Model.Brand();
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
        public Citic.Model.Brand DataRowToModel(DataRow row)
        {
            Citic.Model.Brand model = new Citic.Model.Brand();
            if (row != null)
            {
                if (row["BrandID"] != null && row["BrandID"].ToString() != "")
                {
                    model.BrandID = int.Parse(row["BrandID"].ToString());
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
                }
                if (row["FactoryID"] != null && row["FactoryID"].ToString() != "")
                {
                    model.FactoryID = int.Parse(row["FactoryID"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select BrandID,BrandName,FactoryID,Remark,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Brand_List ");
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
            strSql.Append(" BrandID,BrandName,FactoryID,Remark,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Brand_List ");
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
            strSql.Append("select count(1) FROM tb_Brand_List ");
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
                strSql.Append("order by T.BrandID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Brand_List T ");
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
            parameters[0].Value = "tb_Brand_List";
            parameters[1].Value = "BrandID";
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

