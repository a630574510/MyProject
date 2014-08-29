using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
    /// <summary>
    /// 数据访问类:Linkman
    /// </summary>
    public partial class Linkman
    {
        public Linkman()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LinkmanID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Linkman_List");
            strSql.Append(" where LinkmanID=@LinkmanID");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkmanID", SqlDbType.Int,4)
			};
            parameters[0].Value = LinkmanID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Linkman model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Linkman_List(");
            strSql.Append("LinkmanName,Phone,Fax,Email,Post,LinkType,RelationID,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            strSql.Append(" values (");
            strSql.Append("@LinkmanName,@Phone,@Fax,@Email,@Post,@LinkType,@RelationID,@CreateID,@CreateTime,@UpdateID,@UpdateTime,@DeleteID,@DeleteTime,@IsDelete,@IsPort,@ConnectID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkmanName", SqlDbType.NVarChar,20),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@Post", SqlDbType.NVarChar,20),
					new SqlParameter("@LinkType", SqlDbType.Int,4),
					new SqlParameter("@RelationID", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.LinkmanName;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Fax;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Post;
            parameters[5].Value = model.LinkType;
            parameters[6].Value = model.RelationID;
            parameters[7].Value = model.CreateID;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.UpdateID;
            parameters[10].Value = model.UpdateTime;
            parameters[11].Value = model.DeleteID;
            parameters[12].Value = model.DeleteTime;
            parameters[13].Value = model.IsDelete;
            parameters[14].Value = model.IsPort;
            parameters[15].Value = model.ConnectID;

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
        public bool Update(Citic.Model.Linkman model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Linkman_List set ");
            strSql.Append("LinkmanName=@LinkmanName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("Email=@Email,");
            strSql.Append("Post=@Post,");
            strSql.Append("LinkType=@LinkType,");
            strSql.Append("RelationID=@RelationID,");
            strSql.Append("CreateID=@CreateID,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateID=@UpdateID,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("DeleteID=@DeleteID,");
            strSql.Append("DeleteTime=@DeleteTime,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("IsPort=@IsPort,");
            strSql.Append("ConnectID=@ConnectID");
            strSql.Append(" where LinkmanID=@LinkmanID");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkmanName", SqlDbType.NVarChar,20),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@Post", SqlDbType.NVarChar,20),
					new SqlParameter("@LinkType", SqlDbType.Int,4),
					new SqlParameter("@RelationID", SqlDbType.Int,4),
					new SqlParameter("@CreateID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@DeleteID", SqlDbType.Int,4),
					new SqlParameter("@DeleteTime", SqlDbType.DateTime),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@IsPort", SqlDbType.Bit,1),
					new SqlParameter("@ConnectID", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkmanID", SqlDbType.Int,4)};
            parameters[0].Value = model.LinkmanName;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Fax;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Post;
            parameters[5].Value = model.LinkType;
            parameters[6].Value = model.RelationID;
            parameters[7].Value = model.CreateID;
            parameters[8].Value = model.CreateTime;
            parameters[9].Value = model.UpdateID;
            parameters[10].Value = model.UpdateTime;
            parameters[11].Value = model.DeleteID;
            parameters[12].Value = model.DeleteTime;
            parameters[13].Value = model.IsDelete;
            parameters[14].Value = model.IsPort;
            parameters[15].Value = model.ConnectID;
            parameters[16].Value = model.LinkmanID;

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
        public bool Delete(int LinkmanID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Linkman_List ");
            strSql.Append(" where LinkmanID=@LinkmanID");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkmanID", SqlDbType.Int,4)
			};
            parameters[0].Value = LinkmanID;

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
        public bool DeleteList(string LinkmanIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Linkman_List ");
            strSql.Append(" where LinkmanID in (" + LinkmanIDlist + ")  ");
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
        public Citic.Model.Linkman GetModel(int LinkmanID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LinkmanID,LinkmanName,Phone,Fax,Email,Post,LinkType,RelationID,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID from tb_Linkman_List ");
            strSql.Append(" where LinkmanID=@LinkmanID");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkmanID", SqlDbType.Int,4)
			};
            parameters[0].Value = LinkmanID;

            Citic.Model.Linkman model = new Citic.Model.Linkman();
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
        public Citic.Model.Linkman DataRowToModel(DataRow row)
        {
            Citic.Model.Linkman model = new Citic.Model.Linkman();
            if (row != null)
            {
                if (row["LinkmanID"] != null && row["LinkmanID"].ToString() != "")
                {
                    model.LinkmanID = int.Parse(row["LinkmanID"].ToString());
                }
                if (row["LinkmanName"] != null)
                {
                    model.LinkmanName = row["LinkmanName"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Fax"] != null)
                {
                    model.Fax = row["Fax"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Post"] != null)
                {
                    model.Post = row["Post"].ToString();
                }
                if (row["LinkType"] != null && row["LinkType"].ToString() != "")
                {
                    model.LinkType = int.Parse(row["LinkType"].ToString());
                }
                if (row["RelationID"] != null && row["RelationID"].ToString() != "")
                {
                    model.RelationID = int.Parse(row["RelationID"].ToString());
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
            strSql.Append("select LinkmanID,LinkmanName,Phone,Fax,Email,Post,LinkType,RelationID,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Linkman_List ");
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
            strSql.Append(" LinkmanID,LinkmanName,Phone,Fax,Email,Post,LinkType,RelationID,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID ");
            strSql.Append(" FROM tb_Linkman_List ");
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
            strSql.Append("select count(1) FROM tb_Linkman_List ");
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
                strSql.Append("order by T.LinkmanID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Linkman_List T ");
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
            parameters[0].Value = "tb_Linkman_List";
            parameters[1].Value = "LinkmanID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod

        #region 批量添加--乔春羽
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="lms"></param>
        /// <returns></returns>
        public int AddRange(params Citic.Model.Linkman[] lms)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Linkman_List(");
            strSql.Append("LinkmanName,Phone,Email,Post,LinkType,RelationID,CreateID,CreateTime,UpdateID,UpdateTime,DeleteID,DeleteTime,IsDelete,IsPort,ConnectID)");
            foreach (Citic.Model.Linkman item in lms)
            {
                strSql.Append(" select ");
                strSql.AppendFormat("'{0}','{1}','{2}','{3}',{4},{5},{6},'{7}',{8},'{9}',{10},'{11}',{12},{13},'{14}'", item.LinkmanName, item.Phone, item.Email, item.Post, item.LinkType, item.RelationID, item.CreateID, item.CreateTime, item.UpdateID, item.UpdateTime, item.DeleteID, item.DeleteTime, item.IsDelete ? 1 : 0, item.IsPort ? 1 : 0, item.ConnectID);
                strSql.AppendLine(" union");
            }
            string where = strSql.ToString().Substring(0, strSql.ToString().LastIndexOf("union"));


            int obj = DbHelperSQL.ExecuteSql(where);
            return obj;
        }
        #endregion

        /// <summary>
        /// 逻辑删除--乔春羽
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Linkman model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE tb_Linkman_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where LinkmanID=@LinkmanID");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkmanID", SqlDbType.Int,4),
                    new SqlParameter("@DeleteID",SqlDbType.Int,4),
                    new SqlParameter("@DeleteTime",SqlDbType.DateTime)
			};
            parameters[0].Value = model.LinkmanID;
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
        /// 批量逻辑删除--乔春羽
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string BankIDList, Citic.Model.Linkman model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_Linkman_List SET IsDelete=1,DeleteID=@DeleteID,DeleteTime=@DeleteTime");
            strSql.Append(" where LinkmanID in (" + BankIDList + ")  ");
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

        #endregion  ExtensionMethod
    }
}

