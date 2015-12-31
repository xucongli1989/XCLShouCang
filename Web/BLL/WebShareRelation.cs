using System;
using System.Collections.Generic;
using System.Data;

namespace XCLShouCang.BLL
{
    /// <summary>
    /// WebShareRelation
    /// </summary>
    public partial class WebShareRelation
    {
        private readonly XCLShouCang.DAL.WebShareRelation dal = new XCLShouCang.DAL.WebShareRelation();

        public WebShareRelation()
        { }

        #region BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long WebShareRelationID)
        {
            return dal.Exists(WebShareRelationID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(XCLShouCang.Model.WebShareRelation model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XCLShouCang.Model.WebShareRelation model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long WebShareRelationID)
        {
            return dal.Delete(WebShareRelationID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string WebShareRelationIDlist)
        {
            return dal.DeleteList(WebShareRelationIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XCLShouCang.Model.WebShareRelation GetModel(long WebShareRelationID)
        {
            return dal.GetModel(WebShareRelationID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public XCLShouCang.Model.WebShareRelation GetModelByCache(long WebShareRelationID)
        {
            string CacheKey = "WebShareRelationModel-" + WebShareRelationID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(WebShareRelationID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (XCLShouCang.Model.WebShareRelation)objModel;
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
        public List<XCLShouCang.Model.WebShareRelation> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XCLShouCang.Model.WebShareRelation> DataTableToList(DataTable dt)
        {
            List<XCLShouCang.Model.WebShareRelation> modelList = new List<XCLShouCang.Model.WebShareRelation>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XCLShouCang.Model.WebShareRelation model;
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
        /// 设置共享
        /// </summary>
        public bool SetShare(XCLShouCang.Model.WebShareRelation model, bool isShare)
        {
            return dal.SetShare(model, isShare);
        }

        /// <summary>
        /// 指定的收藏夹ID是否共享
        /// </summary>
        public bool IsExistWebTypeRootID(long webTypeRootID)
        {
            return dal.IsExistWebTypeRootID(webTypeRootID);
        }

        public XCLShouCang.Model.WebShareRelation GetModelByWebTypeRootID(long webTypeRootID)
        {
            List<XCLShouCang.Model.WebShareRelation> lst = this.GetModelList(string.Format("FK_WebTypeRootID={0}", webTypeRootID));
            return null != lst && lst.Count > 0 ? lst[0] : null;
        }

        #endregion ExtensionMethod
    }
}