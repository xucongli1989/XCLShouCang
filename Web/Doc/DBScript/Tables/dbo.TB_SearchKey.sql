CREATE TABLE [dbo].[TB_SearchKey]
(
[SearchKeyID] [bigint] NOT NULL IDENTITY(1, 1),
[KeyName] [varchar] (500) COLLATE Chinese_PRC_CI_AS NOT NULL,
[KeyType] [tinyint] NOT NULL CONSTRAINT [DF_TB_SearchKey_KeyType] DEFAULT ((0)),
[CreateTime] [datetime] NOT NULL CONSTRAINT [DF_TB_SearchKey_CreateTime] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_SearchKey] ADD CONSTRAINT [PK_TB_SearchKey] PRIMARY KEY CLUSTERED  ([SearchKeyID]) ON [PRIMARY]
GO
