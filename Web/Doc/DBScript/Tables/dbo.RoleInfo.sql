CREATE TABLE [dbo].[RoleInfo]
(
[RoleInfoID] [bigint] NOT NULL IDENTITY(1, 1),
[ParentRoleInfoID] [bigint] NOT NULL,
[RoleName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoleInfo] ADD CONSTRAINT [PK_RoleInfo] PRIMARY KEY CLUSTERED  ([RoleInfoID]) ON [PRIMARY]
GO
