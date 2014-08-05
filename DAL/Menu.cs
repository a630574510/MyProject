using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
	/// <summary>
	/// 数据访问类:Menu
	/// </summary>
	public partial class Menu
	{
		public Menu()
		{}
		#region  BasicMethod
        /// <summary>
        /// 根据RoleId获取侧边栏数据 2013.4.17 罗振南
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public DataSet GetLeftMenuForRoleId(string RoleId)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select tm.MenuId,tm.MenuName,tm.ParentMenu,tm.MenuOrder,tm.MenuUrl,tm.IsNavigation from tb_Menu tm ");
            strSql.Append(" inner join (select distinct(MenuId) From tb_UserPermission tu where RoleId = (" + RoleId + ")) tb on tm.MenuId=tb.MenuId");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得级联菜单列表
        /// </summary>
        public DataSet GetListForParent(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.MenuName ParentName,b.MenuName ,b.MenuId,b.MenuUrl,b.ParentMenu,b.IsNavigation,b.MenuOrder ");
            strSql.Append(" FROM tb_Menu a Right JOin tb_Menu b on a.MenuId =b.ParentMenu ");
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
		return DbHelperSQL.GetMaxID("MenuId", "tb_Menu"); 
		}
        /// <summary>
        /// 根据名字是否存在该记录
        /// </summary>
        public bool Exists(string MenuName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Menu");
            strSql.Append(" where MenuName=@MenuName");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.VarChar,50)
			};
            parameters[0].Value = MenuName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Menu");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Menu(");
            strSql.Append("MenuName,MenuUrl,ParentMenu,IsNavigation,MenuOrder)");
            strSql.Append(" values (");
            strSql.Append("@MenuName,@MenuUrl,@ParentMenu,@IsNavigation,@MenuOrder)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.VarChar,200),
					new SqlParameter("@ParentMenu", SqlDbType.Int,4),
					new SqlParameter("@IsNavigation", SqlDbType.Bit,1),
					new SqlParameter("@MenuOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuName;
            parameters[1].Value = model.MenuUrl;
            parameters[2].Value = model.ParentMenu;
            parameters[3].Value = model.IsNavigation;
            parameters[4].Value = model.MenuOrder;

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
        public bool Update(Citic.Model.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Menu set ");
            strSql.Append("MenuName=@MenuName,");
            strSql.Append("MenuUrl=@MenuUrl,");
            strSql.Append("ParentMenu=@ParentMenu,");
            strSql.Append("IsNavigation=@IsNavigation,");
            strSql.Append("MenuOrder=@MenuOrder");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.VarChar,50),
					new SqlParameter("@MenuUrl", SqlDbType.VarChar,200),
					new SqlParameter("@ParentMenu", SqlDbType.Int,4),
					new SqlParameter("@IsNavigation", SqlDbType.Bit,1),
					new SqlParameter("@MenuOrder", SqlDbType.Int,4),
					new SqlParameter("@MenuId", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuName;
            parameters[1].Value = model.MenuUrl;
            parameters[2].Value = model.ParentMenu;
            parameters[3].Value = model.IsNavigation;
            parameters[4].Value = model.MenuOrder;
            parameters[5].Value = model.MenuId;

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
        public bool Delete(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Menu ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;

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
        public bool DeleteList(string MenuIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Menu ");
            strSql.Append(" where MenuId in (" + MenuIdlist + ")  ");
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
        public Citic.Model.Menu GetModel(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MenuId,MenuName,MenuUrl,ParentMenu,IsNavigation,MenuOrder from tb_Menu ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;

            Citic.Model.Menu model = new Citic.Model.Menu();
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
        public Citic.Model.Menu DataRowToModel(DataRow row)
        {
            Citic.Model.Menu model = new Citic.Model.Menu();
            if (row != null)
            {
                if (row["MenuId"] != null && row["MenuId"].ToString() != "")
                {
                    model.MenuId = int.Parse(row["MenuId"].ToString());
                }
                if (row["MenuName"] != null)
                {
                    model.MenuName = row["MenuName"].ToString();
                }
                if (row["MenuUrl"] != null)
                {
                    model.MenuUrl = row["MenuUrl"].ToString();
                }
                if (row["ParentMenu"] != null && row["ParentMenu"].ToString() != "")
                {
                    model.ParentMenu = int.Parse(row["ParentMenu"].ToString());
                }
                if (row["IsNavigation"] != null && row["IsNavigation"].ToString() != "")
                {
                    if ((row["IsNavigation"].ToString() == "1") || (row["IsNavigation"].ToString().ToLower() == "true"))
                    {
                        model.IsNavigation = true;
                    }
                    else
                    {
                        model.IsNavigation = false;
                    }
                }
                if (row["MenuOrder"] != null && row["MenuOrder"].ToString() != "")
                {
                    model.MenuOrder = int.Parse(row["MenuOrder"].ToString());
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
            strSql.Append("select MenuId,MenuName,MenuUrl,ParentMenu,IsNavigation,MenuOrder ");
            strSql.Append(" FROM tb_Menu ");
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
            strSql.Append(" MenuId,MenuName,MenuUrl,ParentMenu,IsNavigation,MenuOrder ");
            strSql.Append(" FROM tb_Menu ");
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
            strSql.Append("select count(1) FROM tb_Menu ");
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
                strSql.Append("order by T.MenuId desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Menu T ");
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
            parameters[0].Value = "tb_Menu";
            parameters[1].Value = "MenuId";
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

