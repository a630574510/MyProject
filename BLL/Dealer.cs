using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// Dealer
    /// </summary>
    public partial class Dealer
    {
        private readonly Citic.DAL.Dealer dal = new Citic.DAL.Dealer();
        public Dealer()
        { }
        #region  BasicMethod

        /// <summary>
        /// 当监管员id为空时，查询所有
        /// 根据监管员id查询银行id，经销商名称，银行名称 张繁 2013年7月24日 
        /// </summary>
        /// <param name="SupervisorID">监管员id</param>
        /// <returns></returns>
        public DataSet GetBankID_DealerID_BankName_List(string SupervisorID)
        {
            return dal.GetBankID_DealerID_BankName_List(SupervisorID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DealerID)
        {
            return dal.Exists(DealerID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Dealer model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Dealer model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int DealerID)
        {

            return dal.Delete(DealerID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string DealerIDlist)
        {
            return dal.DeleteList(DealerIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Dealer GetModel(int DealerID)
        {

            return dal.GetModel(DealerID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Dealer GetModelByCache(int DealerID)
        {

            string CacheKey = "DealerModel-" + DealerID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(DealerID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.Dealer)objModel;
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
        public List<Citic.Model.Dealer> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Dealer> DataTableToList(DataTable dt)
        {
            List<Citic.Model.Dealer> modelList = new List<Citic.Model.Dealer>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Dealer model;
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

        #region 根据DealerID查询经销商名称--乔春羽
        /// <summary>
        /// 根据DealerID查询经销商名称
        /// </summary>
        /// <param name="dealerID"></param>
        /// <returns></returns>
        public string GetDealerNameByID(int dealerID)
        {
            return dal.GetDealerNameByID(dealerID);
        }
        #endregion

        #region 只查询经销商的ID与名称--乔春羽
        public DataTable GetDealerIDAndDealerName(string strWhere)
        {
            return dal.GetDealerIDAndDealerName(strWhere);
        }
        #endregion

        #region 逻辑删除--乔春羽
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Dealer model)
        {
            return dal.DeleteOnLogic(model);
        }
        #endregion

        #region 批量逻辑删除--乔春羽
        /// <summary>
        /// 批量逻辑删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string IDList, Citic.Model.Dealer model)
        {
            return dal.DeleteListOnLogic(IDList, model);
        }
        #endregion

        #region 添加经销商，同时添加该经销商的本库信息--乔春羽（2013.11.25）
        public int CreateDealer(Citic.Model.Dealer dealerModel)
        {
            return dal.CreateDealer(dealerModel);
        }
        #endregion

        #region 给经销商匹配监管员--乔春羽(2013.8.28)
        public bool SuperToDealer(Citic.Model.Dealer model)
        {
            return dal.SuperToDealer(model);
        }
        #endregion

        #region 根据监管员ID，获取经销商的ID号集合。--乔春羽(2013.11.28)
        public string[] GetDealerIDsBySupervisorID(int supervisorID)
        {
            List<string> list = new List<string>();
            DataTable dt = dal.GetDealerIDsBySupervisorID(supervisorID);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["DealerID"].ToString());
            }
            return list.ToArray();
        }
        #endregion

        #region 执行SQL语句，返回DataTable--乔春羽(2013.12.9)
        /// <summary>
        /// 执行一条SQL语句，返回DataTable
        /// </summary>
        /// <param name="path">存放SQL语句的XML文件路径</param>
        /// <param name="sqlStr">SQL命令</param>
        /// <returns></returns>
        public DataTable QuerySqlCommand(string path, string sqlStr, string where)
        {
            return dal.QuerySqlCommand(path, sqlStr, where);
        }
        #endregion

        #endregion  ExtensionMethod
    }
}

