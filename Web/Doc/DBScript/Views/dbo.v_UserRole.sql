SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[v_UserRole] AS
SELECT
a.*,
b.RoleName
FROM dbo.UserRole AS a
INNER JOIN dbo.RoleInfo AS b ON a.FK_RoleInfoID=b.RoleInfoID
GO
