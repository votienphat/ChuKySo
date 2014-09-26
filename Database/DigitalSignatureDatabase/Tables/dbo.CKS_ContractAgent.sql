CREATE TABLE [dbo].[CKS_ContractAgent]
(
[Id] [bigint] NOT NULL IDENTITY(1, 1),
[ContractId] [int] NOT NULL,
[AgentId] [int] NOT NULL,
[ProfitAgentId] [int] NOT NULL,
[ProfitSubAgentId] [int] NULL,
[PercentProfitAgent] [decimal] (18, 2) NOT NULL,
[AmountProfitAgent] [decimal] (18, 2) NOT NULL,
[PercentProfitSubAgent] [decimal] (18, 2) NOT NULL,
[AmountProfitSubAgent] [decimal] (18, 2) NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_ContractAgent_CreateDate] DEFAULT (getdate())
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_ContractAgent] ADD
CONSTRAINT [FK_CKS_ContractAgent_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
ALTER TABLE [dbo].[CKS_ContractAgent] ADD
CONSTRAINT [FK_CKS_ContractAgent_CKS_Contract] FOREIGN KEY ([ContractId]) REFERENCES [dbo].[CKS_Contract] ([Id])
ALTER TABLE [dbo].[CKS_ContractAgent] ADD
CONSTRAINT [FK_CKS_ContractAgent_CKS_Agent1] FOREIGN KEY ([ProfitAgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
ALTER TABLE [dbo].[CKS_ContractAgent] ADD
CONSTRAINT [FK_CKS_ContractAgent_CKS_Agent2] FOREIGN KEY ([ProfitSubAgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
ALTER TABLE [dbo].[CKS_ContractAgent] ADD CONSTRAINT [PK_CKS_ContractAgent] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Đại lý ký hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractAgent', 'COLUMN', N'AgentId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số tiền đại lý profit nhận được', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractAgent', 'COLUMN', N'AmountProfitAgent'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số tiền đại lý con của đại lý profit nhận được', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractAgent', 'COLUMN', N'AmountProfitSubAgent'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý profit nhận được trong một hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractAgent', 'COLUMN', N'PercentProfitAgent'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý con của đại lý profit nhận được trong một hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractAgent', 'COLUMN', N'PercentProfitSubAgent'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Đại lý được hưởng phần trăm lợi nhuận từ hợp đồng. Nếu đại lý này là đại lý ký hợp đồng thì giá trị này sẽ giống giá trị AgentId', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractAgent', 'COLUMN', N'ProfitAgentId'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Đại lý cấp con ngay sau đại lý được nhận phần trăm lợi nhuận. Giá trị này để cho biết hợp đồng thuộc nhánh nào. Nếu đại lý hưởng lợi nhuận và đại lý ký hợp đồng là 1 thì giá trị ở đây là rỗng vì không còn đại lý cấp thấp hơn.', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractAgent', 'COLUMN', N'ProfitSubAgentId'
GO
