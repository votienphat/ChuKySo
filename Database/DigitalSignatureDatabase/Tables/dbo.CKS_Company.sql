CREATE TABLE [dbo].[CKS_Company]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TransTitle] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CompanyType] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Address] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[City] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Phone] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Fax] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Website] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CompanyCode] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ActiveDate] [datetime] NULL,
[LegalRepresentive] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LegalRepresentiveAddress] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AuthorizedCapital] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DescriptionMajor] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Directors] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Avatar] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AllowedDate] [datetime] NULL,
[IsDisabled] [bit] NOT NULL CONSTRAINT [DF_CKS_Company_IsDisabled] DEFAULT ((0)),
[CreateUser] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_Company_CreateDate] DEFAULT (getdate()),
[UpdateUser] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[UpdateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_Company_UpdateDate] DEFAULT (getdate())
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_Company] ADD CONSTRAINT [PK_CKS_Company] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ngày hoạt động chính thức', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'ActiveDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ngày cấp phép', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'AllowedDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Vốn điều lệ', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'AuthorizedCapital'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Hình ảnh được lưu dưới mã base 64', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'Avatar'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Mã số doanh nghiệp', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'CompanyCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Loại hình doanh nghiệp: TNHH, Cổ phần...', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'CompanyType'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ngày tạo', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'CreateDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Mô tả khác', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'Description'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ngành nghề kinh doanh', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'DescriptionMajor'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Hội đồng quản trị', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'Directors'
GO
EXEC sp_addextendedproperty N'MS_Description', N'', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'IsDisabled'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Người đại diện pháp luật', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'LegalRepresentive'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Tên giao dịch', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'TransTitle'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ngày tạo', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Company', 'COLUMN', N'UpdateDate'
GO
