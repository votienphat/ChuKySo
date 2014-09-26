CREATE TABLE [dbo].[CKS_CompanyProduct]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[CompanyId] [int] NOT NULL,
[ProductId] [int] NOT NULL,
[ContractNumber] [int] NOT NULL CONSTRAINT [DF_CKS_CompanyProduct_ContractNumber] DEFAULT ((0))
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_CompanyProduct] ADD
CONSTRAINT [FK_CKS_CompanyProduct_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
ALTER TABLE [dbo].[CKS_CompanyProduct] ADD
CONSTRAINT [FK_CKS_CompanyProduct_CKS_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[CKS_Company] ([Id])
GO
ALTER TABLE [dbo].[CKS_CompanyProduct] ADD CONSTRAINT [PK_CKS_CompanyProduct] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Số lượng hợp đồng CKS mà công ty đã ký', 'SCHEMA', N'dbo', 'TABLE', N'CKS_CompanyProduct', 'COLUMN', N'ContractNumber'
GO
