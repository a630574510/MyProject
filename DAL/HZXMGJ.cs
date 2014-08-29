using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:HZXMGJ
    /// </summary>
    public partial class HZXMGJ
    {
        public HZXMGJ()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_HZXMGJ");
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
        public int Add(Citic.Model.HZXMGJ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_HZXMGJ(");
            strSql.Append("DealerID,DealerName,BankID,BankName,BrandID,BrandName,BM,type,DTime,SID,SName,LinkPhone,col_1,col_2,col_3,col_4,col_5,col_6,col_7,col_8,col_9,col_10,col_11,Remark,CreateID,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@BankID,@BankName,@BrandID,@BrandName,@BM,@type,@DTime,@SID,@SName,@LinkPhone,@col_1,@col_2,@col_3,@col_4,@col_5,@col_6,@col_7,@col_8,@col_9,@col_10,@col_11,@Remark,@CreateID,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@BM", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@DTime", SqlDbType.DateTime),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@col_1", SqlDbType.NVarChar,100),
					new SqlParameter("@col_2", SqlDbType.NVarChar,100),
					new SqlParameter("@col_3", SqlDbType.NVarChar,100),
					new SqlParameter("@col_4", SqlDbType.NVarChar,100),
					new SqlParameter("@col_5", SqlDbType.NVarChar,100),
					new SqlParameter("@col_6", SqlDbType.NVarChar,100),
					new SqlParameter("@col_7", SqlDbType.NVarChar,100),
					new SqlParameter("@col_8", SqlDbType.NVarChar,100),
					new SqlParameter("@col_9", SqlDbType.NVarChar,100),
					new SqlParameter("@col_10", SqlDbType.NVarChar,100),
					new SqlParameter("@col_11", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.BM;
            parameters[7].Value = model.type;
            parameters[8].Value = model.DTime;
            parameters[9].Value = model.SID;
            parameters[10].Value = model.SName;
            parameters[11].Value = model.LinkPhone;
            parameters[12].Value = model.col_1;
            parameters[13].Value = model.col_2;
            parameters[14].Value = model.col_3;
            parameters[15].Value = model.col_4;
            parameters[16].Value = model.col_5;
            parameters[17].Value = model.col_6;
            parameters[18].Value = model.col_7;
            parameters[19].Value = model.col_8;
            parameters[20].Value = model.col_9;
            parameters[21].Value = model.col_10;
            parameters[22].Value = model.col_11;
            parameters[23].Value = model.Remark;
            parameters[24].Value = model.CreateID;
            parameters[25].Value = model.CreateTime;

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
        public bool Update(Citic.Model.HZXMGJ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_HZXMGJ set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("BM=@BM,");
            strSql.Append("type=@type,");
            strSql.Append("DTime=@DTime,");
            strSql.Append("SID=@SID,");
            strSql.Append("SName=@SName,");
            strSql.Append("LinkPhone=@LinkPhone,");
            strSql.Append("col_1=@col_1,");
            strSql.Append("col_2=@col_2,");
            strSql.Append("col_3=@col_3,");
            strSql.Append("col_4=@col_4,");
            strSql.Append("col_5=@col_5,");
            strSql.Append("col_6=@col_6,");
            strSql.Append("col_7=@col_7,");
            strSql.Append("col_8=@col_8,");
            strSql.Append("col_9=@col_9,");
            strSql.Append("col_10=@col_10,");
            strSql.Append("col_11=@col_11,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@BM", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@DTime", SqlDbType.DateTime),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@col_1", SqlDbType.NVarChar,100),
					new SqlParameter("@col_2", SqlDbType.NVarChar,100),
					new SqlParameter("@col_3", SqlDbType.NVarChar,100),
					new SqlParameter("@col_4", SqlDbType.NVarChar,100),
					new SqlParameter("@col_5", SqlDbType.NVarChar,100),
					new SqlParameter("@col_6", SqlDbType.NVarChar,100),
					new SqlParameter("@col_7", SqlDbType.NVarChar,100),
					new SqlParameter("@col_8", SqlDbType.NVarChar,100),
					new SqlParameter("@col_9", SqlDbType.NVarChar,100),
					new SqlParameter("@col_10", SqlDbType.NVarChar,100),
					new SqlParameter("@col_11", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.BrandID;
            parameters[5].Value = model.BrandName;
            parameters[6].Value = model.BM;
            parameters[7].Value = model.type;
            parameters[8].Value = model.DTime;
            parameters[9].Value = model.SID;
            parameters[10].Value = model.SName;
            parameters[11].Value = model.LinkPhone;
            parameters[12].Value = model.col_1;
            parameters[13].Value = model.col_2;
            parameters[14].Value = model.col_3;
            parameters[15].Value = model.col_4;
            parameters[16].Value = model.col_5;
            parameters[17].Value = model.col_6;
            parameters[18].Value = model.col_7;
            parameters[19].Value = model.col_8;
            parameters[20].Value = model.col_9;
            parameters[21].Value = model.col_10;
            parameters[22].Value = model.col_11;
            parameters[23].Value = model.Remark;
            parameters[24].Value = model.CreateID;
            parameters[25].Value = model.CreateTime;
            parameters[26].Value = model.ID;

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
            strSql.Append("delete from tb_HZXMGJ ");
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
            strSql.Append("delete from tb_HZXMGJ ");
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
        public Citic.Model.HZXMGJ GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,BM,type,DTime,SID,SName,LinkPhone,col_1,col_2,col_3,col_4,col_5,col_6,col_7,col_8,col_9,col_10,col_11,Remark,CreateID,CreateTime from tb_HZXMGJ ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.HZXMGJ model = new Citic.Model.HZXMGJ();
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
        public Citic.Model.HZXMGJ DataRowToModel(DataRow row)
        {
            Citic.Model.HZXMGJ model = new Citic.Model.HZXMGJ();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
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
                if (row["BrandID"] != null && row["BrandID"].ToString() != "")
                {
                    model.BrandID = int.Parse(row["BrandID"].ToString());
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
                }
                if (row["BM"] != null)
                {
                    model.BM = row["BM"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["DTime"] != null && row["DTime"].ToString() != "")
                {
                    model.DTime = DateTime.Parse(row["DTime"].ToString());
                }
                if (row["SID"] != null && row["SID"].ToString() != "")
                {
                    model.SID = int.Parse(row["SID"].ToString());
                }
                if (row["SName"] != null)
                {
                    model.SName = row["SName"].ToString();
                }
                if (row["LinkPhone"] != null)
                {
                    model.LinkPhone = row["LinkPhone"].ToString();
                }
                if (row["col_1"] != null)
                {
                    model.col_1 = row["col_1"].ToString();
                }
                if (row["col_2"] != null)
                {
                    model.col_2 = row["col_2"].ToString();
                }
                if (row["col_3"] != null)
                {
                    model.col_3 = row["col_3"].ToString();
                }
                if (row["col_4"] != null)
                {
                    model.col_4 = row["col_4"].ToString();
                }
                if (row["col_5"] != null)
                {
                    model.col_5 = row["col_5"].ToString();
                }
                if (row["col_6"] != null)
                {
                    model.col_6 = row["col_6"].ToString();
                }
                if (row["col_7"] != null)
                {
                    model.col_7 = row["col_7"].ToString();
                }
                if (row["col_8"] != null)
                {
                    model.col_8 = row["col_8"].ToString();
                }
                if (row["col_9"] != null)
                {
                    model.col_9 = row["col_9"].ToString();
                }
                if (row["col_10"] != null)
                {
                    model.col_10 = row["col_10"].ToString();
                }
                if (row["col_11"] != null)
                {
                    model.col_11 = row["col_11"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,BM,type,DTime,SID,SName,LinkPhone,col_1,col_2,col_3,col_4,col_5,col_6,col_7,col_8,col_9,col_10,col_11,Remark,CreateID,CreateTime ");
            strSql.Append(" FROM tb_HZXMGJ ");
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
            strSql.Append(" ID,DealerID,DealerName,BankID,BankName,BrandID,BrandName,BM,type,DTime,SID,SName,LinkPhone,col_1,col_2,col_3,col_4,col_5,col_6,col_7,col_8,col_9,col_10,col_11,Remark,CreateID,CreateTime ");
            strSql.Append(" FROM tb_HZXMGJ ");
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
            strSql.Append("select count(1) FROM tb_HZXMGJ ");
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
            strSql.Append(")AS Row, T.*  from tb_HZXMGJ T ");
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

