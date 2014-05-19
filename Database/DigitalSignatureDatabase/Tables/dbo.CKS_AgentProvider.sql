CREATE TABLE [dbo].[CKS_AgentProvider]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[ProviderId] [int] NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentProvider_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_AgentProvider] ADD CONSTRAINT [PK_CKS_AgentProvider] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_AgentProvider] ADD CONSTRAINT [FK_CKS_AgentProvider_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
ALTER TABLE [dbo].[CKS_AgentProvider] ADD CONSTRAINT [FK_CKS_AgentProvider_CKS_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[CKS_Provider] ([Id])
GO
