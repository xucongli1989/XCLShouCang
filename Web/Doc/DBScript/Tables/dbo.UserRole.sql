CREATE TABLE [dbo].[UserRole]
(
[UserRoleID] [bigint] NOT NULL IDENTITY(1, 1),
[FK_UserID] [bigint] NOT NULL,
[FK_RoleInfoID] [bigint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserRole] ADD CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED  ([UserRoleID]) ON [PRIMARY]
GO
