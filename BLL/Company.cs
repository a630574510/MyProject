using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Citic.Model;
namespace Citic.BLL
{
	/// <summary>
	/// Company
	/// </summary>
	public partial class Company
	{
		private readonly Citic.DAL.Company dal=new Citic.DAL.Company();
		public Company()
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
		public bool Exists(int CompanyId)
		{
			return dal.Exists(CompanyId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Citic.Model.Company model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Citic.Model.Company model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CompanyId)
		{
			
			return dal.Delete(CompanyId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CompanyIdlist )
		{
			return dal.DeleteList(CompanyIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Citic.Model.Company GetModel(int CompanyId)
		{
			
			return dal.GetModel(CompanyId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Citic.Model.Company GetModelByCache(int CompanyId)
		{
			
			string CacheKey = "CompanyModel-" + CompanyId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CompanyId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Citic.Model.Company)objModel;
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
		public List<Citic.Model.Company> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Citic.Model.Company> DataTableToList(DataTable dt)
		{
			List<Citic.Model.Company> modelList = new List<Citic.Model.Company>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Citic.Model.Company model;
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

