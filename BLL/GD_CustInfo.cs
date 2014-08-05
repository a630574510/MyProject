using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// GD_CustInfo
    /// </summary>
    public partial class GD_CustInfo
    {
        private readonly Citic.DAL.GD_CustInfo dal = new Citic.DAL.GD_CustInfo();
        public GD_CustInfo()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal CUST_ID)
        {
            return dal.Exists(CUST_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Citic.Model.GD_CustInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.GD_CustInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal CUST_ID)
        {

            return dal.Delete(CUST_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CUST_IDlist)
        {
            return dal.DeleteList(CUST_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.GD_CustInfo GetModel(decimal CUST_ID)
        {

            return dal.GetModel(CUST_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.GD_CustInfo GetModelByCache(decimal CUST_ID)
        {

            string CacheKey = "GD_CustInfoModel-" + CUST_ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CUST_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.GD_CustInfo)objModel;
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
        public List<Citic.Model.GD_CustInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.GD_CustInfo> DataTableToList(DataTable dt)
        {
            List<Citic.Model.GD_CustInfo> modelList = new List<Citic.Model.GD_CustInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.GD_CustInfo model;
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
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

