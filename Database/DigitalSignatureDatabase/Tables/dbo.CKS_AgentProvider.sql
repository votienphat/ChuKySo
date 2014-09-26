CREATE TABLE [dbo].[CKS_AgentProvider]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[ProviderId] [int] NOT NULL,
[ProductId] [int] NOT NULL,
[PercentProfit] [decimal] (18, 2) NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentProvider_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_AgentProvider] ADD
CONSTRAINT [FK_CKS_AgentProvider_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
ALTER TABLE [dbo].[CKS_AgentProvider] ADD 
CONSTRAINT [PK_CKS_AgentProvider] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý nhận được trong một hợp đồng. Giá trị này là giá trị chung cho đại lý đối với sản phẩm của từng nhà cung cấp', 'SCHEMA', N'dbo', 'TABLE', N'CKS_AgentProvider', 'COLUMN', N'PercentProfit'
GO

ALTER TABLE [dbo].[CKS_AgentProvider] ADD CONSTRAINT [FK_CKS_AgentProvider_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
GO
ALTER TABLE [dbo].[CKS_AgentProvider] ADD CONSTRAINT [FK_CKS_AgentProvider_CKS_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[CKS_Provider] ([Id])
GO
