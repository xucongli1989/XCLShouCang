using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using XCLShouCang.Model;
namespace XCLShouCang.BLL
{
    /// <summary>
    /// v_WebType
    /// </summary>
    public partial class v_WebType
    {
        private readonly XCLShouCang.DAL.v_WebType dal = new XCLShouCang.DAL.v_WebType();
        public v_WebType()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long WebTypeID)
        {
            return dal.Exists(WebTypeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLShouCang.Model.v_WebType GetModel(long WebTypeID)
        {

            return dal.GetModel(WebTypeID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public XCLShouCang.Model.v_WebType GetModelByCache(long WebTypeID)
        {

            string CacheKey = "v_WebTypeModel-" + WebTypeID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(WebTypeID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (XCLShouCang.Model.v_WebType)objModel;
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
        public List<XCLShouCang.Model.v_WebType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLShouCang.Model.v_WebType> DataTableToList(DataTable dt)
        {
            List<XCLShouCang.Model.v_WebType> modelList = new List<XCLShouCang.Model.v_WebType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLShouCang.Model.v_WebType model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable GetList(long parentID,long userID)
        {
            return dal.GetList(parentID, userID);
        }

        public List<Model.v_WebType> GetModelList(long parentID, long userID)
        {
            DataTable dt = this.GetList(parentID, userID);
            return null != dt && dt.Rows.Count > 0 ? DataTableToList(dt) : null;
        }
        #endregion  ExtensionMethod
    }
}

