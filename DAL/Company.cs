using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Citic.DAL
{
	/// <summary>
	/// 数据访问类:Company
	/// </summary>
	public partial class Company
	{
		public Company()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CompanyId", "tb_Company"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CompanyId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Company");
			strSql.Append(" where CompanyId=@CompanyId");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4)
			};
			parameters[0].Value = CompanyId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Citic.Model.Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Company(");
			strSql.Append("CompanyName,CompanyDesc)");
			strSql.Append(" values (");
			strSql.Append("@CompanyName,@CompanyDesc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyDesc", SqlDbType.VarChar,200)};
			parameters[0].Value = model.CompanyName;
			parameters[1].Value = model.CompanyDesc;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Citic.Model.Company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Company set ");
			strSql.Append("CompanyName=@CompanyName,");
			strSql.Append("CompanyDesc=@CompanyDesc");
			strSql.Append(" where CompanyId=@CompanyId");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyDesc", SqlDbType.VarChar,200),
					new SqlParameter("@CompanyId", SqlDbType.Int,4)};
			parameters[0].Value = model.CompanyName;
			parameters[1].Value = model.CompanyDesc;
			parameters[2].Value = model.CompanyId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CompanyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Company ");
			strSql.Append(" where CompanyId=@CompanyId");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4)
			};
			parameters[0].Value = CompanyId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string CompanyIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Company ");
			strSql.Append(" where CompanyId in ("+CompanyIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Citic.Model.Company GetModel(int CompanyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CompanyId,CompanyName,CompanyDesc from tb_Company ");
			strSql.Append(" where CompanyId=@CompanyId");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4)
			};
			parameters[0].Value = CompanyId;

			Citic.Model.Company model=new Citic.Model.Company();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Citic.Model.Company DataRowToModel(DataRow row)
		{
			Citic.Model.Company model=new Citic.Model.Company();
			if (row != null)
			{
				if(row["CompanyId"]!=null && row["CompanyId"].ToString()!="")
				{
					model.CompanyId=int.Parse(row["CompanyId"].ToString());
				}
				if(row["CompanyName"]!=null)
				{
					model.CompanyName=row["CompanyName"].ToString();
				}
				if(row["CompanyDesc"]!=null)
				{
					model.CompanyDesc=row["CompanyDesc"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CompanyId,CompanyName,CompanyDesc ");
			strSql.Append(" FROM tb_Company ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" CompanyId,CompanyName,CompanyDesc ");
			strSql.Append(" FROM tb_Company ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_Company ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.CompanyId desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Company T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_Company";
			parameters[1].Value = "CompanyId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

