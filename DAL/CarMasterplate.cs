using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:CarMasterplate
    /// </summary>
    public partial class CarMasterplate
    {
        public CarMasterplate()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_CarMasterplate");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.CarMasterplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_CarMasterplate(");
            strSql.Append("DealerID,DealerName,BankID,BankName,FileName1,FileName2,FileName3,FileName4,FileName5,FileName6,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@BankID,@BankName,@FileName1,@FileName2,@FileName3,@FileName4,@FileName5,@FileName6,@CountCar,@CreateID,@CreateName,@CreateTime,@TypeID,@isDel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileName1", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName2", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName3", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName4", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName5", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName6", SqlDbType.NVarChar,-1),
					new SqlParameter("@CountCar", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@isDel", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.FileName1;
            parameters[5].Value = model.FileName2;
            parameters[6].Value = model.FileName3;
            parameters[7].Value = model.FileName4;
            parameters[8].Value = model.FileName5;
            parameters[9].Value = model.FileName6;
            parameters[10].Value = model.CountCar;
            parameters[11].Value = model.CreateID;
            parameters[12].Value = model.CreateName;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.TypeID;
            parameters[15].Value = model.isDel;

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
        public bool Update(Citic.Model.CarMasterplate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_CarMasterplate set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("FileName1=@FileName1,");
            strSql.Append("FileName2=@FileName2,");
            strSql.Append("FileName3=@FileName3,");
            strSql.Append("FileName4=@FileName4,");
            strSql.Append("FileName5=@FileName5,");
            strSql.Append("FileName6=@FileName6,");
            strSql.Append("CountCar=@CountCar,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateName=@CreateName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("isDel=@isDel");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileName1", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName2", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName3", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName4", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName5", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName6", SqlDbType.NVarChar,-1),
					new SqlParameter("@CountCar", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@isDel", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.FileName1;
            parameters[5].Value = model.FileName2;
            parameters[6].Value = model.FileName3;
            parameters[7].Value = model.FileName4;
            parameters[8].Value = model.FileName5;
            parameters[9].Value = model.FileName6;
            parameters[10].Value = model.CountCar;
            parameters[11].Value = model.CreateID;
            parameters[12].Value = model.CreateName;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.TypeID;
            parameters[15].Value = model.isDel;
            parameters[16].Value = model.Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_CarMasterplate ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_CarMasterplate ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public Citic.Model.CarMasterplate GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,DealerID,DealerName,BankID,BankName,FileName1,FileName2,FileName3,FileName4,FileName5,FileName6,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel from tb_CarMasterplate ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            Citic.Model.CarMasterplate model = new Citic.Model.CarMasterplate();
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
        public Citic.Model.CarMasterplate DataRowToModel(DataRow row)
        {
            Citic.Model.CarMasterplate model = new Citic.Model.CarMasterplate();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["DealerID"] != null && row["DealerID"].ToString() != "")
                {
                    model.DealerID = int.Parse(row["DealerID"].ToString());
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["BankID"] != null && row["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(row["BankID"].ToString());
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["FileName1"] != null)
                {
                    model.FileName1 = row["FileName1"].ToString();
                }
                if (row["FileName2"] != null)
                {
                    model.FileName2 = row["FileName2"].ToString();
                }
                if (row["FileName3"] != null)
                {
                    model.FileName3 = row["FileName3"].ToString();
                }
                if (row["FileName4"] != null)
                {
                    model.FileName4 = row["FileName4"].ToString();
                }
                if (row["FileName5"] != null)
                {
                    model.FileName5 = row["FileName5"].ToString();
                }
                if (row["FileName6"] != null)
                {
                    model.FileName6 = row["FileName6"].ToString();
                }
                if (row["CountCar"] != null && row["CountCar"].ToString() != "")
                {
                    model.CountCar = int.Parse(row["CountCar"].ToString());
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateName"] != null)
                {
                    model.CreateName = row["CreateName"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["isDel"] != null && row["isDel"].ToString() != "")
                {
                    model.isDel = int.Parse(row["isDel"].ToString());
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
            strSql.Append("select Id,DealerID,DealerName,BankID,BankName,FileName1,FileName2,FileName3,FileName4,FileName5,FileName6,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel ");
            strSql.Append(" FROM tb_CarMasterplate ");
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
            strSql.Append(" Id,DealerID,DealerName,BankID,BankName,FileName1,FileName2,FileName3,FileName4,FileName5,FileName6,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel ");
            strSql.Append(" FROM tb_CarMasterplate ");
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
            strSql.Append("select count(1) FROM tb_CarMasterplate ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_CarMasterplate T ");
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
            parameters[0].Value = "tb_CarMasterplate";
            parameters[1].Value = "Id";
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

