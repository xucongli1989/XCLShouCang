using System;
using System.Collections.Generic;
using System.Data;

namespace XCLShouCang.BLL
{
    /// <summary>
    /// UserInfo
    /// </summary>
    public partial class UserInfo
    {
        private readonly XCLShouCang.DAL.UserInfo dal = new XCLShouCang.DAL.UserInfo();

        public UserInfo()
        { }

        #region BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(XCLShouCang.Model.UserInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLShouCang.Model.UserInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long UserID)
        {
            return dal.Delete(UserID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLShouCang.Model.UserInfo GetModel(long UserID)
        {
            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public XCLShouCang.Model.UserInfo GetModelByCache(long UserID)
        {
            string CacheKey = "UserInfoModel-" + UserID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (XCLShouCang.Model.UserInfo)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLShouCang.Model.UserInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLShouCang.Model.UserInfo> DataTableToList(DataTable dt)
        {
            List<XCLShouCang.Model.UserInfo> modelList = new List<XCLShouCang.Model.UserInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLShouCang.Model.UserInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public long AddUserInfo(XCLShouCang.Model.UserInfo model)
        {
            return dal.AddUserInfo(model);
        }

        public bool IsExists(string userName, string pwd)
        {
            return dal.IsExists(userName, pwd);
        }

        public bool IsExists(string userName)
        {
            return dal.IsExists(userName);
        }

        public XCLShouCang.Model.UserInfo GetModel(string userName)
        {
            XCLShouCang.Model.UserInfo model = null;
            DataTable dt = dal.GetModelByUserName(userName);
            if (null != dt && dt.Rows.Count > 0)
            {
                model = dal.DataRowToModel(dt.Rows[0]);
            }
            return model;
        }

        public bool IsExistsThirdLogin(string thirdLoginType, string thirdLoginToken)
        {
            return dal.IsExistsThirdLogin(thirdLoginType, thirdLoginToken);
        }

        public XCLShouCang.Model.UserInfo GetModelByThirdLogin(string thirdLoginType, string thirdLoginToken)
        {
            XCLShouCang.Model.UserInfo model = null;
            DataTable dt = dal.GetModelByThirdLogin(thirdLoginType, thirdLoginToken);
            if (null != dt && dt.Rows.Count > 0)
            {
                model = dal.DataRowToModel(dt.Rows[0]);
            }
            return model;
        }

        #endregion ExtensionMethod
    }
}