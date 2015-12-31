using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace XCLShouCang.DAL
{
    /// <summary>
    /// 数据访问类:v_WebType
    /// </summary>
    public partial class v_WebType
    {
        public v_WebType()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long WebTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_WebType");
            strSql.Append(" where WebTypeID=@WebTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WebTypeID", SqlDbType.BigInt,8)			};
            parameters[0].Value = WebTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLShouCang.Model.v_WebType GetModel(long WebTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WebTypeID,ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsShare,IsFolder,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel,IsHasChildWebType,FK_UserName from v_WebType ");
            strSql.Append(" where WebTypeID=@WebTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WebTypeID", SqlDbType.BigInt,8)			};
            parameters[0].Value = WebTypeID;

            XCLShouCang.Model.v_WebType model = new XCLShouCang.Model.v_WebType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public XCLShouCang.Model.v_WebType DataRowToModel(DataRow row)
        {
            XCLShouCang.Model.v_WebType model = new XCLShouCang.Model.v_WebType();
            if (row != null)
            {
                if (row["WebTypeID"] != null && row["WebTypeID"].ToString() != "")
                {
                    model.WebTypeID = long.Parse(row["WebTypeID"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["WebTypeGid"] != null)
                {
                    model.WebTypeGid = row["WebTypeGid"].ToString();
                }
                if (row["ParentGid"] != null)
                {
                    model.ParentGid = row["ParentGid"].ToString();
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["TypeURL"] != null)
                {
                    model.TypeURL = row["TypeURL"].ToString();
                }
                if (row["TypeDescription"] != null)
                {
                    model.TypeDescription = row["TypeDescription"].ToString();
                }
                if (row["IcoURL"] != null)
                {
                    model.IcoURL = row["IcoURL"].ToString();
                }
                if (row["FK_UserID"] != null && row["FK_UserID"].ToString() != "")
                {
                    model.FK_UserID = long.Parse(row["FK_UserID"].ToString());
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = long.Parse(row["Sort"].ToString());
                }
                if (row["IsShare"] != null && row["IsShare"].ToString() != "")
                {
                    model.IsShare = int.Parse(row["IsShare"].ToString());
                }
                if (row["IsFolder"] != null && row["IsFolder"].ToString() != "")
                {
                    model.IsFolder = int.Parse(row["IsFolder"].ToString());
                }
                if (row["IsReadOnly"] != null && row["IsReadOnly"].ToString() != "")
                {
                    model.IsReadOnly = int.Parse(row["IsReadOnly"].ToString());
                }
                if (row["CreatorName"] != null)
                {
                    model.CreatorName = row["CreatorName"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateName"] != null)
                {
                    model.UpdateName = row["UpdateName"].ToString();
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(row["IsDel"].ToString());
                }
                if (row["IsHasChildWebType"] != null && row["IsHasChildWebType"].ToString() != "")
                {
                    model.IsHasChildWebType = int.Parse(row["IsHasChildWebType"].ToString());
                }
                if (row["FK_UserName"] != null)
                {
                    model.FK_UserName = row["FK_UserName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WebTypeID,ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsShare,IsFolder,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel,IsHasChildWebType,FK_UserName ");
            strSql.Append(" FROM v_WebType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" WebTypeID,ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsShare,IsFolder,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel,IsHasChildWebType,FK_UserName ");
            strSql.Append(" FROM v_WebType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM v_WebType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.WebTypeID desc");
            }
            strSql.Append(")AS Row, T.*  from v_WebType T ");
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
            parameters[0].Value = "v_WebType";
            parameters[1].Value = "WebTypeID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public DataTable GetList(long parentID,long userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM dbo.v_WebType WHERE ParentID=@ParentID and FK_UserID=@FK_UserID
                                    ORDER BY IsFolder DESC ,Sort ASC");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
	                new SqlParameter("@FK_UserID", SqlDbType.BigInt,8)
                                        
                                        };
            parameters[0].Value = parentID;
            parameters[1].Value = userID;

            DataSet ds=DbHelperSQL.Query(strSql.ToString(), parameters);
            DataTable dt=null;
            if (null != ds && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        #endregion  ExtensionMethod
    }
}

