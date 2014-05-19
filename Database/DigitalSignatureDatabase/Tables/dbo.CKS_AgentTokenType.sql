CREATE TABLE [dbo].[CKS_AgentTokenType]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[TokenTypeId] [int] NOT NULL,
[ProviderId] [int] NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentTokenType_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_AgentTokenType] ADD CONSTRAINT [PK_CKS_AgentTokenType] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_AgentTokenType] ADD CONSTRAINT [FK_CKS_AgentTokenType_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
ALTER TABLE [dbo].[CKS_AgentTokenType] ADD CONSTRAINT [FK_CKS_AgentTokenType_CKS_TokenType] FOREIGN KEY ([TokenTypeId]) REFERENCES [dbo].[CKS_TokenType] ([Id])
GO
