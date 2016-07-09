SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[v_UserInfo] AS

WITH Info1 AS (
	SELECT
	a.*,
	b.FK_RoleInfoID,
	b.RoleName
	FROM dbo.UserInfo AS a
	LEFT JOIN dbo.v_UserRole AS b ON a.UserID=b.FK_UserID
),
Info2 AS (
	SELECT * FROM  dbo.WebType WHERE ParentID=0
)
SELECT
a.*,
isnull(b.WebTypeID,0) AS RootWebTypeID,
b.TypeName AS RootWebTypeName
FROM Info1 AS a LEFT JOIN info2 AS b ON a.UserID=b.FK_UserID
GO
