using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// 巡店报告
    /// </summary>
    public partial class XDBG
    {
        private readonly Citic.DAL.XDBG dal = new Citic.DAL.XDBG();
        public XDBG()
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
        public int Add(Citic.Model.XDBG model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.XDBG model)
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
        public Citic.Model.XDBG GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.XDBG GetModelByCache(int ID)
        {

            string CacheKey = "XDBGModel-" + ID;
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
            return (Citic.Model.XDBG)objModel;
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
        public List<Citic.Model.XDBG> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.XDBG> DataTableToList(DataTable dt)
        {
            List<Citic.Model.XDBG> modelList = new List<Citic.Model.XDBG>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.XDBG model;
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
        #region 增加一条“巡店报告”数据--乔春羽(2013.12.25)
        /// <summary>
        /// 调用存储过程，添加一条数据，同时还添加一条“记录”
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddXDBG(Citic.Model.XDBG model)
        {
            return dal.AddXDBG(model);
        }
        #endregion
        #region 修改一条“巡店报告”数据--乔春羽(2013.12.25)
        /// <summary>
        /// 调用存储过程，修改一条数据，同时还添加一条“记录”
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateXDBG(Citic.Model.XDBG model)
        {
            return dal.UpdateXDBG(model);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

