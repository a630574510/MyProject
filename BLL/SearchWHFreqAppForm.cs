﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
    /// <summary>
    /// SearchWare
    /// </summary>
    public partial class SearchWHFreqAppForm
    {
        private readonly Citic.DAL.SearchWHFreqAppForm dal = new Citic.DAL.SearchWHFreqAppForm();
        public SearchWHFreqAppForm()
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
        public int Add(Citic.Model.SearchWHFreqAppForm model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Citic.Model.SearchWHFreqAppForm model)
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
        public Citic.Model.SearchWHFreqAppForm GetModel(int ID)
        {

            return dal.GetModel(ID);
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
        public List<Citic.Model.SearchWHFreqAppForm> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Citic.Model.SearchWHFreqAppForm> DataTableToList(DataTable dt)
        {
            List<Citic.Model.SearchWHFreqAppForm> modelList = new List<Citic.Model.SearchWHFreqAppForm>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Citic.Model.SearchWHFreqAppForm model;
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
        #region 批量修改--乔春羽(2014.4.28)
        public int UpdateRange(List<Citic.Model.SearchWHFreqAppForm> models, int roleID)
        {
            int num = 0;
            string[] columns = null;
            switch (roleID)
            {
                case 27:    //风控专员
                //columns = new string[] { "ORCD", "ORCD_OptionID", "ORCD_OptionTime", "ID" };
                //break;
                case 28:    //风控经理
                    columns = new string[] { "ORCDStatus", "ORCD", "ORCD_OptionID", "ORCD_OptionTime", "ORCDPIC", "ORCDPIC_OptionID", "ORCDPIC_OptionTime", "ID" };
                    break;
                case 6:     //业务专员
                //columns = new string[] { "OBD", "OBD_OptionID", "OBD_OptionTime", "ID" };
                //break;
                case 3:     //业务经理
                    columns = new string[] { "OBDStatus", "OBD", "OBD_OptionID", "OBD_OptionTime", "OBDPIC", "OBDPIC_OptionID", "OBDPIC_OptionTime", "ID" };
                    break;
                default:
                    return -1;
            }
            num = dal.UpdateRange(models.ToArray(), columns);
            return num;
        }
        #endregion
        #region 把DataRow数据转换为实体类对象--乔春羽(2014.4.28)
        public Citic.Model.SearchWHFreqAppForm DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
        #endregion
        #region 需要导出Excel的数据，此业务比较复杂--乔春羽(2014.4.30)
        public DataSet GetDataGetDataForExcel(string strWhere)
        {
            return dal.GetDataGetDataForExcel(strWhere);
        }
        #endregion
        #endregion  ExtensionMethod
    }
}

