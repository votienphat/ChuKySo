CREATE TABLE [dbo].[CKS_Contract]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[TokenType] [int] NOT NULL,
[CompanyId] [int] NOT NULL,
[AgentId] [int] NOT NULL,
[RegisterDate] [datetime] NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NOT NULL,
[Price] [int] NOT NULL,
[Amount] [int] NOT NULL,
[DiscountPercent] [int] NOT NULL,
[Discount] [int] NOT NULL,
[ContractType] [int] NOT NULL,
[ContractDuration] [int] NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_Contract_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_Contract] ADD CONSTRAINT [PK_CKS_Contract] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_Contract] ADD CONSTRAINT [FK_CKS_Contract_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
ALTER TABLE [dbo].[CKS_Contract] ADD CONSTRAINT [FK_CKS_Contract_CKS_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[CKS_Company] ([Id])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Real amount', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'Amount'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Contract type. 0: New, 1: Renew, 2: Change', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'ContractType'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Real amount', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'Discount'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Contract type. 0: New, 1: Renew, 2: Change', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'DiscountPercent'
GO
EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'Price'
GO
