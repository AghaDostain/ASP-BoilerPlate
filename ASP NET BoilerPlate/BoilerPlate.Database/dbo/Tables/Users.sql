CREATE TABLE [dbo].[Users] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]            NVARCHAR (128) NULL,
    [LastName]             NVARCHAR (128) NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [ImageUrl]             NVARCHAR (512) NULL,
    [IsActive]             BIT            NULL,
    [AlternateUserName]    NVARCHAR (256) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_UserName]
    ON [dbo].[Users]([UserName] ASC);