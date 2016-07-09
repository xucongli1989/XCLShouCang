CREATE TABLE [dbo].[WebType]
(
[WebTypeID] [bigint] NOT NULL IDENTITY(1, 1),
[ParentID] [bigint] NOT NULL,
[WebTypeGid] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[ParentGid] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[TypeName] [varchar] (500) COLLATE Chinese_PRC_CI_AS NOT NULL,
[TypeURL] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[TypeDescription] [varchar] (max) COLLATE Chinese_PRC_CI_AS NULL,
[IcoURL] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[FK_UserID] [bigint] NOT NULL,
[Sort] [bigint] NOT NULL CONSTRAINT [DF_WebType_Sort] DEFAULT ((0)),
[IsShare] [tinyint] NOT NULL CONSTRAINT [DF_WebType_IsShare] DEFAULT ((0)),
[IsFolder] [tinyint] NOT NULL CONSTRAINT [DF_WebType_IsFolder] DEFAULT ((0)),
[IsReadOnly] [tinyint] NOT NULL CONSTRAINT [DF_WebType_IsReadOnly] DEFAULT ((0)),
[CreatorName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[CreateTime] [datetime] NULL CONSTRAINT [DF_WebType_CreateTime] DEFAULT (getdate()),
[UpdateName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NULL,
[IsDel] [tinyint] NOT NULL CONSTRAINT [DF_WebType_IsDel] DEFAULT ((0))
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[WebType] ADD CONSTRAINT [PK_WebType] PRIMARY KEY CLUSTERED  ([WebTypeID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_WebType_TypeName] ON [dbo].[WebType] ([TypeName]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_WebType_TypeURL] ON [dbo].[WebType] ([TypeURL]) ON [PRIMARY]
GO
