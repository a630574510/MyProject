using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Supervisor
    /// </summary>
    public partial class Supervisor
    {
        public Supervisor()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SupervisorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Supervisor_List");
            strSql.Append(" where SupervisorID=@SupervisorID");
            SqlParameter[] parameters = {
					new SqlParameter("@SupervisorID", SqlDbType.Int,4)
			};
            parameters[0].Value = SupervisorID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Supervisor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Supervisor_List(");
            strSql.Append("SupervisorName,Age,Gender,IDCard,LinkPhone,EntryTime,Education,QQ,UrgencyMan,UrgencyConnect,UrgencyPhone,WorkType,WorkSource,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@SupervisorName,@Age,@Gender,@IDCard,@LinkPhone,@EntryTime,@Education,@QQ,@UrgencyMan,@UrgencyConnect,@UrgencyPhone,@WorkType,@WorkSource,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,18),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@Education", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyMan", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyConnect", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@WorkType", SqlDbType.Int,4),
					new SqlParameter("@WorkSource", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SupervisorName;
            parameters[1].Value = model.Age;
            parameters[2].Value = model.Gender;
            parameters[3].Value = model.IDCard;
            parameters[4].Value = model.LinkPhone;
            parameters[5].Value = model.EntryTime;
            parameters[6].Value = model.Education;
            parameters[7].Value = model.QQ;
            parameters[8].Value = model.UrgencyMan;
            parameters[9].Value = model.UrgencyConnect;
            parameters[10].Value = model.UrgencyPhone;
            parameters[11].Value = model.WorkType;
            parameters[12].Value = model.WorkSource;
            parameters[13].Value = model.CreateID;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.UpdateID;
            parameters[16].Value = model.UpdateTime;
            parameters[17].Value = model.DeleteID;
            parameters[18].Value = model.DeleteTime;
            parameters[19].Value = model.IsDelete;
            parameters[20].Value = model.IsPort;
            parameters[21].Value = model.ConnectID;

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
        public bool Update(Citic.Model.Supervisor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Supervisor_List set ");
            strSql.Append("SupervisorName=@SupervisorName,");
            strSql.Append("Age=@Age,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("IDCard=@IDCard,");
            strSql.Append("LinkPhone=@LinkPhone,");
            strSql.Append("EntryTime=@EntryTime,");
            strSql.Append("Education=@Education,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("UrgencyMan=@UrgencyMan,");
            strSql.Append("UrgencyConnect=@UrgencyConnect,");
            strSql.Append("UrgencyPhone=@UrgencyPhone,");
            strSql.Append("WorkType=@WorkType,");
            strSql.Append("WorkSource=@WorkSource,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where SupervisorID=@SupervisorID");
            SqlParameter[] parameters = {
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,18),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@Education", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyMan", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyConnect", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@WorkType", SqlDbType.Int,4),
					new SqlParameter("@WorkSource", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisorID", SqlDbType.Int,4)};
            parameters[0].Value = model.SupervisorName;
            parameters[1].Value = model.Age;
            parameters[2].Value = model.Gender;
            parameters[3].Value = model.IDCard;
            parameters[4].Value = model.LinkPhone;
            parameters[5].Value = model.EntryTime;
            parameters[6].Value = model.Education;
            parameters[7].Value = model.QQ;
            parameters[8].Value = model.UrgencyMan;
            parameters[9].Value = model.UrgencyConnect;
            parameters[10].Value = model.UrgencyPhone;
            parameters[11].Value = model.WorkType;
            parameters[12].Value = model.WorkSource;
            parameters[13].Value = model.CreateID;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.UpdateID;
            parameters[16].Value = model.UpdateTime;
            parameters[17].Value = model.DeleteID;
            parameters[18].Value = model.DeleteTime;
            parameters[19].Value = model.IsDelete;
            parameters[20].Value = model.IsPort;
            parameters[21].Value = model.ConnectID;
            parameters[22].Value = model.SupervisorID;

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
        public bool Delete(int SupervisorID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Supervisor_List ");
            strSql.Append(" where SupervisorID=@SupervisorID");
            SqlParameter[] parameters = {
					new SqlParameter("@SupervisorID", SqlDbType.Int,4)
			};
            parameters[0].Value = SupervisorID;

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
        public bool DeleteList(string SupervisorIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Supervisor_List ");
            strSql.Append(" where SupervisorID in (" + SupervisorIDlist + ")  ");
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
        public Citic.Model.Supervisor GetModel(int SupervisorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SupervisorID,SupervisorName,Age,Gender,IDCard,LinkPhone,EntryTime,Education,QQ,UrgencyMan,UrgencyConnect,UrgencyPhone,WorkType,WorkSource,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Supervisor_List ");
            strSql.Append(" where SupervisorID=@SupervisorID");
            SqlParameter[] parameters = {
					new SqlParameter("@SupervisorID", SqlDbType.Int,4)
			};
            parameters[0].Value = SupervisorID;

            Citic.Model.Supervisor model = new Citic.Model.Supervisor();
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
        public Citic.Model.Supervisor DataRowToModel(DataRow row)
        {
            Citic.Model.Supervisor model = new Citic.Model.Supervisor();
            if (row != null)
            {
                if (row["SupervisorID"] != null && row["SupervisorID"].ToString() != "")
                {
                    model.SupervisorID = int.Parse(row["SupervisorID"].ToString());
                }
                if (row["SupervisorName"] != null)
                {
                    model.SupervisorName = row["SupervisorName"].ToString();
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
                if (row["Gender"] != null && row["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(row["Gender"].ToString());
                }
                if (row["IDCard"] != null)
                {
                    model.IDCard = row["IDCard"].ToString();
                }
                if (row["LinkPhone"] != null)
                {
                    model.LinkPhone = row["LinkPhone"].ToString();
                }
                if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
                {
                    model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
                }
                if (row["Education"] != null)
                {
                    model.Education = row["Education"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["UrgencyMan"] != null)
                {
                    model.UrgencyMan = row["UrgencyMan"].ToString();
                }
                if (row["UrgencyConnect"] != null)
                {
                    model.UrgencyConnect = row["UrgencyConnect"].ToString();
                }
                if (row["UrgencyPhone"] != null)
                {
                    model.UrgencyPhone = row["UrgencyPhone"].ToString();
                }
                if (row["WorkType"] != null && row["WorkType"].ToString() != "")
                {
                    model.WorkType = int.Parse(row["WorkType"].ToString());
                }
                if (row["WorkSource"] != null && row["WorkSource"].ToString() != "")
                {
                    model.WorkSource = int.Parse(row["WorkSource"].ToString());
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
            strSql.Append("select SupervisorID,SupervisorName,Age,Gender,IDCard,LinkPhone,EntryTime,Education,QQ,UrgencyMan,UrgencyConnect,UrgencyPhone,WorkType,WorkSource,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Supervisor_List ");
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
            strSql.Append(" SupervisorID,SupervisorName,Age,Gender,IDCard,LinkPhone,EntryTime,Education,QQ,UrgencyMan,UrgencyConnect,UrgencyPhone,WorkType,WorkSource,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Supervisor_List ");
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
            strSql.Append("select count(1) FROM tb_Supervisor_List T");
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
                strSql.Append("order by T.SupervisorID desc");
            }
            strSql.Append(")AS Row, T.*,tu.TrueName CreateName from tb_Supervisor_List T left join tb_User tu on T.CreateID=tu.UserId");
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

        /// <summary>
        /// 批量逻辑删除--乔春羽
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string SupervisorIDList, Citic.Model.Supervisor model)
        {
            //首先更改监管员的状态
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Supervisor_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.AppendFormat(" where SupervisorID in  ({0})   ", SupervisorIDList);
            SqlParameter[] parameters = {
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.DeleteID;
            parameters[1].Value = model.DeleteTime;
            //其次更改用户表监管员角色的状态

            StringBuilder user_Sql = new StringBuilder();
            user_Sql.Append("UPDATE tb_User SET IsDelete=1,DeleteUser=@DeleteID,DeleteTime=@DeleteTime");
            user_Sql.AppendFormat(" where RelationID in ({0}) and RoleId=10 ", SupervisorIDList);
            SqlParameter[] parameters_User = {
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters_User[0].Value = model.DeleteID;
            parameters_User[1].Value = model.DeleteTime;

            List<CommandInfo> cInfos = new List<CommandInfo> { new CommandInfo(strSql.ToString(), parameters), new CommandInfo(user_Sql.ToString(), parameters_User) };

            int rows = DbHelperSQL.ExecuteSqlTran(cInfos);

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
        public bool DeleteOnLogic(Citic.Model.Supervisor model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tb_Supervisor_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where SupervisorID=@SupervisorID");
            SqlParameter[] parameters = {
					new SqlParameter("@SupervisorID", SqlDbType.Int,4),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.SupervisorID;
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

        #region 获得没有关联用户的监管员信息--乔春羽
        /// <summary>
        /// 获得没有关联用户的监管员信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSupervisorWithoutUser(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.SupervisorID desc");
            }
            strSql.Append(")AS Row, T.*,tu.TrueName CreateName from tb_Supervisor_List T left join tb_User tu on T.CreateID=tu.UserId");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
                strSql.Append(" AND T.SupervisorID NOT IN (SELECT SID FROM tb_User_Supervisor_List)");
            }
            else
            {
                strSql.Append(" WHERE T.SupervisorID NOT IN (SELECT SID FROM tb_User_Supervisor_List)");
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 创建监管员，同时创建一个账号。--乔春羽(2013.11.27)
        public int CreateSupervisor(Citic.Model.Supervisor model)
        {
            int result = 0;
            int returnValue = 0;
            string proc_Name = "proc_CreateSupervisor";
            try
            {

                SqlParameter[] param_Supervisor ={
                    new SqlParameter("@ReturnValue",SqlDbType.Int,4),
				    new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
				    new SqlParameter("@Age", SqlDbType.Int,4),
				    new SqlParameter("@Gender", SqlDbType.Int,4),
			   	    new SqlParameter("@IDCard", SqlDbType.NVarChar,18),
				    new SqlParameter("@LinkPhone", SqlDbType.NVarChar,50),
				    new SqlParameter("@EntryTime", SqlDbType.DateTime),
				    new SqlParameter("@Education", SqlDbType.NVarChar,20),
				    new SqlParameter("@QQ", SqlDbType.NVarChar,20),
				    new SqlParameter("@UrgencyMan", SqlDbType.NVarChar,20),
				    new SqlParameter("@UrgencyConnect", SqlDbType.NVarChar,20),
				    new SqlParameter("@UrgencyPhone", SqlDbType.NVarChar,20),
				    new SqlParameter("@WorkType", SqlDbType.Int,4),
				    new SqlParameter("@WorkSource", SqlDbType.Int,4),
				    new SqlParameter("@CreateID", SqlDbType.Int,4),
				    new SqlParameter("@CreateTime", SqlDbType.DateTime),
				    new SqlParameter("@UpdateID", SqlDbType.Int,4),
				    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
				    new SqlParameter("@DeleteID", SqlDbType.Int,4),
				    new SqlParameter("@DeleteTime", SqlDbType.DateTime),
				    new SqlParameter("@IsDelete", SqlDbType.Bit,1),
				    new SqlParameter("@IsPort", SqlDbType.Bit,1),
				    new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
				    new SqlParameter("@Password", SqlDbType.NVarChar,50)
                };

                param_Supervisor[0].Direction = ParameterDirection.Output;
                param_Supervisor[1].Value = model.SupervisorName;
                param_Supervisor[2].Value = model.Age;
                param_Supervisor[3].Value = model.Gender;
                param_Supervisor[4].Value = model.IDCard;
                param_Supervisor[5].Value = model.LinkPhone;
                param_Supervisor[6].Value = model.EntryTime;
                param_Supervisor[7].Value = model.Education;
                param_Supervisor[8].Value = model.QQ;
                param_Supervisor[9].Value = model.UrgencyMan;
                param_Supervisor[10].Value = model.UrgencyConnect;
                param_Supervisor[11].Value = model.UrgencyPhone;
                param_Supervisor[12].Value = model.WorkType;
                param_Supervisor[13].Value = model.WorkSource;
                param_Supervisor[14].Value = model.CreateID;
                param_Supervisor[15].Value = model.CreateTime;
                param_Supervisor[16].Value = model.UpdateID;
                param_Supervisor[17].Value = model.UpdateTime;
                param_Supervisor[18].Value = model.DeleteID;
                param_Supervisor[19].Value = model.DeleteTime;
                param_Supervisor[20].Value = model.IsDelete;
                param_Supervisor[21].Value = model.IsPort;
                param_Supervisor[22].Value = model.ConnectID;
                param_Supervisor[23].Value = model.Password;

                result = DbHelperSQL.RunProcedure(proc_Name, param_Supervisor, out returnValue);
            }
            catch (SqlException se)
            {
                throw se;
            }


            return result;
        }
        #endregion

        #region 修改监管员的信息，同时也修改监管员对应账号的信息。--乔春羽(2013.11.28)
        public int ModifySupervisor(Citic.Model.Supervisor model)
        {
            int result = 0;
            int returnValue = 0;
            string proc_Name = "proc_ModifySupervisor";
            try
            {
                SqlParameter[] param_Super =
                {
                    new SqlParameter("@ReturnValue", SqlDbType.Int,4),
                    new SqlParameter("@SupervisorID", SqlDbType.Int,4),
                    new SqlParameter("@SupervisorName", SqlDbType.NVarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,18),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@Education", SqlDbType.NVarChar,20),
					new SqlParameter("@QQ", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyMan", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyConnect", SqlDbType.NVarChar,20),
					new SqlParameter("@UrgencyPhone", SqlDbType.NVarChar,20),
					new SqlParameter("@WorkType", SqlDbType.Int,4),
					new SqlParameter("@WorkSource", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50)
                };
                param_Super[0].Direction = ParameterDirection.Output;
                param_Super[1].Value = model.SupervisorID;
                param_Super[2].Value = model.SupervisorName;
                param_Super[3].Value = model.Age;
                param_Super[4].Value = model.Gender;
                param_Super[5].Value = model.IDCard;
                param_Super[6].Value = model.LinkPhone;
                param_Super[7].Value = model.EntryTime;
                param_Super[8].Value = model.Education;
                param_Super[9].Value = model.QQ;
                param_Super[10].Value = model.UrgencyMan;
                param_Super[11].Value = model.UrgencyConnect;
                param_Super[12].Value = model.UrgencyPhone;
                param_Super[13].Value = model.WorkType;
                param_Super[14].Value = model.WorkSource;
                param_Super[15].Value = model.CreateID;
                param_Super[16].Value = model.CreateTime;
                param_Super[17].Value = model.UpdateID;
                param_Super[18].Value = model.UpdateTime;
                param_Super[19].Value = model.DeleteID;
                param_Super[20].Value = model.DeleteTime;
                param_Super[21].Value = model.IsDelete;
                param_Super[22].Value = model.IsPort;
                param_Super[23].Value = model.ConnectID;
                param_Super[24].Value = model.Password;

                result = DbHelperSQL.RunProcedure(proc_Name, param_Super, out returnValue);
            }
            catch (SqlException se)
            {
                throw se;
            }
            return result;
        }
        #endregion

        #region 根据监管员ID得到一个实体对象，该对象中包含此监管员的登录账户的密码。--乔春羽(2013.11.28)
        /// <summary>
        /// 根据监管员ID得到一个实体对象，该对象中包含此监管员的登录账户的密码。
        /// </summary>
        /// <param name="supervisorID"></param>
        /// <returns></returns>
        public Citic.Model.Supervisor GetSupervisorWithCode(int supervisorID)
        {
            Citic.Model.Supervisor model = null;
            try
            {
                string sql = @"SELECT [SupervisorID]
                          ,[SupervisorName]
                          ,[Age]
                          ,[Gender]
                          ,[IDCard]
                          ,[LinkPhone]
                          ,[EntryTime]
                          ,[Education]
                          ,[QQ]
                          ,[UrgencyMan]
                          ,[UrgencyConnect]
                          ,[UrgencyPhone]
                          ,[WorkType]
                          ,[WorkSource]
                          ,sl.[CreateID]
                          ,sl.[CreateTime]
                          ,sl.[UpdateID]
                          ,sl.[UpdateTime]
                          ,sl.[DeleteID]
                          ,sl.[DeleteTime]
                          ,sl.[IsDelete]
                          ,sl.[IsPort]
                          ,sl.[ConnectID]
                          ,ISNULL(u.Password,'') Password
                      FROM [tb_Supervisor_List] sl LEFT JOIN tb_User u ON sl.SupervisorID=u.RelationID
                      WHERE sl.SupervisorID=@SID";
                SqlParameter sparam = new SqlParameter("@SID", supervisorID);

                SqlDataReader reader = DbHelperSQL.ExecuteReader(sql, sparam);
                if (reader.Read())
                {
                    model = new Model.Supervisor();
                    model.Age = Convert.ToInt32(reader["Age"]);
                    model.ConnectID = reader["ConnectID"].ToString();
                    model.CreateID = Convert.ToInt32(reader["CreateID"]);
                    model.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                    model.Education = reader["Education"].ToString();
                    model.EntryTime = Convert.ToDateTime(reader["EntryTime"]);
                    model.Gender = Convert.ToInt32(reader["Gender"]);
                    model.IDCard = reader["IDCard"].ToString();
                    model.IsDelete = Convert.ToBoolean(reader["IsDelete"]);
                    model.IsPort = Convert.ToBoolean(reader["IsPort"]);
                    model.LinkPhone = reader["LinkPhone"].ToString();
                    model.Password = reader["Password"].ToString();
                    model.QQ = reader["QQ"].ToString();
                    model.SupervisorID = Convert.ToInt32(reader["SupervisorID"]);
                    model.SupervisorName = reader["SupervisorName"].ToString();
                    model.UrgencyConnect = reader["UrgencyConnect"].ToString();
                    model.UrgencyMan = reader["UrgencyMan"].ToString();
                    model.UrgencyPhone = reader["UrgencyPhone"].ToString();
                    model.WorkSource = Convert.ToInt32(reader["WorkSource"]);
                    model.WorkType = Convert.ToInt32(reader["WorkType"]);
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

        #region 获得监管员的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT SupervisorID,SupervisorName,Age,CASE Gender WHEN 0 THEN '男' WHEN 1 THEN '女' END Gender,IDCard,LinkPhone,EntryTime,Education,QQ,UrgencyMan,UrgencyConnect,UrgencyPhone,WorkType,CASE WorkSource WHEN 0 THEN '属地' WHEN 1 THEN '外派' END WorkSource,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Supervisor_List ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

