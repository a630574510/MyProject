using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:SearchWHFreqAppForm
    /// </summary>
    public partial class SearchWHFreqAppForm
    {
        public SearchWHFreqAppForm()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_SearchWHFreqAppForm");
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
        public int Add(Citic.Model.SearchWHFreqAppForm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_SearchWHFreqAppForm(");
            strSql.Append("ORCDStatus,OBDStatus,DealerID,DealerName,Banks,Brands,RegulatoryMode,SearchFrequency,SID,SName,ApplyTime,LinkPhone,ApplyResult,ORCD,ORCDPIC,OBD,OBDPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime)");
            strSql.Append(" values (");
            strSql.Append("@ORCDStatus,@OBDStatus,@DealerID,@DealerName,@Banks,@Brands,@RegulatoryMode,@SearchFrequency,@SID,@SName,@ApplyTime,@LinkPhone,@ApplyResult,@ORCD,@ORCDPIC,@OBD,@OBDPIC,@CreateID,@CreateTime,@DeleteID,@DeleteTime,@IsDelete,@ORCD_OptionID,@ORCD_OptionTime,@ORCDPIC_OptionID,@ORCDPIC_OptionTime,@OBD_OptionID,@OBD_OptionTime,@OBDPIC_OptionID,@OBDPIC_OptionTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ORCDStatus", SqlDbType.Int,4),
					new SqlParameter("@OBDStatus", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@Banks", SqlDbType.NVarChar,200),
					new SqlParameter("@Brands", SqlDbType.NVarChar,100),
					new SqlParameter("@RegulatoryMode", SqlDbType.NVarChar,100),
					new SqlParameter("@SearchFrequency", SqlDbType.NVarChar,100),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,100),
					new SqlParameter("@ApplyResult", SqlDbType.NVarChar,1000),
					new SqlParameter("@ORCD", SqlDbType.NVarChar,300),
					new SqlParameter("@ORCDPIC", SqlDbType.Bit,1),
					new SqlParameter("@OBD", SqlDbType.NVarChar,300),
					new SqlParameter("@OBDPIC", SqlDbType.Bit,1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@ORCD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ORCDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBDPIC_OptionTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ORCDStatus;
            parameters[1].Value = model.OBDStatus;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.Banks;
            parameters[5].Value = model.Brands;
            parameters[6].Value = model.RegulatoryMode;
            parameters[7].Value = model.SearchFrequency;
            parameters[8].Value = model.SID;
            parameters[9].Value = model.SName;
            parameters[10].Value = model.ApplyTime;
            parameters[11].Value = model.LinkPhone;
            parameters[12].Value = model.ApplyResult;
            parameters[13].Value = model.ORCD;
            parameters[14].Value = model.ORCDPIC;
            parameters[15].Value = model.OBD;
            parameters[16].Value = model.OBDPIC;
            parameters[17].Value = model.CreateID;
            parameters[18].Value = model.CreateTime;
            parameters[19].Value = model.DeleteID;
            parameters[20].Value = model.DeleteTime;
            parameters[21].Value = model.IsDelete;
            parameters[22].Value = model.ORCD_OptionID;
            parameters[23].Value = model.ORCD_OptionTime;
            parameters[24].Value = model.ORCDPIC_OptionID;
            parameters[25].Value = model.ORCDPIC_OptionTime;
            parameters[26].Value = model.OBD_OptionID;
            parameters[27].Value = model.OBD_OptionTime;
            parameters[28].Value = model.OBDPIC_OptionID;
            parameters[29].Value = model.OBDPIC_OptionTime;

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
        public bool Update(Citic.Model.SearchWHFreqAppForm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_SearchWHFreqAppForm set ");
            strSql.Append("ORCDStatus=@ORCDStatus,");
            strSql.Append("OBDStatus=@OBDStatus,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("Banks=@Banks,");
            strSql.Append("Brands=@Brands,");
            strSql.Append("RegulatoryMode=@RegulatoryMode,");
            strSql.Append("SearchFrequency=@SearchFrequency,");
            strSql.Append("SID=@SID,");
            strSql.Append("SName=@SName,");
            strSql.Append("ApplyTime=@ApplyTime,");
            strSql.Append("LinkPhone=@LinkPhone,");
            strSql.Append("ApplyResult=@ApplyResult,");
            strSql.Append("ORCD=@ORCD,");
            strSql.Append("ORCDPIC=@ORCDPIC,");
            strSql.Append("OBD=@OBD,");
            strSql.Append("OBDPIC=@OBDPIC,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("ORCD_OptionID=@ORCD_OptionID,");
            strSql.Append("ORCD_OptionTime=@ORCD_OptionTime,");
            strSql.Append("ORCDPIC_OptionID=@ORCDPIC_OptionID,");
            strSql.Append("ORCDPIC_OptionTime=@ORCDPIC_OptionTime,");
            strSql.Append("OBD_OptionID=@OBD_OptionID,");
            strSql.Append("OBD_OptionTime=@OBD_OptionTime,");
            strSql.Append("OBDPIC_OptionID=@OBDPIC_OptionID,");
            strSql.Append("OBDPIC_OptionTime=@OBDPIC_OptionTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ORCDStatus", SqlDbType.Int,4),
					new SqlParameter("@OBDStatus", SqlDbType.Int,4),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@Banks", SqlDbType.NVarChar,200),
					new SqlParameter("@Brands", SqlDbType.NVarChar,100),
					new SqlParameter("@RegulatoryMode", SqlDbType.NVarChar,100),
					new SqlParameter("@SearchFrequency", SqlDbType.NVarChar,100),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,100),
					new SqlParameter("@ApplyResult", SqlDbType.NVarChar,1000),
					new SqlParameter("@ORCD", SqlDbType.NVarChar,300),
					new SqlParameter("@ORCDPIC", SqlDbType.Bit,1),
					new SqlParameter("@OBD", SqlDbType.NVarChar,300),
					new SqlParameter("@OBDPIC", SqlDbType.Bit,1),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@ORCD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ORCDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@ORCDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBD_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBD_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@OBDPIC_OptionID", SqlDbType.Int,4),
					new SqlParameter("@OBDPIC_OptionTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ORCDStatus;
            parameters[1].Value = model.OBDStatus;
            parameters[2].Value = model.DealerID;
            parameters[3].Value = model.DealerName;
            parameters[4].Value = model.Banks;
            parameters[5].Value = model.Brands;
            parameters[6].Value = model.RegulatoryMode;
            parameters[7].Value = model.SearchFrequency;
            parameters[8].Value = model.SID;
            parameters[9].Value = model.SName;
            parameters[10].Value = model.ApplyTime;
            parameters[11].Value = model.LinkPhone;
            parameters[12].Value = model.ApplyResult;
            parameters[13].Value = model.ORCD;
            parameters[14].Value = model.ORCDPIC;
            parameters[15].Value = model.OBD;
            parameters[16].Value = model.OBDPIC;
            parameters[17].Value = model.CreateID;
            parameters[18].Value = model.CreateTime;
            parameters[19].Value = model.DeleteID;
            parameters[20].Value = model.DeleteTime;
            parameters[21].Value = model.IsDelete;
            parameters[22].Value = model.ORCD_OptionID;
            parameters[23].Value = model.ORCD_OptionTime;
            parameters[24].Value = model.ORCDPIC_OptionID;
            parameters[25].Value = model.ORCDPIC_OptionTime;
            parameters[26].Value = model.OBD_OptionID;
            parameters[27].Value = model.OBD_OptionTime;
            parameters[28].Value = model.OBDPIC_OptionID;
            parameters[29].Value = model.OBDPIC_OptionTime;
            parameters[30].Value = model.ID;

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
            strSql.Append("delete from tb_SearchWHFreqAppForm ");
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
            strSql.Append("delete from tb_SearchWHFreqAppForm ");
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
        public Citic.Model.SearchWHFreqAppForm GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ORCDStatus,OBDStatus,DealerID,DealerName,Banks,Brands,RegulatoryMode,SearchFrequency,SID,SName,ApplyTime,LinkPhone,ApplyResult,ORCD,ORCDPIC,OBD,OBDPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime from tb_SearchWHFreqAppForm ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.SearchWHFreqAppForm model = new Citic.Model.SearchWHFreqAppForm();
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
        public Citic.Model.SearchWHFreqAppForm DataRowToModel(DataRow row)
        {
            Citic.Model.SearchWHFreqAppForm model = new Citic.Model.SearchWHFreqAppForm();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ORCDStatus"] != null && row["ORCDStatus"].ToString() != "")
                {
                    model.ORCDStatus = int.Parse(row["ORCDStatus"].ToString());
                }
                if (row["OBDStatus"] != null && row["OBDStatus"].ToString() != "")
                {
                    model.OBDStatus = int.Parse(row["OBDStatus"].ToString());
                }
                if (row["DealerID"] != null && row["DealerID"].ToString() != "")
                {
                    model.DealerID = int.Parse(row["DealerID"].ToString());
                }
                if (row["DealerName"] != null)
                {
                    model.DealerName = row["DealerName"].ToString();
                }
                if (row["Banks"] != null)
                {
                    model.Banks = row["Banks"].ToString();
                }
                if (row["Brands"] != null)
                {
                    model.Brands = row["Brands"].ToString();
                }
                if (row["RegulatoryMode"] != null)
                {
                    model.RegulatoryMode = row["RegulatoryMode"].ToString();
                }
                if (row["SearchFrequency"] != null)
                {
                    model.SearchFrequency = row["SearchFrequency"].ToString();
                }
                if (row["SID"] != null && row["SID"].ToString() != "")
                {
                    model.SID = int.Parse(row["SID"].ToString());
                }
                if (row["SName"] != null)
                {
                    model.SName = row["SName"].ToString();
                }
                if (row["ApplyTime"] != null && row["ApplyTime"].ToString() != "")
                {
                    model.ApplyTime = DateTime.Parse(row["ApplyTime"].ToString());
                }
                if (row["LinkPhone"] != null)
                {
                    model.LinkPhone = row["LinkPhone"].ToString();
                }
                if (row["ApplyResult"] != null)
                {
                    model.ApplyResult = row["ApplyResult"].ToString();
                }
                if (row["ORCD"] != null)
                {
                    model.ORCD = row["ORCD"].ToString();
                }
                if (row["ORCDPIC"] != null && row["ORCDPIC"].ToString() != "")
                {
                    if ((row["ORCDPIC"].ToString() == "1") || (row["ORCDPIC"].ToString().ToLower() == "true"))
                    {
                        model.ORCDPIC = true;
                    }
                    else
                    {
                        model.ORCDPIC = false;
                    }
                }
                if (row["OBD"] != null)
                {
                    model.OBD = row["OBD"].ToString();
                }
                if (row["OBDPIC"] != null && row["OBDPIC"].ToString() != "")
                {
                    if ((row["OBDPIC"].ToString() == "1") || (row["OBDPIC"].ToString().ToLower() == "true"))
                    {
                        model.OBDPIC = true;
                    }
                    else
                    {
                        model.OBDPIC = false;
                    }
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
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
                if (row["ORCD_OptionID"] != null && row["ORCD_OptionID"].ToString() != "")
                {
                    model.ORCD_OptionID = int.Parse(row["ORCD_OptionID"].ToString());
                }
                if (row["ORCD_OptionTime"] != null && row["ORCD_OptionTime"].ToString() != "")
                {
                    model.ORCD_OptionTime = DateTime.Parse(row["ORCD_OptionTime"].ToString());
                }
                if (row["ORCDPIC_OptionID"] != null && row["ORCDPIC_OptionID"].ToString() != "")
                {
                    model.ORCDPIC_OptionID = int.Parse(row["ORCDPIC_OptionID"].ToString());
                }
                if (row["ORCDPIC_OptionTime"] != null && row["ORCDPIC_OptionTime"].ToString() != "")
                {
                    model.ORCDPIC_OptionTime = DateTime.Parse(row["ORCDPIC_OptionTime"].ToString());
                }
                if (row["OBD_OptionID"] != null && row["OBD_OptionID"].ToString() != "")
                {
                    model.OBD_OptionID = int.Parse(row["OBD_OptionID"].ToString());
                }
                if (row["OBD_OptionTime"] != null && row["OBD_OptionTime"].ToString() != "")
                {
                    model.OBD_OptionTime = DateTime.Parse(row["OBD_OptionTime"].ToString());
                }
                if (row["OBDPIC_OptionID"] != null && row["OBDPIC_OptionID"].ToString() != "")
                {
                    model.OBDPIC_OptionID = int.Parse(row["OBDPIC_OptionID"].ToString());
                }
                if (row["OBDPIC_OptionTime"] != null && row["OBDPIC_OptionTime"].ToString() != "")
                {
                    model.OBDPIC_OptionTime = DateTime.Parse(row["OBDPIC_OptionTime"].ToString());
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
            strSql.Append("select ID,ORCDStatus,OBDStatus,DealerID,DealerName,Banks,Brands,RegulatoryMode,SearchFrequency,SID,SName,ApplyTime,LinkPhone,ApplyResult,ORCD,ORCDPIC,OBD,OBDPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime ");
            strSql.Append(" FROM tb_SearchWHFreqAppForm ");
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
            strSql.Append(" ID,ORCDStatus,OBDStatus,DealerID,DealerName,Banks,Brands,RegulatoryMode,SearchFrequency,SID,SName,ApplyTime,LinkPhone,ApplyResult,ORCD,ORCDPIC,OBD,OBDPIC,CreateID,CreateTime,DeleteID,DeleteTime,IsDelete,ORCD_OptionID,ORCD_OptionTime,ORCDPIC_OptionID,ORCDPIC_OptionTime,OBD_OptionID,OBD_OptionTime,OBDPIC_OptionID,OBDPIC_OptionTime ");
            strSql.Append(" FROM tb_SearchWHFreqAppForm ");
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
            strSql.Append("select count(1) FROM tb_SearchWHFreqAppForm ");
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
            strSql.Append(")AS Row, T.*  from tb_SearchWHFreqAppForm T ");
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
        #region 批量修改--乔春羽(2014.4.28)
        /// <summary>
        /// 批量修改数据，不固定数据列数
        /// </summary>
        /// <param name="models">要修改的数据</param>
        /// <param name="columns">要修改数据的列</param>
        /// <returns></returns>
        public int UpdateRange(Citic.Model.SearchWHFreqAppForm[] models, params string[] columns)
        {
            int num = 0;
            System.Collections.Generic.List<CommandInfo> cInfos = null;
            System.Collections.Generic.List<SqlParameter> parameters = null;
            StringBuilder strSql = null;
            StringBuilder temp = new StringBuilder("Update tb_SearchWHFreqAppForm Set ");
            if (columns != null && columns.Length > 0)
            {
                foreach (string col in columns)
                {
                    if (col.LastIndexOf("OptionTime") > 0)
                    {
                        temp.AppendFormat("{0} = GETDATE(),", col);
                    }
                    else
                    {
                        temp.AppendFormat("{0} = @{0},", col);
                    }
                }
                temp.Remove(temp.Length - 1, 1);
                temp.Remove(temp.ToString().LastIndexOf(','), temp.Length - temp.ToString().LastIndexOf(','));
                temp.Append(" Where ID = @ID");
            }
            if (models != null && models.Length > 0)
            {
                cInfos = new System.Collections.Generic.List<CommandInfo>();
                System.Collections.Generic.List<int> tempDealerID = new System.Collections.Generic.List<int>();
                foreach (Citic.Model.SearchWHFreqAppForm model in models)
                {
                    strSql = new StringBuilder();
                    strSql.Append(temp);

                    parameters = new System.Collections.Generic.List<SqlParameter>();
                    foreach (string col in columns)
                    {
                        switch (col)
                        {
                            case "ORCDStatus":
                                parameters.Add(new SqlParameter("@ORCDStatus", model.ORCDStatus));
                                break;
                            case "OBDStatus":
                                parameters.Add(new SqlParameter("@OBDStatus", model.OBDStatus));
                                break;
                            case "ORCD":
                                parameters.Add(new SqlParameter("@ORCD", model.ORCD));
                                break;
                            case "ORCD_OptionID":
                                parameters.Add(new SqlParameter("@ORCD_OptionID", model.ORCD_OptionID));
                                break;
                            case "ORCDPIC":
                                parameters.Add(new SqlParameter("@ORCDPIC", model.ORCDPIC));
                                break;
                            case "ORCDPIC_OptionID":
                                parameters.Add(new SqlParameter("@ORCDPIC_OptionID", model.ORCDPIC_OptionID));
                                break;
                            case "OBD":
                                parameters.Add(new SqlParameter("@OBD", model.OBD));
                                break;
                            case "OBD_OptionID":
                                parameters.Add(new SqlParameter("@OBD_OptionID", model.OBD_OptionID));
                                break;
                            case "OBDPIC":
                                parameters.Add(new SqlParameter("@OBDPIC", model.OBDPIC));
                                break;
                            case "OBDPIC_OptionID":
                                parameters.Add(new SqlParameter("@OBDPIC_OptionID", model.OBDPIC_OptionID));
                                break;
                        }
                    }
                    parameters.Add(new SqlParameter("@ID", model.ID));

                    cInfos.Add(new CommandInfo(strSql.ToString(), parameters.ToArray()));

                    if (model.OBDStatus.HasValue && model.OBDStatus == 1)
                    {
                        if (!tempDealerID.Contains(model.DealerID.Value))
                        {
                            strSql = new StringBuilder(string.Format("Update tb_QueryWH Set CheckFrequency = @CheckFrequency Where DB_ID like '{0}%'", model.DealerID));
                            parameters = new System.Collections.Generic.List<SqlParameter>() {
                                new SqlParameter("@CheckFrequency",model.SearchFrequency)
                            };

                            cInfos.Add(new CommandInfo(strSql.ToString(), parameters.ToArray()));
                        }
                    }
                    tempDealerID.Add(model.DealerID.Value);
                }
            }
            try
            {
                num = DbHelperSQL.ExecuteSqlTran(cInfos);
            }
            catch
            {

            }
            return num;
        }
        #endregion
        #region 需要导出Excel的数据，此业务比较复杂--乔春羽(2014.4.30)
        public DataSet GetDataGetDataForExcel(string strWhere)
        {
            DataSet ds = new DataSet();
            StringBuilder strSql = new StringBuilder("SELECT");
            strSql.AppendLine("ID,DealerName,Banks,Brands,RegulatoryMode,SearchFrequency,ApplyResult,OBDPIC_OptionTime,B.TrueName");
            strSql.AppendLine("FROM tb_SearchWHFreqAppForm A Inner join tb_User B on A.CreateID = B.UserId");
            if(!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendLine(strWhere);
            }
            try
            {
                ds = DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception)
            {
                ds.Tables.Add(new DataTable());
            }
            return ds;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

