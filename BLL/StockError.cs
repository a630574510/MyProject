using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// 日查库信息
    /// </summary>
    public partial class StockError
    {
        private readonly Citic.DAL.StockError dal = new Citic.DAL.StockError();
        public StockError()
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
        public int Add(Citic.Model.StockError model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.StockError model)
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
        public Citic.Model.StockError GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.StockError GetModelByCache(int ID)
        {

            string CacheKey = "StockErrorModel-" + ID;
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
            return (Citic.Model.StockError)objModel;
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
        public List<Citic.Model.StockError> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.StockError> DataTableToList(DataTable dt)
        {
            List<Citic.Model.StockError> modelList = new List<Citic.Model.StockError>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.StockError model;
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
        public DataSet GetListByPage(string strWhere, string tbName, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, tbName, orderby, startIndex, endIndex);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #region 导出Excel--乔春羽(2014.1.17)
        public DataTable GetAllProcess(string where)
        {
            return dal.GetAllProcess(where);
        }
        #endregion
        #region 根据合作行ID与经销商ID查询车架号--乔春羽(2013.8.14)
        /// <summary>
        /// 根据合作行ID与经销商ID查询车架号
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public string GetVinsByBankIDAndDealerID(int bankID, int dealerID, string errorOther)
        {
            DataSet ds = null;
            string result = string.Empty;
            string strWhere = string.Format("BankID={0} and DealerID={1} and ErrorOther='{2}'", bankID, dealerID, errorOther);
            ds = dal.GetVinsByBankIDAndDealerID(strWhere);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder sbuilder = new StringBuilder();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sbuilder.AppendLine(row["Vin"].ToString());
                    }
                    result = sbuilder.ToString();
                }
            }
            return result;
        }
        #endregion
        #region 根据合作行ID与经销商ID查询车架号--乔春羽(2013.8.15)
        /// <summary>
        /// 根据合作行ID与经销商ID查询车架号
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public string[] GetVinsByBankIDAndDealerIDForArray(int bankID, int dealerID, string errorOther)
        {
            DataSet ds = null;
            string[] result = null;
            string strWhere = string.Format("BankID={0} and DealerID={1} and ErrorOther='{2}'", bankID, dealerID, errorOther);
            ds = dal.GetVinsByBankIDAndDealerID(strWhere);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    result = new string[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        result[i] = ds.Tables[0].Rows[i]["Vin"].ToString();
                    }
                }
            }
            return result;
        }
        #endregion
        #region 车辆异常统计查询--乔春羽(2013.8.14)
        /// <summary>
        /// 车辆异常统计查询
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="sqlstr">SQL命令</param>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet CarErrorSearch(string path, string sqlstr, string strWhere)
        {
            return dal.CarErrorSearch(path, sqlstr, strWhere);
        }
        #endregion
        #region 日车库异常汇总查询--乔春羽(2013.8.7)
        /// <summary>
        /// 日车库异常汇总查询
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="sqlstr">SQL命令</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">分页的开始下标</param>
        /// <param name="endIndex">分页的结束下标</param>
        /// <returns></returns>
        public DataSet StockErrorReportSearch(string path, string sqlstr, string strWhere, int startIndex, int endIndex)
        {
            return dal.StockErrorReportSearch(path, sqlstr, strWhere, startIndex, endIndex);
        }
        #endregion
        #region 批量更新，解除异常--乔春羽(2013.12.23)
        public int UpdateErrorStatusRange(string[] ids, int userid)
        {
            int num = 0;
            string value = string.Empty;
            foreach (string id in ids)
            {
                value += string.Format("'{0}',", id);
            }
            value = value.Remove(value.Length - 1, 1);
            num = dal.UpdateErrorStatusRange(value, userid);
            return num;
        }
        #endregion
#region 获得“日查库异常汇总”数据数量--乔春羽(2014.2.20)
        public int GetStockErrorCount(string strWhere)
        {
            return dal.GetStockErrorCount(strWhere);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

