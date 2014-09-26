CREATE TABLE [dbo].[CKS_Provider]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDisabled] [bit] NOT NULL CONSTRAINT [DF_CKS_Provider_IsDisabled] DEFAULT ((0))
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Provider', 'COLUMN', N'IsDisabled'
GO

ALTER TABLE [dbo].[CKS_Provider] ADD CONSTRAINT [PK_CKS_Provider] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
