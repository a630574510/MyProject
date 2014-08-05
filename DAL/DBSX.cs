using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:DBSX
    /// </summary>
    public partial class DBSX
    {
        public DBSX()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DBSX_List");
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
        public int Add(Citic.Model.DBSX model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DBSX_List(");
            strSql.Append("BankID,BankName,DealerID,DealerName,DraftNo,Vin,ReqType,Content,Status,IsSupervisorLook,IsBMLook,CreateID,CreateTime,OperateID,OperateTime,TargetUser,IsDelete)");
            strSql.Append(" values (");
            strSql.Append("@BankID,@BankName,@DealerID,@DealerName,@DraftNo,@Vin,@ReqType,@Content,@Status,@IsSupervisorLook,@IsBMLook,@CreateID,@CreateTime,@OperateID,@OperateTime,@TargetUser,@IsDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Vin", SqlDbType.NVarChar,50),
					new SqlParameter("@ReqType", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,200),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@IsSupervisorLook", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsBMLook", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@TargetUser", SqlDbType.NVarChar,20),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1)};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.DraftNo;
            parameters[5].Value = model.Vin;
            parameters[6].Value = model.ReqType;
            parameters[7].Value = model.Content;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.IsSupervisorLook;
            parameters[10].Value = model.IsBMLook;
            parameters[11].Value = model.CreateID;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.OperateID;
            parameters[14].Value = model.OperateTime;
            parameters[15].Value = model.TargetUser;
            parameters[16].Value = model.IsDelete;

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
        public bool Update(Citic.Model.DBSX model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DBSX_List set ");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("DraftNo=@DraftNo,");
            strSql.Append("Vin=@Vin,");
            strSql.Append("ReqType=@ReqType,");
            strSql.Append("Content=@Content,");
            strSql.Append("Status=@Status,");
            strSql.Append("IsSupervisorLook=@IsSupervisorLook,");
            strSql.Append("IsBMLook=@IsBMLook,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("OperateID=@OperateID,");
            strSql.Append("OperateTime=@OperateTime,");
            strSql.Append("TargetUser=@TargetUser,");
            strSql.Append("IsDelete=@IsDelete");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Vin", SqlDbType.NVarChar,50),
					new SqlParameter("@ReqType", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,200),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@IsSupervisorLook", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsBMLook", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@TargetUser", SqlDbType.NVarChar,20),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.BankID;
            parameters[1].Value = model.BankName;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.DraftNo;
            parameters[5].Value = model.Vin;
            parameters[6].Value = model.ReqType;
            parameters[7].Value = model.Content;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.IsSupervisorLook;
            parameters[10].Value = model.IsBMLook;
            parameters[11].Value = model.CreateID;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.OperateID;
            parameters[14].Value = model.OperateTime;
            parameters[15].Value = model.TargetUser;
            parameters[16].Value = model.IsDelete;
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
            strSql.Append("delete from tb_DBSX_List ");
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
            strSql.Append("delete from tb_DBSX_List ");
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
        public Citic.Model.DBSX GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BankID,BankName,DealerID,DealerName,DraftNo,Vin,ReqType,Content,Status,IsSupervisorLook,IsBMLook,CreateID,CreateTime,OperateID,OperateTime,TargetUser,IsDelete from tb_DBSX_List ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.DBSX model = new Citic.Model.DBSX();
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
        public Citic.Model.DBSX DataRowToModel(DataRow row)
        {
            Citic.Model.DBSX model = new Citic.Model.DBSX();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["BankID"] != null && row["BankID"].ToString() != "")
                {
                    model.BankID = int.Parse(row["BankID"].ToString());
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["DealerID"] != null && row["DealerID"].ToString() != "")
                {
                    model.DealerID = int.Parse(row["DealerID"].ToString());
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["DraftNo"] != null)
                {
                    model.DraftNo = row["DraftNo"].ToString();
                }
                if (row["Vin"] != null)
                {
                    model.Vin = row["Vin"].ToString();
                }
                if (row["ReqType"] != null && row["ReqType"].ToString() != "")
                {
                    model.ReqType = int.Parse(row["ReqType"].ToString());
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["IsSupervisorLook"] != null)
                {
                    model.IsSupervisorLook = row["IsSupervisorLook"].ToString();
                }
                if (row["IsBMLook"] != null)
                {
                    model.IsBMLook = row["IsBMLook"].ToString();
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["OperateID"] != null && row["OperateID"].ToString() != "")
                {
                    model.OperateID = int.Parse(row["OperateID"].ToString());
                }
                if (row["OperateTime"] != null && row["OperateTime"].ToString() != "")
                {
                    model.OperateTime = DateTime.Parse(row["OperateTime"].ToString());
                }
                if (row["TargetUser"] != null)
                {
                    model.TargetUser = row["TargetUser"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BankID,BankName,DealerID,DealerName,DraftNo,Vin,ReqType,Content,Status,IsSupervisorLook,IsBMLook,CreateID,CreateTime,OperateID,OperateTime,TargetUser,IsDelete ");
            strSql.Append(" FROM tb_DBSX_List ");
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
            strSql.Append(" ID,BankID,BankName,DealerID,DealerName,DraftNo,Vin,ReqType,Content,Status,IsSupervisorLook,IsBMLook,CreateID,CreateTime,OperateID,OperateTime,TargetUser,IsDelete ");
            strSql.Append(" FROM tb_DBSX_List ");
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
            strSql.Append("select count(1) FROM tb_DBSX_List T ");
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
            strSql.Append(")AS Row, T.*,U.UserName OperateName  from tb_DBSX_List T LEFT JOIN tb_User U ON T.OperateID=U.UserId");
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
        #region 修改相应角色的“是否已查阅”状态--乔春羽
        /// <summary>
        /// 修改相应角色的“是否已查阅”状态
        /// </summary>
        /// <param name="roleId">角色</param>
        /// <param name="model">数据</param>
        /// <returns></returns>
        public bool ModifyIsLook(int roleId, Citic.Model.DBSX model)
        {
            StringBuilder sqlStr = new StringBuilder("UPDATE tb_DBSX_List SET ");
            bool flag = false;
            //是监管员
            if (roleId == 10)
            {
                sqlStr.AppendFormat("IsSupervisorLook=1");
            }
            //市场经理
            else if (roleId == 3)
            {
                sqlStr.AppendFormat("IsBMLook=1");
            }
            sqlStr.Append(" WHERE ID=@ID");
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
            param.Value = model.ID;
            try
            {
                flag = DbHelperSQL.ExecuteSql(sqlStr.ToString(), param) > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

