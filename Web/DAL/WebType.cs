using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace XCLShouCang.DAL
{
	/// <summary>
	/// 数据访问类:WebType
	/// </summary>
	public partial class WebType
	{
		public WebType()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long WebTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebType");
            strSql.Append(" where WebTypeID=@WebTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@WebTypeID", SqlDbType.BigInt)
			};
            parameters[0].Value = WebTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(XCLShouCang.Model.WebType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebType(");
            strSql.Append("ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsShare,IsFolder,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@WebTypeGid,@ParentGid,@TypeName,@TypeURL,@TypeDescription,@IcoURL,@FK_UserID,@Sort,@IsShare,@IsFolder,@IsReadOnly,@CreatorName,@CreateTime,@UpdateName,@UpdateTime,@IsDel)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@WebTypeGid", SqlDbType.VarChar,50),
					new SqlParameter("@ParentGid", SqlDbType.VarChar,50),
					new SqlParameter("@TypeName", SqlDbType.VarChar,500),
					new SqlParameter("@TypeURL", SqlDbType.VarChar,500),
					new SqlParameter("@TypeDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@IcoURL", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Sort", SqlDbType.BigInt,8),
					new SqlParameter("@IsShare", SqlDbType.TinyInt,1),
					new SqlParameter("@IsFolder", SqlDbType.TinyInt,1),
					new SqlParameter("@IsReadOnly", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatorName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateName", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.WebTypeGid;
            parameters[2].Value = model.ParentGid;
            parameters[3].Value = model.TypeName;
            parameters[4].Value = model.TypeURL;
            parameters[5].Value = model.TypeDescription;
            parameters[6].Value = model.IcoURL;
            parameters[7].Value = model.FK_UserID;
            parameters[8].Value = model.Sort;
            parameters[9].Value = model.IsShare;
            parameters[10].Value = model.IsFolder;
            parameters[11].Value = model.IsReadOnly;
            parameters[12].Value = model.CreatorName;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.UpdateName;
            parameters[15].Value = model.UpdateTime;
            parameters[16].Value = model.IsDel;

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
        public bool Update(XCLShouCang.Model.WebType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebType set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("WebTypeGid=@WebTypeGid,");
            strSql.Append("ParentGid=@ParentGid,");
            strSql.Append("TypeDescription=@TypeDescription,");
            strSql.Append("IcoURL=@IcoURL,");
            strSql.Append("FK_UserID=@FK_UserID,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("IsShare=@IsShare,");
            strSql.Append("IsFolder=@IsFolder,");
            strSql.Append("IsReadOnly=@IsReadOnly,");
            strSql.Append("CreatorName=@CreatorName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateName=@UpdateName,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where WebTypeID=@WebTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@WebTypeGid", SqlDbType.VarChar,50),
					new SqlParameter("@ParentGid", SqlDbType.VarChar,50),
					new SqlParameter("@TypeDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@IcoURL", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Sort", SqlDbType.BigInt,8),
					new SqlParameter("@IsShare", SqlDbType.TinyInt,1),
					new SqlParameter("@IsFolder", SqlDbType.TinyInt,1),
					new SqlParameter("@IsReadOnly", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatorName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateName", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1),
					new SqlParameter("@WebTypeID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeName", SqlDbType.VarChar,500),
					new SqlParameter("@TypeURL", SqlDbType.VarChar,500)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.WebTypeGid;
            parameters[2].Value = model.ParentGid;
            parameters[3].Value = model.TypeDescription;
            parameters[4].Value = model.IcoURL;
            parameters[5].Value = model.FK_UserID;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.IsShare;
            parameters[8].Value = model.IsFolder;
            parameters[9].Value = model.IsReadOnly;
            parameters[10].Value = model.CreatorName;
            parameters[11].Value = model.CreateTime;
            parameters[12].Value = model.UpdateName;
            parameters[13].Value = model.UpdateTime;
            parameters[14].Value = model.IsDel;
            parameters[15].Value = model.WebTypeID;
            parameters[16].Value = model.TypeName;
            parameters[17].Value = model.TypeURL;

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
        public bool Delete(long WebTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebType ");
            strSql.Append(" where WebTypeID=@WebTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@WebTypeID", SqlDbType.BigInt)
			};
            parameters[0].Value = WebTypeID;

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
        public bool DeleteList(string WebTypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebType ");
            strSql.Append(" where WebTypeID in (" + WebTypeIDlist + ")  ");
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
        public XCLShouCang.Model.WebType GetModel(long WebTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WebTypeID,ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsShare,IsFolder,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel from WebType ");
            strSql.Append(" where WebTypeID=@WebTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@WebTypeID", SqlDbType.BigInt)
			};
            parameters[0].Value = WebTypeID;

            XCLShouCang.Model.WebType model = new XCLShouCang.Model.WebType();
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
        public XCLShouCang.Model.WebType DataRowToModel(DataRow row)
        {
            XCLShouCang.Model.WebType model = new XCLShouCang.Model.WebType();
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
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " IsDel=0 ";
            }
            else
            {
                strWhere = string.Format("({0}) and Isdel=0 ", strWhere);
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WebTypeID,ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsShare,IsFolder,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel ");
            strSql.Append(" FROM WebType ");
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
            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = " IsDel=0 ";
            }
            else
            {
                strWhere = string.Format("({0}) and Isdel=0 ", strWhere);
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" WebTypeID,ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsShare,IsFolder,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel ");
            strSql.Append(" FROM WebType ");
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
            strSql.Append("select count(1) FROM WebType ");
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

        #endregion  BasicMethod
		#region  ExtensionMethod
        public bool IsExistParentID(long parentID)
        {
            string strSql = string.Format("SELECT TOP 1 1 FROM dbo.WebType WHERE ParentID={0}", parentID);
            return DbHelperSQL.Exists(strSql);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(List<long> WebTypeID,long userID, string userName, bool isDelAllChildType)
        {
            string strSql = string.Format(@"UPDATE dbo.WebType
				                                            SET IsDel=1,
				                                            UpdateTime=getdate(),
				                                            UpdateName=@UserName
				                                            FROM dbo.WebType 
                                                            where FK_UserID=@UserID and isdel=0 and WebTypeID in({0})
                                    ", string.Join(",",WebTypeID.ToArray()));
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50)
            };
            parameters[0].Value = userID;
            parameters[1].Value = userName;
            return DbHelperSQL.ExecuteSql(strSql, parameters) > 0;

            //SqlParameter[] parameters = {
            //        new SqlParameter("@ResultCode", SqlDbType.Int,4),
            //        new SqlParameter("@ResultMessage", SqlDbType.NVarChar,1000),
            //        new SqlParameter("@WebTypeID", SqlDbType.BigInt,8),
            //        new SqlParameter("@UserID", SqlDbType.BigInt,8),
            //        new SqlParameter("@UserName", SqlDbType.VarChar,50),
            //        new SqlParameter("@IsDelAllChildType", SqlDbType.TinyInt)
            //};
            //parameters[0].Direction = ParameterDirection.Output;
            //parameters[1].Direction = ParameterDirection.Output;
            //parameters[2].Value = WebTypeID;
            //parameters[3].Value = userID;
            //parameters[4].Value = userName;
            //parameters[5].Value = isDelAllChildType ? 1 : 0;
            //DbHelperSQL.RunProcedure("proc_WebTypeDel", parameters,"ds");
            //int flag = XCLNetTools.StringHander.Common.GetInt(parameters[0].Value);
            //if (flag>0)
            //{
            //    return true;
            //}
            //else
            //{
            //    throw new Exception(Convert.ToString(parameters[1].Value));
            //}
        }

        /// <summary>
        /// 获取指定webTypeID所属的层级list
        /// </summary>
        public DataTable GetLayerListByWebTypeID(long webTypeID,long userID)
        {
            string str = string.Format("select * from fun_GetLayerListByWebTypeID({0},{1})",webTypeID,userID);
            DataSet ds = DbHelperSQL.Query(str);
            DataTable dt = null;
            if (null != ds && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 批量导入添加
        /// </summary>
        public bool BulkInputAdd(List<XCLShouCang.Model.WebType> lst, string rootGuid, long rootID)
        {
            bool result = false;
            if (null == lst || lst.Count == 0)
            {
                return result;
            }

            List<CommandInfo> cmdList = new List<CommandInfo>() ;

            //导入收藏
            foreach (var model in lst)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into WebType(");
                strSql.Append("ParentID,WebTypeGid,ParentGid,TypeName,TypeURL,TypeDescription,IcoURL,FK_UserID,Sort,IsFolder,IsShare,IsReadOnly,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel)");
                strSql.Append(" values (");
                strSql.Append("@ParentID,@WebTypeGid,@ParentGid,@TypeName,@TypeURL,@TypeDescription,@IcoURL,@FK_UserID,@Sort,@IsFolder,@IsShare,@IsReadOnly,@CreatorName,@CreateTime,@UpdateName,@UpdateTime,@IsDel);");
                SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@WebTypeGid", SqlDbType.VarChar,50),
					new SqlParameter("@ParentGid", SqlDbType.VarChar,50),
					new SqlParameter("@TypeName", SqlDbType.VarChar,500),
					new SqlParameter("@TypeURL", SqlDbType.VarChar,500),
					new SqlParameter("@TypeDescription", SqlDbType.VarChar,-1),
					new SqlParameter("@IcoURL", SqlDbType.VarChar,1000),
					new SqlParameter("@FK_UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Sort", SqlDbType.BigInt,8),
					new SqlParameter("@IsFolder", SqlDbType.TinyInt,1),
					new SqlParameter("@IsShare", SqlDbType.TinyInt,1),
					new SqlParameter("@IsReadOnly", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatorName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateName", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1)};
                parameters[0].Value = model.ParentID;
                parameters[1].Value = model.WebTypeGid;
                parameters[2].Value = model.ParentGid;
                parameters[3].Value = model.TypeName;
                parameters[4].Value = model.TypeURL;
                parameters[5].Value = model.TypeDescription;
                parameters[6].Value = model.IcoURL;
                parameters[7].Value = model.FK_UserID;
                parameters[8].Value = model.Sort;
                parameters[9].Value = model.IsFolder;
                parameters[10].Value = model.IsShare;
                parameters[11].Value = model.IsReadOnly;
                parameters[12].Value = model.CreatorName;
                parameters[13].Value = model.CreateTime;
                parameters[14].Value = model.UpdateName;
                parameters[15].Value = model.UpdateTime;
                parameters[16].Value = model.IsDel;

                cmdList.Add(new CommandInfo() { 
                    CommandText=strSql.ToString(),
                    Parameters=parameters
                });
            }

            //根据guid,更新收藏parentID
            foreach (var model in lst)
            {
                StringBuilder strSql = new StringBuilder();
                SqlParameter[] parameters = new SqlParameter[] { };
                if (string.Equals(model.ParentGid, rootGuid))
                {
                    strSql.AppendFormat("update WebType set ParentID=@ParentID where ParentGid=@ParentGid;");
                    parameters = new SqlParameter[] {
					    new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					    new SqlParameter("@ParentGid", SqlDbType.VarChar,50)
                    };
                    parameters[0].Value = rootID;
                    parameters[1].Value = rootGuid;
                }
                else
                {
                    strSql.AppendFormat(@"UPDATE dbo.WebType SET ParentID=(
	                                                        SELECT WebTypeID FROM dbo.WebType WHERE WebTypeGid=@ParentGid
                                                        ) WHERE ParentGid=@ParentGid;");
                    parameters = new SqlParameter[] {
					    new SqlParameter("@ParentGid", SqlDbType.VarChar,50)
                    };
                    parameters[0].Value = model.ParentGid;
                }
                cmdList.Add(new CommandInfo()
                {
                    CommandText = strSql.ToString(),
                    Parameters = parameters
                });
            }

            if (null != cmdList && cmdList.Count > 0)
            {
               result= DbHelperSQL.ExecuteSqlTran(cmdList) > 0;
            }
            return result;
        }

        /// <summary>
        /// 获取查询结果
        /// </summary>
        public DataTable GetSearchList(XCLShouCang.Model.Custom.WebTypeSearch searchModel,int top)
        {
            searchModel.TypeName = string.Format("%{0}%",searchModel.TypeName).ToUpper();
            searchModel.TypeURL = string.Format("%{0}%",searchModel.TypeURL).ToUpper();

            DataSet ds = null;
            DataTable dt=null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            if (top > 0)
            {
                strSql.AppendFormat(" top {0} ",top);
            }
            strSql.Append(" WebTypeID,TypeName,TypeURL,IsFolder from WebType where isdel=0 and FK_UserID=@FK_UserID and (Upper(TypeName) like @typeName or Upper(TypeURL) like @typeURL) ");
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@FK_UserID",SqlDbType.BigInt,8),
                new SqlParameter("@typeName",SqlDbType.VarChar,500),
                new SqlParameter("@typeURL",SqlDbType.VarChar,500)
            };
            parameters[0].Value = searchModel.FK_UserID;
            parameters[1].Value = searchModel.TypeName;
            parameters[2].Value = searchModel.TypeURL;
            ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (null != ds && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
		#endregion  ExtensionMethod
	}
}

