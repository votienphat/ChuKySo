CREATE TABLE [dbo].[CKS_AgentBrandDetail]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AgentId] [int] NOT NULL,
[BrandDetailId] [int] NOT NULL,
[ProductBrandId] [int] NOT NULL,
[ProductId] [int] NOT NULL,
[PercentProfit] [decimal] (18, 2) NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_AgentBrandDetail_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_AgentBrandDetail] ADD
CONSTRAINT [FK_CKS_AgentBrandDetail_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
ALTER TABLE [dbo].[CKS_AgentBrandDetail] ADD
CONSTRAINT [FK_CKS_AgentBrandDetail_CKS_BrandDetail] FOREIGN KEY ([BrandDetailId]) REFERENCES [dbo].[CKS_BrandDetail] ([Id])
ALTER TABLE [dbo].[CKS_AgentBrandDetail] ADD
CONSTRAINT [FK_CKS_AgentBrandDetail_CKS_ProductBrand] FOREIGN KEY ([ProductBrandId]) REFERENCES [dbo].[CKS_ProductBrand] ([Id])
ALTER TABLE [dbo].[CKS_AgentBrandDetail] ADD
CONSTRAINT [FK_CKS_AgentBrandDetail_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
GO
ALTER TABLE [dbo].[CKS_AgentBrandDetail] ADD CONSTRAINT [PK_CKS_AgentBrandDetail] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số phần trăm đại lý nhận được trong một hợp đồng. Giá trị này là giá trị theo từng sản phẩm cụ thể. Nếu null thì lấy giá trị phần trăm được hưởng theo sản phẩm', 'SCHEMA', N'dbo', 'TABLE', N'CKS_AgentBrandDetail', 'COLUMN', N'PercentProfit'
GO
