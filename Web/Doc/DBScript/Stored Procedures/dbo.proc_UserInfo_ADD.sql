SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO














CREATE PROCEDURE [dbo].[proc_UserInfo_ADD]
@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT,

@UserID bigint output,
@UserName varchar(50),
@NickName varchar(50),
@RealName varchar(50),
@Pwd varchar(50),
@Age INT,
@Birthday smalldatetime,
@Tel varchar(50),
@QQ bigint,
@Email varchar(50),
@OtherContactWay varchar(500),
@ThirdLoginType varchar(50),
@ThirdLoginToken varchar(50),
@CreatorName varchar(50),
@CreateTime DATETIME,
@UpdateName varchar(50),
@UpdateTime datetime,
@IsDel TINYINT

 AS 

BEGIN 
	SET @CreateTime=GETDATE()
	SET @ResultCode=1
	SET @ResultMessage=N''
	SET @Age=ISNULL(@Age,0)
	SET @IsDel=ISNULL(@IsDel,0)
	
	
	IF EXISTS (SELECT top 1 1 FROM dbo.UserInfo WHERE UserName=@UserName)
	BEGIN
		SET @ResultMessage=@ResultMessage+N'用户名已存在！'
	END

	IF @ResultMessage<>N''
	BEGIN
		SET @ResultCode=0
		RETURN
	END

	BEGIN TRY 
		BEGIN TRAN trans
		
			--插入用户信息
			INSERT INTO [UserInfo](
			[UserName],[NickName],[RealName],[Pwd],[Age],[Birthday],[Tel],[QQ],[Email],[OtherContactWay],[ThirdLoginType],[ThirdLoginToken],[CreatorName],[CreateTime],[UpdateName],[UpdateTime],[IsDel]
			)VALUES(
			@UserName,@NickName,@RealName,@Pwd,@Age,@Birthday,@Tel,@QQ,@Email,@OtherContactWay,@ThirdLoginType,@ThirdLoginToken,@CreatorName,@CreateTime,@UpdateName,@UpdateTime,@IsDel
			)
			
			SET @UserID = SCOPE_IDENTITY()
			
			--插入角色信息
			INSERT dbo.UserRole
			        ( FK_UserID, FK_RoleInfoID )
			VALUES  ( @UserID, -- FK_UserID - bigint
			          2  -- FK_RoleInfoID - bigint
			          )
			
			--插入默认分类的根分类
		INSERT INTO dbo.WebType
				( ParentID ,
				  TypeName ,
				  TypeURL ,
				  TypeDescription ,
				  IcoURL ,
				  FK_UserID ,
				  Sort ,
				  IsFolder,
				  IsShare ,
				  IsReadOnly ,
				  CreatorName ,
				  CreateTime ,
				  UpdateName ,
				  UpdateTime ,
				  IsDel
				)
			SELECT TOP 1 
				0 AS ParentID ,
				TypeName ,
				TypeURL ,
				TypeDescription ,
				IcoURL ,
				@UserID AS FK_UserID ,
				Sort ,
				IsFolder,
				IsShare ,
				IsReadOnly ,
				@UserName AS CreatorName ,
				@CreateTime AS CreateTime ,
				UpdateName ,
				UpdateTime ,
				IsDel 
			FROM dbo.WebType WHERE TypeName='全部' AND ParentID=-1
			
			 DECLARE @WebTypeRootID BIGINT
			 SET @WebTypeRootID=SCOPE_IDENTITY()
			        
			        
			--插入默认的子类
			INSERT INTO dbo.WebType
				( ParentID ,
				  TypeName ,
				  TypeURL ,
				  TypeDescription ,
				  IcoURL ,
				  FK_UserID ,
				  Sort ,
				  IsFolder,
				  IsShare ,
				  IsReadOnly ,
				  CreatorName ,
				  CreateTime ,
				  UpdateName ,
				  UpdateTime ,
				  IsDel
				)
			SELECT 
				@WebTypeRootID AS ParentID ,
				TypeName ,
				TypeURL ,
				TypeDescription ,
				IcoURL ,
				@UserID AS FK_UserID ,
				Sort ,
				IsFolder,
				IsShare ,
				IsReadOnly ,
				@UserName AS CreatorName ,
				@CreateTime AS CreateTime ,
				UpdateName ,
				UpdateTime ,
				IsDel 
			FROM dbo.WebType WHERE ParentID IN(
				SELECT TOP 1 WebTypeID FROM dbo.WebType  WHERE TypeName='全部' AND ParentID=-1
			)
			        
			
			SET @ResultCode=1
		COMMIT TRAN trans
	END TRY

	BEGIN CATCH
		set @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0
		ROLLBACK TRAN trans
	END CATCH
	
END













GO
