CREATE TABLE [dbo].[CKS_AgentHierarchy]
(
[Id] [bigint] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[SupervisorId] [int] NULL,
[PercentProfit] [decimal] (18, 2) NOT NULL,
[IsDisabled] [bit] NOT NULL CONSTRAINT [DF_CKS_AgentHierarchy_IsDisabled] DEFAULT ((0)),
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentHierarchy_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_AgentHierarchy] ADD
CONSTRAINT [FK_CKS_AgentHierarchy_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
ALTER TABLE [dbo].[CKS_AgentHierarchy] ADD
CONSTRAINT [FK_CKS_AgentHierarchy_CKS_Agent1] FOREIGN KEY ([SupervisorId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
ALTER TABLE [dbo].[CKS_AgentHierarchy] ADD CONSTRAINT [PK_CKS_AgentHierarchy] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Bảng định nghĩa các đại lý đa cấp', 'SCHEMA', N'dbo', 'TABLE', N'CKS_AgentHierarchy', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý nhận được trong một hợp đồng. Giá trị này là giá trị chung cho đại lý', 'SCHEMA', N'dbo', 'TABLE', N'CKS_AgentHierarchy', 'COLUMN', N'PercentProfit'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Mã đại lý cha. Nếu là đại lý đầu thì null', 'SCHEMA', N'dbo', 'TABLE', N'CKS_AgentHierarchy', 'COLUMN', N'SupervisorId'
GO
