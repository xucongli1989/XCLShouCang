using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;//Please add references

namespace XCLShouCang.DAL
{
    /// <summary>
    /// 数据访问类:UserInfo
    /// </summary>
    public partial class UserInfo
    {
        public UserInfo()
        { }

        #region BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
			};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(XCLShouCang.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("UserName,NickName,RealName,Pwd,Age,Birthday,Tel,QQ,Email,OtherContactWay,ThirdLoginType,ThirdLoginToken,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@NickName,@RealName,@Pwd,@Age,@Birthday,@Tel,@QQ,@Email,@OtherContactWay,@ThirdLoginType,@ThirdLoginToken,@CreatorName,@CreateTime,@UpdateName,@UpdateTime,@IsDel)");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Birthday", SqlDbType.SmallDateTime),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.BigInt,8),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@OtherContactWay", SqlDbType.VarChar,500),
					new SqlParameter("@ThirdLoginType", SqlDbType.VarChar,50),
					new SqlParameter("@ThirdLoginToken", SqlDbType.VarChar,50),
					new SqlParameter("@CreatorName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateName", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.NickName;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.Age;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.Tel;
            parameters[7].Value = model.QQ;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.OtherContactWay;
            parameters[10].Value = model.ThirdLoginType;
            parameters[11].Value = model.ThirdLoginToken;
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
        public bool Update(XCLShouCang.Model.UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Age=@Age,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Email=@Email,");
            strSql.Append("OtherContactWay=@OtherContactWay,");
            strSql.Append("ThirdLoginType=@ThirdLoginType,");
            strSql.Append("ThirdLoginToken=@ThirdLoginToken,");
            strSql.Append("CreatorName=@CreatorName,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateName=@UpdateName,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Birthday", SqlDbType.SmallDateTime),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.BigInt,8),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@OtherContactWay", SqlDbType.VarChar,500),
					new SqlParameter("@ThirdLoginType", SqlDbType.VarChar,50),
					new SqlParameter("@ThirdLoginToken", SqlDbType.VarChar,50),
					new SqlParameter("@CreatorName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateName", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.NickName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Pwd;
            parameters[3].Value = model.Age;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.QQ;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.OtherContactWay;
            parameters[9].Value = model.ThirdLoginType;
            parameters[10].Value = model.ThirdLoginToken;
            parameters[11].Value = model.CreatorName;
            parameters[12].Value = model.CreateTime;
            parameters[13].Value = model.UpdateName;
            parameters[14].Value = model.UpdateTime;
            parameters[15].Value = model.IsDel;
            parameters[16].Value = model.UserID;
            parameters[17].Value = model.UserName;

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
        public bool Delete(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
			};
            parameters[0].Value = UserID;

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
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
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
        public XCLShouCang.Model.UserInfo GetModel(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,NickName,RealName,Pwd,Age,Birthday,Tel,QQ,Email,OtherContactWay,ThirdLoginType,ThirdLoginToken,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel from UserInfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
			};
            parameters[0].Value = UserID;

            XCLShouCang.Model.UserInfo model = new XCLShouCang.Model.UserInfo();
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
        public XCLShouCang.Model.UserInfo DataRowToModel(DataRow row)
        {
            XCLShouCang.Model.UserInfo model = new XCLShouCang.Model.UserInfo();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["Tel"] != null)
                {
                    model.Tel = row["Tel"].ToString();
                }
                if (row["QQ"] != null && row["QQ"].ToString() != "")
                {
                    model.QQ = long.Parse(row["QQ"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["OtherContactWay"] != null)
                {
                    model.OtherContactWay = row["OtherContactWay"].ToString();
                }
                if (row["ThirdLoginType"] != null)
                {
                    model.ThirdLoginType = row["ThirdLoginType"].ToString();
                }
                if (row["ThirdLoginToken"] != null)
                {
                    model.ThirdLoginToken = row["ThirdLoginToken"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserName,NickName,RealName,Pwd,Age,Birthday,Tel,QQ,Email,OtherContactWay,ThirdLoginType,ThirdLoginToken,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel ");
            strSql.Append(" FROM UserInfo ");
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
            strSql.Append(" UserID,UserName,NickName,RealName,Pwd,Age,Birthday,Tel,QQ,Email,OtherContactWay,ThirdLoginType,ThirdLoginToken,CreatorName,CreateTime,UpdateName,UpdateTime,IsDel ");
            strSql.Append(" FROM UserInfo ");
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
            strSql.Append("select count(1) FROM UserInfo ");
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
                strSql.Append("order by T.UserID desc");
            }
            strSql.Append(")AS Row, T.*  from UserInfo T ");
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
            parameters[0].Value = "UserInfo";
            parameters[1].Value = "UserID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion BasicMethod

        #region ExtensionMethod

        public bool IsExists(string userName, string pwd)
        {
            string strSql = "select top 1 1 from UserInfo where UserName=@UserName and Pwd=@Pwd";
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.VarChar, 50),
                    new SqlParameter("@Pwd", SqlDbType.VarChar, 50)
                    };
            parameters[0].Value = userName;
            parameters[1].Value = pwd;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        public bool IsExists(string userName)
        {
            string strSql = "select top 1 1 from UserInfo where UserName=@UserName";
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.VarChar, 50)
                    };
            parameters[0].Value = userName;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public long AddUserInfo(XCLShouCang.Model.UserInfo model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@Pwd", SqlDbType.VarChar,50),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Birthday", SqlDbType.SmallDateTime),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.BigInt,8),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@OtherContactWay", SqlDbType.VarChar,500),
                    					new SqlParameter("@ThirdLoginType", SqlDbType.VarChar,50),
					new SqlParameter("@ThirdLoginToken", SqlDbType.VarChar,50),
					new SqlParameter("@CreatorName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateName", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.TinyInt,1),
                    new SqlParameter("@ResultCode", SqlDbType.Int,4),
                    new SqlParameter("@ResultMessage", SqlDbType.NVarChar,1000),
                                        };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.RealName;
            parameters[4].Value = model.Pwd;
            parameters[5].Value = model.Age;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.Tel;
            parameters[8].Value = model.QQ;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.OtherContactWay;

            parameters[11].Value = model.ThirdLoginType;
            parameters[12].Value = model.ThirdLoginToken;

            parameters[13].Value = model.CreatorName;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.UpdateName;
            parameters[16].Value = model.UpdateTime;
            parameters[17].Value = model.IsDel;
            parameters[18].Direction = ParameterDirection.Output;
            parameters[19].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("proc_UserInfo_ADD", parameters, "ds");

            long userID = XCLNetTools.StringHander.Common.GetInt(parameters[0].Value);
            if (userID > 0)
            {
                return userID;
            }
            else
            {
                throw new Exception(Convert.ToString(parameters[19].Value));
            }
        }

