
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/09/2017 21:12:02
-- Generated from EDMX file: F:\work\甲方资料\B部项目\BeckMan\BeckMan.Del\BeckManDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BeckMan];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'bes_userSet'
CREATE TABLE [dbo].[bes_userSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserNo] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [RoleType] nvarchar(max)  NOT NULL,
    [IsDistributor] nvarchar(max)  NOT NULL,
    [Activity] nvarchar(max)  NOT NULL,
    [UserCode] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'bec_AearSet'
CREATE TABLE [dbo].[bec_AearSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Remak] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'bec_ProductSet'
CREATE TABLE [dbo].[bec_ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SequeNo] nvarchar(max)  NOT NULL,
    [Year] nvarchar(max)  NOT NULL,
    [PName] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'bec_PartionSet'
CREATE TABLE [dbo].[bec_PartionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PartionID] nvarchar(max)  NOT NULL,
    [PartionName] nvarchar(max)  NOT NULL,
    [bes_user_Id] int  NOT NULL
);
GO

-- Creating table 'bec_AssInformationSet'
CREATE TABLE [dbo].[bec_AssInformationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] nvarchar(max)  NOT NULL,
    [DisNo] nvarchar(max)  NOT NULL,
    [DisName] nvarchar(max)  NOT NULL,
    [MYTotal] nvarchar(max)  NOT NULL,
    [MYSales] nvarchar(max)  NOT NULL,
    [MYApplication] nvarchar(max)  NOT NULL,
    [MYCallCenter] nvarchar(max)  NOT NULL,
    [MYOperation] nvarchar(max)  NOT NULL,
    [SalesState] nvarchar(max)  NOT NULL,
    [AppState] nvarchar(max)  NOT NULL,
    [CallCenterState] nvarchar(max)  NOT NULL,
    [OperationState] nvarchar(max)  NOT NULL,
    [AYTotal] nvarchar(max)  NOT NULL,
    [AYSales] nvarchar(max)  NOT NULL,
    [AYApplication] nvarchar(max)  NOT NULL,
    [AYCallCenter] nvarchar(max)  NOT NULL,
    [AYOperation] nvarchar(max)  NOT NULL,
    [bec_Partion_Id] int  NOT NULL,
    [bec_Aear_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'bes_userSet'
ALTER TABLE [dbo].[bes_userSet]
ADD CONSTRAINT [PK_bes_userSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'bec_AearSet'
ALTER TABLE [dbo].[bec_AearSet]
ADD CONSTRAINT [PK_bec_AearSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'bec_ProductSet'
ALTER TABLE [dbo].[bec_ProductSet]
ADD CONSTRAINT [PK_bec_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'bec_PartionSet'
ALTER TABLE [dbo].[bec_PartionSet]
ADD CONSTRAINT [PK_bec_PartionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'bec_AssInformationSet'
ALTER TABLE [dbo].[bec_AssInformationSet]
ADD CONSTRAINT [PK_bec_AssInformationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [bes_user_Id] in table 'bec_PartionSet'
ALTER TABLE [dbo].[bec_PartionSet]
ADD CONSTRAINT [FK_bes_userbec_Partion]
    FOREIGN KEY ([bes_user_Id])
    REFERENCES [dbo].[bes_userSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_bes_userbec_Partion'
CREATE INDEX [IX_FK_bes_userbec_Partion]
ON [dbo].[bec_PartionSet]
    ([bes_user_Id]);
GO

-- Creating foreign key on [bec_Partion_Id] in table 'bec_AssInformationSet'
ALTER TABLE [dbo].[bec_AssInformationSet]
ADD CONSTRAINT [FK_bec_Partionbec_AssInformation]
    FOREIGN KEY ([bec_Partion_Id])
    REFERENCES [dbo].[bec_PartionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_bec_Partionbec_AssInformation'
CREATE INDEX [IX_FK_bec_Partionbec_AssInformation]
ON [dbo].[bec_AssInformationSet]
    ([bec_Partion_Id]);
GO

-- Creating foreign key on [bec_Aear_Id] in table 'bec_AssInformationSet'
ALTER TABLE [dbo].[bec_AssInformationSet]
ADD CONSTRAINT [FK_bec_Aearbec_AssInformation]
    FOREIGN KEY ([bec_Aear_Id])
    REFERENCES [dbo].[bec_AearSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_bec_Aearbec_AssInformation'
CREATE INDEX [IX_FK_bec_Aearbec_AssInformation]
ON [dbo].[bec_AssInformationSet]
    ([bec_Aear_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------