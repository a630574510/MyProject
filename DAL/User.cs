using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:User
    /// </summary>
    public partial class User
    {
        public User()
        { }
        #region  BasicMethod


        /// <summary>
        /// 根据用户名验证登陆
        /// </summary>2013.4.17罗振南
        public Citic.Model.User GetModel(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TOP 1 [UserId]
                          ,[UserName]
                          ,[Password]
                          ,[TrueName]
                          ,[CompanyID]
                          ,[DeptId]
                          ,[RoleId]
                          ,[Post]
                          ,[Email]
                          ,[MobileNo]
                          ,[UserType]
                          ,[RelationID]
                          ,[CreateUser]
                          ,[CreateTime]
                          ,[UpdateUser]
                          ,[UpdateTime]
                          ,[IsDelete]
                          ,[DeleteUser]
                          ,[DeleteTime]
                          ,[IsPort]
                          ,[ConnectID]
                          FROM [dbo].[tb_User]");
            strSql.Append(" WHERE UserName=@UserName AND IsDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20)
			};
            parameters[0].Value = UserName;

            Citic.Model.User model = new Citic.Model.User();
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
        /// 获取用户信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetUserList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,UserName,Password,TrueName,DeptId,DepartmentName,Email,MobileNo,UserType,tu.RoleId,RoleName,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,DeleteUser,DeleteTime,IsPort,ConnectID ");
            strSql.Append(" FROM tb_User tu left join tb_Department td on tu.DeptId=td.DepartmentId");
            strSql.Append(" left join tb_Role tr on tu.RoleId=tr.RoleId");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserId", "tb_User");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_User");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_User(");
            strSql.Append("UserName,Password,TrueName,CompanyID,DeptId,RoleId,Post,Email,MobileNo,UserType,RelationID,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,DeleteUser,DeleteTime,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@TrueName,@CompanyID,@DeptId,@RoleId,@Post,@Email,@MobileNo,@UserType,@RelationID,@CreateUser,@CreateTime,@UpdateUser,@UpdateTime,@IsDelete,@DeleteUser,@DeleteTime,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,52),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@Post", SqlDbType.NVarChar,200),
					new SqlParameter("@Email", SqlDbType.VarChar,200),
					new SqlParameter("@MobileNo", SqlDbType.VarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@RelationID", SqlDbType.Int,4),
					new SqlParameter("@CreateUser", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@DeleteUser", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.CompanyID;
            parameters[4].Value = model.DeptId;
            parameters[5].Value = model.RoleId;
            parameters[6].Value = model.Post;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.MobileNo;
            parameters[9].Value = model.UserType;
            parameters[10].Value = model.RelationID;
            parameters[11].Value = model.CreateUser;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.UpdateUser;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.IsDelete;
            parameters[16].Value = model.DeleteUser;
            parameters[17].Value = model.DeleteTime;
            parameters[18].Value = model.IsPort;
            parameters[19].Value = model.ConnectID;

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
        public bool Update(Citic.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_User set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("DeptId=@DeptId,");
            strSql.Append("RoleId=@RoleId,");
            strSql.Append("Post=@Post,");
            strSql.Append("Email=@Email,");
            strSql.Append("MobileNo=@MobileNo,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("RelationID=@RelationID,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("DeleteUser=@DeleteUser,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@TrueName", SqlDbType.VarChar,52),
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@DeptId", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@Post", SqlDbType.NVarChar,200),
					new SqlParameter("@Email", SqlDbType.VarChar,200),
					new SqlParameter("@MobileNo", SqlDbType.VarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@RelationID", SqlDbType.Int,4),
					new SqlParameter("@CreateUser", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@DeleteUser", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.VarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.CompanyID;
            parameters[4].Value = model.DeptId;
            parameters[5].Value = model.RoleId;
            parameters[6].Value = model.Post;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.MobileNo;
            parameters[9].Value = model.UserType;
            parameters[10].Value = model.RelationID;
            parameters[11].Value = model.CreateUser;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.UpdateUser;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.IsDelete;
            parameters[16].Value = model.DeleteUser;
            parameters[17].Value = model.DeleteTime;
            parameters[18].Value = model.IsPort;
            parameters[19].Value = model.ConnectID;
            parameters[20].Value = model.UserId;

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
        public bool Delete(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_User ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

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
        public bool DeleteList(string UserIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_User ");
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
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
        public Citic.Model.User GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,UserName,Password,TrueName,CompanyID,DeptId,RoleId,Post,Email,MobileNo,UserType,RelationID,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,DeleteUser,DeleteTime,IsPort,ConnectID from tb_User ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

            Citic.Model.User model = new Citic.Model.User();
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
        public Citic.Model.User DataRowToModel(DataRow row)
        {
            Citic.Model.User model = new Citic.Model.User();
            if (row != null)
            {
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
                if (row["CompanyID"] != null && row["CompanyID"].ToString() != "")
                {
                    model.CompanyID = int.Parse(row["CompanyID"].ToString());
                }
                if (row["DeptId"] != null && row["DeptId"].ToString() != "")
                {
                    model.DeptId = int.Parse(row["DeptId"].ToString());
                }
                if (row["RoleId"] != null && row["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(row["RoleId"].ToString());
                }
                if (row["Post"] != null)
                {
                    model.Post = row["Post"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["MobileNo"] != null)
                {
                    model.MobileNo = row["MobileNo"].ToString();
                }
                if (row["UserType"] != null && row["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(row["UserType"].ToString());
                }
                if (row["RelationID"] != null && row["RelationID"].ToString() != "")
                {
                    model.RelationID = int.Parse(row["RelationID"].ToString());
                }
                if (row["CreateUser"] != null && row["CreateUser"].ToString() != "")
                {
                    model.CreateUser = int.Parse(row["CreateUser"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateUser"] != null && row["UpdateUser"].ToString() != "")
                {
                    model.UpdateUser = int.Parse(row["UpdateUser"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
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
                if (row["DeleteUser"] != null && row["DeleteUser"].ToString() != "")
                {
                    model.DeleteUser = int.Parse(row["DeleteUser"].ToString());
                }
                if (row["DeleteTime"] != null && row["DeleteTime"].ToString() != "")
                {
                    model.DeleteTime = DateTime.Parse(row["DeleteTime"].ToString());
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
            strSql.Append("select UserId,UserName,Password,TrueName,CompanyID,DeptId,RoleId,Post,Email,MobileNo,UserType,RelationID,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,DeleteUser,DeleteTime,IsPort,ConnectID ");
            strSql.Append(" FROM tb_User ");
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
            strSql.Append(" UserId,UserName,Password,TrueName,CompanyID,DeptId,RoleId,Post,Email,MobileNo,UserType,RelationID,CreateUser,CreateTime,UpdateUser,UpdateTime,IsDelete,DeleteUser,DeleteTime,IsPort,ConnectID ");
            strSql.Append(" FROM tb_User ");
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
            strSql.Append("select count(1) FROM tb_User T ");
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
                strSql.Append("order by T.UserId desc");
            }
            strSql.Append(")AS Row, T.*,R.RoleName,D.DName  from tb_User T ");
            strSql.Append("LEFT JOIN tb_Role R ON T.RoleId=R.RoleId ");
            strSql.Append("LEFT JOIN tb_Department D ON T.DeptId=D.ID ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

