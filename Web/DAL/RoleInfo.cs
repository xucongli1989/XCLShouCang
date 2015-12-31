using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace XCLShouCang.DAL
{
	/// <summary>
	/// 数据访问类:RoleInfo
	/// </summary>
	public partial class RoleInfo
	{
		public RoleInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long RoleInfoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RoleInfo");
			strSql.Append(" where RoleInfoID=@RoleInfoID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleInfoID", SqlDbType.BigInt)
			};
			parameters[0].Value = RoleInfoID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(XCLShouCang.Model.RoleInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RoleInfo(");
			strSql.Append("ParentRoleInfoID,RoleName)");
			strSql.Append(" values (");
			strSql.Append("@ParentRoleInfoID,@RoleName)");
			strSql.Append(";select SCOPE_IDENTITY()");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentRoleInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@RoleName", SqlDbType.VarChar,100)};
			parameters[0].Value = model.ParentRoleInfoID;
			parameters[1].Value = model.RoleName;

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
		public bool Update(XCLShouCang.Model.RoleInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RoleInfo set ");
			strSql.Append("ParentRoleInfoID=@ParentRoleInfoID,");
			strSql.Append("RoleName=@RoleName");
			strSql.Append(" where RoleInfoID=@RoleInfoID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentRoleInfoID", SqlDbType.BigInt,8),
					new SqlParameter("@RoleName", SqlDbType.VarChar,100),
					new SqlParameter("@RoleInfoID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.ParentRoleInfoID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = model.RoleInfoID;

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
		public bool Delete(long RoleInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoleInfo ");
			strSql.Append(" where RoleInfoID=@RoleInfoID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleInfoID", SqlDbType.BigInt)
			};
			parameters[0].Value = RoleInfoID;

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
		public bool DeleteList(string RoleInfoIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoleInfo ");
			strSql.Append(" where RoleInfoID in ("+RoleInfoIDlist + ")  ");
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
		public XCLShouCang.Model.RoleInfo GetModel(long RoleInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleInfoID,ParentRoleInfoID,RoleName from RoleInfo ");
			strSql.Append(" where RoleInfoID=@RoleInfoID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleInfoID", SqlDbType.BigInt)
			};
			parameters[0].Value = RoleInfoID;

			XCLShouCang.Model.RoleInfo model=new XCLShouCang.Model.RoleInfo();
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
		public XCLShouCang.Model.RoleInfo DataRowToModel(DataRow row)
		{
			XCLShouCang.Model.RoleInfo model=new XCLShouCang.Model.RoleInfo();
			if (row != null)
			{
				if(row["RoleInfoID"]!=null && row["RoleInfoID"].ToString()!="")
				{
					model.RoleInfoID=long.Parse(row["RoleInfoID"].ToString());
				}
				if(row["ParentRoleInfoID"]!=null && row["ParentRoleInfoID"].ToString()!="")
				{
					model.ParentRoleInfoID=long.Parse(row["ParentRoleInfoID"].ToString());
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
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
			strSql.Append("select RoleInfoID,ParentRoleInfoID,RoleName ");
			strSql.Append(" FROM RoleInfo ");
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
			strSql.Append(" RoleInfoID,ParentRoleInfoID,RoleName ");
			strSql.Append(" FROM RoleInfo ");
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
			strSql.Append("select count(1) FROM RoleInfo ");
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
				strSql.Append("order by T.RoleInfoID desc");
			}
			strSql.Append(")AS Row, T.*  from RoleInfo T ");
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
			parameters[0].Value = "RoleInfo";
			parameters[1].Value = "RoleInfoID";
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

