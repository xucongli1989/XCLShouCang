using System;
namespace XCLShouCang.Model
{
	/// <summary>
	/// UserRole:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserRole
	{
		public UserRole()
		{}
		#region Model
		private long _userroleid;
		private long _fk_userid;
		private long _fk_roleinfoid;
		/// <summary>
		/// 
		/// </summary>
		public long UserRoleID
		{
			set{ _userroleid=value;}
			get{return _userroleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long FK_UserID
		{
			set{ _fk_userid=value;}
			get{return _fk_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long FK_RoleInfoID
		{
			set{ _fk_roleinfoid=value;}
			get{return _fk_roleinfoid;}
		}
		#endregion Model

	}
}

