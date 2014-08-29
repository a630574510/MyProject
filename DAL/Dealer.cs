using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Xml;
using System.IO;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Dealer
    /// </summary>
    public partial class Dealer
    {
        public Dealer()
        { }
        #region  BasicMethod


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DealerID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Dealer_List");
            strSql.Append(" where DealerID=@DealerID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4)
			};
            parameters[0].Value = DealerID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Dealer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Dealer_List(");
            strSql.Append("DealerName,SupervisorID,SupervisorName,SupervisorDispatchTime,DealerType,IsGroup,IsSingleStore,HasOtherIndustries,GotoworkTime,GoffworkTime,Address,DealerPayCode,Remarks,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@DealerName,@SupervisorID,@SupervisorName,@SupervisorDispatchTime,@DealerType,@IsGroup,@IsSingleStore,@HasOtherIndustries,@GotoworkTime,@GoffworkTime,@Address,@DealerPayCode,@Remarks,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisorID", SqlDbType.Int,4),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,100),
					new SqlParameter("@SupervisorDispatchTime", SqlDbType.DateTime),
					new SqlParameter("@DealerType", SqlDbType.NVarChar,50),
					new SqlParameter("@IsGroup", SqlDbType.Bit,1),
					new SqlParameter("@IsSingleStore", SqlDbType.Bit,1),
					new SqlParameter("@HasOtherIndustries", SqlDbType.NVarChar,200),
					new SqlParameter("@GotoworkTime", SqlDbType.NVarChar,10),
					new SqlParameter("@GoffworkTime", SqlDbType.NVarChar,10),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerPayCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.DealerName;
            parameters[1].Value = model.SupervisorID;
            parameters[2].Value = model.SupervisorName;
            parameters[3].Value = model.SupervisorDispatchTime;
            parameters[4].Value = model.DealerType;
            parameters[5].Value = model.IsGroup;
            parameters[6].Value = model.IsSingleStore;
            parameters[7].Value = model.HasOtherIndustries;
            parameters[8].Value = model.GotoworkTime;
            parameters[9].Value = model.GoffworkTime;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.DealerPayCode;
            parameters[12].Value = model.Remarks;
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
        public bool Update(Citic.Model.Dealer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Dealer_List set ");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("SupervisorID=@SupervisorID,");
            strSql.Append("SupervisorName=@SupervisorName,");
            strSql.Append("SupervisorDispatchTime=@SupervisorDispatchTime,");
            strSql.Append("DealerType=@DealerType,");
            strSql.Append("IsGroup=@IsGroup,");
            strSql.Append("IsSingleStore=@IsSingleStore,");
            strSql.Append("HasOtherIndustries=@HasOtherIndustries,");
            strSql.Append("GotoworkTime=@GotoworkTime,");
            strSql.Append("GoffworkTime=@GoffworkTime,");
            strSql.Append("Address=@Address,");
            strSql.Append("DealerPayCode=@DealerPayCode,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where DealerID=@DealerID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupervisorID", SqlDbType.Int,4),
					new SqlParameter("@SupervisorName", SqlDbType.NVarChar,100),
					new SqlParameter("@SupervisorDispatchTime", SqlDbType.DateTime),
					new SqlParameter("@DealerType", SqlDbType.NVarChar,50),
					new SqlParameter("@IsGroup", SqlDbType.Bit,1),
					new SqlParameter("@IsSingleStore", SqlDbType.Bit,1),
					new SqlParameter("@HasOtherIndustries", SqlDbType.NVarChar,200),
					new SqlParameter("@GotoworkTime", SqlDbType.NVarChar,10),
					new SqlParameter("@GoffworkTime", SqlDbType.NVarChar,10),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerPayCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerName;
            parameters[1].Value = model.SupervisorID;
            parameters[2].Value = model.SupervisorName;
            parameters[3].Value = model.SupervisorDispatchTime;
            parameters[4].Value = model.DealerType;
            parameters[5].Value = model.IsGroup;
            parameters[6].Value = model.IsSingleStore;
            parameters[7].Value = model.HasOtherIndustries;
            parameters[8].Value = model.GotoworkTime;
            parameters[9].Value = model.GoffworkTime;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.DealerPayCode;
            parameters[12].Value = model.Remarks;
            parameters[13].Value = model.CreateID;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.UpdateID;
            parameters[16].Value = model.UpdateTime;
            parameters[17].Value = model.DeleteID;
            parameters[18].Value = model.DeleteTime;
            parameters[19].Value = model.IsDelete;
            parameters[20].Value = model.IsPort;
            parameters[21].Value = model.ConnectID;
            parameters[22].Value = model.DealerID;

            string strSqlT = "Update tb_Dealer_Bank_List set DealerName = @DealerName,JC=@JC Where DealerID=@DealerID";
            SqlParameter[] parametersT = new SqlParameter[]
            {
                new SqlParameter("@JC",model.JC),
                new SqlParameter("@DealerName",model.DealerName),
                new SqlParameter("@DealerID",model.DealerID)
            };

            System.Collections.Generic.List<CommandInfo> cInfos = new System.Collections.Generic.List<CommandInfo>();
            cInfos.Add(new CommandInfo(strSql.ToString(), parameters));
            cInfos.Add(new CommandInfo(strSqlT.ToString(), parametersT));

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int DealerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Dealer_List ");
            strSql.Append(" where DealerID=@DealerID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4)
			};
            parameters[0].Value = DealerID;

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
        public bool DeleteList(string DealerIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Dealer_List ");
            strSql.Append(" where DealerID in (" + DealerIDlist + ")  ");
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
        public Citic.Model.Dealer GetModel(int DealerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DealerID,DealerName,SupervisorID,SupervisorName,SupervisorDispatchTime,DealerType,IsGroup,IsSingleStore,HasOtherIndustries,GotoworkTime,GoffworkTime,Address,DealerPayCode,Remarks,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Dealer_List ");
            strSql.Append(" where DealerID=@DealerID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4)
			};
            parameters[0].Value = DealerID;

            Citic.Model.Dealer model = new Citic.Model.Dealer();
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
        public Citic.Model.Dealer DataRowToModel(DataRow row)
        {
            Citic.Model.Dealer model = new Citic.Model.Dealer();
            if (row != null)
            {
                if (row["DealerID"] != null && row["DealerID"].ToString() != "")
                {
                    model.DealerID = int.Parse(row["DealerID"].ToString());
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["SupervisorID"] != null && row["SupervisorID"].ToString() != "")
                {
                    model.SupervisorID = int.Parse(row["SupervisorID"].ToString());
                }
                if (row["SupervisorName"] != null)
                {
                    model.SupervisorName = row["SupervisorName"].ToString();
                }
                if (row["SupervisorDispatchTime"] != null && row["SupervisorDispatchTime"].ToString() != "")
                {
                    model.SupervisorDispatchTime = DateTime.Parse(row["SupervisorDispatchTime"].ToString());
                }
                if (row["DealerType"] != null)
                {
                    model.DealerType = row["DealerType"].ToString();
                }
                if (row["IsGroup"] != null && row["IsGroup"].ToString() != "")
                {
                    if ((row["IsGroup"].ToString() == "1") || (row["IsGroup"].ToString().ToLower() == "true"))
                    {
                        model.IsGroup = true;
                    }
                    else
                    {
                        model.IsGroup = false;
                    }
                }
                if (row["IsSingleStore"] != null && row["IsSingleStore"].ToString() != "")
                {
                    if ((row["IsSingleStore"].ToString() == "1") || (row["IsSingleStore"].ToString().ToLower() == "true"))
                    {
                        model.IsSingleStore = true;
                    }
                    else
                    {
                        model.IsSingleStore = false;
                    }
                }
                if (row["HasOtherIndustries"] != null)
                {
                    model.HasOtherIndustries = row["HasOtherIndustries"].ToString();
                }
                if (row["GotoworkTime"] != null)
                {
                    model.GotoworkTime = row["GotoworkTime"].ToString();
                }
                if (row["GoffworkTime"] != null)
                {
                    model.GoffworkTime = row["GoffworkTime"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["DealerPayCode"] != null)
                {
                    model.DealerPayCode = row["DealerPayCode"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
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
            strSql.Append("select DealerID,DealerName,SupervisorID,SupervisorName,SupervisorDispatchTime,DealerType,IsGroup,IsSingleStore,HasOtherIndustries,GotoworkTime,GoffworkTime,Address,DealerPayCode,Remarks,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Dealer_List ");
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
            strSql.Append(" DealerID,DealerName,SupervisorID,SupervisorName,SupervisorDispatchTime,DealerType,IsGroup,IsSingleStore,HasOtherIndustries,GotoworkTime,GoffworkTime,Address,DealerPayCode,Remarks,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Dealer_List ");
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
            strSql.Append("select count(1) FROM tb_Dealer_List ");
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
                strSql.Append("order by T.DealerID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Dealer_List T ");
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

        #region 查询银行id，经销商名称，银行名称 张繁 2013年7月24日
        /// <summary>
        /// 查询银行id，经销商名称，银行名称 张繁 2013年7月24日 
        /// </summary>
        /// <param name="SupervisorID">监管员id</param>
        /// <returns></returns>
        public DataSet GetBankID_DealerID_BankName_List(string strSql)
        {
            //2014年5月14日 张繁 2014年6月10日
            //strSql = "select (CONVERT(nvarchar,BankID )+'_'+CONVERT(nvarchar,D_L.DealerID)+'_'+CONVERT(nvarchar,BankName)+'_'+CONVERT(nvarchar,BrandName)+'_'+CONVERT(nvarchar,BusinessMode)) as DealerID,D_L.DealerName,D_B_L.BankName,D_B_L.GD_ID,D_B_L.ZX_ID  from tb_Dealer_List D_L left join tb_Dealer_Bank_List D_B_L on D_L.DealerID=D_B_L.DealerID where  1=1 " + strSql;
            strSql = "select D_B_L.DealerID,D_L.DealerName,D_B_L.BankID,D_B_L.BankName,D_B_L.BrandID, D_B_L.BrandName,D_B_L.BusinessMode,D_B_L.GD_ID,D_B_L.ZX_ID,D_B_L.ZS_ID,D_B_L.ID  from tb_Dealer_List D_L left join tb_Dealer_Bank_List D_B_L on D_L.DealerID=D_B_L.DealerID where  1=1 " + strSql;
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 只查询经销商的ID与名称--乔春羽
        public DataTable GetDealerIDAndDealerName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DealerID,DealerName");
            strSql.Append(" FROM tb_Dealer_List ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

        #region 根据DealerID查询经销商名称--乔春羽
        /// <summary>
        /// 根据DealerID查询经销商名称
        /// </summary>
        /// <param name="dealerID"></param>
        /// <returns></returns>
        public string GetDealerNameByID(int dealerID)
        {
            string dealerName = string.Empty;
            try
            {
                string sql = "select DealerName from tb_Dealer_List where DealerID=@DealerID";
                SqlParameter param = new SqlParameter("@DealerID", SqlDbType.Int, 4);
                param.Value = dealerID;
                object obj = DbHelperSQL.GetSingle(sql, param);
                dealerName = obj == null ? string.Empty : obj.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return dealerName;
        }
        #endregion

        #region 逻辑删除--乔春羽
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Dealer model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tb_Dealer_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where DealerID=@DealerID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.DealerID;
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
        #endregion

        #region 批量逻辑删除--乔春羽
        /// <summary>
        /// 批量逻辑删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string IDList, Citic.Model.Dealer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Dealer_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where DealerID in (" + IDList + ")  ");
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
        #endregion

        #region 添加经销商，同时添加该经销商的本库信息--乔春羽（2013.11.25）
        public int CreateDealer(Citic.Model.Dealer dealerModel)
        {
            int returnValue = 0;

            int dealerID = 0;
            //经销商SQL语句，是一个存储过程
            StringBuilder strSql_Dealer = new StringBuilder();
            strSql_Dealer.Append("proc_CreateDealer");

            SqlParameter[] params_Dealer = {
                    new SqlParameter("@ReturnValue",SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,50),
					new SqlParameter("@DealerType", SqlDbType.NVarChar,50),
					new SqlParameter("@IsGroup", SqlDbType.Bit,1),
					new SqlParameter("@IsSingleStore", SqlDbType.Bit,1),
					new SqlParameter("@HasOtherIndustries", SqlDbType.NVarChar,200),
					new SqlParameter("@GotoworkTime", SqlDbType.NVarChar,10),
					new SqlParameter("@GoffworkTime", SqlDbType.NVarChar,10),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerPayCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            params_Dealer[0].Direction = ParameterDirection.Output;
            params_Dealer[1].Value = dealerModel.DealerName;
            params_Dealer[2].Value = dealerModel.DealerType;
            params_Dealer[3].Value = dealerModel.IsGroup;
            params_Dealer[4].Value = dealerModel.IsSingleStore;
            params_Dealer[5].Value = dealerModel.HasOtherIndustries;
            params_Dealer[6].Value = dealerModel.GotoworkTime;
            params_Dealer[7].Value = dealerModel.GoffworkTime;
            params_Dealer[8].Value = dealerModel.Address;
            params_Dealer[9].Value = dealerModel.DealerPayCode;
            params_Dealer[10].Value = dealerModel.Remarks;
            params_Dealer[11].Value = dealerModel.CreateID;
            params_Dealer[12].Value = dealerModel.CreateTime;
            params_Dealer[13].Value = dealerModel.UpdateID;
            params_Dealer[14].Value = dealerModel.UpdateTime;
            params_Dealer[15].Value = dealerModel.DeleteID;
            params_Dealer[16].Value = dealerModel.DeleteTime;
            params_Dealer[17].Value = dealerModel.IsDelete;
            params_Dealer[18].Value = dealerModel.IsPort;
            params_Dealer[19].Value = dealerModel.ConnectID;

            try
            {
                dealerID = DbHelperSQL.RunProcedure(strSql_Dealer.ToString(), params_Dealer, out returnValue);


            }
            catch (Exception)
            {
                throw;
            }
            return dealerID;
        }
        #endregion

        #region 保存经销商（完整版）--乔春羽(2013.1.23)
        private int SaveDealer(Citic.Model.Dealer _dealer)
        {
            int result = 0;
            StringBuilder dealer_Sql = new StringBuilder();
            dealer_Sql.AppendLine("INSERT INTO tb_Dealer_List(DealerName,SupervisorID,SupervisorName,DealerType,IsGroup,IsSingleStore,HasOtherIndustries,GotoworkTime,GoffworkTime,Address,DealerPayCode,Remarks,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID) ");
            dealer_Sql.AppendFormat("VALUES (@DealerName,0,'',@DealerType,@IsGroup,@IsSingleStore,@HasOtherIndustries,@GotoworkTime,@GoffworkTime,@Address,@DealerPayCode,@Remarks,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            return result;
        }
        #endregion

        #region 给经销商匹配监管员--乔春羽(2013.8.28)
        public bool SuperToDealer(Citic.Model.Dealer model)
        {
            bool flag = false;
            StringBuilder sql = new StringBuilder("Update tb_Dealer_List Set SupervisorID=@SID,SupervisorName=@SName Where DealerID=@ID");
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SID",SqlDbType.Int,4),
                new SqlParameter("@SName",SqlDbType.NVarChar,50),
                new SqlParameter("@ID",SqlDbType.Int,4)
            };
            param[0].Value = model.SupervisorID;
            param[1].Value = model.SupervisorName;
            param[2].Value = model.DealerID;
            try
            {
                flag = DbHelperSQL.ExecuteSql(sql.ToString(), param) > 0 ? true : false;
            }
            catch (Exception)
            {
            }
            return flag;
        }
        #endregion

        #region 根据监管员ID，获取经销商的ID号集合。--乔春羽(2013.11.28)
        public DataTable GetDealerIDsBySupervisorID(int supervisorID)
        {
            DataTable dt = null;
            try
            {
                string sql = "SELECT DealerID FROM tb_Dealer_List WHERE SupervisorID=" + supervisorID;
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion

        #region 读取配置文件，获取SQL语句--乔春羽
        /// <summary>
        /// 读取配置文件，获取SQL语句
        /// </summary>
        /// <returns></returns>
        private string GetSQL(string fileName, string id)
        {
            string sqlstr = string.Empty;
            XmlDocument document = new XmlDocument();
            if (File.Exists(fileName))
            {
                document.Load(fileName);
                XmlElement element = document.DocumentElement;
                foreach (XmlNode node in element.ChildNodes)
                {
                    if (node.Attributes["ID"].Value == id)
                    {
                        sqlstr = node.InnerText;
                        break;
                    }
                }
            }
            return sqlstr;
        }
        #endregion

        #region 执行SQL语句，返回DataTable--乔春羽(2013.12.9)
        /// <summary>
        /// 执行一条SQL语句，返回DataTable
        /// </summary>
        /// <param name="path">存放SQL语句的XML文件路径</param>
        /// <param name="sqlStr">SQL命令</param>
        /// <returns></returns>
        public DataTable QuerySqlCommand(string path, string sqlStr, string where)
        {
            DataTable dt = null;
            try
            {
                string sql = GetSQL(path, sqlStr);
                if (!string.IsNullOrEmpty(sql))
                {
                    if (!string.IsNullOrEmpty(where))
                    {
                        sql = sql.Replace("{Where}", " Where " + where);
                    }
                    dt = DbHelperSQL.Query(sql).Tables[0];
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

