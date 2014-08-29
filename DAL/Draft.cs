using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Draft
    /// </summary>
    public partial class Draft
    {
        public Draft()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Draft_List");
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
        public int Add(Citic.Model.Draft model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Draft_List(");
            strSql.Append("DraftNo,BankID,BankName,DealerID,DealerName,BrandID,BrandName,DarftMoney,BeginTime,EndTime,PledgeNo,GuaranteeNo,Ratio,RGuaranteeNo,Remarks,DraftType,CarAllCount,CarAllMoney,CarILCount,CarILMoney,CarITCount,CarITMoney,WYMoney,YYMoney,HKMoney,CKMoney,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID,GD_ID,ZX_ID)");
            strSql.Append(" values (");
            strSql.Append("@DraftNo,@BankID,@BankName,@DealerID,@DealerName,@BrandID,@BrandName,@DarftMoney,@BeginTime,@EndTime,@PledgeNo,@GuaranteeNo,@Ratio,@RGuaranteeNo,@Remarks,@DraftType,@CarAllCount,@CarAllMoney,@CarILCount,@CarILMoney,@CarITCount,@CarITMoney,@WYMoney,@YYMoney,@HKMoney,@CKMoney,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID,@GD_ID,@ZX_ID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@DarftMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PledgeNo", SqlDbType.NVarChar,50),
					new SqlParameter("@GuaranteeNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Ratio", SqlDbType.Float,8),
					new SqlParameter("@RGuaranteeNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@DraftType", SqlDbType.Bit,1),
					new SqlParameter("@CarAllCount", SqlDbType.Int,4),
					new SqlParameter("@CarAllMoney", SqlDbType.Money,8),
					new SqlParameter("@CarILCount", SqlDbType.Int,4),
					new SqlParameter("@CarILMoney", SqlDbType.Money,8),
					new SqlParameter("@CarITCount", SqlDbType.Int,4),
					new SqlParameter("@CarITMoney", SqlDbType.Money,8),
					new SqlParameter("@WYMoney", SqlDbType.Money,8),
					new SqlParameter("@YYMoney", SqlDbType.Money,8),
					new SqlParameter("@HKMoney", SqlDbType.Money,8),
					new SqlParameter("@CKMoney", SqlDbType.Money,8),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@GD_ID", SqlDbType.VarChar,100),
					new SqlParameter("@ZX_ID", SqlDbType.VarChar,100)};
            parameters[0].Value = model.DraftNo;
            parameters[1].Value = model.BankID;
            parameters[2].Value = model.BankName;
            parameters[3].Value = model.DealerID;
            parameters[4].Value = model.DealerName;
            parameters[5].Value = model.BrandID;
            parameters[6].Value = model.BrandName;
            parameters[7].Value = model.DarftMoney;
            parameters[8].Value = model.BeginTime;
            parameters[9].Value = model.EndTime;
            parameters[10].Value = model.PledgeNo;
            parameters[11].Value = model.GuaranteeNo;
            parameters[12].Value = model.Ratio;
            parameters[13].Value = model.RGuaranteeNo;
            parameters[14].Value = model.Remarks;
            parameters[15].Value = model.DraftType;
            parameters[16].Value = model.CarAllCount;
            parameters[17].Value = model.CarAllMoney;
            parameters[18].Value = model.CarILCount;
            parameters[19].Value = model.CarILMoney;
            parameters[20].Value = model.CarITCount;
            parameters[21].Value = model.CarITMoney;
            parameters[22].Value = model.WYMoney;
            parameters[23].Value = model.YYMoney;
            parameters[24].Value = model.HKMoney;
            parameters[25].Value = model.CKMoney;
            parameters[26].Value = model.CreateID;
            parameters[27].Value = model.CreateTime;
            parameters[28].Value = model.UpdateID;
            parameters[29].Value = model.UpdateTime;
            parameters[30].Value = model.DeleteID;
            parameters[31].Value = model.DeleteTime;
            parameters[32].Value = model.IsDelete;
            parameters[33].Value = model.IsPort;
            parameters[34].Value = model.ConnectID;
            parameters[35].Value = model.GD_ID;
            parameters[36].Value = model.ZX_ID;

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
        public bool Update(Citic.Model.Draft model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Draft_List set ");
            strSql.Append("DraftNo=@DraftNo,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("DarftMoney=@DarftMoney,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("PledgeNo=@PledgeNo,");
            strSql.Append("GuaranteeNo=@GuaranteeNo,");
            strSql.Append("Ratio=@Ratio,");
            strSql.Append("RGuaranteeNo=@RGuaranteeNo,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("DraftType=@DraftType,");
            strSql.Append("CarAllCount=@CarAllCount,");
            strSql.Append("CarAllMoney=@CarAllMoney,");
            strSql.Append("CarILCount=@CarILCount,");
            strSql.Append("CarILMoney=@CarILMoney,");
            strSql.Append("CarITCount=@CarITCount,");
            strSql.Append("CarITMoney=@CarITMoney,");
            strSql.Append("WYMoney=@WYMoney,");
            strSql.Append("YYMoney=@YYMoney,");
            strSql.Append("HKMoney=@HKMoney,");
            strSql.Append("CKMoney=@CKMoney,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID,");
            strSql.Append("GD_ID=@GD_ID,");
            strSql.Append("ZX_ID=@ZX_ID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,200),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@DarftMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PledgeNo", SqlDbType.NVarChar,50),
					new SqlParameter("@GuaranteeNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Ratio", SqlDbType.Float,8),
					new SqlParameter("@RGuaranteeNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@DraftType", SqlDbType.Bit,1),
					new SqlParameter("@CarAllCount", SqlDbType.Int,4),
					new SqlParameter("@CarAllMoney", SqlDbType.Money,8),
					new SqlParameter("@CarILCount", SqlDbType.Int,4),
					new SqlParameter("@CarILMoney", SqlDbType.Money,8),
					new SqlParameter("@CarITCount", SqlDbType.Int,4),
					new SqlParameter("@CarITMoney", SqlDbType.Money,8),
					new SqlParameter("@WYMoney", SqlDbType.Money,8),
					new SqlParameter("@YYMoney", SqlDbType.Money,8),
					new SqlParameter("@HKMoney", SqlDbType.Money,8),
					new SqlParameter("@CKMoney", SqlDbType.Money,8),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@GD_ID", SqlDbType.VarChar,100),
					new SqlParameter("@ZX_ID", SqlDbType.VarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DraftNo;
            parameters[1].Value = model.BankID;
            parameters[2].Value = model.BankName;
            parameters[3].Value = model.DealerID;
            parameters[4].Value = model.DealerName;
            parameters[5].Value = model.BrandID;
            parameters[6].Value = model.BrandName;
            parameters[7].Value = model.DarftMoney;
            parameters[8].Value = model.BeginTime;
            parameters[9].Value = model.EndTime;
            parameters[10].Value = model.PledgeNo;
            parameters[11].Value = model.GuaranteeNo;
            parameters[12].Value = model.Ratio;
            parameters[13].Value = model.RGuaranteeNo;
            parameters[14].Value = model.Remarks;
            parameters[15].Value = model.DraftType;
            parameters[16].Value = model.CarAllCount;
            parameters[17].Value = model.CarAllMoney;
            parameters[18].Value = model.CarILCount;
            parameters[19].Value = model.CarILMoney;
            parameters[20].Value = model.CarITCount;
            parameters[21].Value = model.CarITMoney;
            parameters[22].Value = model.WYMoney;
            parameters[23].Value = model.YYMoney;
            parameters[24].Value = model.HKMoney;
            parameters[25].Value = model.CKMoney;
            parameters[26].Value = model.CreateID;
            parameters[27].Value = model.CreateTime;
            parameters[28].Value = model.UpdateID;
            parameters[29].Value = model.UpdateTime;
            parameters[30].Value = model.DeleteID;
            parameters[31].Value = model.DeleteTime;
            parameters[32].Value = model.IsDelete;
            parameters[33].Value = model.IsPort;
            parameters[34].Value = model.ConnectID;
            parameters[35].Value = model.GD_ID;
            parameters[36].Value = model.ZX_ID;
            parameters[37].Value = model.ID;

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
            strSql.Append("delete from tb_Draft_List ");
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
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Draft GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DraftNo,BankID,BankName,DealerID,DealerName,BrandID,BrandName,DarftMoney,BeginTime,EndTime,PledgeNo,GuaranteeNo,Ratio,RGuaranteeNo,Remarks,DraftType,CarAllCount,CarAllMoney,CarILCount,CarILMoney,CarITCount,CarITMoney,WYMoney,YYMoney,HKMoney,CKMoney,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID,GD_ID,ZX_ID from tb_Draft_List ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.Draft model = new Citic.Model.Draft();
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
        public Citic.Model.Draft DataRowToModel(DataRow row)
        {
            Citic.Model.Draft model = new Citic.Model.Draft();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DraftNo"] != null)
                {
                    model.DraftNo = row["DraftNo"].ToString();
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
                if (row["BrandID"] != null && row["BrandID"].ToString() != "")
                {
                    model.BrandID = int.Parse(row["BrandID"].ToString());
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
                }
                if (row["DarftMoney"] != null)
                {
                    model.DarftMoney = row["DarftMoney"].ToString();
                }
                if (row["BeginTime"] != null && row["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(row["BeginTime"].ToString());
                }
                if (row["EndTime"] != null && row["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["PledgeNo"] != null)
                {
                    model.PledgeNo = row["PledgeNo"].ToString();
                }
                if (row["GuaranteeNo"] != null)
                {
                    model.GuaranteeNo = row["GuaranteeNo"].ToString();
                }
                if (row["Ratio"] != null && row["Ratio"].ToString() != "")
                {
                    model.Ratio = decimal.Parse(row["Ratio"].ToString());
                }
                if (row["RGuaranteeNo"] != null)
                {
                    model.RGuaranteeNo = row["RGuaranteeNo"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["DraftType"] != null && row["DraftType"].ToString() != "")
                {
                    if ((row["DraftType"].ToString() == "1") || (row["DraftType"].ToString().ToLower() == "true"))
                    {
                        model.DraftType = true;
                    }
                    else
                    {
                        model.DraftType = false;
                    }
                }
                if (row["CarAllCount"] != null && row["CarAllCount"].ToString() != "")
                {
                    model.CarAllCount = int.Parse(row["CarAllCount"].ToString());
                }
                if (row["CarAllMoney"] != null && row["CarAllMoney"].ToString() != "")
                {
                    model.CarAllMoney = decimal.Parse(row["CarAllMoney"].ToString());
                }
                if (row["CarILCount"] != null && row["CarILCount"].ToString() != "")
                {
                    model.CarILCount = int.Parse(row["CarILCount"].ToString());
                }
                if (row["CarILMoney"] != null && row["CarILMoney"].ToString() != "")
                {
                    model.CarILMoney = decimal.Parse(row["CarILMoney"].ToString());
                }
                if (row["CarITCount"] != null && row["CarITCount"].ToString() != "")
                {
                    model.CarITCount = int.Parse(row["CarITCount"].ToString());
                }
                if (row["CarITMoney"] != null && row["CarITMoney"].ToString() != "")
                {
                    model.CarITMoney = decimal.Parse(row["CarITMoney"].ToString());
                }
                if (row["WYMoney"] != null && row["WYMoney"].ToString() != "")
                {
                    model.WYMoney = decimal.Parse(row["WYMoney"].ToString());
                }
                if (row["YYMoney"] != null && row["YYMoney"].ToString() != "")
                {
                    model.YYMoney = decimal.Parse(row["YYMoney"].ToString());
                }
                if (row["HKMoney"] != null && row["HKMoney"].ToString() != "")
                {
                    model.HKMoney = decimal.Parse(row["HKMoney"].ToString());
                }
                if (row["CKMoney"] != null && row["CKMoney"].ToString() != "")
                {
                    model.CKMoney = decimal.Parse(row["CKMoney"].ToString());
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
            strSql.Append("select ID,DraftNo,BankID,BankName,DealerID,DealerName,BrandID,BrandName,DarftMoney,BeginTime,EndTime,PledgeNo,GuaranteeNo,Ratio,RGuaranteeNo,Remarks,DraftType,CarAllCount,CarAllMoney,CarILCount,CarILMoney,CarITCount,CarITMoney,WYMoney,YYMoney,HKMoney,CKMoney,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID,GD_ID,ZX_ID ");
            strSql.Append(" FROM tb_Draft_List ");
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
            strSql.Append(" ID,DraftNo,BankID,BankName,DealerID,DealerName,BrandID,BrandName,DarftMoney,BeginTime,EndTime,PledgeNo,GuaranteeNo,Ratio,RGuaranteeNo,Remarks,DraftType,CarAllCount,CarAllMoney,CarILCount,CarILMoney,CarITCount,CarITMoney,WYMoney,YYMoney,HKMoney,CKMoney,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID,GD_ID,ZX_ID ");
            strSql.Append(" FROM tb_Draft_List ");
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
            strSql.Append("select count(1) FROM tb_Draft_List ");
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
            strSql.Append(")AS Row, T.*, CASE T.DraftType WHEN 0 THEN '已清票' WHEN 1 THEN '未清票' END DraftTypeName from tb_Draft_List T ");
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
        #region 批量添加--乔春羽(2013.9.5)
        /// <summary>
        /// 批量添加--乔春羽
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int AddRange(Citic.Model.Draft[] models)
        {
            int count = 0;
            try
            {
                StringBuilder sbuilder = new StringBuilder(@"insert into tb_Draft_List
                (DraftNo,BankID,BankName,DealerID,DealerName,DarftMoney,BeginTime,EndTime,PledgeNo,GuaranteeNo,
                Ratio,RGuaranteeNo,Remarks,DraftType,CarAllCount,CarAllMoney,CarILCount,CarILMoney,CarITCount,
                CarITMoney,WYMoney,YYMoney,HKMoney,CKMoney,CreateID,CreateTime,UpdateID,UpdateTime,
                DeleteID,DeleteTime,IsDelete,IsPort,ConnectID,BrandID,BrandName)");

                foreach (Citic.Model.Draft model in models)
                {
                    sbuilder.AppendLine(string.Format(@"select '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}',0,getdate(),0,getdate(),0,0,'','{26}','{27}' union"
                    , model.DraftNo, model.BankID, model.BankName, model.DealerID, model.DealerName, model.DarftMoney, model.BeginTime, model.EndTime
                    , model.PledgeNo, model.GuaranteeNo, model.Ratio, model.RGuaranteeNo, model.Remarks, model.DraftType, model.CarAllCount
                    , model.CarAllMoney, model.CarILCount, model.CarILMoney, model.CarITCount, model.CarITMoney, model.WYMoney
                    , model.YYMoney, model.HKMoney, model.CKMoney, model.CreateID, model.CreateTime
                    , model.BrandID, model.BrandName));
                }
                string sql = sbuilder.ToString().Substring(0, sbuilder.ToString().LastIndexOf("union"));

                count = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception)
            {
                throw;
            }
            return count;
        }
        #endregion

        #region 逻辑删除--乔春羽(2013.9.5)
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Draft model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tb_Draft_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where DraftNo=@DraftNo");
            SqlParameter[] parameters = {
					new SqlParameter("@DraftNo", SqlDbType.Int,4),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.DraftNo;
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

        /// <summary>
        /// 批量逻辑删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string IDList, Citic.Model.Draft model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Draft_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where DraftNo in (" + IDList + ")  ");
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

        #region 物理删除，删除汇票的同时也删除该票下的质押物信息--乔春羽(2014.4.2)
        /// <summary>
        /// 物理删除，删除汇票的同时也删除该票下的质押物信息
        /// </summary>
        public bool DeleteList(Citic.Model.Draft[] models)
        {
            StringBuilder strSql = null;
            List<CommandInfo> cInfos = null;
            if (models != null && models.Length > 0)
            {
                cInfos = new List<CommandInfo>();
                foreach (Citic.Model.Draft model in models)
                {
                    strSql = new StringBuilder();
                    strSql.AppendLine("Delete tb_Draft_List where ID=@ID");
                    SqlParameter[] sp = null;
                    if (model.BankID != 0 && model.DealerID != 0)
                    {
                        strSql.AppendLine(string.Format("Delete {0} where DraftNo=@DraftNo", string.Format("tb_Car_{0}_{1}", model.BankID, model.DealerID)));
                        sp = new SqlParameter[] { new SqlParameter("@ID", model.ID), new SqlParameter("@DraftNo", model.DraftNo) };
                    }
                    else
                    {
                        sp = new SqlParameter[] { new SqlParameter("@ID", model.ID) };
                    }
                    cInfos.Add(new CommandInfo(strSql.ToString(), sp));
                }
            }
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

        #endregion

        #region 得到一个对象实体，通过汇票号--乔春羽(2013.9.5)
        /// <summary>
        /// 得到一个对象实体，通过汇票号
        /// </summary>
        public Citic.Model.Draft GetModel(string draftNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 ID,DraftNo,BankID,BankName,DealerID,DealerName,BrandID,BrandName,DarftMoney,BeginTime,EndTime,PledgeNo,GuaranteeNo,Ratio,RGuaranteeNo,Remarks,DraftType,CarAllCount,CarAllMoney,CarILCount,CarILMoney,CarITCount,CarITMoney,WYMoney,YYMoney,HKMoney,CKMoney,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID,GD_ID,ZX_ID FROM tb_Draft_List ");
            strSql.Append(" WHERE DraftNo=@DraftNo");
            SqlParameter[] parameters = {
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = draftNo;

            Citic.Model.Draft model = new Citic.Model.Draft();
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
        #endregion

        #region 给汇票“清票”--乔春羽(2013.9.5)
        /// <summary>
        /// 给汇票“清票”
        /// </summary>
        /// <param name="draftNo"></param>
        /// <returns></returns>
        public bool DraftClear(string[] draftNo, int userID)
        {
            bool flag = false;
            if (draftNo != null && draftNo.Length > 0)
            {
                StringBuilder draftNos = new StringBuilder();
                foreach (string no in draftNo)
                {
                    draftNos.AppendFormat("'{0}',", no);
                }
                draftNos.Remove(draftNos.ToString().LastIndexOf(","), 1);
                string sql = string.Format("Update tb_Draft_List set DraftType=0,UpdateID=" + userID + ",UpdateTime=GETDATE() where DraftNo in ({0})", draftNos.ToString());
                try
                {
                    flag = DbHelperSQL.ExecuteSql(sql) > 0;
                }
                catch (Exception)
                {
                }
            }
            return flag;
        }
        #endregion

        #region 获得汇票的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess(string where, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM (SELECT ROW_NUMBER() OVER(order by ID) Row,ID,DraftNo,BankID,BankName,DealerID,DealerName,DarftMoney,
CONVERT(NVARCHAR(12),BeginTime,111) BeginTime,CONVERT(NVARCHAR(12),EndTime,111) EndTime,PledgeNo,GuaranteeNo,
CAST(Ratio*100 as nvarchar(100))+'%' Ratio,RGuaranteeNo,Remarks,
CASE DraftType WHEN 1 THEN '未清票' WHEN 0 THEN '已清票' END DraftType,CarAllCount,CarAllMoney,CarILCount,CarILMoney,CarITCount,CarITMoney,WYMoney,YYMoney,HKMoney,CKMoney,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID 
FROM tb_Draft_List ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.AppendFormat(" WHERE {0}", where);
            }
            strSql.Append(" ) T ");
            if (startIndex != 0 && endIndex != 0)
            {
                strSql.AppendFormat(" WHERE T.Row BETWEEN {0} AND {1} ", startIndex, endIndex);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region 修改汇票的回款金额、敞口金额、已押金额、未押金额--乔春羽(2014.6.9)
        public int UpdateDraftMoney(string[] draftNos)
        {
            int num = 1;
            StringBuilder proc_Name = new StringBuilder();
            if (draftNos != null && draftNos.Length > 0)
            {
                foreach (string draftNo in draftNos)
                {
                    proc_Name.AppendLine(string.Format("exec UpdateDraftMoney '{0}' ;", draftNo));
                }
            }
            try
            {
                DbHelperSQL.ExecuteSql(proc_Name.ToString());
            }
            catch
            {
                num = -1;
            }
            return num;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

