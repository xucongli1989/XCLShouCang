using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace XCLShouCang.DAL
{
	/// <summary>
	/// 数据访问类:UserRole
	/// </summary>
	public partial class UserRole
	{
		public UserRole()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserRoleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserRole");
			strSql.Append(" where UserRoleID=@UserRoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserRoleID", SqlDbType.BigInt)
			};
			parameters[0].Value = UserRoleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(XCLShouCang.Model.UserRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserRole(");
			strSql.Append("FK_UserID,FK_RoleInfoID)");
			strSql.Append(" values (");
			strSql.Append("@FK_UserID,@FK_RoleInfoID)");
			strSql.Append(";select SCOPE_IDENTITY()");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.BigInt,8),
					new SqlParameter("@FK_RoleInfoID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.FK_UserID;
			parameters[1].Value = model.FK_RoleInfoID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCLShouCang.Model.UserRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserRole set ");
			strSql.Append("FK_UserID=@FK_UserID,");
			strSql.Append("FK_RoleInfoID=@FK_RoleInfoID");
			strSql.Append(" where UserRoleID=@UserRoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.BigInt,8),
					new SqlParameter("@FK_RoleInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@UserRoleID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.FK_UserID;
			parameters[1].Value = model.FK_RoleInfoID;
			parameters[2].Value = model.UserRoleID;

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
		public bool Delete(long UserRoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserRole ");
			strSql.Append(" where UserRoleID=@UserRoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserRoleID", SqlDbType.BigInt)
			};
			parameters[0].Value = UserRoleID;

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
		public bool DeleteList(string UserRoleIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserRole ");
			strSql.Append(" where UserRoleID in ("+UserRoleIDlist + ")  ");
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
		public XCLShouCang.Model.UserRole GetModel(long UserRoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserRoleID,FK_UserID,FK_RoleInfoID from UserRole ");
			strSql.Append(" where UserRoleID=@UserRoleID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserRoleID", SqlDbType.BigInt)
			};
			parameters[0].Value = UserRoleID;

			XCLShouCang.Model.UserRole model=new XCLShouCang.Model.UserRole();
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
		public XCLShouCang.Model.UserRole DataRowToModel(DataRow row)
		{
			XCLShouCang.Model.UserRole model=new XCLShouCang.Model.UserRole();
			if (row != null)
			{
				if(row["UserRoleID"]!=null && row["UserRoleID"].ToString()!="")
				{
					model.UserRoleID=long.Parse(row["UserRoleID"].ToString());
				}
				if(row["FK_UserID"]!=null && row["FK_UserID"].ToString()!="")
				{
					model.FK_UserID=long.Parse(row["FK_UserID"].ToString());
				}
				if(row["FK_RoleInfoID"]!=null && row["FK_RoleInfoID"].ToString()!="")
				{
					model.FK_RoleInfoID=long.Parse(row["FK_RoleInfoID"].ToString());
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
			strSql.Append("select UserRoleID,FK_UserID,FK_RoleInfoID ");
			strSql.Append(" FROM UserRole ");
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
			strSql.Append(" UserRoleID,FK_UserID,FK_RoleInfoID ");
			strSql.Append(" FROM UserRole ");
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
			strSql.Append("select count(1) FROM UserRole ");
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
				strSql.Append("order by T.UserRoleID desc");
			}
			strSql.Append(")AS Row, T.*  from UserRole T ");
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
			parameters[0].Value = "UserRole";
			parameters[1].Value = "UserRoleID";
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

