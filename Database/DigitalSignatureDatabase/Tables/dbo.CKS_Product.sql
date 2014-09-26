CREATE TABLE [dbo].[CKS_Product]
(
[Id] [int] NOT NULL IDENTITY(10001, 1),
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsDisabled] [bit] NOT NULL CONSTRAINT [DF_CKS_Product_IsDisabled] DEFAULT ((0))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_Product] ADD CONSTRAINT [PK_CKS_Product] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Định nghĩa các sản phẩm như Chữ Ký Số, VipLife...', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Product', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Product', 'COLUMN', N'IsDisabled'
GO
