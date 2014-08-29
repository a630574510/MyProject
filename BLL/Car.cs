using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// Car
    /// </summary>
    public partial class Car
    {
        private readonly Citic.DAL.Car dal = new Citic.DAL.Car();
        public Car()
        { }
        #region  BasicMethod

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。 张繁 2013年7月22日 
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        /// <returns></returns>
        public int SqlTran(List<String> SQLStringList)
        {
            return dal.SqlTran(SQLStringList);
        }
        /// <summary>
        /// 根据sql查询返回集合 张繁 2013年8月21日
        /// </summary>
        public DataSet GetList(string strSql)
        {
            return dal.GetList(strSql);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Vin, string tb_Name)
        {
            return dal.Exists(Vin, tb_Name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Citic.Model.Car model, string tb_Name)
        {
            return dal.Add(model, tb_Name);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.Car model, string tb_Name)
        {
            return dal.Update(model, tb_Name);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Vin, string tb_Name)
        {

            return dal.Delete(Vin, tb_Name);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Vinlist, string tb_Name)
        {
            return dal.DeleteList(Vinlist, tb_Name);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Citic.Model.Car GetModel(string Vin, string tb_Name)
        {

            return dal.GetModel(Vin, tb_Name);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Citic.Model.Car GetModelByCache(string Vin, string tb_Name)
        {

            string CacheKey = "CarModel-" + Vin;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Vin, tb_Name);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Citic.Model.Car)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string tb_Name)
        {
            return dal.GetList(strWhere, tb_Name);
        }
        /// <summary>
        /// 获得数据列表 前多少条 2014年5月23日
        /// </summary>
        public DataSet GetList(string strWhere, string tb_Name, int Top)
        {
            return dal.GetList(strWhere, tb_Name, Top);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder, string tb_Name)
        {
            return dal.GetList(Top, strWhere, filedOrder, tb_Name);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Car> GetModelList(string strWhere, string tb_Name)
        {
            DataSet ds = dal.GetList(strWhere, tb_Name);
            return DataTableToList(ds.Tables[0], tb_Name);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.Car> DataTableToList(DataTable dt, string tb_Name)
        {
            List<Citic.Model.Car> modelList = new List<Citic.Model.Car>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.Car model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n], tb_Name);
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
        public DataSet GetAllList(string where, string tb_Name)
        {
            return GetList(where, tb_Name);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere, string tb_Name)
        {
            return dal.GetRecordCount(strWhere, tb_Name);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string tb_Name)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, tb_Name);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        #region 显示一个经销商下的所有质押物的详细信息，包括其所属的汇票--乔春羽(2013.7.19)
        /// <summary>
        ///  显示一个经销商下的所有质押物的详细信息，包括其所属的汇票
        /// </summary>
        /// <param name="strWhere">SQL语句Where条件</param>
        /// <param name="orderby">排序列</param>
        /// <param name="startIndex">开始下标位</param>
        /// <param name="endIndex">结束下标位</param>
        /// <param name="tb_Name">要查询的表名</param>
        /// <param name="path">文件路径</param>
        /// <param name="sqlCmd">要调用的SQL语句</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string tb_Name, string path, string sqlCmd)
        {
            DataSet ds = null;
            ds = dal.GetListByPage(strWhere, string.Empty, startIndex, endIndex, tb_Name, path, sqlCmd);
            if (ds == null || ds.Tables.Count == 0)
            {
                ds = new DataSet();
                ds.Tables.Add(new DataTable());
            }
            return ds;
        }

        #endregion
        #region 根据输入的列名返回该列下的结果--乔春羽(2013.8.9)
        /// <summary>
        /// 根据输入的列名返回该列下的结果
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="vin">车架号</param>
        /// <param name="columns">动态数据参数</param>
        /// <returns></returns>
        public DataSet GetValueByColumns(string tableName, string vin, params string[] columns)
        {
            return dal.GetValueByColumns(tableName, vin, columns);
        }
        #endregion
        #region 获得一家店质押物的所有信息，替换了所有的数字字段--乔春羽(2013.12.27)
        public DataSet GetAllListByProcess(string strWhere, string tbName)
        {
            return dal.GetAllListByProcess(strWhere, tbName);
        }
        #endregion
        #region 批量修改质押物的状态，走“待办事项”操作--乔春羽(2013.12.30)
        /// <summary>
        /// 批量修改质押物的状态，走“待办事项”操作
        /// </summary>
        /// <param name="Models"></param>
        /// <returns></returns>
        public int UpdateRange(Citic.Model.Car[] Models)
        {
            return dal.UpdateRange(Models);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

