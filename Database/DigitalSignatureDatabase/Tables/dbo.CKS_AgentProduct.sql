CREATE TABLE [dbo].[CKS_AgentProduct]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[ProductId] [int] NOT NULL,
[PercentProfit] [decimal] (18, 2) NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentProduct_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_AgentProduct] ADD
CONSTRAINT [FK_CKS_AgentProduct_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
ALTER TABLE [dbo].[CKS_AgentProduct] ADD
CONSTRAINT [FK_CKS_AgentProduct_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
GO
ALTER TABLE [dbo].[CKS_AgentProduct] ADD CONSTRAINT [PK_CKS_AgentProduct] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý nhận được trong một hợp đồng. Giá trị này là giá trị chung cho đại lý đối với sản phẩm', 'SCHEMA', N'dbo', 'TABLE', N'CKS_AgentProduct', 'COLUMN', N'PercentProfit'
GO
