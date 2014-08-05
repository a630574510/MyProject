using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// Draft
    /// </summary>
    public partial class Draft
    {
        private readonly Citic.DAL.Draft dal = new Citic.DAL.Draft();
        public Draft()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Draft model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Draft model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Draft GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Draft GetModelByCache(int ID)
        {

            string CacheKey = "DraftModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.Draft)objModel;
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
        public List<Citic.Model.Draft> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Draft> DataTableToList(DataTable dt)
        {
            List<Citic.Model.Draft> modelList = new List<Citic.Model.Draft>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Draft model;
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
        /// <summary>
        /// 批量添加--乔春羽
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int AddRange(Citic.Model.Draft[] models)
        {
            return dal.AddRange(models);
        }
        /// <summary>
        /// 检查多个汇票号是否存在--乔春羽
        /// </summary>
        /// <param name="nos"></param>
        /// <returns></returns>
        public bool ExistsDraftNos(string[] nos)
        {
            return dal.ExistsDraftNos(nos);
        }
        /// <summary>
        /// 得到一个对象实体，通过汇票号
        /// </summary>
        public Citic.Model.Draft GetModel(string draftNo)
        {
            return dal.GetModel(draftNo);
        }
        /// <summary>
        /// 批量逻辑删除--乔春羽
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string IDList, Citic.Model.Draft model)
        {
            return dal.DeleteListOnLogic(IDList, model);
        }

        #region 给汇票“清票”--乔春羽(2013.9.5)
        /// <summary>
        /// 给汇票“清票”
        /// </summary>
        /// <param name="draftNo"></param>
        /// <returns></returns>
        public bool DraftClear(string draftNo)
        {
            return dal.DraftClear(draftNo);
        }
        #endregion
        #region 获得汇票的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess(string where)
        {
            return dal.GetAllListByProcess(where);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

