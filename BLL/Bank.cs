using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// Bank
    /// </summary>
    public partial class Bank
    {
        private readonly Citic.DAL.Bank dal = new Citic.DAL.Bank();
        public Bank()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BankID)
        {
            return dal.Exists(BankID);
        }

        #region 只查询银行的ID与名称--乔春羽
        public DataTable GetBankIDAndBankName(string where)
        {
            return dal.GetBankIDAndBankName(where);
        }
        #endregion
        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Bank model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Bank model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BankID)
        {

            return dal.Delete(BankID);
        }

        /// <summary>
        /// 逻辑删除--乔春羽
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Bank model)
        {
            return dal.DeleteOnLogic(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string BankIDlist)
        {
            return dal.DeleteList(BankIDlist);
        }
        /// <summary>
        /// 批量逻辑删除--乔春羽
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string SupervisorIDList, Citic.Model.Bank model)
        {
            return dal.DeleteListOnLogic(SupervisorIDList, model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Bank GetModel(int BankID)
        {

            return dal.GetModel(BankID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Bank GetModelByCache(int BankID)
        {

            string CacheKey = "BankModel-" + BankID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(BankID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.Bank)objModel;
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
        public List<Citic.Model.Bank> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Bank> DataTableToList(DataTable dt)
        {
            List<Citic.Model.Bank> modelList = new List<Citic.Model.Bank>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Bank model;
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

        #region 执行一条SQL语句--乔春羽(2013.12.11)
        public DataTable Query(string sql)
        {
            return dal.Query(sql);
        }
        #endregion

        #region 获得监管员的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess()
        {
            return dal.GetAllListByProcess();
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

