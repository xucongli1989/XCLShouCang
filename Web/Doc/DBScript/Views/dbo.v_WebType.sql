SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE VIEW [dbo].[v_WebType] AS 

WITH Info1 AS (
	SELECT
	a.*,
	(
		CASE WHEN EXISTS (SELECT TOP 1 1 FROM dbo.WebType WHERE IsDel =0 AND ParentID=a.WebTypeID) THEN 1 ELSE 0 END
	) AS IsHasChildWebType
	FROM dbo.WebType AS a WHERE a.IsDel=0
)

SELECT
a.*,
b.UserName AS FK_UserName
FROM Info1 AS a
INNER JOIN dbo.UserInfo AS b ON a.FK_UserID=b.UserID

GO
