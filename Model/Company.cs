using System;
namespace Citic.Model
{
	/// <summary>
	/// Company:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Company
	{
		public Company()
		{}
		#region Model
		private int _companyid;
		private string _companyname;
		private string _companydesc;
		/// <summary>
		/// 
		/// </summary>
		public int CompanyId
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyDesc
		{
			set{ _companydesc=value;}
			get{return _companydesc;}
		}
		#endregion Model

	}
}

