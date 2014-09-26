CREATE TABLE [dbo].[CKS_ProductProvider]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[ProductId] [int] NOT NULL,
[ProviderId] [int] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_ProductProvider] ADD
CONSTRAINT [FK_CKS_ProductProvider_CKS_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[CKS_Product] ([Id])
ALTER TABLE [dbo].[CKS_ProductProvider] ADD
CONSTRAINT [FK_CKS_ProductProvider_CKS_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[CKS_Provider] ([Id])
GO
ALTER TABLE [dbo].[CKS_ProductProvider] ADD CONSTRAINT [PK_CKS_ProductProvider] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
