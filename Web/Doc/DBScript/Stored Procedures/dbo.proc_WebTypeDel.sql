SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO





CREATE PROC [dbo].[proc_WebTypeDel]
(
	@ResultCode INT OUTPUT,
	@ResultMessage NVARCHAR(1000) OUTPUT,

	@WebTypeID BIGINT,--分类ID
	@UserID BIGINT,--用户Id
	@UserName VARCHAR(50),--用户名
	@IsDelAllChildType TINYINT--是否删除所有子类
) AS

DECLARE @dtNow DATETIME
SET @dtNow=GETDATE()
SET @IsDelAllChildType=ISNULL(@IsDelAllChildType,0)
SET @ResultCode=1
SET @ResultMessage=N''


IF EXISTS(SELECT top 1 1 FROM dbo.WebType WHERE WebTypeID=@WebTypeID AND ParentID=0)
BEGIN
	SET @ResultMessage=@ResultMessage+N'根分类不能删除！'
	SET @ResultCode=0
	RETURN
END



--临时表，存放待删除的webtypeID
CREATE TABLE #WebTypeID_Temp(WebTypeID BIGINT)

	BEGIN TRY 
		BEGIN TRAN trans

				IF(@IsDelAllChildType=1)
				BEGIN
					--递归获取该类及其所有子类
					 with WebTypeID_tb as 
					 ( 
						 SELECT WebTypeID FROM dbo.WebType WHERE WebTypeID=@WebTypeID AND FK_UserID=@UserID
						 UNION ALL
						 select a.WebTypeID  from dbo.WebType as a inner join WebTypeID_tb c on a.ParentID =c.WebTypeID AND a.IsDel=0 AND a.FK_UserID=@UserID
					 )
					 INSERT INTO #WebTypeID_Temp SELECT WebTypeID FROM WebTypeID_tb 
				END 
				ELSE
				BEGIN
					INSERT INTO #WebTypeID_Temp SELECT @WebTypeID AS WebTypeID
				END


				--删除所有分类
				UPDATE dbo.WebType
				SET IsDel=1,
				UpdateTime=@dtNow,
				UpdateName=@UserName
				FROM dbo.WebType AS a INNER JOIN #WebTypeID_Temp AS b ON a.WebTypeID=b.WebTypeID AND a.IsDel=0

				DROP TABLE #WebTypeID_Temp

			SET @ResultCode=1
		COMMIT TRAN trans
	END TRY

	BEGIN CATCH
		set @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0
		ROLLBACK TRAN trans
	END CATCH





GO
