using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections;
using System.Collections.Generic;
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:QueryWH
    /// </summary>
    public partial class QueryWH
    {
        public QueryWH()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_QueryWH");
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
        public int Add(Citic.Model.QueryWH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_QueryWH(");
            strSql.Append("DB_ID,CheckFrequency,Description,Remark,CreateID,CreateTime,ApplyTime)");
            strSql.Append(" values (");
            strSql.Append("@DB_ID,@CheckFrequency,@Description,@Remark,@CreateID,@CreateTime,@ApplyTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DB_ID", SqlDbType.NVarChar,20),
					new SqlParameter("@CheckFrequency", SqlDbType.NVarChar,200),
					new SqlParameter("@Description", SqlDbType.NVarChar,200),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime)};
            parameters[0].Value = model.DB_ID;
            parameters[1].Value = model.CheckFrequency;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.CreateID;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.ApplyTime;

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
        public bool Update(Citic.Model.QueryWH model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_QueryWH set ");
            strSql.Append("DB_ID=@DB_ID,");
            strSql.Append("CheckFrequency=@CheckFrequency,");
            strSql.Append("Description=@Description,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("ApplyTime=@ApplyTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DB_ID", SqlDbType.NVarChar,20),
					new SqlParameter("@CheckFrequency", SqlDbType.NVarChar,200),
					new SqlParameter("@Description", SqlDbType.NVarChar,200),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DB_ID;
            parameters[1].Value = model.CheckFrequency;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.CreateID;
            parameters[5].Value = model.CreateTime;
            parameters[6].Value = model.ApplyTime;
            parameters[7].Value = model.ID;

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
            strSql.Append("delete from tb_QueryWH ");
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
            strSql.Append("delete from tb_QueryWH ");
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
        public Citic.Model.QueryWH GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DB_ID,CheckFrequency,Description,Remark,CreateID,CreateTime,ApplyTime from tb_QueryWH ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.QueryWH model = new Citic.Model.QueryWH();
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
        public Citic.Model.QueryWH DataRowToModel(DataRow row)
        {
            Citic.Model.QueryWH model = new Citic.Model.QueryWH();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DB_ID"] != null)
                {
                    model.DB_ID = row["DB_ID"].ToString();
                }
                if (row["CheckFrequency"] != null)
                {
                    model.CheckFrequency = row["CheckFrequency"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
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
                if (row["ApplyTime"] != null && row["ApplyTime"].ToString() != "")
                {
                    model.ApplyTime = DateTime.Parse(row["ApplyTime"].ToString());
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
            strSql.Append("select ID,DB_ID,CheckFrequency,Description,Remark,CreateID,CreateTime,ApplyTime ");
            strSql.Append(" FROM tb_QueryWH ");
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
            strSql.Append(" ID,DB_ID,CheckFrequency,Description,Remark,CreateID,CreateTime,ApplyTime ");
            strSql.Append(" FROM tb_QueryWH ");
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
            strSql.Append("select count(1) FROM tb_QueryWH ");
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
            strSql.Append(")AS Row, T.*  from tb_QueryWH T ");
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
        #region 批量更新--乔春羽(2013.12.6)
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int Updates(params Citic.Model.QueryWH[] models)
        {
            int num = 0;
            try
            {
                List<CommandInfo> cInfos = new List<CommandInfo>();
                if (models != null && models.Length > 0)
                {
                    foreach (Citic.Model.QueryWH model in models)
                    {
                        CommandInfo cInfo = new CommandInfo()
                        {
                            CommandText = "UPDATE tb_QueryWH SET CheckFrequency=@CheckFrequency,Description=@Description,Remark=@Remark,CreateID=@CreateID,CreateTime=@CreateTime,ApplyTime=@ApplyTime WHERE DB_ID=@DB_ID",
                            Parameters = new SqlParameter[]{
                                new SqlParameter("@CheckFrequency",model.CheckFrequency),
                                new SqlParameter("@Description",model.Description),
                                new SqlParameter("@Remark",model.Remark),
                                new SqlParameter("@CreateID",model.CreateID),
                                new SqlParameter("@CreateTime",model.CreateTime),
                                new SqlParameter("@ApplyTime",model.ApplyTime),
                                new SqlParameter("@DB_ID",model.DB_ID)
                            }
                        };
                        cInfos.Add(cInfo);
                    }
                }
                DbHelperSQL.ExecuteSqlTranWithIndentity(cInfos);
                num = 1;
            }
            catch (SqlException se)
            {
                num = 0;
                throw se;
            }
            return num;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

