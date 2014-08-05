using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
	/// <summary>
	/// UserLog
	/// </summary>
	public partial class UserLog
	{
		private readonly Citic.DAL.UserLog dal=new Citic.DAL.UserLog();
		public UserLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LogId)
		{
			return dal.Exists(LogId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Citic.Model.UserLog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Citic.Model.UserLog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LogId)
		{
			
			return dal.Delete(LogId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LogIdlist )
		{
			return dal.DeleteList(LogIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Citic.Model.UserLog GetModel(int LogId)
		{
			
			return dal.GetModel(LogId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Citic.Model.UserLog GetModelByCache(int LogId)
		{
			
			string CacheKey = "UserLogModel-" + LogId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(LogId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Citic.Model.UserLog)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Citic.Model.UserLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Citic.Model.UserLog> DataTableToList(DataTable dt)
		{
			List<Citic.Model.UserLog> modelList = new List<Citic.Model.UserLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Citic.Model.UserLog model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

		#endregion  ExtensionMethod
	}
}

