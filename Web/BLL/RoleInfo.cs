using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using XCLShouCang.Model;
namespace XCLShouCang.BLL
{
	/// <summary>
	/// RoleInfo
	/// </summary>
	public partial class RoleInfo
	{
		private readonly XCLShouCang.DAL.RoleInfo dal=new XCLShouCang.DAL.RoleInfo();
		public RoleInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long RoleInfoID)
		{
			return dal.Exists(RoleInfoID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(XCLShouCang.Model.RoleInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XCLShouCang.Model.RoleInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long RoleInfoID)
		{
			
			return dal.Delete(RoleInfoID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RoleInfoIDlist )
		{
			return dal.DeleteList(RoleInfoIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XCLShouCang.Model.RoleInfo GetModel(long RoleInfoID)
		{
			
			return dal.GetModel(RoleInfoID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public XCLShouCang.Model.RoleInfo GetModelByCache(long RoleInfoID)
		{
			
			string CacheKey = "RoleInfoModel-" + RoleInfoID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RoleInfoID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (XCLShouCang.Model.RoleInfo)objModel;
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
		public List<XCLShouCang.Model.RoleInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XCLShouCang.Model.RoleInfo> DataTableToList(DataTable dt)
		{
			List<XCLShouCang.Model.RoleInfo> modelList = new List<XCLShouCang.Model.RoleInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XCLShouCang.Model.RoleInfo model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

		#endregion  ExtensionMethod
	}
}

