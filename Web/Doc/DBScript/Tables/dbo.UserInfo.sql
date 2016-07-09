CREATE TABLE [dbo].[UserInfo]
(
[UserID] [bigint] NOT NULL IDENTITY(1, 1),
[UserName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[NickName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[RealName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Pwd] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Age] [int] NULL,
[Birthday] [smalldatetime] NULL,
[Tel] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[QQ] [bigint] NULL,
[Email] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[OtherContactWay] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[ThirdLoginType] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[ThirdLoginToken] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[CreatorName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[CreateTime] [datetime] NULL CONSTRAINT [DF_UserInfo_CreateTime] DEFAULT (getdate()),
[UpdateName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NULL,
[IsDel] [tinyint] NOT NULL CONSTRAINT [DF_UserInfo_IsDel] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserInfo] ADD CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED  ([UserID]) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[UserInfo] ([UserName]) ON [PRIMARY]
GO
