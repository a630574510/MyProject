using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.IO;
using System.Xml;
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Dealer_Bank
    /// </summary>
    public partial class Dealer_Bank
    {
        public Dealer_Bank()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Dealer_Bank_List");
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
        public int Add(Citic.Model.Dealer_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Dealer_Bank_List(");
            strSql.Append("DealerID,DealerName,JC,BC,BankID,BankName,BrandID,BrandName,BusinessMode,FinancingMode,CollaborateType,SSMoney,YSMoney,PaymentCycle,DispatchTime,CreateID,CreateTime,IsDelete,StopTime,GD_ID,ZX_ID)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@JC,@BC,@BankID,@BankName,@BrandID,@BrandName,@BusinessMode,@FinancingMode,@CollaborateType,@SSMoney,@YSMoney,@PaymentCycle,@DispatchTime,@CreateID,@CreateTime,@IsDelete,@StopTime,@GD_ID,@ZX_ID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@JC", SqlDbType.NVarChar,20),
					new SqlParameter("@BC", SqlDbType.Int,4),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,100),
					new SqlParameter("@BusinessMode", SqlDbType.Int,4),
					new SqlParameter("@FinancingMode", SqlDbType.NVarChar,50),
					new SqlParameter("@CollaborateType", SqlDbType.Int,4),
					new SqlParameter("@SSMoney", SqlDbType.Money,8),
					new SqlParameter("@YSMoney", SqlDbType.Money,8),
					new SqlParameter("@PaymentCycle", SqlDbType.Int,4),
					new SqlParameter("@DispatchTime", SqlDbType.DateTime),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@StopTime", SqlDbType.DateTime),
					new SqlParameter("@GD_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@ZX_ID", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.JC;
            parameters[3].Value = model.BC;
            parameters[4].Value = model.BankID;
            parameters[5].Value = model.BankName;
            parameters[6].Value = model.BrandID;
            parameters[7].Value = model.BrandName;
            parameters[8].Value = model.BusinessMode;
            parameters[9].Value = model.FinancingMode;
            parameters[10].Value = model.CollaborateType;
            parameters[11].Value = model.SSMoney;
            parameters[12].Value = model.YSMoney;
            parameters[13].Value = model.PaymentCycle;
            parameters[14].Value = model.DispatchTime;
            parameters[15].Value = model.CreateID;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.IsDelete;
            parameters[18].Value = model.StopTime;
            parameters[19].Value = model.GD_ID;
            parameters[20].Value = model.ZX_ID;

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
        public bool Update(Citic.Model.Dealer_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Dealer_Bank_List set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("JC=@JC,");
            strSql.Append("BC=@BC,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("BusinessMode=@BusinessMode,");
            strSql.Append("FinancingMode=@FinancingMode,");
            strSql.Append("CollaborateType=@CollaborateType,");
            strSql.Append("SSMoney=@SSMoney,");
            strSql.Append("YSMoney=@YSMoney,");
            strSql.Append("PaymentCycle=@PaymentCycle,");
            strSql.Append("DispatchTime=@DispatchTime,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("StopTime=@StopTime,");
            strSql.Append("GD_ID=@GD_ID,");
            strSql.Append("ZX_ID=@ZX_ID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@JC", SqlDbType.NVarChar,20),
					new SqlParameter("@BC", SqlDbType.Int,4),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,100),
					new SqlParameter("@BusinessMode", SqlDbType.Int,4),
					new SqlParameter("@FinancingMode", SqlDbType.NVarChar,50),
					new SqlParameter("@CollaborateType", SqlDbType.Int,4),
					new SqlParameter("@SSMoney", SqlDbType.Money,8),
					new SqlParameter("@YSMoney", SqlDbType.Money,8),
					new SqlParameter("@PaymentCycle", SqlDbType.Int,4),
					new SqlParameter("@DispatchTime", SqlDbType.DateTime),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@StopTime", SqlDbType.DateTime),
					new SqlParameter("@GD_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@ZX_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.JC;
            parameters[3].Value = model.BC;
            parameters[4].Value = model.BankID;
            parameters[5].Value = model.BankName;
            parameters[6].Value = model.BrandID;
            parameters[7].Value = model.BrandName;
            parameters[8].Value = model.BusinessMode;
            parameters[9].Value = model.FinancingMode;
            parameters[10].Value = model.CollaborateType;
            parameters[11].Value = model.SSMoney;
            parameters[12].Value = model.YSMoney;
            parameters[13].Value = model.PaymentCycle;
            parameters[14].Value = model.DispatchTime;
            parameters[15].Value = model.CreateID;
            parameters[16].Value = model.CreateTime;
            parameters[17].Value = model.IsDelete;
            parameters[18].Value = model.StopTime;
            parameters[19].Value = model.GD_ID;
            parameters[20].Value = model.ZX_ID;
            parameters[21].Value = model.ID;

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
            strSql.Append("delete from tb_Dealer_Bank_List ");
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
            strSql.Append("delete from tb_Dealer_Bank_List ");
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
        public Citic.Model.Dealer_Bank GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 ID,DealerID,DealerName,JC,BC,BankID,BankName,BrandID,BrandName,BusinessMode,FinancingMode,CollaborateType,SSMoney,YSMoney,PaymentCycle,DispatchTime,CreateID,CreateTime,IsDelete,StopTime,GD_ID,ZX_ID from tb_Dealer_Bank_List ");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.Dealer_Bank model = new Citic.Model.Dealer_Bank();
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
        public Citic.Model.Dealer_Bank DataRowToModel(DataRow row)
        {
            Citic.Model.Dealer_Bank model = new Citic.Model.Dealer_Bank();
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
                if (row["JC"] != null)
                {
                    model.JC = row["JC"].ToString();
                }
                if (row["BC"] != null && row["BC"].ToString() != "")
                {
                    model.BC = int.Parse(row["BC"].ToString());
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
                if (row["BusinessMode"] != null && row["BusinessMode"].ToString() != "")
                {
                    model.BusinessMode = int.Parse(row["BusinessMode"].ToString());
                }
                if (row["FinancingMode"] != null)
                {
                    model.FinancingMode = row["FinancingMode"].ToString();
                }
                if (row["CollaborateType"] != null && row["CollaborateType"].ToString() != "")
                {
                    model.CollaborateType = int.Parse(row["CollaborateType"].ToString());
                }
                if (row["SSMoney"] != null && row["SSMoney"].ToString() != "")
                {
                    model.SSMoney = decimal.Parse(row["SSMoney"].ToString());
                }
                if (row["YSMoney"] != null && row["YSMoney"].ToString() != "")
                {
                    model.YSMoney = decimal.Parse(row["YSMoney"].ToString());
                }
                if (row["PaymentCycle"] != null && row["PaymentCycle"].ToString() != "")
                {
                    model.PaymentCycle = int.Parse(row["PaymentCycle"].ToString());
                }
                if (row["DispatchTime"] != null && row["DispatchTime"].ToString() != "")
                {
                    model.DispatchTime = DateTime.Parse(row["DispatchTime"].ToString());
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
                if (row["StopTime"] != null && row["StopTime"].ToString() != "")
                {
                    model.StopTime = DateTime.Parse(row["StopTime"].ToString());
                }
                if (row["GD_ID"] != null)
                {
                    model.GD_ID = row["GD_ID"].ToString();
                }
                if (row["ZX_ID"] != null)
                {
                    model.ZX_ID = row["ZX_ID"].ToString();
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
            strSql.Append("SELECT ID,DealerID,DealerName,JC,BC,A.BankID,A.BankName,BrandID,BrandName,BusinessMode,FinancingMode,CollaborateType,SSMoney,YSMoney,PaymentCycle,DispatchTime,StopTime,GD_ID,ZX_ID,B.ConnectID,A.CreateID,A.CreateTime ");
            strSql.Append("FROM tb_Dealer_Bank_List A left join tb_Bank_List B on A.BankID = B.BankID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表 张繁 2014年6月11日
        /// </summary>
        public DataSet GetListAll(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,DealerID,DealerName,JC,BC,BankID,BankName,BrandID,BrandName,BusinessMode,FinancingMode,CollaborateType,SSMoney,YSMoney,PaymentCycle,DispatchTime,StopTime,GD_ID,ZX_ID,CreateID,CreateTime ");
            strSql.Append("FROM tb_Dealer_Bank_List");
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
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" ID,DealerID,DealerName,JC,BC,BankID,BankName,BrandID,BrandName,BusinessMode,FinancingMode,CollaborateType,SSMoney,YSMoney,PaymentCycle,DispatchTime,CreateID,CreateTime,IsDelete,StopTime,GD_ID,ZX_ID ");
            strSql.Append(" FROM tb_Dealer_Bank_List ");
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
            strSql.Append("select count(1) FROM tb_Dealer_Bank_List T ");
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
                strSql.Append("order by T.ID DESC");
            }
            strSql.Append(")AS Row, T.*,D.[Address],D.SupervisorID,D.SupervisorName FROM tb_Dealer_Bank_List T Left Join tb_Dealer_List D ON T.DealerID = D.DealerID");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1} order by TT.DealerName,TT.CreateTime", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region  ExtensionMethod

        #region 获得经销商信息，数据来自“经销商银行合作表”表示该经销商已于银行合作--乔春羽(2013.8.9)
        public DataSet GetDealers(string where)
        {
            DataSet ds = null;
            StringBuilder sql = new StringBuilder("SELECT DealerID,DealerName FROM tb_Dealer_Bank_List WHERE IsDelete=0 AND CollaborateType=1");
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" AND {0}", where);
            }
            sql.Append("Group By DealerID,DealerName");
            try
            {
                ds = DbHelperSQL.Query(sql.ToString());
            }
            catch
            { }
            return ds;
        }
        #endregion

        #region 获得合作行的信息，数据来自“经销商银行合作表”表示该银行是有经销商与之合作的--乔春羽(2013.8.9)
        public DataSet GetBanks(string where)
        {
            DataSet ds = null;
            StringBuilder sql = new StringBuilder(@"SELECT BankID,BankName FROM tb_Dealer_Bank_List T INNER JOIN tb_Dealer_List D on T.DealerID=D.DealerID
                                                    WHERE T.IsDelete=0 AND CollaborateType=1 ");
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" AND {0} ", where);
            }
            sql.Append(" Group By BankID,BankName");
            try
            {
                ds = DbHelperSQL.Query(sql.ToString());
            }
            catch
            {
            }
            return ds;
        }
        #endregion

        #region 根据经销商名称获取该经销商的详细信息（包括经销商基本信息、合作行信息、合作品牌信息）--乔春羽
        /// <summary>
        /// 根据经销商名称获取该经销商的详细信息（包括经销商基本信息、合作行信息、合作品牌信息）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDetailList(string strWhere)
        {
            DataSet ds = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT T.ID,T.DealerID,T.DealerName,dl.IsGroup,dl.IsSingleStore,dl.DealerType,dl.[Address],T.BankID,T.BankName,T.BrandID,T.BrandName,T.BusinessMode,T.FinancingMode,T.CollaborateType,
                            T.SSMoney,T.YSMoney,T.PaymentCycle,dl.SupervisorDispatchTime,T.CreateID,T.CreateTime,T.IsDelete,T.StopTime");
            strSql.Append(" FROM tb_Dealer_Bank_List T LEFT JOIN tb_Dealer_List dl ON T.DealerID=dl.DealerID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            ds = DbHelperSQL.Query(strSql.ToString());
            return ds;
        }
        #endregion

        #region 根据银行ID获取经销商的ID--乔春羽
        /// <summary>
        /// 根据银行ID获取经销商的ID
        /// </summary>
        /// <param name="bankID"></param>
        /// <returns></returns>
        public DataTable GetDealerIDsByBankID(int bankID)
        {
            DataTable dt = null;
            try
            {
                string sql = "select DealerID from tb_Dealer_Bank_List where BankID=@BankID";
                SqlParameter sp = new SqlParameter("@BankID", SqlDbType.Int, 4);
                sp.Value = bankID;
                dt = DbHelperSQL.Query(sql, sp).Tables[0];
            }
            catch (Exception)
            {
            }
            return dt;
        }
        #endregion

        #region 根据登陆人的角色，来获得与该角色下监管的经销商合作的银行--乔春羽
        /// <summary>
        /// 根据登陆人的角色，来获得与该角色下监管的经销商合作的银行
        /// </summary>
        /// <param name="supervisorID"></param>
        /// <returns></returns>
        public DataSet GetBankIDAndNameFilterRole(int supervisorID)
        {
            DataSet ds = null;
            try
            {
                string sql = @"SELECT DISTINCT BankID,BankName FROM tb_Dealer_Bank_List WHERE DealerID in 
(SELECT DealerID FROM tb_Dealer_List WHERE SupervisorID=@SupervisorID) AND CollaborateType = 1";
                SqlParameter param = new SqlParameter("@SupervisorID", supervisorID);
                ds = DbHelperSQL.Query(sql, param);
            }
            catch (Exception) { }
            return ds;
        }
        #endregion

        #region 修改合作状态--乔春羽
        /// <summary>
        /// 修改合作状态
        /// </summary>
        /// <param name="dealerID"></param>
        /// <returns></returns>
        public int ModifyCollaborateType(Citic.Model.Dealer_Bank model)
        {
            int num = 0;
            StringBuilder sbuilder = new StringBuilder("UPDATE tb_Dealer_Bank_List SET");
            sbuilder.Append(" CollaborateType=@CollaborateType,StopTime=@StopTime where ID=@ID");
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CollaborateType",DbType.Int32),
                new SqlParameter("@StopTime",DbType.DateTime),
                new SqlParameter("@ID",DbType.Int32)
            };
            param[0].Value = model.CollaborateType;
            param[1].Value = model.StopTime;
            param[2].Value = model.ID;
            num = DbHelperSQL.ExecuteSql(sbuilder.ToString(), param);
            return num;
        }
        #endregion

        #region 查看合作银行是否以存在--乔春羽
        /// <summary>
        /// 查看合作银行是否以存在
        /// </summary>
        /// <param name="dealerID"></param>
        /// <param name="bankID"></param>
        /// <returns></returns>
        public bool ExistsDealerBank(int dealerID, int bankID)
        {
            bool flag = false;
            string sql = "select count(1) from tb_Dealer_Bank_List where DealerID=@DealerID and BankID=@BankID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@DealerID",SqlDbType.Int),
                new SqlParameter("@BankID",SqlDbType.Int)
            };
            param[0].Value = dealerID;
            param[1].Value = bankID;
            try
            {
                object obj = DbHelperSQL.GetSingle(sql, param);
                flag = Convert.ToInt32(obj) > 0 ? true : false;
            }
            catch
            {

            }
            return flag;
        }
        #endregion

        #region 查询与某银行合作的经销商们（只有ID与名称），权限过滤--乔春羽
        /// <summary>
        /// 查询与某银行合作的经销商们（只有ID与名称）
        /// 正在合作中的
        /// 没有被删除掉的
        /// 权限过滤
        /// </summary>
        /// <param name="bankID"></param>
        /// <returns></returns>
        public DataTable GetDealerByBankForDataTable(int bankID, string where)
        {
            DataTable dt = null;
            string sql = "SELECT distinct DealerID,DealerName FROM tb_Dealer_Bank_List WHERE BankID=@BankID AND CollaborateType=1 ";
            SqlParameter param = new SqlParameter("@BankID", SqlDbType.Int, 4);
            param.Value = bankID;
            if (!string.IsNullOrEmpty(where))
            {
                sql = sql + " AND " + where;
            }
            sql += " Order By DealerName ";
            try
            {
                dt = DbHelperSQL.Query(sql, param).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        #endregion

        #region 获取“一家店”的所有品牌信息--乔春羽(2013.8.19)
        /// <summary>
        /// 获取“一家店”的所有品牌信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetBrands(string strWhere)
        {
            DataSet ds = null;
            StringBuilder sql = new StringBuilder("select BrandID,BrandName from tb_Dealer_Bank_List where CollaborateType=1");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sql.Append(" and ");
                sql.Append(strWhere);
            }
            try
            {
                ds = DbHelperSQL.Query(sql.ToString());
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }
        #endregion

        #region 批量添加--乔春羽
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int AddRange(params Citic.Model.Dealer_Bank[] models)
        {
            int num = 0;
            System.Collections.Generic.List<CommandInfo> cmdList = null;
            if (models != null && models.Length > 0)
            {
                cmdList = new System.Collections.Generic.List<CommandInfo>();
                //避免重复
                System.Collections.Generic.List<Citic.Model.Dealer_Bank> isExists = new System.Collections.Generic.List<Citic.Model.Dealer_Bank>();
                foreach (Citic.Model.Dealer_Bank model in models)
                {
                    if (!isExists.Contains(model))
                    {
                        StringBuilder strSql = new StringBuilder();
                        StringBuilder strCar = new StringBuilder();
                        StringBuilder strQueryWH = new StringBuilder("Insert into tb_QueryWH(");
                        SqlParameter[] spDealer_Bank = null;
                        SqlParameter[] spCar = null;
                        SqlParameter[] spQ = null;
                        strSql.Append("Insert into tb_Dealer_Bank_List(");
                        strSql.Append("DealerID,DealerName,JC,BankID,BankName,BrandID,BrandName,BusinessMode,FinancingMode,CollaborateType,SSMoney,YSMoney,PaymentCycle,DispatchTime,CreateID,CreateTime,IsDelete,GD_ID,ZX_ID)");
                        //添加经销商与银行合作数据
                        strSql.AppendLine("values (@DealerID,@DealerName,@JC,@BankID,@BankName,@BrandID,@BrandName,@BusinessMode,@FinancingMode,@CollaborateType,@SSMoney,@YSMoney,@PaymentCycle,@DispatchTime,@CreateID,@CreateTime,0,@GD_ID,@ZX_ID )");
                        spDealer_Bank = new SqlParameter[]{
                            new SqlParameter("@DealerID",model.DealerID),
                            new SqlParameter("@DealerName",model.DealerName),
                            new SqlParameter("@JC",model.JC),
                            new SqlParameter("@BankID",model.BankID),
                            new SqlParameter("@BankName",model.BankName),
                            new SqlParameter("@BrandID",model.BrandID),
                            new SqlParameter("@BrandName",model.BrandName),
                            new SqlParameter("@BusinessMode",model.BusinessMode),
                            new SqlParameter("@FinancingMode",model.FinancingMode),
                            new SqlParameter("@CollaborateType",model.CollaborateType),
                            new SqlParameter("@SSMoney",model.SSMoney),
                            new SqlParameter("@YSMoney",model.YSMoney),
                            new SqlParameter("@PaymentCycle",model.PaymentCycle),
                            new SqlParameter("@DispatchTime",model.DispatchTime),
                            new SqlParameter("@CreateID",model.CreateID),
                            new SqlParameter("@CreateTime",model.CreateTime),
                            new SqlParameter("@GD_ID",model.GD_ID),
                            new SqlParameter("@ZX_ID",model.ZX_ID)
                        };

                        //添加“查库频率”数据
                        strQueryWH.Append("DB_ID,CheckFrequency,Description,Remark,CreateID,CreateTime,ApplyTime) ");
                        strQueryWH.AppendLine("Values (@DB_ID,@CheckFrequency,@Description,@Remark,@CreateID,@CreateTime,@ApplyTime) ;select @@IDENTITY");

                        spQ = new SqlParameter[] 
                        {
                            new SqlParameter("@DB_ID", string.Format("{0}_{1}", model.DealerID, model.BankID)) ,
                            new SqlParameter("@CheckFrequency",string.Empty),
                            new SqlParameter("@Description",string.Empty),
                            new SqlParameter("@Remark",string.Empty),
                            new SqlParameter("@CreateID",model.CreateID),
                            new SqlParameter("@CreateTime",model.CreateTime),
                            new SqlParameter("@ApplyTime",DateTime.Now)
                        };

                        //创建质押物表
                        strCar.AppendLine("exec proc_CreateCar @TableName");
                        spCar = new SqlParameter[] { new SqlParameter("@TableName", "tb_Car_" + model.BankID + "_" + model.DealerID) };
                        cmdList.AddRange(new CommandInfo[]{
                            new CommandInfo(strSql.ToString(),spDealer_Bank,EffentNextType.ExcuteEffectRows),
                            new CommandInfo(strCar.ToString(),spCar),
                            new CommandInfo(strQueryWH.ToString(),spQ)
                        });
                        isExists.Add(model);
                    }
                }
                try
                {
                    num = DbHelperSQL.ExecuteSqlTran(cmdList);
                }
                catch (Exception)
                {
                }
            }
            return num;
        }
        #endregion

        #region 排量修改--乔春羽(2014.3.14)
        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int UpdateRange(params Citic.Model.Dealer_Bank[] models)
        {
            int num = 0;
            System.Collections.Generic.List<CommandInfo> cmdList = null;
            if (models != null && models.Length > 0)
            {
                cmdList = new System.Collections.Generic.List<CommandInfo>();
                //避免重复
                System.Collections.Generic.List<Citic.Model.Dealer_Bank> isExists = new System.Collections.Generic.List<Citic.Model.Dealer_Bank>();
                foreach (Citic.Model.Dealer_Bank model in models)
                {
                    if (!isExists.Contains(model))
                    {
                        string select_Sql = string.Format("select count(1) from tb_Dealer_Bank_List where BankID={0} and DealerID={1} and BrandName='{2}'", model.BankID, model.DealerID, model.BrandName);
                        Object obj = DbHelperSQL.GetSingle(select_Sql);
                        if (obj != null && Convert.ToInt32(obj) > 0)
                        {

                            StringBuilder strSql = new StringBuilder("Update tb_Dealer_Bank_List Set ");
                            strSql.Append("DealerName=@DealerName,");
                            strSql.Append("BankName=@BankName,");
                            strSql.Append("BrandName=@BrandName,");
                            strSql.Append("BusinessMode=@BusinessMode,");
                            strSql.Append("FinancingMode=@FinancingMode,");
                            strSql.Append("CollaborateType=@CollaborateType,");
                            strSql.Append("SSMoney=@SSMoney,");
                            strSql.Append("YSMoney=@YSMoney,");
                            strSql.Append("PaymentCycle=@PaymentCycle,");
                            strSql.Append("DispatchTime=@DispatchTime,");
                            strSql.Append("CreateID=@CreateID,");
                            strSql.Append("CreateTime=@CreateTime,");
                            strSql.Append("IsDelete=@IsDelete,");
                            strSql.Append("StopTime=@StopTime,");
                            strSql.Append("GD_ID=@GD_ID,");
                            strSql.Append("ZX_ID=@ZX_ID");
                            strSql.Append(" where BankID=@BankID AND DealerID=@DealerID AND BrandID = @BrandID ");

                            SqlParameter[] parameters = {
					        new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					        new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					        new SqlParameter("@BrandName", SqlDbType.NVarChar,100),
					        new SqlParameter("@BusinessMode", SqlDbType.Int,4),
					        new SqlParameter("@FinancingMode", SqlDbType.NVarChar,50),
					        new SqlParameter("@CollaborateType", SqlDbType.Int,4),
					        new SqlParameter("@SSMoney", SqlDbType.Money,8),
					        new SqlParameter("@YSMoney", SqlDbType.Money,8),
					        new SqlParameter("@PaymentCycle", SqlDbType.Int,4),
					        new SqlParameter("@DispatchTime", SqlDbType.DateTime),
					        new SqlParameter("@CreateID", SqlDbType.Int,4),
					        new SqlParameter("@CreateTime", SqlDbType.DateTime),
					        new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					        new SqlParameter("@StopTime", SqlDbType.DateTime),
					        new SqlParameter("@GD_ID", SqlDbType.NVarChar,100),
					        new SqlParameter("@ZX_ID", SqlDbType.NVarChar,100),
					        new SqlParameter("@BankID", SqlDbType.Int,4),
					        new SqlParameter("@DealerID", SqlDbType.Int,4),
					        new SqlParameter("@BrandID", SqlDbType.Int,4)};
                            parameters[0].Value = model.DealerName;
                            parameters[1].Value = model.BankName;
                            parameters[2].Value = model.BrandName;
                            parameters[3].Value = model.BusinessMode;
                            parameters[4].Value = model.FinancingMode;
                            parameters[5].Value = model.CollaborateType;
                            parameters[6].Value = model.SSMoney;
                            parameters[7].Value = model.YSMoney;
                            parameters[8].Value = model.PaymentCycle;
                            parameters[9].Value = model.DispatchTime;
                            parameters[10].Value = model.CreateID;
                            parameters[11].Value = model.CreateTime;
                            parameters[12].Value = model.IsDelete;
                            parameters[13].Value = model.StopTime;
                            parameters[14].Value = model.GD_ID;
                            parameters[15].Value = model.ZX_ID;
                            parameters[16].Value = model.BankID;
                            parameters[17].Value = model.DealerID;
                            parameters[18].Value = model.BrandID;

                            cmdList.Add(new CommandInfo(strSql.ToString(), parameters));
                        }
                        else
                        {
                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("insert into tb_Dealer_Bank_List(");
                            strSql.Append("DealerID,DealerName,JC,BC,BankID,BankName,BrandID,BrandName,BusinessMode,FinancingMode,CollaborateType,SSMoney,YSMoney,PaymentCycle,DispatchTime,CreateID,CreateTime,IsDelete,StopTime,GD_ID,ZX_ID)");
                            strSql.Append(" values (");
                            strSql.Append("@DealerID,@DealerName,@JC,@BC,@BankID,@BankName,@BrandID,@BrandName,@BusinessMode,@FinancingMode,@CollaborateType,@SSMoney,@YSMoney,@PaymentCycle,@DispatchTime,@CreateID,@CreateTime,@IsDelete,@StopTime,@GD_ID,@ZX_ID)");
                            strSql.Append(";select @@IDENTITY");
                            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@JC", SqlDbType.NVarChar,20),
					new SqlParameter("@BC", SqlDbType.Int,4),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,100),
					new SqlParameter("@BusinessMode", SqlDbType.Int,4),
					new SqlParameter("@FinancingMode", SqlDbType.NVarChar,50),
					new SqlParameter("@CollaborateType", SqlDbType.Int,4),
					new SqlParameter("@SSMoney", SqlDbType.Money,8),
					new SqlParameter("@YSMoney", SqlDbType.Money,8),
					new SqlParameter("@PaymentCycle", SqlDbType.Int,4),
					new SqlParameter("@DispatchTime", SqlDbType.DateTime),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@StopTime", SqlDbType.DateTime),
					new SqlParameter("@GD_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@ZX_ID", SqlDbType.NVarChar,100)};
                            parameters[0].Value = model.DealerID;
                            parameters[1].Value = model.DealerName;
                            parameters[2].Value = model.JC;
                            parameters[3].Value = model.BC;
                            parameters[4].Value = model.BankID;
                            parameters[5].Value = model.BankName;
                            parameters[6].Value = model.BrandID;
                            parameters[7].Value = model.BrandName;
                            parameters[8].Value = model.BusinessMode;
                            parameters[9].Value = model.FinancingMode;
                            parameters[10].Value = model.CollaborateType;
                            parameters[11].Value = model.SSMoney;
                            parameters[12].Value = model.YSMoney;
                            parameters[13].Value = model.PaymentCycle;
                            parameters[14].Value = model.DispatchTime;
                            parameters[15].Value = model.CreateID;
                            parameters[16].Value = model.CreateTime;
                            parameters[17].Value = model.IsDelete;
                            parameters[18].Value = model.StopTime;
                            parameters[19].Value = model.GD_ID;
                            parameters[20].Value = model.ZX_ID;

                            cmdList.Add(new CommandInfo(strSql.ToString(), parameters));
                        }
                    }
                }

                try
                {
                    num = DbHelperSQL.ExecuteSqlTran(cmdList);
                }
                catch (Exception)
                {
                }

            }
            return num;
        }
        #endregion

        #region 总账查询--乔春羽
        /// <summary>
        /// 总账查询
        /// </summary>
        /// <param name="path">SQL文件存放的路径</param>
        /// <param name="sqlstr">指定要使用哪一条SQL语句</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">一页的开始Index</param>
        /// <param name="endIndex">一页的结束Index</param>
        /// <param name="tableNames">表名集合</param>
        /// <returns>返回查询结果</returns>
        public DataSet LedgerSearch(string path, string sqlstr, string strWhere, string orderby, int startIndex, int endIndex, params string[] tableNames)
        {
            DataSet ds = null;
            string sql = GetSQL(path, sqlstr);
            if (sql != null && sql != string.Empty)
            {
                StringBuilder sbuilder = new StringBuilder();
                foreach (string tbName in tableNames)
                {
                    string temp = string.Empty;
                    if (!string.IsNullOrEmpty(orderby.Trim()))
                    {
                        temp = sql.Replace("{OrderBy}", orderby);
                    }
                    else
                    {
                        temp = sql.Replace("{OrderBy}", "ID");
                    }
                    temp = sql.Replace("{Where}", "where " + strWhere);
                    temp = temp.Replace("{Start}", startIndex.ToString());
                    temp = temp.Replace("{End}", endIndex.ToString());
                    temp = temp.Replace("{TableName}", tbName);
                    sbuilder.AppendLine(temp);
                    sbuilder.AppendLine("union");
                }
                sql = sbuilder.ToString().Substring(0, sbuilder.ToString().LastIndexOf("union") - 1);
            }
            try
            {
                ds = DbHelperSQL.Query(sql);
            }
            catch (Exception)
            {
            }
            return ds;
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

        #region 查询经销商ID，根据各种条件--乔春羽(2013.12.2)
        public DataTable GetDealerIDBySearch(string where)
        {
            DataTable dt = null;
            string sql = "SELECT DealerID FROM tb_Dealer_Bank_List(NOLOCK) T ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = sql + " WHERE " + where;
            }
            sql += " Group By DealerID";
            try
            {
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion

        #region 查询银行ID，根据各种条件--乔春羽(2014.3.25)
        public DataTable GetBankIDsBySearch(string where)
        {
            DataTable dt = null;
            string sql = "SELECT BankID FROM tb_Dealer_Bank_List(NOLOCK) ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = sql + " WHERE " + where;
            }
            sql += " Group By BankID";
            try
            {
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion

        #region 返回“合作行_品牌”格式的数据，根据经销商查询该数据--乔春羽(2013.12.6)
        /// <summary>
        /// 返回“合作行_品牌”格式的数据，根据经销商查询该数据
        /// </summary>
        /// <param name="where">Where条件</param>
        /// <returns></returns>
        public DataSet GetBankBrandBySearch(string where)
        {
            DataSet ds = null;
            try
            {
                StringBuilder sql = new StringBuilder("SELECT ID,CAST(BankID AS NVARCHAR)+'_'+CAST(BrandID AS NVARCHAR) BankID,BankName+'_'+BrandName BankName FROM tb_Dealer_Bank_List(NOLOCK) ");
                if (!string.IsNullOrEmpty(where))
                {
                    sql.Append("WHERE " + where);
                }
                ds = DbHelperSQL.Query(sql.ToString());
            }
            catch (SqlException se)
            {
                throw se;
            }
            return ds;
        }
        #endregion

        #region 查询“经销商银行映射表”与“查库频率表”的内联查询数据，SQL语句放在XML文件中--乔春羽(2013.12.6)
        /// <summary>
        /// 查询“经销商银行映射表”与“查库频率表”的内联查询数据
        /// </summary>
        /// <param name="path">SQL文件路径</param>
        /// <param name="sqlstr">SQL命令</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns></returns>
        public DataSet GetDBInnerFrequencyBySearch(string path, string sqlstr, string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = null;
            string sql = GetSQL(path, sqlstr);
            if (!string.IsNullOrEmpty(sql))
            {
                try
                {
                    sql = sql.Replace("{Where}", " Where " + strWhere);
                    sql = sql.Replace("{OrderBy}", orderby);
                    sql = sql.Replace("{Start}", startIndex.ToString());
                    sql = sql.Replace("{End}", endIndex.ToString());

                    ds = DbHelperSQL.Query(sql);
                }
                catch (SqlException se)
                {
                    throw se;
                }
            }
            return ds;
        }
        #endregion

        #region 获得前几条数据，非固定列--乔春羽(2013.12.6)
        /// <summary>
        /// 获得前几条数据，非固定列
        /// </summary>
        /// <param name="Top">数据数量</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="groupBy">排序条件</param>
        /// <param name="columns">列名集合</param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string groupBy, params string[] columns)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            if (columns != null && columns.Length > 0)
            {
                foreach (string col in columns)
                {
                    strSql.AppendFormat("{0},", col);
                }
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append(" FROM tb_Dealer_Bank_List(NOLOCK) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(groupBy))
            {
                strSql.Append(" Group By " + groupBy);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 执行一条SQL语句--乔春羽(2013.12.11)
        public DataTable Query(string sql)
        {
            DataTable dt = null;
            try
            {
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion

        #region 根据需求不同，根据不同的条件，查询数据数量（tb_Dealer_Bank_List表与tb_Dealer_List表的联查）--乔春羽(2014.5.14)
        public int GetRecordCountBySearch(string strWhere)
        {
            int count = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM tb_Dealer_Bank_List A INNER JOIN tb_Dealer_List B ON A.DealerID = B.DealerID  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                count = 0;
            }
            else
            {
                count = Convert.ToInt32(obj);
            }
            return count;
        }
        #endregion

        #region 需要导出Excel的数据（根据需要不同，可能导出一页或者全部的数据），将表头改成了文字，并且联查经销商信息表--乔春羽(2013.12.20)
        public DataTable GetDataForExcel(string where, int startIndex, int endIndex)
        {
            DataTable dt = null;
            StringBuilder sql = new StringBuilder(@"SELECT * FROM (SELECT ROW_NUMBER() OVER(order by DB.ID) Row, DB.DealerName 经销商,DB.BankName 合作行,DB.BrandName 合作品牌,
CASE DB.BusinessMode WHEN 1 THEN '车证模式' WHEN 2 THEN '合格证模式' WHEN 3 THEN '巡库模式' END 业务模式,
dbo.changeFinancingMode(DB.FinancingMode,'fm') 融资模式,
CASE DB.CollaborateType WHEN 0 THEN '停止合作' WHEN 1 THEN '正在合作' END 合作状态,
DB.YSMoney 应收费用,DB.SSMoney 实收费用,
CASE DB.PaymentCycle WHEN 1 THEN '月' WHEN 2 THEN '季' WHEN 3 THEN '半年' WHEN 4 THEN '年' END 缴费周期,
dbo.changeFinancingMode(T.DealerType,'dealertype') 经销商类型,
CASE T.IsGroup WHEN 1 THEN '是' WHEN 0 THEN '否' END 是否是集团性质,
T.HasOtherIndustries 其他产业,T.DealerPayCode 组织机构代码,
T.SupervisorName 监管员,T.SupervisorDispatchTime 监管员驻店时间,
T.GotoworkTime 上班时间,T.GoffworkTime 下班时间,T.Address 地址
FROM tb_Dealer_List T
LEFT JOIN tb_Dealer_Bank_List DB ON T.DealerID=DB.DealerID");
            if (!string.IsNullOrEmpty(where))
            {
                sql.AppendFormat(" WHERE {0} ", where);
            }
            sql.Append(") TT");
            if (startIndex > 0 && endIndex > 0)
            {
                sql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);
            }
            try
            {
                dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            return dt;
        }
        #endregion

        #region 根据经销商id和银行id查询二网信息
        /// <summary>
        /// 根据经销商id和银行id查询二网信息 张繁 2013年11月22日
        /// </summary>
        /// <param name="BankID"></param>
        /// <param name="DealerID"></param>
        /// <returns></returns>
        public DataSet GetStorageListByDealerIDAndBankID(int BankID, int DealerID)
        {
            string sql = " select StorageID,StorageName,Address from tb_Dealer_Bank_List dbl left join tb_Storage_List sl on dbl.DealerID=sl.DealerID where dbl.DealerID='" + DealerID + "' and dbl.BankID='" + BankID + "' and sl.IsDelete=0";
            return DbHelperSQL.Query(sql);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

