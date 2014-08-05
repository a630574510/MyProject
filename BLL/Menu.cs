using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
using System.Text;
namespace Citic.BLL
{
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu
    {
        private readonly Citic.DAL.Menu dal = new Citic.DAL.Menu();
        public Menu()
        { }
        #region  BasicMethod
        public string GetLeftMenuForRoleId(string RoleId)
        {
            DataSet ds = dal.GetLeftMenuForRoleId(RoleId);
            StringBuilder xml = new StringBuilder();
            DataTable newdt = new DataTable();
            newdt = ds.Tables[0].Clone();
            DataRow[] rows = ds.Tables[0].Select("ParentMenu = 0 AND IsNavigation = 1", "MenuOrder ASC");
            foreach (DataRow row in rows)  // 将查询的结果添加到dt中；
            {
                newdt.Rows.Add(row.ItemArray);
            }
            xml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n");
            xml.Append("<Tree>");

            for (int i = 0; i < newdt.Rows.Count; i++)
            {
                DataTable newdtZi = new DataTable();
                newdtZi = ds.Tables[0].Clone();
                DataRow[] rowsZi = ds.Tables[0].Select("ParentMenu = " + newdt.Rows[i]["MenuId"] + " AND IsNavigation = 1");
                foreach (DataRow rowZi in rowsZi)  // 将查询的结果添加到dt中；
                {
                    newdtZi.Rows.Add(rowZi.ItemArray);
                }
                xml.Append("<TreeNode Text=\"" + newdt.Rows[i]["MenuName"] + "\" SingleClickExpand=\"true\">");
                for (int j = 0; j < newdtZi.Rows.Count; j++)
                {
                    xml.Append("<TreeNode Text=\"" + newdtZi.Rows[j]["MenuName"] + "\" NavigateUrl=\"" + newdtZi.Rows[j]["MenuUrl"] + "\"></TreeNode>\r\n");
                }
                xml.Append("</TreeNode >\r\n");
            }

            // xml.AppendLine(BuildMenuXML(0, ds.Tables[0]));

            xml.Append("</Tree>");
            return xml.ToString();
        }

        public string BuildMenuXML(int parentID, DataTable dt)
        {
            StringBuilder xml = new StringBuilder();
            DataTable newDt = dt.Clone();
            DataRow[] rows = dt.Select(" ParentMenu=" + parentID + " AND IsNavigation = 1");
            foreach (DataRow item in rows)
            {
                newDt.Rows.Add(item.ItemArray);
            }
            foreach (DataRow row in newDt.Rows)
            {
                xml.AppendLine("<TreeNode Text=\"" + row["MenuName"] + "\" SingleClickExpand=\"true\"  NavigateUrl=\"" + row["MenuUrl"] + "\">");
                xml.AppendLine(BuildMenuXML(Convert.ToInt32(row["ParentMenu"]), dt));
                xml.AppendLine("</TreeNode>");
            }
            return xml.ToString();
        }

        public DataSet GetMenusByRoleID(string roleID)
        {
            return dal.GetLeftMenuForRoleId(roleID);
        }

        public DataSet GetMenusByRoleID(string roleID, bool isNavigation)
        {
            DataSet ds = dal.GetLeftMenuForRoleId(roleID);
            DataSet result = new DataSet();
            DataTable dt = ds.Tables[0].Clone();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (Convert.ToBoolean(row["isNavigation"]) == isNavigation)
                {
                    dt.Rows.Add(row.ItemArray);
                }
            }
            result.Tables.Add(dt);
            return result;
        }

        /// <summary>
        /// 获得级联菜单列表
        /// </summary>
        public DataSet GetListForParent(string strWhere)
        {
            return dal.GetListForParent(strWhere);
        }
        /// <summary>
        /// 根据名字是否存在该记录
        /// </summary>
        public bool Exists(string MenuName)
        {
            return dal.Exists(MenuName);
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MenuId)
        {
            return dal.Exists(MenuId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Menu model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Menu model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MenuId)
        {

            return dal.Delete(MenuId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string MenuIdlist)
        {
            return dal.DeleteList(MenuIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Menu GetModel(int MenuId)
        {

            return dal.GetModel(MenuId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Menu GetModelByCache(int MenuId)
        {

            string CacheKey = "MenuModel-" + MenuId;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(MenuId);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.Menu)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Menu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Menu> DataTableToList(DataTable dt)
        {
            List<Citic.Model.Menu> modelList = new List<Citic.Model.Menu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Menu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

