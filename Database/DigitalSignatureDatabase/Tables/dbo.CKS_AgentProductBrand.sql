CREATE TABLE [dbo].[CKS_AgentProductBrand]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[ProductBrandId] [int] NOT NULL,
[ProductId] [int] NOT NULL,
[PercentProfit] [decimal] (18, 2) NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentProductBrand_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_AgentProductBrand] ADD
CONSTRAINT [FK_CKS_AgentProductBrand_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
ALTER TABLE [dbo].[CKS_AgentProductBrand] ADD
CONSTRAINT [FK_CKS_AgentProductBrand_CKS_ProductBrand] FOREIGN KEY ([ProductBrandId]) REFERENCES [dbo].[CKS_ProductBrand] ([Id])
ALTER TABLE [dbo].[CKS_AgentProductBrand] ADD
CONSTRAINT [FK_CKS_AgentProductBrand_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
GO
ALTER TABLE [dbo].[CKS_AgentProductBrand] ADD CONSTRAINT [PK_CKS_AgentProductBrand] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý nhận được trong một hợp đồng. Giá trị này là giá trị theo từng sản phẩm cụ thể. Nếu null thì lấy giá trị phần trăm được hưởng theo sản phẩm', 'SCHEMA', N'dbo', 'TABLE', N'CKS_AgentProductBrand', 'COLUMN', N'PercentProfit'
GO
