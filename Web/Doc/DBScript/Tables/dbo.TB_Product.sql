CREATE TABLE [dbo].[TB_Product]
(
[ProductID] [bigint] NOT NULL IDENTITY(1, 1),
[FK_SearchKeyID] [bigint] NOT NULL,
[ID] [bigint] NOT NULL,
[ProductURL] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[Sort] [int] NOT NULL,
[ImgURL] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[Price] [decimal] (18, 2) NOT NULL,
[Title] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[MonthDealCount] [int] NOT NULL,
[AppraiseCount] [int] NOT NULL,
[ShopName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[ShopID] [bigint] NOT NULL,
[ShopURL] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[ShopProvince] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[ShopCity] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[ProductProvince] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[ProductCity] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Rate] [decimal] (18, 1) NOT NULL CONSTRAINT [DF_TB_Product_Rate] DEFAULT ((0)),
[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_TB_Product_CreateTime] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_Product] ADD CONSTRAINT [PK_TB_Product] PRIMARY KEY CLUSTERED  ([ProductID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'评价数', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'AppraiseCount'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', N'关键字ID', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'FK_SearchKeyID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'淘宝商品ID', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品图片链接', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ImgURL'
GO
EXEC sp_addextendedproperty N'MS_Description', N'月成交', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'MonthDealCount'
GO
EXEC sp_addextendedproperty N'MS_Description', N'价格', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'Price'
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品所在城市', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ProductCity'
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品所在省', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ProductProvince'
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品链接', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ProductURL'
GO
EXEC sp_addextendedproperty N'MS_Description', N'评分', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'Rate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'店铺所在城市', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ShopCity'
GO
EXEC sp_addextendedproperty N'MS_Description', N'所属店铺ID', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ShopID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'所属店铺名', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ShopName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'店铺所在省', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ShopProvince'
GO
EXEC sp_addextendedproperty N'MS_Description', N'所属店铺URL', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'ShopURL'
GO
EXEC sp_addextendedproperty N'MS_Description', N'搜索排名', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'Sort'
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品名', 'SCHEMA', N'dbo', 'TABLE', N'TB_Product', 'COLUMN', N'Title'
GO
