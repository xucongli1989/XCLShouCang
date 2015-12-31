using System;
namespace XCLShouCang.Model
{
    /// <summary>
    /// WebType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WebType
    {
        public WebType()
        { }
        #region Model
        private long _webtypeid;
        private long _parentid;
        private string _webtypegid;
        private string _parentgid;
        private string _typename;
        private string _typeurl;
        private string _typedescription;
        private string _icourl;
        private long _fk_userid;
        private long _sort = 0;
        private int _isshare = 0;
        private int _isfolder = 0;
        private int _isreadonly = 0;
        private string _creatorname;
        private DateTime? _createtime = DateTime.Now;
        private string _updatename;
        private DateTime? _updatetime;
        private int _isdel = 0;
        /// <summary>
        /// 
        /// </summary>
        public long WebTypeID
        {
            set { _webtypeid = value; }
            get { return _webtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WebTypeGid
        {
            set { _webtypegid = value; }
            get { return _webtypegid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentGid
        {
            set { _parentgid = value; }
            get { return _parentgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeURL
        {
            set { _typeurl = value; }
            get { return _typeurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeDescription
        {
            set { _typedescription = value; }
            get { return _typedescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IcoURL
        {
            set { _icourl = value; }
            get { return _icourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long FK_UserID
        {
            set { _fk_userid = value; }
            get { return _fk_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsShare
        {
            set { _isshare = value; }
            get { return _isshare; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsFolder
        {
            set { _isfolder = value; }
            get { return _isfolder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsReadOnly
        {
            set { _isreadonly = value; }
            get { return _isreadonly; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreatorName
        {
            set { _creatorname = value; }
            get { return _creatorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateName
        {
            set { _updatename = value; }
            get { return _updatename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        #endregion Model

    }
}

