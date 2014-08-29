
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:InspectionDay
    /// </summary>
    public partial class InspectionDay
    {
        public InspectionDay()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_InspectionDay");
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
        public int Add(Citic.Model.InspectionDay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_InspectionDay(");
            strSql.Append("Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,MainProblem,Remark,CreateTime,CreateId,isDel,DelId,DelTime)");
            strSql.Append(" values (");
            strSql.Append("@Area,@Rummager,@DealerName,@Bank,@BrandName,@SupervisorName,@Model,@Inventory,@QuartersLedger,@MainProblem,@Remark,@CreateTime,@CreateId,@isDel,@DelId,@DelTime)");
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
					new SqlParameter("@MainProblem", SqlDbType.NVarChar,-1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateId", SqlDbType.Int,4),
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
            parameters[9].Value = model.MainProblem;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.CreateTime;
            parameters[12].Value = model.CreateId;
            parameters[13].Value = model.isDel;
            parameters[14].Value = model.DelId;
            parameters[15].Value = model.DelTime;

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
        public bool Update(Citic.Model.InspectionDay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_InspectionDay set ");
            strSql.Append("Area=@Area,");
            strSql.Append("Rummager=@Rummager,");
            strSql.Append("DealerName=@DealerName,");
            strSql.Append("Bank=@Bank,");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("SupervisorName=@SupervisorName,");
            strSql.Append("Model=@Model,");
            strSql.Append("Inventory=@Inventory,");
            strSql.Append("QuartersLedger=@QuartersLedger,");
            strSql.Append("MainProblem=@MainProblem,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("CreateId=@CreateId,");
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
					new SqlParameter("@MainProblem", SqlDbType.NVarChar,-1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateId", SqlDbType.Int,4),
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
            parameters[9].Value = model.MainProblem;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.CreateTime;
            parameters[12].Value = model.CreateId;
            parameters[13].Value = model.isDel;
            parameters[14].Value = model.DelId;
            parameters[15].Value = model.DelTime;
            parameters[16].Value = model.ID;

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
            strSql.Append("delete from tb_InspectionDay ");
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
            strSql.Append("delete from tb_InspectionDay ");
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
        public Citic.Model.InspectionDay GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,MainProblem,Remark,CreateTime,CreateId,isDel,DelId,DelTime from tb_InspectionDay ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Citic.Model.InspectionDay model = new Citic.Model.InspectionDay();
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
        public Citic.Model.InspectionDay DataRowToModel(DataRow row)
        {
            Citic.Model.InspectionDay model = new Citic.Model.InspectionDay();
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
                if (row["MainProblem"] != null)
                {
                    model.MainProblem = row["MainProblem"].ToString();
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
            strSql.Append("select ID,Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,MainProblem,Remark,CreateTime,CreateId,isDel,DelId,DelTime ");
            strSql.Append(" FROM tb_InspectionDay ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 返回某天检查情况结果 张繁 2013年8月21日
        /// </summary>
        /// <param name="strSql">日期格式</param>
        /// <returns></returns>
        public DataSet DayInspection(string strSql)
        {
            string sql = string.Format(@"select a.ShopCount,b.ConformShopCount,c.NotConformShopCount,d.InventoryShopCount from (
select COUNT(id)as ShopCount,1 as id from tb_InspectionDay where CONVERT(varchar(10),CreateTime,23)='{0}'
) as a left join (
select COUNT(id) as ConformShopCount,1 as id from tb_InspectionDay where CONVERT(varchar(10),CreateTime,23)='{1}' and MainProblem='正常'
) as b on b.id=a.id left join (
select COUNT(id) as NotConformShopCount,1 as id from tb_InspectionDay where CONVERT(varchar(10),CreateTime,23)='{2}' and MainProblem <> '正常'
) as c on c.id=b.id left join (
select COUNT(id) as InventoryShopCount,1 as id from tb_InspectionDay where Inventory=0 and CONVERT(varchar(10),CreateTime,23)='{3}'
) as d on d.id=c.id", strSql, strSql, strSql, strSql);
            return DbHelperSQL.Query(sql.ToString());
        }
        /// <summary>
        /// 返回某月检查情况结果 张繁 2013年8月21日
        /// </summary>
        /// <param name="strSql">日期格式</param>
        /// <returns></returns>
        public DataSet MonthInspection(string strSql)
        {
            string sql = string.Format(@"select a.ShopCount,b.ConformShopCount,c.NotConformShopCount,d.InventoryShopCount from (select COUNT(id)as ShopCount,1 as id from tb_InspectionDay where convert(varchar(7), CreateTime, 120)=convert(varchar(7), '{0}', 120)
) as a left join (
select COUNT(id) as ConformShopCount,1 as id from tb_InspectionDay where convert(varchar(7), CreateTime, 120)=convert(varchar(7), '{1}', 120) and MainProblem='正常'
) as b on b.id=a.id left join (
select COUNT(id) as NotConformShopCount,1 as id from tb_InspectionDay where convert(varchar(7), CreateTime, 120)=convert(varchar(7), '{2}', 120) and MainProblem <> '正常'
) as c on c.id=b.id left join (
select COUNT(id) as InventoryShopCount,1 as id from tb_InspectionDay where Inventory=0 and convert(varchar(7), CreateTime, 120)=convert(varchar(7), '{3}', 120)
) as d on d.id=c.id", strSql, strSql, strSql, strSql);
            return DbHelperSQL.Query(sql.ToString());
        }
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
            strSql.Append(" ID,Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,MainProblem,Remark,CreateTime,CreateId,isDel,DelId,DelTime ");
            strSql.Append(" FROM tb_InspectionDay ");
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
            strSql.Append("select count(1) FROM tb_InspectionDay ");
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
            strSql.Append(")AS Row, T.*  from tb_InspectionDay T ");
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
            parameters[0].Value = "tb_InspectionDay";
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

