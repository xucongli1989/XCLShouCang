CREATE TABLE [dbo].[WebShareRelation]
(
[WebShareRelationID] [bigint] NOT NULL IDENTITY(1, 1),
[FK_WebTypeRootID] [bigint] NOT NULL,
[AccessPwd] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WebShareRelation] ADD CONSTRAINT [PK_WebShareRelation] PRIMARY KEY CLUSTERED  ([WebShareRelationID]) ON [PRIMARY]
GO
