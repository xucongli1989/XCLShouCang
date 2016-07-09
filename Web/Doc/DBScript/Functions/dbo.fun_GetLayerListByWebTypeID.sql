SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE FUNCTION [dbo].[fun_GetLayerListByWebTypeID](@webTypeID BIGINT,@userID BIGINT) RETURNS TABLE AS RETURN


WITH Info1 AS (
	SELECT WebTypeID, ParentID,TypeName FROM dbo.WebType WHERE WebTypeID=@webTypeID AND FK_UserID=@userID
	UNION ALL
	SELECT a.WebTypeID, a.ParentID,a.TypeName FROM dbo.WebType AS a 
	INNER JOIN Info1 AS b ON a.WebTypeID=b.ParentID AND a.IsFolder=1 AND a.FK_UserID=@userID AND a.IsDel=0
)
SELECT WebTypeID, ParentID,TypeName FROM Info1

GO
