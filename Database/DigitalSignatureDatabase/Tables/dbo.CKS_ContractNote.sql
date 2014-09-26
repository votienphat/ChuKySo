CREATE TABLE [dbo].[CKS_ContractNote]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[ContractId] [int] NOT NULL,
[AgentId] [int] NULL,
[ActionType] [int] NOT NULL,
[Note] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_CKS_ContractNote_CreateDate] DEFAULT (getdate())
) ON [PRIMARY]
ALTER TABLE [dbo].[CKS_ContractNote] ADD
CONSTRAINT [FK_CKS_ContractNote_CKS_Agent] FOREIGN KEY ([AgentId]) REFERENCES [dbo].[CKS_Agent] ([Id])
ALTER TABLE [dbo].[CKS_ContractNote] ADD
CONSTRAINT [FK_CKS_ContractNote_CKS_Contract] FOREIGN KEY ([ContractId]) REFERENCES [dbo].[CKS_Contract] ([Id])
GO
ALTER TABLE [dbo].[CKS_ContractNote] ADD CONSTRAINT [PK_CKS_ContractNote] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Các hành động đối với contract', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractNote', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Thao thác thực hiện. 0: Tạo mới, 1: Xác nhận, 2: Từ chối, 3: Hủy', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractNote', 'COLUMN', N'ActionType'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Đại lý thực hiện thao tác', 'SCHEMA', N'dbo', 'TABLE', N'CKS_ContractNote', 'COLUMN', N'AgentId'
GO
