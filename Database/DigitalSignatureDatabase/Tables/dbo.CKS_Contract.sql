CREATE TABLE [dbo].[CKS_Contract]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[TokenType] [int] NOT NULL,
[CompanyId] [int] NOT NULL,
[AgentId] [int] NOT NULL,
[RegisterDate] [datetime] NULL,
[ConfirmDate] [datetime] NULL,
[Note] [datetime] NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NULL,
[Price] [decimal] (18, 2) NOT NULL,
[DiscountPercent] [decimal] (18, 2) NOT NULL CONSTRAINT [DF_CKS_Contract_DiscountPercent] DEFAULT ((0)),
[Discount] [decimal] (18, 2) NOT NULL,
[Amount] [decimal] (18, 2) NOT NULL,
[ProviderAmount] [decimal] (18, 2) NOT NULL,
[AgentPercent] [decimal] (18, 2) NOT NULL,
[AgentAmount] [decimal] (18, 2) NOT NULL,
[ContractType] [int] NOT NULL,
[ContractStatus] [int] NOT NULL,
[ContractDuration] [int] NULL,
[IsDisabled] [bit] NOT NULL CONSTRAINT [DF_CKS_Contract_IsDisabled] DEFAULT ((0)),
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_Contract_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_Contract] ADD 
CONSTRAINT [PK_CKS_Contract] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số tiền đại lý sẽ nhận', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'AgentAmount'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Agent tạo hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'AgentId'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý nhận được trong một hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'AgentPercent'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Số tiền nhận được sau khi giảm giá', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'Amount'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Ngày phản hồi hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'ConfirmDate'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Trạng thái hợp đồng. 0: New, 1: Accept, 2: Denied', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'ContractStatus'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Loại hợp đồng. 0: New, 1: Renew, 2: Change', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'ContractType'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Số tiền được giảm', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'Discount'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Phần trăm được giảm giá', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'DiscountPercent'
GO

EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'IsDisabled'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Ngày phản hồi hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'Note'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Mệnh giá của hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'Price'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Số tiền nhà cung cấp sẽ nhận', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'ProviderAmount'
GO

EXEC sp_addextendedproperty N'MS_Description', N'Ngày agent đăng ký hợp đồng', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Contract', 'COLUMN', N'RegisterDate'
GO


ALTER TABLE [dbo].[CKS_Contract] ADD CONSTRAINT [FK_CKS_Contract_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
ALTER TABLE [dbo].[CKS_Contract] ADD CONSTRAINT [FK_CKS_Contract_CKS_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[CKS_Company] ([Id])
GO
