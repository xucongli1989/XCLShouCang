SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE FUNCTION [dbo].[TB_fun_GetProductCountGroupProvince](@FK_SearchKeyID BIGINT) RETURNS TABLE AS RETURN
--按所在省分组，宝贝数量排名
WITH Info1 AS (
	SELECT ProductProvince,COUNT(1) AS Rep_ProductCount FROM dbo.TB_Product WHERE FK_SearchKeyID=@FK_SearchKeyID GROUP BY ProductProvince
)
SELECT TOP 1000 * FROM  Info1 AS a ORDER BY a.Rep_ProductCount DESC

GO
