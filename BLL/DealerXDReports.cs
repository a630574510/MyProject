using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// DealerXDReports
    /// </summary>
    public partial class DealerXDReports
    {
        private readonly Citic.DAL.DealerXDReports dal = new Citic.DAL.DealerXDReports();
        public DealerXDReports()
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
        public int Add(Citic.Model.DealerXDReports model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.DealerXDReports model)
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
        public Citic.Model.DealerXDReports GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.DealerXDReports GetModelByCache(int ID)
        {

            string CacheKey = "DealerXDReportsModel-" + ID;
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
            return (Citic.Model.DealerXDReports)objModel;
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
        public List<Citic.Model.DealerXDReports> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.DealerXDReports> DataTableToList(DataTable dt)
        {
            List<Citic.Model.DealerXDReports> modelList = new List<Citic.Model.DealerXDReports>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.DealerXDReports model;
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
        #region 更新基本信息--乔春羽(2013.7.30)
        /// <summary>
        /// 更新基本信息
        /// </summary>
        public bool UpdateBasic(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateBasic(model);
        }
        #endregion
        #region 更新检查内容信息--乔春羽(2013.7.30)
        /// <summary>
        /// 更新检查内容信息
        /// </summary>
        public bool UpdateCCS(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateCCS(model);
        }
        #endregion
        #region 更新检查过程中发现的问题--乔春羽(2013.7.30)
        /// <summary>
        /// 更新检查过程中发现的问题
        /// </summary>
        public bool UpdatePIC(Citic.Model.DealerXDReports model)
        {
            return dal.UpdatePIC(model);
        }
        #endregion
        #region 更新监管员优缺点--乔春羽(2013.7.30)
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSGAB(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateSGAB(model);
        }
        #endregion
        #region 更新与店方沟通情况--乔春羽(2013.7.30)
        /// <summary>
        /// 更新与店方沟通情况
        /// </summary>
        public bool UpdateCWS(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateCWS(model);
        }
        #endregion
        #region 更新检查结果--乔春羽(2013.7.30)
        /// <summary>
        /// 更新检查结果
        /// </summary>
        public bool UpdateCheckResult(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateCheckResult(model);
        }
        #endregion
        #region 更新监管员基本情况--乔春羽(2013.7.30)
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateBIS(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateBIS(model);
        }
        #endregion
        #region 更新店面照片--乔春羽(2013.8.5)
        /// <summary>
        /// 更新店面照片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateP(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateP(model);
        }
        #endregion 
        #region 提交巡店报告--乔春羽（2013.8.5）
        /// <summary>
        /// 提交巡店报告
        /// </summary>
        public bool UpdateEnd(Citic.Model.DealerXDReports model)
        {
            return dal.UpdateEnd(model);
        }
        #endregion
        #region 分页获得数据列表--乔春羽(2013.8.5)
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

