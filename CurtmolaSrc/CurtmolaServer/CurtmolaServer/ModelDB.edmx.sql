
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/13/2016 20:24:52
-- Generated from EDMX file: C:\Users\naicul\Desktop\Proiect-TAIP\CurtmolaSrc\CurtmolaServer\CurtmolaServer\ModelDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TAIP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserFolder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserFolder];
GO
IF OBJECT_ID(N'[dbo].[FK_FolderData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Data] DROP CONSTRAINT [FK_FolderData];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Folders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Folders];
GO
IF OBJECT_ID(N'[dbo].[Data]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Data];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [Folder_Id] int  NOT NULL
);
GO

-- Creating table 'Folders'
CREATE TABLE [dbo].[Folders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [createdDate] nvarchar(max)  NOT NULL,
    [asignedUser] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Data'
CREATE TABLE [dbo].[Data] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL,
    [addedDate] nvarchar(max)  NOT NULL,
    [data] nvarchar(max)  NOT NULL,
    [FolderId] int  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [keywords] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Folders'
ALTER TABLE [dbo].[Folders]
ADD CONSTRAINT [PK_Folders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Data'
ALTER TABLE [dbo].[Data]
ADD CONSTRAINT [PK_Data]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Folder_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserFolder]
    FOREIGN KEY ([Folder_Id])
    REFERENCES [dbo].[Folders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFolder'
CREATE INDEX [IX_FK_UserFolder]
ON [dbo].[Users]
    ([Folder_Id]);
GO

-- Creating foreign key on [FolderId] in table 'Data'
ALTER TABLE [dbo].[Data]
ADD CONSTRAINT [FK_FolderData]
    FOREIGN KEY ([FolderId])
    REFERENCES [dbo].[Folders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FolderData'
CREATE INDEX [IX_FK_FolderData]
ON [dbo].[Data]
    ([FolderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------