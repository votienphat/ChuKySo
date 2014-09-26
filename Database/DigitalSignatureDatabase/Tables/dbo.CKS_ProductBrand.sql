CREATE TABLE [dbo].[CKS_ProductBrand]
(
[Id] [int] NOT NULL,
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ProductId] [int] NOT NULL,
[IsDisabled] [bit] NOT NULL CONSTRAINT [DF_CKS_ProductBrand_IsDisabled] DEFAULT ((0)),
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_ProductBrand_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_ProductBrand] ADD 
CONSTRAINT [PK_CKS_ProductBrand] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ProductBrand', 'COLUMN', N'IsDisabled'
GO

ALTER TABLE [dbo].[CKS_ProductBrand] ADD
CONSTRAINT [FK_CKS_ProductBrand_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
GO
