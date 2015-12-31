using System;
namespace XCLShouCang.Model
{
    /// <summary>
    /// WebShareRelation:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebShareRelation
    {
        public WebShareRelation()
        { }
        #region Model
        private long _websharerelationid;
        private long _fk_webtyperootid;
        private string _accesspwd;
        /// <summary>
        /// 
        /// </summary>
        public long WebShareRelationID
        {
            set { _websharerelationid = value; }
            get { return _websharerelationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long FK_WebTypeRootID
        {
            set { _fk_webtyperootid = value; }
            get { return _fk_webtyperootid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccessPwd
        {
            set { _accesspwd = value; }
            get { return _accesspwd; }
        }
        #endregion Model

    }
}

