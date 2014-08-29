using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:XDBG
    /// 巡店报告
    /// </summary>
    public partial class XDBG
    {
        public XDBG()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_XDBG_List");
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
        public int Add(Citic.Model.XDBG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_XDBG_List(");
            strSql.Append("DealerID,DealerName,BankID,BankName,Address,Area,FilePath,FileName,CreateID,CreateName,CreateTime,InspectTime,UpdateID,UpdateName,UpdateTime,Remark,Field1,Field2)");
            strSql.Append(" values (");
            strSql.Append("@DealerID,@DealerName,@BankID,@BankName,@Address,@Area,@FilePath,@FileName,@CreateID,@CreateName,@CreateTime,@InspectTime,@UpdateID,@UpdateName,@UpdateTime,@Remark,@Field1,@Field2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Area", SqlDbType.NVarChar,100),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,500),
					new SqlParameter("@FileName", SqlDbType.NVarChar,300),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@InspectTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,300),
					new SqlParameter("@Field1", SqlDbType.NVarChar,200),
					new SqlParameter("@Field2", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Area;
            parameters[6].Value = model.FilePath;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.CreateID;
            parameters[9].Value = model.CreateName;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.InspectTime;
            parameters[12].Value = model.UpdateID;
            parameters[13].Value = model.UpdateName;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.Field1;
            parameters[17].Value = model.Field2;

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
        public bool Update(Citic.Model.XDBG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_XDBG_List set ");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("Address=@Address,");
            strSql.Append("Area=@Area,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateName=@CreateName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("InspectTime=@InspectTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateName=@UpdateName,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Field1=@Field1,");
            strSql.Append("Field2=@Field2");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Area", SqlDbType.NVarChar,100),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,500),
					new SqlParameter("@FileName", SqlDbType.NVarChar,300),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@InspectTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateName", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,300),
					new SqlParameter("@Field1", SqlDbType.NVarChar,200),
					new SqlParameter("@Field2", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DealerID;
            parameters[1].Value = model.DealerName;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Area;
            parameters[6].Value = model.FilePath;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.CreateID;
            parameters[9].Value = model.CreateName;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.InspectTime;
            parameters[12].Value = model.UpdateID;
            parameters[13].Value = model.UpdateName;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.Field1;
            parameters[17].Value = model.Field2;
            parameters[18].Value = model.ID;

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
            strSql.Append("delete from tb_XDBG_List ");
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
            strSql.Append("delete from tb_XDBG_List ");
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
        public Citic.Model.XDBG GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DealerID,DealerName,BankID,BankName,Address,Area,FilePath,FileName,CreateID,CreateName,CreateTime,InspectTime,UpdateID,UpdateName,UpdateTime,Remark,Field1,Field2 from tb_XDBG_List ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.XDBG model = new Citic.Model.XDBG();
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
        public Citic.Model.XDBG DataRowToModel(DataRow row)
        {
            Citic.Model.XDBG model = new Citic.Model.XDBG();
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
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["FilePath"] != null)
                {
                    model.FilePath = row["FilePath"].ToString();
                }
                if (row["FileName"] != null)
                {
                    model.FileName = row["FileName"].ToString();
                }
                if (row["CreateID"] != null && row["CreateID"].ToString() != "")
                {
                    model.CreateID = int.Parse(row["CreateID"].ToString());
                }
                if (row["CreateName"] != null)
                {
                    model.CreateName = row["CreateName"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["InspectTime"] != null && row["InspectTime"].ToString() != "")
                {
                    model.InspectTime = DateTime.Parse(row["InspectTime"].ToString());
                }
                if (row["UpdateID"] != null && row["UpdateID"].ToString() != "")
                {
                    model.UpdateID = int.Parse(row["UpdateID"].ToString());
                }
                if (row["UpdateName"] != null)
                {
                    model.UpdateName = row["UpdateName"].ToString();
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Field1"] != null)
                {
                    model.Field1 = row["Field1"].ToString();
                }
                if (row["Field2"] != null)
                {
                    model.Field2 = row["Field2"].ToString();
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
            strSql.Append("select ID,DealerID,DealerName,BankID,BankName,Address,Area,FilePath,FileName,CreateID,CreateName,CreateTime,InspectTime,UpdateID,UpdateName,UpdateTime,Remark,Field1,Field2 ");
            strSql.Append(" FROM tb_XDBG_List ");
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
            strSql.Append(" ID,DealerID,DealerName,BankID,BankName,Address,Area,FilePath,FileName,CreateID,CreateName,CreateTime,InspectTime,UpdateID,UpdateName,UpdateTime,Remark,Field1,Field2 ");
            strSql.Append(" FROM tb_XDBG_List ");
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
            strSql.Append("select count(1) FROM tb_XDBG_List ");
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
            strSql.Append(")AS Row, T.*  from tb_XDBG_List T ");
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
        #region 增加一条“巡店报告”数据--乔春羽(2013.12.25)
        /// <summary>
        /// 调用存储过程，添加一条数据，同时还添加一条“记录”
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddXDBG(Citic.Model.XDBG model)
        {
            int num = 0;
            int returnValue = 0;
            string procName = "proc_CreateXDBG";
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@ReturnValue",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.Int,4),
                new SqlParameter("@DealerName",SqlDbType.NVarChar,200),
                new SqlParameter("@BankID",SqlDbType.Int,4),
                new SqlParameter("@BankName",SqlDbType.NVarChar,200),
                new SqlParameter("@Address",SqlDbType.NVarChar,300),
                new SqlParameter("@Area",SqlDbType.NVarChar,100),
                new SqlParameter("@FilePath",SqlDbType.NVarChar,300),
                new SqlParameter("@FileName",SqlDbType.NVarChar,200),
                new SqlParameter("@CreateID",SqlDbType.Int,4),
                new SqlParameter("@CreateName",SqlDbType.NVarChar,100),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@InspectTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateID",SqlDbType.Int,4),
                new SqlParameter("@UpdateName",SqlDbType.NVarChar,200),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@Remark",SqlDbType.NVarChar,300),
                new SqlParameter("@Field1",SqlDbType.NVarChar,200),
                new SqlParameter("@Field2",SqlDbType.NVarChar,200),
                new SqlParameter("@TrueName",SqlDbType.NVarChar,200)
            };
            sps[0].Direction = ParameterDirection.Output;
            sps[1].Value = model.DealerID;
            sps[2].Value = model.DealerName;
            sps[3].Value = model.BankID;
            sps[4].Value = model.BankName;
            sps[5].Value = model.Address;
            sps[6].Value = model.Area;
            sps[7].Value = model.FilePath;
            sps[8].Value = model.FileName;
            sps[9].Value = model.CreateID;
            sps[10].Value = model.CreateName;
            sps[11].Value = model.CreateTime;
            sps[12].Value = model.InspectTime;
            sps[13].Value = model.UpdateID;
            sps[14].Value = model.UpdateName;
            sps[15].Value = model.UpdateTime;
            sps[16].Value = model.Remark;
            sps[17].Value = model.Field1;
            sps[18].Value = model.Field2;
            sps[19].Value = model.TrueName;
            try
            {
                num = DbHelperSQL.RunProcedure(procName, sps, out returnValue);
            }
            catch (SqlException se)
            {
                throw se;
            }
            return num;
        }
        #endregion

        #region 修改一条“巡店报告”数据--乔春羽(2013.12.25)
        /// <summary>
        /// 调用存储过程，修改一条数据，同时还添加一条“记录”
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateXDBG(Citic.Model.XDBG model)
        {
            int num = 0;
            int returnValue = 0;
            string procName = "proc_ModifyXDBG";
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@ReturnValue",SqlDbType.Int,4),
                new SqlParameter("@ID",SqlDbType.Int,4),
                new SqlParameter("@DealerID",SqlDbType.Int,4),
                new SqlParameter("@DealerName",SqlDbType.NVarChar,200),
                new SqlParameter("@BankID",SqlDbType.Int,4),
                new SqlParameter("@BankName",SqlDbType.NVarChar,200),
                new SqlParameter("@Address",SqlDbType.NVarChar,300),
                new SqlParameter("@Area",SqlDbType.NVarChar,100),
                new SqlParameter("@FilePath",SqlDbType.NVarChar,300),
                new SqlParameter("@FileName",SqlDbType.NVarChar,200),
                new SqlParameter("@CreateID",SqlDbType.Int,4),
                new SqlParameter("@CreateName",SqlDbType.NVarChar,100),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@InspectTime",SqlDbType.DateTime),
                new SqlParameter("@UpdateID",SqlDbType.Int,4),
                new SqlParameter("@UpdateName",SqlDbType.NVarChar,200),
                new SqlParameter("@UpdateTime",SqlDbType.DateTime),
                new SqlParameter("@Remark",SqlDbType.NVarChar,300),
                new SqlParameter("@Field1",SqlDbType.NVarChar,200),
                new SqlParameter("@Field2",SqlDbType.NVarChar,200),
                new SqlParameter("@TrueName",SqlDbType.NVarChar,200)
            };
            sps[0].Direction = ParameterDirection.Output;
            sps[1].Value = model.ID;
            sps[2].Value = model.DealerID;
            sps[3].Value = model.DealerName;
            sps[4].Value = model.BankID;
            sps[5].Value = model.BankName;
            sps[6].Value = model.Address;
            sps[7].Value = model.Area;
            sps[8].Value = model.FilePath;
            sps[9].Value = model.FileName;
            sps[10].Value = model.CreateID;
            sps[11].Value = model.CreateName;
            sps[12].Value = model.CreateTime;
            sps[13].Value = model.InspectTime;
            sps[14].Value = model.UpdateID;
            sps[15].Value = model.UpdateName;
            sps[16].Value = model.UpdateTime;
            sps[17].Value = model.Remark;
            sps[18].Value = model.Field1;
            sps[19].Value = model.Field2;
            sps[20].Value = model.TrueName;
            try
            {
                num = DbHelperSQL.RunProcedure(procName, sps, out returnValue);
            }
            catch (SqlException se)
            {
                throw se;
            }
            return num;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

