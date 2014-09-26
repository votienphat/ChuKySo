CREATE TABLE [dbo].[CKS_BrandDetail]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ProductId] [int] NOT NULL,
[ProductBrandId] [int] NOT NULL,
[Code] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Duration] [int] NULL,
[Price] [int] NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_BrandDetail_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_BrandDetail] ADD
CONSTRAINT [FK_CKS_BrandDetail_CKS_ProductBrand] FOREIGN KEY ([ProductBrandId]) REFERENCES [dbo].[CKS_ProductBrand] ([Id])
ALTER TABLE [dbo].[CKS_BrandDetail] ADD
CONSTRAINT [FK_CKS_BrandDetail_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
GO
ALTER TABLE [dbo].[CKS_BrandDetail] ADD CONSTRAINT [PK_CKS_BrandDetail] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Duration for token type, it must be month', 'SCHEMA', N'dbo', 'TABLE', N'CKS_BrandDetail', 'COLUMN', N'Duration'
GO
