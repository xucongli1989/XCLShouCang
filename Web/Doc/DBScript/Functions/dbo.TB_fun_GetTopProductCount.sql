SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE FUNCTION [dbo].[TB_fun_GetTopProductCount](@FK_SearchKeyID BIGINT) RETURNS TABLE AS RETURN
--获取产品数据最多的前几个商家

WITH Info1 AS (
	SELECT * FROM dbo.TB_Product WHERE FK_SearchKeyID=@FK_SearchKeyID	
),
Info2 AS (
	SELECT
	a.ShopID,
	a.ShopName,
	COUNT(1) AS Rep_ProductCount
	FROM Info1 AS a GROUP BY a.ShopID,a.ShopName
)

SELECT TOP 20 * FROM Info2 ORDER BY Rep_ProductCount DESC


GO