        public DataTable GetModelByUserName(string userName)
        {
            string strSql = "select * from UserInfo where UserName=@UserName";
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.VarChar, 50)
                    };
            parameters[0].Value = userName;
            DataSet ds = DbHelperSQL.Query(strSql, parameters);
            DataTable dt = null;
            if (null != ds && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public bool IsExistsThirdLogin(string thirdLoginType, string thirdLoginToken)
        {
            string strSql = "select top 1 1 from UserInfo where ThirdLoginType=@ThirdLoginType and ThirdLoginToken=@ThirdLoginToken";
            SqlParameter[] parameters = {
                    new SqlParameter("@ThirdLoginType", SqlDbType.VarChar, 50),
                    new SqlParameter("@ThirdLoginToken", SqlDbType.VarChar, 50)
                    };
            parameters[0].Value = thirdLoginType;
            parameters[1].Value = thirdLoginToken;
            return DbHelperSQL.Exists(strSql, parameters);
        }

        public DataTable GetModelByThirdLogin(string thirdLoginType, string thirdLoginToken)
        {
            string strSql = "select * from UserInfo where ThirdLoginType=@ThirdLoginType and ThirdLoginToken=@ThirdLoginToken";
            SqlParameter[] parameters = {
                    new SqlParameter("@ThirdLoginType", SqlDbType.VarChar, 50),
                    new SqlParameter("@ThirdLoginToken", SqlDbType.VarChar, 50)
                    };
            parameters[0].Value = thirdLoginType;
            parameters[1].Value = thirdLoginToken;
            DataSet ds = DbHelperSQL.Query(strSql, parameters);
            DataTable dt = null;
            if (null != ds && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        #endregion ExtensionMethod
    }
}