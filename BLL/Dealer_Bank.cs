using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using System.Text;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// Dealer_Bank
    /// </summary>
    public partial class Dealer_Bank
    {
        private readonly Citic.DAL.Dealer_Bank dal = new Citic.DAL.Dealer_Bank();
        public Dealer_Bank()
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
        public int Add(Citic.Model.Dealer_Bank model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Dealer_Bank model)
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
        public Citic.Model.Dealer_Bank GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Dealer_Bank GetModelByCache(int ID)
        {

            string CacheKey = "Dealer_BankModel-" + ID;
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
            return (Citic.Model.Dealer_Bank)objModel;
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
        public List<Citic.Model.Dealer_Bank> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Dealer_Bank> DataTableToList(DataTable dt)
        {
            List<Citic.Model.Dealer_Bank> modelList = new List<Citic.Model.Dealer_Bank>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Dealer_Bank model;
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
        #region 获得经销商信息，数据来自“经销商银行合作表”表示该经销商已于银行合作--乔春羽(2013.8.9)
        public DataSet GetDealers(string where)
        {
            return dal.GetDealers(where);
        }
        #endregion
        #region 获得合作行的信息，数据来自“经销商银行合作表”表示该银行是有经销商与之合作的--乔春羽(2013.8.9)
        public DataSet GetBanks(string where)
        {
            return dal.GetBanks(where);
        }
        #endregion
        #region 根据经销商名称获取该经销商的详细信息（包括经销商基本信息、合作行信息、合作品牌信息）--乔春羽
        /// <summary>
        /// 根据经销商名称获取该经销商的详细信息（包括经销商基本信息、合作行信息、合作品牌信息）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDetailList(string strWhere)
        {
            return dal.GetDetailList(strWhere);
        }
        #endregion
        #region 根据银行ID获取经销商的ID--乔春羽
        /// <summary>
        /// 根据银行ID获取经销商的ID
        /// </summary>
        /// <param name="bankID"></param>
        /// <returns></returns>
        public string[] GetDealerIDsByBankID(int bankID)
        {
            DataTable dt = dal.GetDealerIDsByBankID(bankID);
            List<string> dealerids = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                dealerids.Add(row[0].ToString());
            }
            return dealerids.ToArray();
        }
        #endregion
        #region 根据登陆人的角色，来获得与该角色下监管的经销商合作的银行--乔春羽
        /// <summary>
        /// 根据登陆人的角色，来获得与该角色下监管的经销商合作的银行
        /// </summary>
        /// <param name="supervisorID"></param>
        /// <returns></returns>
        public DataSet GetBankIDAndNameFilterRole(int supervisorID)
        {
            return dal.GetBankIDAndNameFilterRole(supervisorID);
        }
        #endregion
        #region 总账查询--乔春羽
        /// <summary>
        /// 总账查询
        /// </summary>
        /// <param name="path">SQL文件存放的路径</param>
        /// <param name="sqlstr">指定要使用哪一条SQL语句</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">一页的开始Index</param>
        /// <param name="endIndex">一页的结束Index</param>
        /// <param name="bankID">选择的银行ID</param>
        /// <param name="tableNames">表名集合</param>
        /// <returns>返回的结果</returns>
        public DataSet LedgerSearch(string path, string sqlstr, string strWhere, string orderby, int startIndex, int endIndex, string[] bankIDs, string[] dealerIDs)
        {
            DataSet ds = null;
            if ((bankIDs != null && bankIDs.Length > 0) && (dealerIDs != null && dealerIDs.Length > 0))
            {
                List<string> tbnames = new List<string>();

                foreach (string bankID in bankIDs)
                {
                    foreach (string dealerID in dealerIDs)
                    {
                        tbnames.Add(string.Format("tb_Car_{0}_{1}", bankID, dealerID));
                    }
                }

                ds = dal.LedgerSearch(path, sqlstr, strWhere, orderby, startIndex, endIndex, tbnames.ToArray());
            }
            else
            {
                ds = new DataSet();
                ds.Tables.Add(new DataTable());
            }
            return ds;
        }
        #endregion
        #region 批量添加--乔春羽
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int AddRange(params Citic.Model.Dealer_Bank[] models)
        {
            return dal.AddRange(models);
        }
        #endregion

        #region 排量修改--乔春羽(2014.3.14)
        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int UpdateRange(params Citic.Model.Dealer_Bank[] models)
        {
            return dal.UpdateRange(models);
        }
        #endregion
        #region 获取“一家店”的所有品牌信息--乔春羽(2013.8.19)
        /// <summary>
        /// 获取“一家店”的所有品牌信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetBrands(string strWhere)
        {
            return dal.GetBrands(strWhere);
        }
        #endregion
        #region 查询与某银行合作的经销商们（只有ID与名称）--乔春羽
        /// <summary>
        /// 查询与某银行合作的经销商们（只有ID与名称）
        /// </summary>
        /// <param name="bankID"></param>
        /// <returns></returns>
        public DataTable GetDealerByBankForDataTable(int bankID, string where)
        {
            return dal.GetDealerByBankForDataTable(bankID, where);
        }
        #endregion
        #region 修改合作状态--乔春羽
        /// <summary>
        /// 修改合作状态
        /// </summary>
        /// <param name="dealerID"></param>
        /// <returns></returns>
        public int ModifyCollaborateType(Citic.Model.Dealer_Bank model)
        {
            return dal.ModifyCollaborateType(model);
        }
        #endregion
        #region 查看合作银行是否以存在--乔春羽
        /// <summary>
        /// 查看合作银行是否以存在
        /// </summary>
        /// <param name="dealerID"></param>
        /// <param name="bankID"></param>
        /// <returns></returns>
        public bool ExistsDealerBank(int dealerID, int bankID)
        {
            return dal.ExistsDealerBank(dealerID, bankID);
        }
        #endregion
        #region 返回“合作行_品牌”格式的数据，根据经销商查询该数据--乔春羽(2013.12.6)
        /// <summary>
        /// 返回“合作行_品牌”格式的数据，根据经销商查询该数据
        /// </summary>
        /// <param name="where">Where条件</param>
        /// <returns></returns>
        public DataTable GetBankBrandBySearch(string where)
        {
            return dal.GetBankBrandBySearch(where).Tables[0];
        }
        #endregion
        #region 查询经销商ID，根据各种条件--乔春羽(2013.12.2)
        public string[] GetDealerIDBySearch(string where)
        {
            List<string> list = new List<string>();
            DataTable dt = dal.GetDealerIDBySearch(where);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["DealerID"].ToString());
            }
            return list.ToArray();
        }
        #endregion
        #region 查询银行ID，根据各种条件--乔春羽(2014.3.25)
        public string[] GetBankIDsBySearch(string where)
        {
            List<string> list = new List<string>();
            DataTable dt = dal.GetBankIDsBySearch(where);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["BankID"].ToString());
            }
            return list.ToArray();
        }
        #endregion
        #region 查询“经销商银行映射表”与“查库频率表”的内联查询数据，SQL语句放在XML文件中--乔春羽(2013.12.6)
        /// <summary>
        /// 查询“经销商银行映射表”与“查库频率表”的内联查询数据
        /// </summary>
        /// <param name="path">SQL文件路径</param>
        /// <param name="sqlstr">SQL命令</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="orderby">排序条件</param>
        /// <param name="startIndex">开始</param>
        /// <param name="endIndex">结束</param>
        /// <returns></returns>
        public DataTable GetDBInnerFrequencyBySearch(string path, string sqlstr, string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetDBInnerFrequencyBySearch(path, sqlstr, strWhere, orderby, startIndex, endIndex).Tables[0];
        }
        #endregion
        #region 获得前几条数据，非固定列--乔春羽(2013.12.6)
        /// <summary>
        /// 获得前几条数据，非固定列
        /// </summary>
        /// <param name="Top">数据数量</param>
        /// <param name="strWhere">Where条件</param>
        /// <param name="groupBy">排序条件</param>
        /// <param name="columns">列名集合</param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string groupBy, params string[] columns)
        {
            return dal.GetList(Top, strWhere, groupBy, columns);
        }
        #endregion
        #region 执行一条SQL语句--乔春羽(2013.12.11)
        public DataTable Query(string sql)
        {
            return dal.Query(sql);
        }
        #endregion
        #region 需要导出Excel的数据（根据需要不同，可能导出一页或者全部的数据），将表头改成了文字，并且联查经销商信息表--乔春羽(2013.12.20)
        public DataTable GetDataForExcel(string[] dealerIDs)
        {
            StringBuilder where = new StringBuilder(string.Empty);
            if (dealerIDs != null && dealerIDs.Length > 0)
            {
                foreach (string dealerID in dealerIDs)
                {
                    where.AppendFormat("'{0}',", dealerID);
                }
                where.Remove(where.Length - 1, 1);
            }
            return dal.GetDataForExcel(where.ToString());
        }
        #endregion
        #region 根据经销商id和银行id查询二网信息
        /// <summary>
        /// 根据经销商id和银行id查询二网信息 张繁 2013年11月22日
        /// </summary>
        /// <param name="BankID"></param>
        /// <param name="DealerID"></param>
        /// <returns></returns>
        public DataSet GetStorageListByDealerIDAndBankID(int BankID, int DealerID)
        {
            return dal.GetStorageListByDealerIDAndBankID(BankID, DealerID);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

