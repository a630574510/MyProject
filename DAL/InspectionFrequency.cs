using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:InspectionFrequency
    /// </summary>
    public partial class InspectionFrequency
    {
        public InspectionFrequency()
        { }
        #region  BasicMethod

        /// <summary>
        /// 执行sql语句 张繁 2013年8月21日
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecuteSql(string strSql)
        {
            return DbHelperSQL.ExecuteSql(strSql);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_InspectionFrequency");
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
        public int Add(Citic.Model.InspectionFrequency model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_InspectionFrequency(");
            strSql.Append("Area,DealerName,Bank,BrandName,SupervisorName,CheckProblem,FinancialCenter,RiskControl,AdminDepartment,QuartersLedger,HistoryTime,CreateId,CreateTime,Statu,IsDel,DelId,DelTime)");
            strSql.Append(" values (");
            strSql.Append("@Area,@DealerName,@Bank,@BrandName,@SupervisorName,@CheckProblem,@FinancialCenter,@RiskControl,@AdminDepartment,@QuartersLedger,@HistoryTime,@CreateId,@CreateTime,@Statu,@IsDel,@DelId,@DelTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckProblem", SqlDbType.NVarChar,-1),
					new SqlParameter("@FinancialCenter", SqlDbType.NVarChar,-1),
					new SqlParameter("@RiskControl", SqlDbType.NVarChar,-1),
					new SqlParameter("@AdminDepartment", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger", SqlDbType.NVarChar,-1),
					new SqlParameter("@HistoryTime", SqlDbType.DateTime),
					new SqlParameter("@CreateId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Statu", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@DelId", SqlDbType.Int,4),
					new SqlParameter("@DelTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Area;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.Bank;
            parameters[3].Value = model.BrandName;
            parameters[4].Value = model.SupervisorName;
            parameters[5].Value = model.CheckProblem;
            parameters[6].Value = model.FinancialCenter;
            parameters[7].Value = model.RiskControl;
            parameters[8].Value = model.AdminDepartment;
            parameters[9].Value = model.QuartersLedger;
            parameters[10].Value = model.HistoryTime;
            parameters[11].Value = model.CreateId;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.Statu;
            parameters[14].Value = model.IsDel;
            parameters[15].Value = model.DelId;
            parameters[16].Value = model.DelTime;

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
        public bool Update(Citic.Model.InspectionFrequency model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_InspectionFrequency set ");
            strSql.Append("Area=@Area,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("Bank=@Bank,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("SupervisorName=@SupervisorName,");
            strSql.Append("CheckProblem=@CheckProblem,");
            strSql.Append("FinancialCenter=@FinancialCenter,");
            strSql.Append("RiskControl=@RiskControl,");
            strSql.Append("AdminDepartment=@AdminDepartment,");
            strSql.Append("QuartersLedger=@QuartersLedger,");
            strSql.Append("HistoryTime=@HistoryTime,");
            strSql.Append("CreateId=@CreateId,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Statu=@Statu,");
            strSql.Append("IsDel=@IsDel,");
            strSql.Append("DelId=@DelId,");
            strSql.Append("DelTime=@DelTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckProblem", SqlDbType.NVarChar,-1),
					new SqlParameter("@FinancialCenter", SqlDbType.NVarChar,-1),
					new SqlParameter("@RiskControl", SqlDbType.NVarChar,-1),
					new SqlParameter("@AdminDepartment", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger", SqlDbType.NVarChar,-1),
					new SqlParameter("@HistoryTime", SqlDbType.DateTime),
					new SqlParameter("@CreateId", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Statu", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@DelId", SqlDbType.Int,4),
					new SqlParameter("@DelTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Area;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.Bank;
            parameters[3].Value = model.BrandName;
            parameters[4].Value = model.SupervisorName;
            parameters[5].Value = model.CheckProblem;
            parameters[6].Value = model.FinancialCenter;
            parameters[7].Value = model.RiskControl;
            parameters[8].Value = model.AdminDepartment;
            parameters[9].Value = model.QuartersLedger;
            parameters[10].Value = model.HistoryTime;
            parameters[11].Value = model.CreateId;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.Statu;
            parameters[14].Value = model.IsDel;
            parameters[15].Value = model.DelId;
            parameters[16].Value = model.DelTime;
            parameters[17].Value = model.ID;

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
            strSql.Append("delete from tb_InspectionFrequency ");
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
            strSql.Append("delete from tb_InspectionFrequency ");
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
        public Citic.Model.InspectionFrequency GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Area,DealerName,Bank,BrandName,SupervisorName,CheckProblem,FinancialCenter,RiskControl,AdminDepartment,QuartersLedger,HistoryTime,CreateId,CreateTime,Statu,IsDel,DelId,DelTime from tb_InspectionFrequency ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.InspectionFrequency model = new Citic.Model.InspectionFrequency();
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
        public Citic.Model.InspectionFrequency DataRowToModel(DataRow row)
        {
            Citic.Model.InspectionFrequency model = new Citic.Model.InspectionFrequency();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["Bank"] != null)
                {
                    model.Bank = row["Bank"].ToString();
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
                }
                if (row["SupervisorName"] != null)
                {
                    model.SupervisorName = row["SupervisorName"].ToString();
                }
                if (row["CheckProblem"] != null)
                {
                    model.CheckProblem = row["CheckProblem"].ToString();
                }
                if (row["FinancialCenter"] != null)
                {
                    model.FinancialCenter = row["FinancialCenter"].ToString();
                }
                if (row["RiskControl"] != null)
                {
                    model.RiskControl = row["RiskControl"].ToString();
                }
                if (row["AdminDepartment"] != null)
                {
                    model.AdminDepartment = row["AdminDepartment"].ToString();
                }
                if (row["QuartersLedger"] != null)
                {
                    model.QuartersLedger = row["QuartersLedger"].ToString();
                }
                if (row["HistoryTime"] != null && row["HistoryTime"].ToString() != "")
                {
                    model.HistoryTime = DateTime.Parse(row["HistoryTime"].ToString());
                }
                if (row["CreateId"] != null && row["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(row["CreateId"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Statu"] != null && row["Statu"].ToString() != "")
                {
                    model.Statu = int.Parse(row["Statu"].ToString());
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(row["IsDel"].ToString());
                }
                if (row["DelId"] != null && row["DelId"].ToString() != "")
                {
                    model.DelId = int.Parse(row["DelId"].ToString());
                }
                if (row["DelTime"] != null && row["DelTime"].ToString() != "")
                {
                    model.DelTime = DateTime.Parse(row["DelTime"].ToString());
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
            strSql.Append("select ID,Area,DealerName,Bank,BrandName,SupervisorName,CheckProblem,FinancialCenter,RiskControl,AdminDepartment,QuartersLedger,HistoryTime,CreateId,CreateTime,Statu,IsDel,DelId,DelTime ");
            strSql.Append(" FROM tb_InspectionFrequency ");
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
            strSql.Append(" ID,Area,DealerName,Bank,BrandName,SupervisorName,CheckProblem,FinancialCenter,RiskControl,AdminDepartment,QuartersLedger,HistoryTime,CreateId,CreateTime,Statu,IsDel,DelId,DelTime ");
            strSql.Append(" FROM tb_InspectionFrequency ");
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
            strSql.Append("select count(1) FROM tb_InspectionFrequency ");
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
            strSql.Append(")AS Row, T.*  from tb_InspectionFrequency T ");
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
            parameters[0].Value = "tb_InspectionFrequency";
            parameters[1].Value = "ID";
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

