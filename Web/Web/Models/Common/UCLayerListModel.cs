using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.Common
{
    /// <summary>
    /// 路径形式的导航实体
    /// </summary>
    public class UCLayerListModel
    {
        public long UserID { get; set; }

        public long WebTypeID { get; set; }

        public List<XCLShouCang.Model.Custom.WebTypeSimple> LayerList
        {
            get
            {
                XCLShouCang.BLL.WebType webTypeBLL = new XCLShouCang.BLL.WebType();
                return webTypeBLL.GetLayerListByWebTypeID(this.WebTypeID, this.UserID);
            }
        }

        /// <summary>
        /// 显示类型（主要是里面的链接不一样）
        /// </summary>
        public UCLayerListShowTypeEnum UCLayerListShowType { get; set; }
    }

    public enum UCLayerListShowTypeEnum
    { 
        管理页,
        列表页
    }
}