using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:GD_CustInfo
    /// </summary>
    public partial class GD_CustInfo
    {
        public GD_CustInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal CUST_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GD_CustInfo");
            strSql.Append(" where CUST_ID=@CUST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUST_ID", SqlDbType.Decimal,17)			};
            parameters[0].Value = CUST_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Citic.Model.GD_CustInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GD_CustInfo(");
            strSql.Append("CUST_ID,CUST_NAME,ORG_CODE,CUST_TYPE,CM_NAME,OFFICE_PHONE_NO,CELLPHONE_NO,EMAIL,RESERVE1,RESERVE2,RESERVE3,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@CUST_ID,@CUST_NAME,@ORG_CODE,@CUST_TYPE,@CM_NAME,@OFFICE_PHONE_NO,@CELLPHONE_NO,@EMAIL,@RESERVE1,@RESERVE2,@RESERVE3,@CreateTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@CUST_ID", SqlDbType.Decimal,17),
					new SqlParameter("@CUST_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@ORG_CODE", SqlDbType.VarChar,10),
					new SqlParameter("@CUST_TYPE", SqlDbType.VarChar,3),
					new SqlParameter("@CM_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@OFFICE_PHONE_NO", SqlDbType.VarChar,20),
					new SqlParameter("@CELLPHONE_NO", SqlDbType.VarChar,20),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
					new SqlParameter("@RESERVE1", SqlDbType.VarChar,100),
					new SqlParameter("@RESERVE2", SqlDbType.VarChar,100),
					new SqlParameter("@RESERVE3", SqlDbType.VarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CUST_ID;
            parameters[1].Value = model.CUST_NAME;
            parameters[2].Value = model.ORG_CODE;
            parameters[3].Value = model.CUST_TYPE;
            parameters[4].Value = model.CM_NAME;
            parameters[5].Value = model.OFFICE_PHONE_NO;
            parameters[6].Value = model.CELLPHONE_NO;
            parameters[7].Value = model.EMAIL;
            parameters[8].Value = model.RESERVE1;
            parameters[9].Value = model.RESERVE2;
            parameters[10].Value = model.RESERVE3;
            parameters[11].Value = model.CreateTime;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.GD_CustInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GD_CustInfo set ");
            strSql.Append("CUST_NAME=@CUST_NAME,");
            strSql.Append("ORG_CODE=@ORG_CODE,");
            strSql.Append("CUST_TYPE=@CUST_TYPE,");
            strSql.Append("CM_NAME=@CM_NAME,");
            strSql.Append("OFFICE_PHONE_NO=@OFFICE_PHONE_NO,");
            strSql.Append("CELLPHONE_NO=@CELLPHONE_NO,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("RESERVE1=@RESERVE1,");
            strSql.Append("RESERVE2=@RESERVE2,");
            strSql.Append("RESERVE3=@RESERVE3,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where CUST_ID=@CUST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUST_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@ORG_CODE", SqlDbType.VarChar,10),
					new SqlParameter("@CUST_TYPE", SqlDbType.VarChar,3),
					new SqlParameter("@CM_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@OFFICE_PHONE_NO", SqlDbType.VarChar,20),
					new SqlParameter("@CELLPHONE_NO", SqlDbType.VarChar,20),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
					new SqlParameter("@RESERVE1", SqlDbType.VarChar,100),
					new SqlParameter("@RESERVE2", SqlDbType.VarChar,100),
					new SqlParameter("@RESERVE3", SqlDbType.VarChar,100),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CUST_ID", SqlDbType.Decimal,17)};
            parameters[0].Value = model.CUST_NAME;
            parameters[1].Value = model.ORG_CODE;
            parameters[2].Value = model.CUST_TYPE;
            parameters[3].Value = model.CM_NAME;
            parameters[4].Value = model.OFFICE_PHONE_NO;
            parameters[5].Value = model.CELLPHONE_NO;
            parameters[6].Value = model.EMAIL;
            parameters[7].Value = model.RESERVE1;
            parameters[8].Value = model.RESERVE2;
            parameters[9].Value = model.RESERVE3;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.CUST_ID;

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
        public bool Delete(decimal CUST_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GD_CustInfo ");
            strSql.Append(" where CUST_ID=@CUST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUST_ID", SqlDbType.Decimal,17)			};
            parameters[0].Value = CUST_ID;

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
        public bool DeleteList(string CUST_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GD_CustInfo ");
            strSql.Append(" where CUST_ID in (" + CUST_IDlist + ")  ");
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
        public Citic.Model.GD_CustInfo GetModel(decimal CUST_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CUST_ID,CUST_NAME,ORG_CODE,CUST_TYPE,CM_NAME,OFFICE_PHONE_NO,CELLPHONE_NO,EMAIL,RESERVE1,RESERVE2,RESERVE3,CreateTime from GD_CustInfo ");
            strSql.Append(" where CUST_ID=@CUST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUST_ID", SqlDbType.Decimal,17)			};
            parameters[0].Value = CUST_ID;

            Citic.Model.GD_CustInfo model = new Citic.Model.GD_CustInfo();
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
        public Citic.Model.GD_CustInfo DataRowToModel(DataRow row)
        {
            Citic.Model.GD_CustInfo model = new Citic.Model.GD_CustInfo();
            if (row != null)
            {
                if (row["CUST_ID"] != null && row["CUST_ID"].ToString() != "")
                {
                    model.CUST_ID = decimal.Parse(row["CUST_ID"].ToString());
                }
                if (row["CUST_NAME"] != null)
                {
                    model.CUST_NAME = row["CUST_NAME"].ToString();
                }
                if (row["ORG_CODE"] != null)
                {
                    model.ORG_CODE = row["ORG_CODE"].ToString();
                }
                if (row["CUST_TYPE"] != null)
                {
                    model.CUST_TYPE = row["CUST_TYPE"].ToString();
                }
                if (row["CM_NAME"] != null)
                {
                    model.CM_NAME = row["CM_NAME"].ToString();
                }
                if (row["OFFICE_PHONE_NO"] != null)
                {
                    model.OFFICE_PHONE_NO = row["OFFICE_PHONE_NO"].ToString();
                }
                if (row["CELLPHONE_NO"] != null)
                {
                    model.CELLPHONE_NO = row["CELLPHONE_NO"].ToString();
                }
                if (row["EMAIL"] != null)
                {
                    model.EMAIL = row["EMAIL"].ToString();
                }
                if (row["RESERVE1"] != null)
                {
                    model.RESERVE1 = row["RESERVE1"].ToString();
                }
                if (row["RESERVE2"] != null)
                {
                    model.RESERVE2 = row["RESERVE2"].ToString();
                }
                if (row["RESERVE3"] != null)
                {
                    model.RESERVE3 = row["RESERVE3"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
            strSql.Append("select CUST_ID,CUST_NAME,ORG_CODE,CUST_TYPE,CM_NAME,OFFICE_PHONE_NO,CELLPHONE_NO,EMAIL,RESERVE1,RESERVE2,RESERVE3,CreateTime ");
            strSql.Append(" FROM GD_CustInfo ");
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
            strSql.Append(" CUST_ID,CUST_NAME,ORG_CODE,CUST_TYPE,CM_NAME,OFFICE_PHONE_NO,CELLPHONE_NO,EMAIL,RESERVE1,RESERVE2,RESERVE3,CreateTime ");
            strSql.Append(" FROM GD_CustInfo ");
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
            strSql.Append("select count(1) FROM GD_CustInfo ");
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
                strSql.Append("order by T.CUST_ID desc");
            }
            strSql.Append(")AS Row, T.*  from GD_CustInfo T ");
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

