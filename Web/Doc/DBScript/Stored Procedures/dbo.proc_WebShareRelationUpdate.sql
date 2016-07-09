SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO





CREATE PROCEDURE [dbo].[proc_WebShareRelationUpdate]
@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT,

@IsShare tinyint,
@FK_WebTypeRootID bigint,
@AccessPwd varchar(50)
 AS 

BEGIN 

	SET @ResultCode=1
	SET @ResultMessage=N'' 


	BEGIN TRY 
		BEGIN TRAN trans 
		
				DELETE FROM dbo.WebShareRelation WHERE FK_WebTypeRootID=@FK_WebTypeRootID
				IF(@IsShare=1)
				BEGIN
					INSERT INTO dbo.WebShareRelation( FK_WebTypeRootID, AccessPwd ) VALUES  ( @FK_WebTypeRootID,@AccessPwd)
				END
				
				--更新所有子文件的共享状态
				--临时表，存放待更新的webtypeID
				CREATE TABLE #WebTypeID_Temp(WebTypeID BIGINT)
				--递归获取该类及其所有子类
				 ;with WebTypeID_tb as 
				 ( 
					 SELECT WebTypeID FROM dbo.WebType WHERE WebTypeID=@FK_WebTypeRootID
					 UNION ALL
					 select a.WebTypeID  from dbo.WebType as a inner join WebTypeID_tb c on a.ParentID =c.WebTypeID AND a.IsDel=0
				 )
				INSERT INTO #WebTypeID_Temp SELECT WebTypeID FROM WebTypeID_tb 
				 
				UPDATE dbo.WebType
				SET IsShare=@IsShare
				FROM dbo.WebType AS a INNER JOIN #WebTypeID_Temp AS b ON a.WebTypeID=b.WebTypeID AND a.IsShare<>@IsShare
				
				DROP TABLE #WebTypeID_Temp
	
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
