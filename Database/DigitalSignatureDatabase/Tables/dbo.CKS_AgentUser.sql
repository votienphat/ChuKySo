CREATE TABLE [dbo].[CKS_AgentUser]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[UserId] [int] NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentUser_CreateDate] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_AgentUser] ADD CONSTRAINT [PK_CKS_AgentUser] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_AgentUser] ADD CONSTRAINT [FK_CKS_AgentUser_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
