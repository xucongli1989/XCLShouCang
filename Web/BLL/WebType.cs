using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using XCLShouCang.Model;
namespace XCLShouCang.BLL
{
	/// <summary>
	/// WebType
	/// </summary>
	public partial class WebType
	{
		private readonly XCLShouCang.DAL.WebType dal=new XCLShouCang.DAL.WebType();
		public WebType()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long WebTypeID)
		{
			return dal.Exists(WebTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(XCLShouCang.Model.WebType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCLShouCang.Model.WebType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long WebTypeID)
		{
			
			return dal.Delete(WebTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string WebTypeIDlist )
		{
			return dal.DeleteList(WebTypeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XCLShouCang.Model.WebType GetModel(long WebTypeID)
		{
			
			return dal.GetModel(WebTypeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public XCLShouCang.Model.WebType GetModelByCache(long WebTypeID)
		{
			
			string CacheKey = "WebTypeModel-" + WebTypeID;
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
				catch{}
			}
			return (XCLShouCang.Model.WebType)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCLShouCang.Model.WebType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCLShouCang.Model.WebType> DataTableToList(DataTable dt)
		{
			List<XCLShouCang.Model.WebType> modelList = new List<XCLShouCang.Model.WebType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCLShouCang.Model.WebType model;
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

		#endregion  BasicMethod
		#region  ExtensionMethod

        public List<XCLShouCang.Model.WebType> GetListByUserID(long userid)
        {
            return this.GetModelList(string.Format("FK_UserID={0}",userid));
        }

        public List<XCLShouCang.Model.WebType> GetListByParentID(long parentID)
        {
            return this.GetModelList(string.Format("ParentID={0}", parentID));
        }

        public List<XCLShouCang.Model.WebType> GetListByUserIDAndParentID(long userid, long parentID)
        {
            return this.GetModelList(string.Format("FK_UserID={0} and ParentID={1}",userid, parentID));
        }

        public List<XCLShouCang.Model.WebType> GetFolderListByUserIDAndParentID(long userid, long parentID)
        {
            return this.GetModelList(string.Format("FK_UserID={0} and ParentID={1} and IsFolder=1", userid, parentID));
        }

        public XCLShouCang.Model.WebType GetModel(long userID, string typeName)
        {
            XCLShouCang.Model.WebType model = null;
            List<XCLShouCang.Model.WebType> lst = this.GetModelList(string.Format("FK_UserID={0} and TypeName='{1}'", userID, typeName));
            if (null != lst && lst.Count > 0)
            {
                model = lst[0];
            }
            return model;
        }

        public XCLShouCang.Model.WebType GetRootModel(long userID)
        {
            return this.GetModel(userID, "全部");
        }

        public bool IsExistParentID(long parentID)
        {
            return dal.IsExistParentID(parentID);
        }

        public XCLShouCang.Model.WebType GetModel(long userID, long webTypeID)
        {
            XCLShouCang.Model.WebType model = null;
            List<XCLShouCang.Model.WebType> lst = this.GetModelList(string.Format("FK_UserID={0} and WebTypeID={1}", userID, webTypeID));
            if (null != lst && lst.Count > 0)
            {
                model = lst[0];
            }
            return model;
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <returns></returns>
        public void DeleteAll(List<long> webTypeIDList,long userID, string userName, bool isDelAllChildType)
        {
            if (null != webTypeIDList && webTypeIDList.Count > 0)
            {
                dal.Delete(webTypeIDList, userID, userName, isDelAllChildType);
            }
        }

        /// <summary>
        /// 获取当前webTypeID所属的层级list
        /// 如:根目录/子目录/文件
        /// </summary>
        public List<XCLShouCang.Model.Custom.WebTypeSimple> GetLayerListByWebTypeID(long webTypeID,long userID)
        {
            List<XCLShouCang.Model.Custom.WebTypeSimple> lst = null;
            DataTable dt = dal.GetLayerListByWebTypeID(webTypeID, userID);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = new List<Model.Custom.WebTypeSimple>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XCLShouCang.Model.Custom.WebTypeSimple model = new Model.Custom.WebTypeSimple() {
                        TypeName = dt.Rows[i]["TypeName"].ToString(),
                        WebTypeID = Convert.ToInt64(dt.Rows[i]["WebTypeID"].ToString()),
                        ParentID = Convert.ToInt64(dt.Rows[i]["ParentID"].ToString())
                    };
                    lst.Add(model);
                }
                lst.Reverse();
            }
            return lst;
        }

        /// <summary>
        /// 批量导入添加
        /// </summary>
        public bool BulkInputAdd(List<XCLShouCang.Model.WebType> lst,string rootGuid,long rootID)
        {
            return dal.BulkInputAdd(lst, rootGuid, rootID);
        }

         /// <summary>
        /// 获取查询结果
        /// </summary>
        public List<XCLShouCang.Model.Custom.WebTypeSearch> GetSearchList(XCLShouCang.Model.Custom.WebTypeSearch searchModel,int top)
        {
            List<XCLShouCang.Model.Custom.WebTypeSearch> lst = null;
            DataTable dt = dal.GetSearchList(searchModel,top);
            if (null != dt && dt.Rows.Count > 0)
            {
                lst = new List<Model.Custom.WebTypeSearch>();
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    lst.Add(new Model.Custom.WebTypeSearch()
                    {
                        IsFolder = Convert.ToInt32(dt.Rows[i]["IsFolder"] ?? "0"),
                        TypeName = dt.Rows[i]["TypeName"].ToString(),
                        TypeURL = dt.Rows[i]["TypeURL"].ToString(),
                        WebTypeID = Convert.ToInt64(dt.Rows[i]["WebTypeID"].ToString())
                    });
                }
            }
            return lst;
        }
		#endregion  ExtensionMethod
	}
}

