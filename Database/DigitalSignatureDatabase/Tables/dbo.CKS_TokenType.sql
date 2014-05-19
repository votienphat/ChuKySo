CREATE TABLE [dbo].[CKS_TokenType]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[ProviderId] [int] NOT NULL,
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Duration] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_TokenType] ADD CONSTRAINT [PK_CKS_TokenType] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Token type: 3 months, 6 months, 1 years', 'SCHEMA', N'dbo', 'TABLE', N'CKS_TokenType', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Duration for token type, it must be month', 'SCHEMA', N'dbo', 'TABLE', N'CKS_TokenType', 'COLUMN', N'Duration'
GO
