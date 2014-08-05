using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
using System.Text;
namespace Citic.BLL
{
    /// <summary>
    /// Storage
    /// </summary>
    public partial class Storage
    {
        private readonly Citic.DAL.Storage dal = new Citic.DAL.Storage();
        public Storage()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StorageID)
        {
            return dal.Exists(StorageID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Storage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Storage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int StorageID)
        {

            return dal.Delete(StorageID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string StorageIDlist)
        {
            return dal.DeleteList(StorageIDlist);
        }
        /// <summary>
        /// 逻辑删除--乔春羽
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Storage model)
        {
            return false;
        }

        /// <summary>
        /// 批量逻辑删除--乔春羽
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string IDList, Citic.Model.Storage model)
        {
            return dal.DeletesOnLogic(IDList, model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Storage GetModel(int StorageID)
        {

            return dal.GetModel(StorageID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Storage GetModelByCache(int StorageID)
        {

            string CacheKey = "StorageModel-" + StorageID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(StorageID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.Storage)objModel;
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
        public List<Citic.Model.Storage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Storage> DataTableToList(DataTable dt)
        {
            List<Citic.Model.Storage> modelList = new List<Citic.Model.Storage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Storage model;
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

        #region 添加二网信息，顺便带上二网的联系人--乔春羽(2013.11.29)
        public int CreateStorage(Citic.Model.Storage model)
        {
            return dal.CreateStorage(model);
        }
        #endregion

        #region 获得一个二网信息，该二网信息中还带有联系人的信息--乔春羽(2013.11.29)
        public Citic.Model.Storage GetStorageWithLinkman(int storageID)
        {
            return dal.GetStorageWithLinkman(storageID);
        }
        #endregion

        #region 修改二网信息，顺带修改二网的联系人信息--乔春羽(2013.11.29)
        public int ModifyStorage(Citic.Model.Storage model)
        {
            return dal.ModifyStorage(model);
        }
        #endregion

        #region 获得二网的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess()
        {
            return dal.GetAllListByProcess();
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

