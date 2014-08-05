using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Inspection
    /// </summary>
    public partial class Inspection
    {
        public Inspection()
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
            strSql.Append("select count(1) from tb_Inspection");
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
        public int Add(Citic.Model.Inspection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Inspection(");
            strSql.Append("Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,QuartersLedgerStatu,MainProblem,MainProblemStatu,HistoryDate,ContinueStatu,QuartersLedger_1_Results,QuartersLedger_1_People,QuartersLedger_1_Date,QuartersLedger_2_Results,QuartersLedger_2_People,QuartersLedger_2_Date,QuartersLedger_3_Results,QuartersLedger_3_People,QuartersLedger_3_Date,MainProblem_1_Results,MainProblem_1_People,MainProblem_1_Date,MainProblem_2_Results,MainProblem_2_People,MainProblem_2_Date,MainProblem_3_Results,MainProblem_3_People,MainProblem_3_Date,Continue_1_Results,Continue_1_People,Continue_1_Date,Continue_2_Results,Continue_2_People,Continue_2_Date,Continue_3_Results,Continue_3_People,Continue_3_Date,Remark,CreateTime,CreateId,IsConform,isDel,DelId,DelTime)");
            strSql.Append(" values (");
            strSql.Append("@Area,@Rummager,@DealerName,@Bank,@BrandName,@SupervisorName,@Model,@Inventory,@QuartersLedger,@QuartersLedgerStatu,@MainProblem,@MainProblemStatu,@HistoryDate,@ContinueStatu,@QuartersLedger_1_Results,@QuartersLedger_1_People,@QuartersLedger_1_Date,@QuartersLedger_2_Results,@QuartersLedger_2_People,@QuartersLedger_2_Date,@QuartersLedger_3_Results,@QuartersLedger_3_People,@QuartersLedger_3_Date,@MainProblem_1_Results,@MainProblem_1_People,@MainProblem_1_Date,@MainProblem_2_Results,@MainProblem_2_People,@MainProblem_2_Date,@MainProblem_3_Results,@MainProblem_3_People,@MainProblem_3_Date,@Continue_1_Results,@Continue_1_People,@Continue_1_Date,@Continue_2_Results,@Continue_2_People,@Continue_2_Date,@Continue_3_Results,@Continue_3_People,@Continue_3_Date,@Remark,@CreateTime,@CreateId,@IsConform,@isDel,@DelId,@DelTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@Rummager", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
					new SqlParameter("@Model", SqlDbType.NVarChar,50),
					new SqlParameter("@Inventory", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedgerStatu", SqlDbType.Int,4),
					new SqlParameter("@MainProblem", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblemStatu", SqlDbType.Int,4),
					new SqlParameter("@HistoryDate", SqlDbType.DateTime),
					new SqlParameter("@ContinueStatu", SqlDbType.Int,4),
					new SqlParameter("@QuartersLedger_1_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger_1_People", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger_1_Date", SqlDbType.DateTime),
					new SqlParameter("@QuartersLedger_2_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger_2_People", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger_2_Date", SqlDbType.DateTime),
					new SqlParameter("@QuartersLedger_3_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger_3_People", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger_3_Date", SqlDbType.DateTime),
					new SqlParameter("@MainProblem_1_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblem_1_People", SqlDbType.NVarChar,50),
					new SqlParameter("@MainProblem_1_Date", SqlDbType.DateTime),
					new SqlParameter("@MainProblem_2_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblem_2_People", SqlDbType.NVarChar,50),
					new SqlParameter("@MainProblem_2_Date", SqlDbType.DateTime),
					new SqlParameter("@MainProblem_3_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblem_3_People", SqlDbType.NVarChar,50),
					new SqlParameter("@MainProblem_3_Date", SqlDbType.DateTime),
					new SqlParameter("@Continue_1_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@Continue_1_People", SqlDbType.NVarChar,50),
					new SqlParameter("@Continue_1_Date", SqlDbType.DateTime),
					new SqlParameter("@Continue_2_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@Continue_2_People", SqlDbType.NVarChar,50),
					new SqlParameter("@Continue_2_Date", SqlDbType.DateTime),
					new SqlParameter("@Continue_3_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@Continue_3_People", SqlDbType.NVarChar,50),
					new SqlParameter("@Continue_3_Date", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateId", SqlDbType.Int,4),
					new SqlParameter("@IsConform", SqlDbType.Int,4),
					new SqlParameter("@isDel", SqlDbType.Int,4),
					new SqlParameter("@DelId", SqlDbType.Int,4),
					new SqlParameter("@DelTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Area;
            parameters[1].Value = model.Rummager;
            parameters[2].Value = model.DealerName;
            parameters[3].Value = model.Bank;
            parameters[4].Value = model.BrandName;
            parameters[5].Value = model.SupervisorName;
            parameters[6].Value = model.Model;
            parameters[7].Value = model.Inventory;
            parameters[8].Value = model.QuartersLedger;
            parameters[9].Value = model.QuartersLedgerStatu;
            parameters[10].Value = model.MainProblem;
            parameters[11].Value = model.MainProblemStatu;
            parameters[12].Value = model.HistoryDate;
            parameters[13].Value = model.ContinueStatu;
            parameters[14].Value = model.QuartersLedger_1_Results;
            parameters[15].Value = model.QuartersLedger_1_People;
            parameters[16].Value = model.QuartersLedger_1_Date;
            parameters[17].Value = model.QuartersLedger_2_Results;
            parameters[18].Value = model.QuartersLedger_2_People;
            parameters[19].Value = model.QuartersLedger_2_Date;
            parameters[20].Value = model.QuartersLedger_3_Results;
            parameters[21].Value = model.QuartersLedger_3_People;
            parameters[22].Value = model.QuartersLedger_3_Date;
            parameters[23].Value = model.MainProblem_1_Results;
            parameters[24].Value = model.MainProblem_1_People;
            parameters[25].Value = model.MainProblem_1_Date;
            parameters[26].Value = model.MainProblem_2_Results;
            parameters[27].Value = model.MainProblem_2_People;
            parameters[28].Value = model.MainProblem_2_Date;
            parameters[29].Value = model.MainProblem_3_Results;
            parameters[30].Value = model.MainProblem_3_People;
            parameters[31].Value = model.MainProblem_3_Date;
            parameters[32].Value = model.Continue_1_Results;
            parameters[33].Value = model.Continue_1_People;
            parameters[34].Value = model.Continue_1_Date;
            parameters[35].Value = model.Continue_2_Results;
            parameters[36].Value = model.Continue_2_People;
            parameters[37].Value = model.Continue_2_Date;
            parameters[38].Value = model.Continue_3_Results;
            parameters[39].Value = model.Continue_3_People;
            parameters[40].Value = model.Continue_3_Date;
            parameters[41].Value = model.Remark;
            parameters[42].Value = model.CreateTime;
            parameters[43].Value = model.CreateId;
            parameters[44].Value = model.IsConform;
            parameters[45].Value = model.isDel;
            parameters[46].Value = model.DelId;
            parameters[47].Value = model.DelTime;

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
        public bool Update(Citic.Model.Inspection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Inspection set ");
            strSql.Append("Area=@Area,");
            strSql.Append("Rummager=@Rummager,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("Bank=@Bank,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("SupervisorName=@SupervisorName,");
            strSql.Append("Model=@Model,");
            strSql.Append("Inventory=@Inventory,");
            strSql.Append("QuartersLedger=@QuartersLedger,");
            strSql.Append("QuartersLedgerStatu=@QuartersLedgerStatu,");
            strSql.Append("MainProblem=@MainProblem,");
            strSql.Append("MainProblemStatu=@MainProblemStatu,");
            strSql.Append("HistoryDate=@HistoryDate,");
            strSql.Append("ContinueStatu=@ContinueStatu,");
            strSql.Append("QuartersLedger_1_Results=@QuartersLedger_1_Results,");
            strSql.Append("QuartersLedger_1_People=@QuartersLedger_1_People,");
            strSql.Append("QuartersLedger_1_Date=@QuartersLedger_1_Date,");
            strSql.Append("QuartersLedger_2_Results=@QuartersLedger_2_Results,");
            strSql.Append("QuartersLedger_2_People=@QuartersLedger_2_People,");
            strSql.Append("QuartersLedger_2_Date=@QuartersLedger_2_Date,");
            strSql.Append("QuartersLedger_3_Results=@QuartersLedger_3_Results,");
            strSql.Append("QuartersLedger_3_People=@QuartersLedger_3_People,");
            strSql.Append("QuartersLedger_3_Date=@QuartersLedger_3_Date,");
            strSql.Append("MainProblem_1_Results=@MainProblem_1_Results,");
            strSql.Append("MainProblem_1_People=@MainProblem_1_People,");
            strSql.Append("MainProblem_1_Date=@MainProblem_1_Date,");
            strSql.Append("MainProblem_2_Results=@MainProblem_2_Results,");
            strSql.Append("MainProblem_2_People=@MainProblem_2_People,");
            strSql.Append("MainProblem_2_Date=@MainProblem_2_Date,");
            strSql.Append("MainProblem_3_Results=@MainProblem_3_Results,");
            strSql.Append("MainProblem_3_People=@MainProblem_3_People,");
            strSql.Append("MainProblem_3_Date=@MainProblem_3_Date,");
            strSql.Append("Continue_1_Results=@Continue_1_Results,");
            strSql.Append("Continue_1_People=@Continue_1_People,");
            strSql.Append("Continue_1_Date=@Continue_1_Date,");
            strSql.Append("Continue_2_Results=@Continue_2_Results,");
            strSql.Append("Continue_2_People=@Continue_2_People,");
            strSql.Append("Continue_2_Date=@Continue_2_Date,");
            strSql.Append("Continue_3_Results=@Continue_3_Results,");
            strSql.Append("Continue_3_People=@Continue_3_People,");
            strSql.Append("Continue_3_Date=@Continue_3_Date,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("CreateId=@CreateId,");
            strSql.Append("IsConform=@IsConform,");
            strSql.Append("isDel=@isDel,");
            strSql.Append("DelId=@DelId,");
            strSql.Append("DelTime=@DelTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Area", SqlDbType.NVarChar,50),
					new SqlParameter("@Rummager", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
					new SqlParameter("@Model", SqlDbType.NVarChar,50),
					new SqlParameter("@Inventory", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedgerStatu", SqlDbType.Int,4),
					new SqlParameter("@MainProblem", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblemStatu", SqlDbType.Int,4),
					new SqlParameter("@HistoryDate", SqlDbType.DateTime),
					new SqlParameter("@ContinueStatu", SqlDbType.Int,4),
					new SqlParameter("@QuartersLedger_1_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger_1_People", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger_1_Date", SqlDbType.DateTime),
					new SqlParameter("@QuartersLedger_2_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger_2_People", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger_2_Date", SqlDbType.DateTime),
					new SqlParameter("@QuartersLedger_3_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@QuartersLedger_3_People", SqlDbType.NVarChar,50),
					new SqlParameter("@QuartersLedger_3_Date", SqlDbType.DateTime),
					new SqlParameter("@MainProblem_1_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblem_1_People", SqlDbType.NVarChar,50),
					new SqlParameter("@MainProblem_1_Date", SqlDbType.DateTime),
					new SqlParameter("@MainProblem_2_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblem_2_People", SqlDbType.NVarChar,50),
					new SqlParameter("@MainProblem_2_Date", SqlDbType.DateTime),
					new SqlParameter("@MainProblem_3_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@MainProblem_3_People", SqlDbType.NVarChar,50),
					new SqlParameter("@MainProblem_3_Date", SqlDbType.DateTime),
					new SqlParameter("@Continue_1_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@Continue_1_People", SqlDbType.NVarChar,50),
					new SqlParameter("@Continue_1_Date", SqlDbType.DateTime),
					new SqlParameter("@Continue_2_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@Continue_2_People", SqlDbType.NVarChar,50),
					new SqlParameter("@Continue_2_Date", SqlDbType.DateTime),
					new SqlParameter("@Continue_3_Results", SqlDbType.NVarChar,-1),
					new SqlParameter("@Continue_3_People", SqlDbType.NVarChar,50),
					new SqlParameter("@Continue_3_Date", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateId", SqlDbType.Int,4),
					new SqlParameter("@IsConform", SqlDbType.Int,4),
					new SqlParameter("@isDel", SqlDbType.Int,4),
					new SqlParameter("@DelId", SqlDbType.Int,4),
					new SqlParameter("@DelTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Area;
            parameters[1].Value = model.Rummager;
            parameters[2].Value = model.DealerName;
            parameters[3].Value = model.Bank;
            parameters[4].Value = model.BrandName;
            parameters[5].Value = model.SupervisorName;
            parameters[6].Value = model.Model;
            parameters[7].Value = model.Inventory;
            parameters[8].Value = model.QuartersLedger;
            parameters[9].Value = model.QuartersLedgerStatu;
            parameters[10].Value = model.MainProblem;
            parameters[11].Value = model.MainProblemStatu;
            parameters[12].Value = model.HistoryDate;
            parameters[13].Value = model.ContinueStatu;
            parameters[14].Value = model.QuartersLedger_1_Results;
            parameters[15].Value = model.QuartersLedger_1_People;
            parameters[16].Value = model.QuartersLedger_1_Date;
            parameters[17].Value = model.QuartersLedger_2_Results;
            parameters[18].Value = model.QuartersLedger_2_People;
            parameters[19].Value = model.QuartersLedger_2_Date;
            parameters[20].Value = model.QuartersLedger_3_Results;
            parameters[21].Value = model.QuartersLedger_3_People;
            parameters[22].Value = model.QuartersLedger_3_Date;
            parameters[23].Value = model.MainProblem_1_Results;
            parameters[24].Value = model.MainProblem_1_People;
            parameters[25].Value = model.MainProblem_1_Date;
            parameters[26].Value = model.MainProblem_2_Results;
            parameters[27].Value = model.MainProblem_2_People;
            parameters[28].Value = model.MainProblem_2_Date;
            parameters[29].Value = model.MainProblem_3_Results;
            parameters[30].Value = model.MainProblem_3_People;
            parameters[31].Value = model.MainProblem_3_Date;
            parameters[32].Value = model.Continue_1_Results;
            parameters[33].Value = model.Continue_1_People;
            parameters[34].Value = model.Continue_1_Date;
            parameters[35].Value = model.Continue_2_Results;
            parameters[36].Value = model.Continue_2_People;
            parameters[37].Value = model.Continue_2_Date;
            parameters[38].Value = model.Continue_3_Results;
            parameters[39].Value = model.Continue_3_People;
            parameters[40].Value = model.Continue_3_Date;
            parameters[41].Value = model.Remark;
            parameters[42].Value = model.CreateTime;
            parameters[43].Value = model.CreateId;
            parameters[44].Value = model.IsConform;
            parameters[45].Value = model.isDel;
            parameters[46].Value = model.DelId;
            parameters[47].Value = model.DelTime;
            parameters[48].Value = model.ID;

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
            strSql.Append("delete from tb_Inspection ");
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
            strSql.Append("delete from tb_Inspection ");
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
        public Citic.Model.Inspection GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,QuartersLedgerStatu,MainProblem,MainProblemStatu,HistoryDate,ContinueStatu,QuartersLedger_1_Results,QuartersLedger_1_People,QuartersLedger_1_Date,QuartersLedger_2_Results,QuartersLedger_2_People,QuartersLedger_2_Date,QuartersLedger_3_Results,QuartersLedger_3_People,QuartersLedger_3_Date,MainProblem_1_Results,MainProblem_1_People,MainProblem_1_Date,MainProblem_2_Results,MainProblem_2_People,MainProblem_2_Date,MainProblem_3_Results,MainProblem_3_People,MainProblem_3_Date,Continue_1_Results,Continue_1_People,Continue_1_Date,Continue_2_Results,Continue_2_People,Continue_2_Date,Continue_3_Results,Continue_3_People,Continue_3_Date,Remark,CreateTime,CreateId,IsConform,isDel,DelId,DelTime from tb_Inspection ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.Inspection model = new Citic.Model.Inspection();
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
        public Citic.Model.Inspection DataRowToModel(DataRow row)
        {
            Citic.Model.Inspection model = new Citic.Model.Inspection();
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
                if (row["Rummager"] != null)
                {
                    model.Rummager = row["Rummager"].ToString();
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
                if (row["Model"] != null)
                {
                    model.Model = row["Model"].ToString();
                }
                if (row["Inventory"] != null)
                {
                    model.Inventory = row["Inventory"].ToString();
                }
                if (row["QuartersLedger"] != null)
                {
                    model.QuartersLedger = row["QuartersLedger"].ToString();
                }
                if (row["QuartersLedgerStatu"] != null && row["QuartersLedgerStatu"].ToString() != "")
                {
                    model.QuartersLedgerStatu = int.Parse(row["QuartersLedgerStatu"].ToString());
                }
                if (row["MainProblem"] != null)
                {
                    model.MainProblem = row["MainProblem"].ToString();
                }
                if (row["MainProblemStatu"] != null && row["MainProblemStatu"].ToString() != "")
                {
                    model.MainProblemStatu = int.Parse(row["MainProblemStatu"].ToString());
                }
                if (row["HistoryDate"] != null && row["HistoryDate"].ToString() != "")
                {
                    model.HistoryDate = DateTime.Parse(row["HistoryDate"].ToString());
                }
                if (row["ContinueStatu"] != null && row["ContinueStatu"].ToString() != "")
                {
                    model.ContinueStatu = int.Parse(row["ContinueStatu"].ToString());
                }
                if (row["QuartersLedger_1_Results"] != null)
                {
                    model.QuartersLedger_1_Results = row["QuartersLedger_1_Results"].ToString();
                }
                if (row["QuartersLedger_1_People"] != null)
                {
                    model.QuartersLedger_1_People = row["QuartersLedger_1_People"].ToString();
                }
                if (row["QuartersLedger_1_Date"] != null && row["QuartersLedger_1_Date"].ToString() != "")
                {
                    model.QuartersLedger_1_Date = DateTime.Parse(row["QuartersLedger_1_Date"].ToString());
                }
                if (row["QuartersLedger_2_Results"] != null)
                {
                    model.QuartersLedger_2_Results = row["QuartersLedger_2_Results"].ToString();
                }
                if (row["QuartersLedger_2_People"] != null)
                {
                    model.QuartersLedger_2_People = row["QuartersLedger_2_People"].ToString();
                }
                if (row["QuartersLedger_2_Date"] != null && row["QuartersLedger_2_Date"].ToString() != "")
                {
                    model.QuartersLedger_2_Date = DateTime.Parse(row["QuartersLedger_2_Date"].ToString());
                }
                if (row["QuartersLedger_3_Results"] != null)
                {
                    model.QuartersLedger_3_Results = row["QuartersLedger_3_Results"].ToString();
                }
                if (row["QuartersLedger_3_People"] != null)
                {
                    model.QuartersLedger_3_People = row["QuartersLedger_3_People"].ToString();
                }
                if (row["QuartersLedger_3_Date"] != null && row["QuartersLedger_3_Date"].ToString() != "")
                {
                    model.QuartersLedger_3_Date = DateTime.Parse(row["QuartersLedger_3_Date"].ToString());
                }
                if (row["MainProblem_1_Results"] != null)
                {
                    model.MainProblem_1_Results = row["MainProblem_1_Results"].ToString();
                }
                if (row["MainProblem_1_People"] != null)
                {
                    model.MainProblem_1_People = row["MainProblem_1_People"].ToString();
                }
                if (row["MainProblem_1_Date"] != null && row["MainProblem_1_Date"].ToString() != "")
                {
                    model.MainProblem_1_Date = DateTime.Parse(row["MainProblem_1_Date"].ToString());
                }
                if (row["MainProblem_2_Results"] != null)
                {
                    model.MainProblem_2_Results = row["MainProblem_2_Results"].ToString();
                }
                if (row["MainProblem_2_People"] != null)
                {
                    model.MainProblem_2_People = row["MainProblem_2_People"].ToString();
                }
                if (row["MainProblem_2_Date"] != null && row["MainProblem_2_Date"].ToString() != "")
                {
                    model.MainProblem_2_Date = DateTime.Parse(row["MainProblem_2_Date"].ToString());
                }
                if (row["MainProblem_3_Results"] != null)
                {
                    model.MainProblem_3_Results = row["MainProblem_3_Results"].ToString();
                }
                if (row["MainProblem_3_People"] != null)
                {
                    model.MainProblem_3_People = row["MainProblem_3_People"].ToString();
                }
                if (row["MainProblem_3_Date"] != null && row["MainProblem_3_Date"].ToString() != "")
                {
                    model.MainProblem_3_Date = DateTime.Parse(row["MainProblem_3_Date"].ToString());
                }
                if (row["Continue_1_Results"] != null)
                {
                    model.Continue_1_Results = row["Continue_1_Results"].ToString();
                }
                if (row["Continue_1_People"] != null)
                {
                    model.Continue_1_People = row["Continue_1_People"].ToString();
                }
                if (row["Continue_1_Date"] != null && row["Continue_1_Date"].ToString() != "")
                {
                    model.Continue_1_Date = DateTime.Parse(row["Continue_1_Date"].ToString());
                }
                if (row["Continue_2_Results"] != null)
                {
                    model.Continue_2_Results = row["Continue_2_Results"].ToString();
                }
                if (row["Continue_2_People"] != null)
                {
                    model.Continue_2_People = row["Continue_2_People"].ToString();
                }
                if (row["Continue_2_Date"] != null && row["Continue_2_Date"].ToString() != "")
                {
                    model.Continue_2_Date = DateTime.Parse(row["Continue_2_Date"].ToString());
                }
                if (row["Continue_3_Results"] != null)
                {
                    model.Continue_3_Results = row["Continue_3_Results"].ToString();
                }
                if (row["Continue_3_People"] != null)
                {
                    model.Continue_3_People = row["Continue_3_People"].ToString();
                }
                if (row["Continue_3_Date"] != null && row["Continue_3_Date"].ToString() != "")
                {
                    model.Continue_3_Date = DateTime.Parse(row["Continue_3_Date"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["CreateId"] != null && row["CreateId"].ToString() != "")
                {
                    model.CreateId = int.Parse(row["CreateId"].ToString());
                }
                if (row["IsConform"] != null && row["IsConform"].ToString() != "")
                {
                    model.IsConform = int.Parse(row["IsConform"].ToString());
                }
                if (row["isDel"] != null && row["isDel"].ToString() != "")
                {
                    model.isDel = int.Parse(row["isDel"].ToString());
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
            strSql.Append("select ID,Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,QuartersLedgerStatu,MainProblem,MainProblemStatu,HistoryDate,ContinueStatu,QuartersLedger_1_Results,QuartersLedger_1_People,QuartersLedger_1_Date,QuartersLedger_2_Results,QuartersLedger_2_People,QuartersLedger_2_Date,QuartersLedger_3_Results,QuartersLedger_3_People,QuartersLedger_3_Date,MainProblem_1_Results,MainProblem_1_People,MainProblem_1_Date,MainProblem_2_Results,MainProblem_2_People,MainProblem_2_Date,MainProblem_3_Results,MainProblem_3_People,MainProblem_3_Date,Continue_1_Results,Continue_1_People,Continue_1_Date,Continue_2_Results,Continue_2_People,Continue_2_Date,Continue_3_Results,Continue_3_People,Continue_3_Date,Remark,CreateTime,CreateId,IsConform,isDel,DelId,DelTime ");
            strSql.Append(" FROM tb_Inspection ");
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
            strSql.Append(" ID,Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,QuartersLedgerStatu,MainProblem,MainProblemStatu,HistoryDate,ContinueStatu,QuartersLedger_1_Results,QuartersLedger_1_People,QuartersLedger_1_Date,QuartersLedger_2_Results,QuartersLedger_2_People,QuartersLedger_2_Date,QuartersLedger_3_Results,QuartersLedger_3_People,QuartersLedger_3_Date,MainProblem_1_Results,MainProblem_1_People,MainProblem_1_Date,MainProblem_2_Results,MainProblem_2_People,MainProblem_2_Date,MainProblem_3_Results,MainProblem_3_People,MainProblem_3_Date,Continue_1_Results,Continue_1_People,Continue_1_Date,Continue_2_Results,Continue_2_People,Continue_2_Date,Continue_3_Results,Continue_3_People,Continue_3_Date,Remark,CreateTime,CreateId,IsConform,isDel,DelId,DelTime ");
            strSql.Append(" FROM tb_Inspection ");
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
            strSql.Append("select count(1) FROM tb_Inspection ");
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
            strSql.Append(")AS Row, T.*  from tb_Inspection T ");
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
            parameters[0].Value = "tb_Inspection";
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
