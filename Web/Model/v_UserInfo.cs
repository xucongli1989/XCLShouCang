using System;
namespace XCLShouCang.Model
{
    /// <summary>
    /// v_UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_UserInfo
    {
        public v_UserInfo()
        { }
        #region Model
        private long _userid;
        private string _username;
        private string _nickname;
        private string _realname;
        private string _pwd;
        private int? _age;
        private DateTime? _birthday;
        private string _tel;
        private long? _qq;
        private string _email;
        private string _othercontactway;
        private string _thirdlogintype;
        private string _thirdlogintoken;
        private string _creatorname;
        private DateTime? _createtime;
        private string _updatename;
        private DateTime? _updatetime;
        private int _isdel;
        private long? _fk_roleinfoid;
        private string _rolename;
        private long _rootwebtypeid;
        private string _rootwebtypename;
        /// <summary>
        /// 
        /// </summary>
        public long UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherContactWay
        {
            set { _othercontactway = value; }
            get { return _othercontactway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdLoginType
        {
            set { _thirdlogintype = value; }
            get { return _thirdlogintype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdLoginToken
        {
            set { _thirdlogintoken = value; }
            get { return _thirdlogintoken; }
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
        /// <summary>
        /// 
        /// </summary>
        public long? FK_RoleInfoID
        {
            set { _fk_roleinfoid = value; }
            get { return _fk_roleinfoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long RootWebTypeID
        {
            set { _rootwebtypeid = value; }
            get { return _rootwebtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RootWebTypeName
        {
            set { _rootwebtypename = value; }
            get { return _rootwebtypename; }
        }
        #endregion Model

    }
}

