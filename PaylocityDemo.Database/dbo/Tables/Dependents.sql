CREATE TABLE [dbo].[Dependents] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FullName]     NVARCHAR (MAX) NULL,
    [ModifiedDate] DATETIME2 (7)  NOT NULL,
    [EmployeeId]   INT            NULL,
    CONSTRAINT [PK_Dependents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Dependents_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Dependents_EmployeeId]
    ON [dbo].[Dependents]([EmployeeId] ASC);

