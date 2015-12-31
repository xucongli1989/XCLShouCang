using System;
namespace XCLShouCang.Model
{
	/// <summary>
	/// RoleInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleInfo
	{
		public RoleInfo()
		{}
		#region Model
		private long _roleinfoid;
		private long _parentroleinfoid;
		private string _rolename;
		/// <summary>
		/// 
		/// </summary>
		public long RoleInfoID
		{
			set{ _roleinfoid=value;}
			get{return _roleinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long ParentRoleInfoID
		{
			set{ _parentroleinfoid=value;}
			get{return _parentroleinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		#endregion Model

	}
}

