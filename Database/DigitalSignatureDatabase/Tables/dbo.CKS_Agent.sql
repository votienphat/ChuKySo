CREATE TABLE [dbo].[CKS_Agent]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[ParentId] [int] NULL,
[Title] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Firstname] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Lastname] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email1] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email2] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Mobile1] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Mobile2] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Phone] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Address] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Status] [int] NOT NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_Agent_CreateDate] DEFAULT (getdate()),
[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CKS_Agent] ADD CONSTRAINT [PK_CKS_Agent] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Status of agent. 0: New, 1: Active, 2: Blocked', 'SCHEMA', N'dbo', 'TABLE', N'CKS_Agent', 'COLUMN', N'Status'
GO
