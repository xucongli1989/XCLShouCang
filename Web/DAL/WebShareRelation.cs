using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace XCLShouCang.DAL
{
    /// <summary>
    /// 数据访问类:WebShareRelation
    /// </summary>
    public partial class WebShareRelation
    {
        public WebShareRelation()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long WebShareRelationID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebShareRelation");
            strSql.Append(" where WebShareRelationID=@WebShareRelationID");
            SqlParameter[] parameters = {
					new SqlParameter("@WebShareRelationID", SqlDbType.BigInt)
			};
            parameters[0].Value = WebShareRelationID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(XCLShouCang.Model.WebShareRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebShareRelation(");
            strSql.Append("FK_WebTypeRootID,AccessPwd)");
            strSql.Append(" values (");
            strSql.Append("@FK_WebTypeRootID,@AccessPwd)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_WebTypeRootID", SqlDbType.BigInt,8),
					new SqlParameter("@AccessPwd", SqlDbType.VarChar,50)};
            parameters[0].Value = model.FK_WebTypeRootID;
            parameters[1].Value = model.AccessPwd;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(XCLShouCang.Model.WebShareRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebShareRelation set ");
            strSql.Append("FK_WebTypeRootID=@FK_WebTypeRootID,");
            strSql.Append("AccessPwd=@AccessPwd");
            strSql.Append(" where WebShareRelationID=@WebShareRelationID");
            SqlParameter[] parameters = {
					new SqlParameter("@FK_WebTypeRootID", SqlDbType.BigInt,8),
					new SqlParameter("@AccessPwd", SqlDbType.VarChar,50),
					new SqlParameter("@WebShareRelationID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.FK_WebTypeRootID;
            parameters[1].Value = model.AccessPwd;
            parameters[2].Value = model.WebShareRelationID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(long WebShareRelationID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebShareRelation ");
            strSql.Append(" where WebShareRelationID=@WebShareRelationID");
            SqlParameter[] parameters = {
					new SqlParameter("@WebShareRelationID", SqlDbType.BigInt)
			};
            parameters[0].Value = WebShareRelationID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string WebShareRelationIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebShareRelation ");
            strSql.Append(" where WebShareRelationID in (" + WebShareRelationIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public XCLShouCang.Model.WebShareRelation GetModel(long WebShareRelationID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WebShareRelationID,FK_WebTypeRootID,AccessPwd from WebShareRelation ");
            strSql.Append(" where WebShareRelationID=@WebShareRelationID");
            SqlParameter[] parameters = {
					new SqlParameter("@WebShareRelationID", SqlDbType.BigInt)
			};
            parameters[0].Value = WebShareRelationID;

            XCLShouCang.Model.WebShareRelation model = new XCLShouCang.Model.WebShareRelation();
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
        public XCLShouCang.Model.WebShareRelation DataRowToModel(DataRow row)
        {
            XCLShouCang.Model.WebShareRelation model = new XCLShouCang.Model.WebShareRelation();
            if (row != null)
            {
                if (row["WebShareRelationID"] != null && row["WebShareRelationID"].ToString() != "")
                {
                    model.WebShareRelationID = long.Parse(row["WebShareRelationID"].ToString());
                }
                if (row["FK_WebTypeRootID"] != null && row["FK_WebTypeRootID"].ToString() != "")
                {
                    model.FK_WebTypeRootID = long.Parse(row["FK_WebTypeRootID"].ToString());
                }
                if (row["AccessPwd"] != null)
                {
                    model.AccessPwd = row["AccessPwd"].ToString();
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
            strSql.Append("select WebShareRelationID,FK_WebTypeRootID,AccessPwd ");
            strSql.Append(" FROM WebShareRelation ");
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
            strSql.Append(" WebShareRelationID,FK_WebTypeRootID,AccessPwd ");
            strSql.Append(" FROM WebShareRelation ");
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
            strSql.Append("select count(1) FROM WebShareRelation ");
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
                strSql.Append("order by T.WebShareRelationID desc");
            }
            strSql.Append(")AS Row, T.*  from WebShareRelation T ");
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
            parameters[0].Value = "WebShareRelation";
            parameters[1].Value = "WebShareRelationID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 设置共享状态
        /// </summary>
        public bool SetShare(XCLShouCang.Model.WebShareRelation model,bool isShare)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ResultCode", SqlDbType.Int,4),
                    new SqlParameter("@ResultMessage", SqlDbType.NVarChar,1000),
                    new SqlParameter("@IsShare", SqlDbType.TinyInt,1),
                    new SqlParameter("@FK_WebTypeRootID", SqlDbType.BigInt,8),
                    new SqlParameter("@AccessPwd", SqlDbType.VarChar,50)
			};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Value =isShare?1:0;
            parameters[3].Value = model.FK_WebTypeRootID;
            parameters[4].Value = model.AccessPwd;
            DbHelperSQL.RunProcedure("proc_WebShareRelationUpdate", parameters, "ds");
            int flag = XCLNetTools.StringHander.Common.GetInt(parameters[0].Value);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                throw new Exception(Convert.ToString(parameters[1].Value));
            }
        }

        /// <summary>
        /// 指定的收藏夹ID是否共享
        /// </summary>
        public bool IsExistWebTypeRootID(long webTypeRootID)
        {
            string strSql = string.Format("SELECT TOP 1 1 FROM dbo.WebShareRelation WHERE FK_WebTypeRootID=@FK_WebTypeRootID");
            SqlParameter[] parameters = {
                    new SqlParameter("@FK_WebTypeRootID", SqlDbType.BigInt,8)
			};
            parameters[0].Value = webTypeRootID;
            return DbHelperSQL.Exists(strSql,parameters);
        }
        #endregion  ExtensionMethod
    }
}

