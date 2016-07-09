CREATE TABLE [dbo].[LogInfo]
(
[LogInfoID] [bigint] NOT NULL IDENTITY(1, 1),
[Thread] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[LogLevel] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[Logger] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[Message] [varchar] (4000) COLLATE Chinese_PRC_CI_AS NULL,
[Exception] [varchar] (4000) COLLATE Chinese_PRC_CI_AS NULL,
[CreateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LogInfo] ADD CONSTRAINT [PK_LogInfo] PRIMARY KEY CLUSTERED  ([LogInfoID]) ON [PRIMARY]
GO
