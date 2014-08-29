using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// Supervisor
    /// </summary>
    public partial class Supervisor
    {
        private readonly Citic.DAL.Supervisor dal = new Citic.DAL.Supervisor();
        public Supervisor()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SupervisorID)
        {
            return dal.Exists(SupervisorID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Citic.Model.Supervisor model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Supervisor model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SupervisorID)
        {

            return dal.Delete(SupervisorID);
        }
        /// <summary>
        /// 逻辑删除--乔春羽
        /// </summary>
        /// <param name="SupervisorID"></param>
        /// <returns></returns>
        public bool DeleteOnLogic(Citic.Model.Supervisor model)
        {
            return dal.DeleteOnLogic(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SupervisorIDlist)
        {
            return dal.DeleteList(SupervisorIDlist);
        }
        /// <summary>
        /// 批量逻辑删除--乔春羽
        /// </summary>
        /// <returns></returns>
        public bool DeleteListOnLogic(string SupervisorIDList, Citic.Model.Supervisor model)
        {
            return dal.DeleteListOnLogic(SupervisorIDList, model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Supervisor GetModel(int SupervisorID)
        {

            return dal.GetModel(SupervisorID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Supervisor GetModelByCache(int SupervisorID)
        {

            string CacheKey = "SupervisorModel-" + SupervisorID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SupervisorID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.Supervisor)objModel;
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
        public List<Citic.Model.Supervisor> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Supervisor> DataTableToList(DataTable dt)
        {
            List<Citic.Model.Supervisor> modelList = new List<Citic.Model.Supervisor>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Supervisor model;
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
        #region 获得没有关联用户的监管员信息--乔春羽
        /// <summary>
        /// 获得没有关联用户的监管员信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSupervisorWithoutUser(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetSupervisorWithoutUser(strWhere, orderby, startIndex, endIndex);
        }
        #endregion

        #region 创建监管员，同时创建一个账号。--乔春羽(2013.11.27)
        public int CreateSupervisor(Citic.Model.Supervisor model)
        {
            return dal.CreateSupervisor(model);
        }
        #endregion

        #region 修改监管员的信息，同时也修改监管员对应账号的信息。--乔春羽(2013.11.28)
        public int ModifySupervisor(Citic.Model.Supervisor model)
        {
            return dal.ModifySupervisor(model);
        }
        #endregion

        #region 检查监管员的名字是否已经存在--乔春羽(2013.11.27)
        public bool CheckNameIsExists(string name)
        {
            bool flag = false;
            DataSet ds = dal.GetList(string.Format(" SupervisorName='{0}'", name));
            if (ds != null && ds.Tables.Count > 0)
            {
                flag = ds.Tables[0].Rows.Count > 0;
            }
            return flag;
        }
        #endregion

        #region 根据监管员ID得到一个实体对象，该对象中包含此监管员的登录账户的密码。--乔春羽(2013.11.28)
        /// <summary>
        /// 根据监管员ID得到一个实体对象，该对象中包含此监管员的登录账户的密码。
        /// </summary>
        /// <param name="supervisorID"></param>
        /// <returns></returns>
        public Citic.Model.Supervisor GetSupervisorWithCode(int supervisorID)
        {
            return dal.GetSupervisorWithCode(supervisorID);
        }
        #endregion

        #region 获得监管员的所有信息，替换了所有的数字字段--乔春羽(2013.12.20)
        public DataSet GetAllListByProcess(string where, int startIndex, int endIndex)
        {
            return dal.GetAllListByProcess(where, startIndex, endIndex);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

