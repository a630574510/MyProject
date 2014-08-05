using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// RiskQuestion
    /// </summary>
    public partial class RiskQuestion
    {
        private readonly Citic.DAL.RiskQuestion dal = new Citic.DAL.RiskQuestion();
        public RiskQuestion()
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
        public int Add(Citic.Model.RiskQuestion model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.RiskQuestion model)
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
        public Citic.Model.RiskQuestion GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.RiskQuestion GetModelByCache(int ID)
        {

            string CacheKey = "RiskQuestionModel-" + ID;
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
            return (Citic.Model.RiskQuestion)objModel;
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
        public List<Citic.Model.RiskQuestion> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.RiskQuestion> DataTableToList(DataTable dt)
        {
            List<Citic.Model.RiskQuestion> modelList = new List<Citic.Model.RiskQuestion>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.RiskQuestion model;
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
        #region 批量添加--乔春羽(2013.12.9)
        public int AddRange(params Citic.Model.RiskQuestion[] models)
        {
            return dal.AddRange(models);
        }
        #endregion
        #region 批量更新--乔春羽(2013.12.9)
        public int UpdateRange(params Citic.Model.RiskQuestion[] models)
        {
            return dal.UpdateRange(models);
        }
        #endregion
        #region 分页获得数据列表--乔春羽(2013.8.6)
        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">开始下表</param>
        /// <param name="endIndex">结束下表</param>
        /// <param name="cols">要查询的列</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, params string[] cols)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, cols);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

