using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
using System.IO;
using System.Xml;
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Car
    /// </summary>
    public partial class Car
    {
        public Car()
        { }
        #region  BasicMethod

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。 张繁 2013年7月22日 
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        /// <returns></returns>
        public int SqlTran(List<String> SQLStringList)
        {
            return DbHelperSQL.ExecuteSqlTran(SQLStringList);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Vin, string tb_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + tb_Name + "");
            strSql.Append(" where Vin=@Vin ");
            SqlParameter[] parameters = {
					new SqlParameter("@Vin", SqlDbType.NVarChar,100)			};
            parameters[0].Value = Vin;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Citic.Model.Car model, string tb_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}(", tb_Name);
            strSql.Append("Vin,DraftNo,BankID,BankName,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,BrandName,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,KeyNumber,CarCost,ReturnCost,Remarks,TransitTime,MoveTime,OutTime,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,GD_ID,ZX_ID,CarClass,Displacement)");
            strSql.Append(" values (");
            strSql.Append("@Vin,@DraftNo,@BankID,@BankName,@Statu,@QualifiedNoDate,@DealerID,@DealerName,@BrandID,@BrandName,@StorageID,@StorageName,@CarColor,@CarModel,@EngineNo,@QualifiedNo,@KeyCount,@KeyNumber,@CarCost,@ReturnCost,@Remarks,@TransitTime,@MoveTime,@OutTime,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@GD_ID,@ZX_ID,@CarClass,@Displacement)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Vin", SqlDbType.NVarChar,100),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@Statu", SqlDbType.Int,4),
					new SqlParameter("@QualifiedNoDate", SqlDbType.DateTime),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@StorageName", SqlDbType.NVarChar,50),
					new SqlParameter("@CarColor", SqlDbType.NVarChar,50),
					new SqlParameter("@CarModel", SqlDbType.NVarChar,50),
					new SqlParameter("@EngineNo", SqlDbType.NVarChar,50),
					new SqlParameter("@QualifiedNo", SqlDbType.NVarChar,50),
					new SqlParameter("@KeyCount", SqlDbType.Int,4),
					new SqlParameter("@KeyNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@CarCost", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnCost", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,-1),
					new SqlParameter("@TransitTime", SqlDbType.DateTime),
					new SqlParameter("@MoveTime", SqlDbType.DateTime),
					new SqlParameter("@OutTime", SqlDbType.DateTime),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@GD_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@ZX_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@CarClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Displacement", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Vin;
            parameters[1].Value = model.DraftNo;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.Statu;
            parameters[5].Value = model.QualifiedNoDate;
            parameters[6].Value = model.DealerID;
            parameters[7].Value = model.DealerName;
            parameters[8].Value = model.BrandID;
            parameters[9].Value = model.BrandName;
            parameters[10].Value = model.StorageID;
            parameters[11].Value = model.StorageName;
            parameters[12].Value = model.CarColor;
            parameters[13].Value = model.CarModel;
            parameters[14].Value = model.EngineNo;
            parameters[15].Value = model.QualifiedNo;
            parameters[16].Value = model.KeyCount;
            parameters[17].Value = model.KeyNumber;
            parameters[18].Value = model.CarCost;
            parameters[19].Value = model.ReturnCost;
            parameters[20].Value = model.Remarks;
            parameters[21].Value = model.TransitTime;
            parameters[22].Value = model.MoveTime;
            parameters[23].Value = model.OutTime;
            parameters[24].Value = model.CreateID;
            parameters[25].Value = model.CreateTime;
            parameters[26].Value = model.UpdateID;
            parameters[27].Value = model.UpdateTime;
            parameters[28].Value = model.DeleteID;
            parameters[29].Value = model.DeleteTime;
            parameters[30].Value = model.IsDelete;
            parameters[31].Value = model.IsPort;
            parameters[32].Value = model.GD_ID;
            parameters[33].Value = model.ZX_ID;
            parameters[34].Value = model.CarClass;
            parameters[35].Value = model.Displacement;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Car model, string tb_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + tb_Name + " set ");
            strSql.Append("Vin=@Vin,");
            strSql.Append("DraftNo=@DraftNo,");
            strSql.Append("BankID=@BankID,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("Statu=@Statu,");
            strSql.Append("QualifiedNoDate=@QualifiedNoDate,");
            strSql.Append("DealerID=@DealerID,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("BrandID=@BrandID,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("StorageID=@StorageID,");
            strSql.Append("StorageName=@StorageName,");
            strSql.Append("CarColor=@CarColor,");
            strSql.Append("CarModel=@CarModel,");
            strSql.Append("EngineNo=@EngineNo,");
            strSql.Append("QualifiedNo=@QualifiedNo,");
            strSql.Append("KeyCount=@KeyCount,");
            strSql.Append("KeyNumber=@KeyNumber,");
            strSql.Append("CarCost=@CarCost,");
            strSql.Append("ReturnCost=@ReturnCost,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("TransitTime=@TransitTime,");
            strSql.Append("MoveTime=@MoveTime,");
            strSql.Append("OutTime=@OutTime,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("GD_ID=@GD_ID,");
            strSql.Append("ZX_ID=@ZX_ID,");
            strSql.Append("CarClass=@CarClass,");
            strSql.Append("Displacement=@Displacement");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Vin", SqlDbType.NVarChar,100),
					new SqlParameter("@DraftNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@Statu", SqlDbType.Int,4),
					new SqlParameter("@QualifiedNoDate", SqlDbType.DateTime),
					new SqlParameter("@DealerID", SqlDbType.Int,4),
					new SqlParameter("@DealerName", SqlDbType.NVarChar,100),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
					new SqlParameter("@StorageID", SqlDbType.Int,4),
					new SqlParameter("@StorageName", SqlDbType.NVarChar,50),
					new SqlParameter("@CarColor", SqlDbType.NVarChar,50),
					new SqlParameter("@CarModel", SqlDbType.NVarChar,50),
					new SqlParameter("@EngineNo", SqlDbType.NVarChar,50),
					new SqlParameter("@QualifiedNo", SqlDbType.NVarChar,50),
					new SqlParameter("@KeyCount", SqlDbType.Int,4),
					new SqlParameter("@KeyNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@CarCost", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnCost", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,-1),
					new SqlParameter("@TransitTime", SqlDbType.DateTime),
					new SqlParameter("@MoveTime", SqlDbType.DateTime),
					new SqlParameter("@OutTime", SqlDbType.DateTime),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@GD_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@ZX_ID", SqlDbType.NVarChar,100),
					new SqlParameter("@CarClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Displacement", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Vin;
            parameters[1].Value = model.DraftNo;
            parameters[2].Value = model.BankID;
            parameters[3].Value = model.BankName;
            parameters[4].Value = model.Statu;
            parameters[5].Value = model.QualifiedNoDate;
            parameters[6].Value = model.DealerID;
            parameters[7].Value = model.DealerName;
            parameters[8].Value = model.BrandID;
            parameters[9].Value = model.BrandName;
            parameters[10].Value = model.StorageID;
            parameters[11].Value = model.StorageName;
            parameters[12].Value = model.CarColor;
            parameters[13].Value = model.CarModel;
            parameters[14].Value = model.EngineNo;
            parameters[15].Value = model.QualifiedNo;
            parameters[16].Value = model.KeyCount;
            parameters[17].Value = model.KeyNumber;
            parameters[18].Value = model.CarCost;
            parameters[19].Value = model.ReturnCost;
            parameters[20].Value = model.Remarks;
            parameters[21].Value = model.TransitTime;
            parameters[22].Value = model.MoveTime;
            parameters[23].Value = model.OutTime;
            parameters[24].Value = model.CreateID;
            parameters[25].Value = model.CreateTime;
            parameters[26].Value = model.UpdateID;
            parameters[27].Value = model.UpdateTime;
            parameters[28].Value = model.DeleteID;
            parameters[29].Value = model.DeleteTime;
            parameters[30].Value = model.IsDelete;
            parameters[31].Value = model.IsPort;
            parameters[32].Value = model.GD_ID;
            parameters[33].Value = model.ZX_ID;
            parameters[34].Value = model.CarClass;
            parameters[35].Value = model.Displacement;
            parameters[36].Value = model.ID;

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
        public bool Delete(string Vin, string tb_Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tb_Name + " ");
            strSql.Append(" where Vin=@Vin ");
            SqlParameter[] parameters = {
					new SqlParameter("@Vin", SqlDbType.NVarChar,100)			};
            parameters[0].Value = Vin;

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
        public bool DeleteList(string Vinlist, string tb_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tb_Name + " ");
            strSql.Append(" where Vin in (" + Vinlist + ")  ");
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
        public Citic.Model.Car GetModel(string Vin, string tb_Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Vin,DraftNo,BankID,BankName,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,BrandName,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,KeyNumber,CarCost,ReturnCost,Remarks,TransitTime,MoveTime,OutTime,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,GD_ID,ZX_ID,CarClass,Displacement from " + tb_Name + " ");
            strSql.Append(" where Vin=@Vin ");
            SqlParameter[] parameters = {
					new SqlParameter("@Vin", SqlDbType.NVarChar,100)			};
            parameters[0].Value = Vin;

            Citic.Model.Car model = new Citic.Model.Car();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0], tb_Name);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Car DataRowToModel(DataRow row, string tb_Name)
        {
            Citic.Model.Car model = new Citic.Model.Car();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Vin"] != null)
                {
                    model.Vin = row["Vin"].ToString();
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
                if (row["Statu"] != null && row["Statu"].ToString() != "")
                {
                    model.Statu = int.Parse(row["Statu"].ToString());
                }
                if (row["QualifiedNoDate"] != null && row["QualifiedNoDate"].ToString() != "")
                {
                    model.QualifiedNoDate = DateTime.Parse(row["QualifiedNoDate"].ToString());
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
                if (row["StorageID"] != null && row["StorageID"].ToString() != "")
                {
                    model.StorageID = int.Parse(row["StorageID"].ToString());
                }
                if (row["StorageName"] != null)
                {
                    model.StorageName = row["StorageName"].ToString();
                }
                if (row["CarColor"] != null)
                {
                    model.CarColor = row["CarColor"].ToString();
                }
                if (row["CarModel"] != null)
                {
                    model.CarModel = row["CarModel"].ToString();
                }
                if (row["EngineNo"] != null)
                {
                    model.EngineNo = row["EngineNo"].ToString();
                }
                if (row["QualifiedNo"] != null)
                {
                    model.QualifiedNo = row["QualifiedNo"].ToString();
                }
                if (row["KeyCount"] != null && row["KeyCount"].ToString() != "")
                {
                    model.KeyCount = int.Parse(row["KeyCount"].ToString());
                }
                if (row["KeyNumber"] != null)
                {
                    model.KeyNumber = row["KeyNumber"].ToString();
                }
                if (row["CarCost"] != null)
                {
                    model.CarCost = row["CarCost"].ToString();
                }
                if (row["ReturnCost"] != null)
                {
                    model.ReturnCost = row["ReturnCost"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["TransitTime"] != null && row["TransitTime"].ToString() != "")
                {
                    model.TransitTime = DateTime.Parse(row["TransitTime"].ToString());
                }
                if (row["MoveTime"] != null && row["MoveTime"].ToString() != "")
                {
                    model.MoveTime = DateTime.Parse(row["MoveTime"].ToString());
                }
                if (row["OutTime"] != null && row["OutTime"].ToString() != "")
                {
                    model.OutTime = DateTime.Parse(row["OutTime"].ToString());
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
                if (row["GD_ID"] != null)
                {
                    model.GD_ID = row["GD_ID"].ToString();
                }
                if (row["ZX_ID"] != null)
                {
                    model.ZX_ID = row["ZX_ID"].ToString();
                }
                if (row["CarClass"] != null)
                {
                    model.CarClass = row["CarClass"].ToString();
                }
                if (row["Displacement"] != null)
                {
                    model.Displacement = row["Displacement"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string tb_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Vin,DraftNo,BankID,BankName,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,BrandName,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,KeyNumber,CarCost,ReturnCost,Remarks,TransitTime,MoveTime,OutTime,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,GD_ID,ZX_ID,CarClass,Displacement ");
            strSql.Append(" FROM " + tb_Name + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表 前多少条 2014年5月23日
        /// </summary>
        public DataSet GetList(string strWhere, string tb_Name,int Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top {0} ID,Vin,DraftNo,BankID,BankName,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,BrandName,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,KeyNumber,CarCost,ReturnCost,Remarks,TransitTime,MoveTime,OutTime,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,GD_ID,ZX_ID,CarClass,Displacement ",Top);
            strSql.Append(" FROM " + tb_Name + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据sql查询返回集合 张繁 2013年8月21日
        /// </summary>
        public DataSet GetList(string strSql)
        {
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, string tb_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,Vin,DraftNo,BankID,BankName,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,BrandName,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,KeyNumber,CarCost,ReturnCost,Remarks,TransitTime,MoveTime,OutTime,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,GD_ID,ZX_ID,CarClass,Displacement ");
            strSql.Append(" FROM " + tb_Name + " ");
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
        public int GetRecordCount(string strWhere, string tb_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + tb_Name + " ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string tb_Name)
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
                strSql.Append("order by T.Vin desc");
            }
            strSql.Append(")AS Row, T.*  from " + tb_Name + " T ");
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

        #region 显示一个经销商下的所有质押物的详细信息，包括其所属的汇票--乔春羽(2013.7.19)
        /// <summary>
        ///  显示一个经销商下的所有质押物的详细信息，包括其所属的汇票
        /// </summary>
        /// <param name="strWhere">SQL语句Where条件</param>
        /// <param name="orderby">排序列</param>
        /// <param name="startIndex">开始下标位</param>
        /// <param name="endIndex">结束下标位</param>
        /// <param name="tb_Name">要查询的表名</param>
        /// <param name="path">文件路径</param>
        /// <param name="sqlCmd">要调用的SQL语句</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string tb_Name, string path, string sqlCmd)
        {
            DataSet ds = null;
            string sql = GetSQL(path, sqlCmd);
            if (sql != null && sql != string.Empty)
            {
                if (!string.IsNullOrEmpty(orderby.Trim()))
                {
                    sql = sql.Replace("{OrderBy}", orderby);
                }
                else
                {
                    sql = sql.Replace("{OrderBy}", "ID");
                }
                sql = sql.Replace("{Where}", "WHERE car." + strWhere + " and d." + strWhere);
                sql = sql.Replace("{Start}", startIndex.ToString());
                sql = sql.Replace("{End}", endIndex.ToString());
                sql = sql.Replace("{TableName}", tb_Name);
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

        #region 读取配置文件，获取SQL语句--乔春羽(2013.7.19)
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

        #region 根据输入的列名返回该列下的结果--乔春羽(2013.8.9)
        /// <summary>
        /// 根据输入的列名返回该列下的结果
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="vin">车架号</param>
        /// <param name="columns">动态数据参数</param>
        /// <returns></returns>
        public DataSet GetValueByColumns(string tableName, string vin, params string[] columns)
        {
            DataSet ds = null;
            StringBuilder sql = new StringBuilder("SELECT ");
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    if (i == columns.Length - 1)
                    {
                        sql.Append(columns[i]);
                    }
                    else
                    {
                        sql.Append(columns[i] + ",");
                    }
                }
            }
            sql.Append(" FROM " + tableName);
            if (!string.IsNullOrEmpty(vin))
            {
                sql.AppendFormat(" WHERE Vin='{0}'", vin);
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

        #region 获得一家店质押物的所有信息，替换了所有的数字字段--乔春羽(2013.12.27)
        public DataSet GetAllListByProcess(string strWhere, string tbName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT 
d.PledgeNo,
GuaranteeNo,
d.DraftNo,
CONVERT(VARCHAR(12),d.BeginTime,111) BeginTime,
CONVERT(VARCHAR(12),d.EndTime,111) EndTime,
d.DarftMoney,
CONVERT(VARCHAR(12),QualifiedNoDate,111) QualifiedNoDate,
CarModel,
CarClass,
Displacement,
CarColor,
EngineNo,
Vin,
QualifiedNo,
KeyNumber,
CarCost,
CONVERT(VARCHAR(12),car.CreateTime,111) CreateTime,
CONVERT(VARCHAR(12),TransitTime,111) TransitTime,
CASE Statu WHEN 0 THEN '出库' WHEN 1 THEN '在库' WHEN 2 THEN '移动' WHEN 3 THEN '在途' WHEN 4 THEN '申请中' WHEN 5 THEN '异常' END Statu,
CONVERT(VARCHAR(12),OutTime,111) OutTime,
CONVERT(VARCHAR(12),MoveTime,111) MoveTime,
car.Remarks");
            strSql.Append(" FROM " + tbName + "(NOLOCK) car left join tb_Draft_List d on car.DraftNo=d.DraftNo and car.BankID=d.BankID and car.DealerID=d.DealerID");
            if (strWhere.Trim() != string.Empty)
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 批量修改质押物的状态，走“待办事项”操作--乔春羽(2013.12.30)
        /// <summary>
        /// 批量修改质押物的状态，走“待办事项”操作
        /// </summary>
        /// <param name="Models"></param>
        /// <returns></returns>
        public int UpdateRange(Citic.Model.Car[] Models)
        {
            int num = 0;
            List<CommandInfo> cInfos = new List<CommandInfo>();
            string sql = string.Empty;
            if (Models != null && Models.Length > 0)
            {
                foreach (Citic.Model.Car model in Models)
                {
                    sql = string.Format("Update {0} Set Statu=@Statu Where Vin=@Vin", model.TableName);
                    cInfos.Add(new CommandInfo()
                    {
                        CommandText = sql,
                        Parameters = new SqlParameter[]{
                                new SqlParameter("@Statu",model.Statu),
                                new SqlParameter("@Vin",model.Vin)
                            }
                    });
                }
            }
            try
            {
                num = DbHelperSQL.ExecuteSqlTran(cInfos);
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

