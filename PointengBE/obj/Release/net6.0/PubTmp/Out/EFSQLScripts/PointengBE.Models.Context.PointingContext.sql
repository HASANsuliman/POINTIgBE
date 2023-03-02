IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220917163122_plan1')
BEGIN
    CREATE TABLE [CustomClaims] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_CustomClaims] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220917163122_plan1')
BEGIN
    CREATE TABLE [LogHistories] (
        [Id] uniqueidentifier NOT NULL,
        [Type] nvarchar(max) NOT NULL,
        [Month] datetime2 NOT NULL,
        [UserName] nvarchar(max) NULL,
        [DateDeleted] datetime2 NULL,
        CONSTRAINT [PK_LogHistories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220917163122_plan1')
BEGIN
    CREATE TABLE [Plan] (
        [Id] uniqueidentifier NOT NULL,
        [Month] datetime2 NOT NULL,
        [DateFrom] datetime2 NOT NULL,
        [DateTo] datetime2 NOT NULL,
        [PointPrice] int NOT NULL,
        [MinValue] int NOT NULL,
        [UserName] nvarchar(max) NULL,
        [UserUpdate] nvarchar(max) NULL,
        [DateEntry] nvarchar(max) NULL,
        [DateUpdated] nvarchar(max) NULL,
        CONSTRAINT [PK_Plan] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220917163122_plan1')
BEGIN
    CREATE TABLE [SubDirectConfigs] (
        [Id] int NOT NULL IDENTITY,
        [PlanId] uniqueidentifier NOT NULL,
        [RangeId] uniqueidentifier NOT NULL,
        [Month] datetime2 NOT NULL,
        [DateFrom] datetime2 NOT NULL,
        [DateTo] datetime2 NOT NULL,
        [RangeFrom] int NOT NULL,
        [RangeTo] int NOT NULL,
        [SubConfigId] int NOT NULL,
        [Points] int NOT NULL,
        [ExtraPoints] int NOT NULL,
        [REGION] nvarchar(max) NULL,
        [CITY] nvarchar(max) NULL,
        [ZONE] nvarchar(max) NULL,
        [AREA] nvarchar(max) NULL,
        [SUBAREA] nvarchar(max) NULL,
        [UserName] nvarchar(max) NULL,
        [DateEntry] datetime2 NULL,
        [SUBDEALER] nvarchar(max) NULL,
        CONSTRAINT [PK_SubDirectConfigs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220917163122_plan1')
BEGIN
    CREATE TABLE [DirectConfigs] (
        [Id] uniqueidentifier NOT NULL,
        [PlanId] uniqueidentifier NOT NULL,
        [Month] datetime2 NOT NULL,
        [RangeFrom] int NOT NULL,
        [RangeTo] int NOT NULL,
        [Points] int NOT NULL,
        [UserName] nvarchar(max) NULL,
        [DateEntry] nvarchar(max) NULL,
        [DateDeleted] datetime2 NULL,
        CONSTRAINT [PK_DirectConfigs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DirectConfigs_Plan_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [Plan] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220917163122_plan1')
BEGIN
    CREATE INDEX [IX_DirectConfigs_PlanId] ON [DirectConfigs] ([PlanId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220917163122_plan1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220917163122_plan1', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923232109_updatesubconfig')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SubDirectConfigs]') AND [c].[name] = N'DateEntry');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [SubDirectConfigs] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [SubDirectConfigs] ALTER COLUMN [DateEntry] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923232109_updatesubconfig')
BEGIN
    CREATE TABLE [Locations] (
        [Id] uniqueidentifier NOT NULL,
        [Sd_Code] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Shop_Name] nvarchar(max) NULL,
        [Supervisor] nvarchar(max) NULL,
        [SalesRep] nvarchar(max) NULL,
        [REGION] nvarchar(max) NULL,
        [CITY] nvarchar(max) NULL,
        [ZONE] nvarchar(max) NULL,
        [AREA] nvarchar(max) NULL,
        [SUBAREA] nvarchar(max) NULL,
        CONSTRAINT [PK_Locations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220923232109_updatesubconfig')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220923232109_updatesubconfig', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924124426_updateclaims')
BEGIN
    ALTER TABLE [CustomClaims] ADD [Group] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220924124426_updateclaims')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220924124426_updateclaims', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925115414_setnew')
BEGIN
    DROP TABLE [Locations];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925115414_setnew')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925115414_setnew', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925115702_setnewsales')
BEGIN
    CREATE TABLE [Location] (
        [Id] uniqueidentifier NOT NULL,
        [MONTH] nvarchar(max) NULL,
        [SD_CODE] nvarchar(max) NULL,
        [SD_NAME] nvarchar(max) NULL,
        [SHOP_NAME] nvarchar(max) NULL,
        [REGION] nvarchar(max) NULL,
        [CITY] nvarchar(max) NULL,
        [ZONE] nvarchar(max) NULL,
        [AREA] nvarchar(max) NULL,
        [SUBAREA] nvarchar(max) NULL,
        [STREET] nvarchar(max) NULL,
        [SUPERVISOR] nvarchar(max) NULL,
        [RETAIL] nvarchar(max) NULL,
        CONSTRAINT [PK_Location] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925115702_setnewsales')
BEGIN
    CREATE TABLE [Sale] (
        [Id] uniqueidentifier NOT NULL,
        [DAY] datetime2 NOT NULL,
        [MONTH] nvarchar(max) NULL,
        [SD_CODE] nvarchar(max) NULL,
        [SD_NAME] nvarchar(max) NULL,
        [SHOP_NAME] nvarchar(max) NULL,
        [REGION] nvarchar(max) NULL,
        [CITY] nvarchar(max) NULL,
        [ZONE] nvarchar(max) NULL,
        [AREA] nvarchar(max) NULL,
        [SUBAREA] nvarchar(max) NULL,
        [SUPERVISOR] nvarchar(max) NULL,
        [RETAIL] nvarchar(max) NULL,
        [SUBNO] nvarchar(max) NULL,
        [ACTIVEANDHAVECALL] int NOT NULL,
        [FIRST_RECHARGE] int NOT NULL,
        CONSTRAINT [PK_Sale] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925115702_setnewsales')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925115702_setnewsales', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925120559_drop')
BEGIN
    DROP TABLE [Location];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925120559_drop')
BEGIN
    DROP TABLE [Sale];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925120559_drop')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925120559_drop', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925120656_setsales')
BEGIN
    CREATE TABLE [Location] (
        [Id] int NOT NULL IDENTITY,
        [MONTH] nvarchar(max) NULL,
        [SD_CODE] nvarchar(max) NULL,
        [SD_NAME] nvarchar(max) NULL,
        [SHOP_NAME] nvarchar(max) NULL,
        [REGION] nvarchar(max) NULL,
        [CITY] nvarchar(max) NULL,
        [ZONE] nvarchar(max) NULL,
        [AREA] nvarchar(max) NULL,
        [SUBAREA] nvarchar(max) NULL,
        [STREET] nvarchar(max) NULL,
        [SUPERVISOR] nvarchar(max) NULL,
        [RETAIL] nvarchar(max) NULL,
        CONSTRAINT [PK_Location] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925120656_setsales')
BEGIN
    CREATE TABLE [Sales] (
        [Id] int NOT NULL IDENTITY,
        [DAY] datetime2 NOT NULL,
        [MONTH] nvarchar(max) NULL,
        [SD_CODE] nvarchar(max) NULL,
        [SD_NAME] nvarchar(max) NULL,
        [SHOP_NAME] nvarchar(max) NULL,
        [REGION] nvarchar(max) NULL,
        [CITY] nvarchar(max) NULL,
        [ZONE] nvarchar(max) NULL,
        [AREA] nvarchar(max) NULL,
        [SUBAREA] nvarchar(max) NULL,
        [SUPERVISOR] nvarchar(max) NULL,
        [RETAIL] nvarchar(max) NULL,
        [SUBNO] nvarchar(max) NULL,
        [ACTIVEANDHAVECALL] int NOT NULL,
        [FIRST_RECHARGE] int NOT NULL,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925120656_setsales')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925120656_setsales', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925123930_setsales1')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sales]') AND [c].[name] = N'FIRST_RECHARGE');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Sales] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Sales] ALTER COLUMN [FIRST_RECHARGE] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925123930_setsales1')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Sales]') AND [c].[name] = N'ACTIVEANDHAVECALL');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Sales] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Sales] ALTER COLUMN [ACTIVEANDHAVECALL] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925123930_setsales1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925123930_setsales1', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925124100_setsales2')
BEGIN
    ALTER TABLE [Sales] ADD [Extrapoint] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925124100_setsales2')
BEGIN
    ALTER TABLE [Sales] ADD [Point] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925124100_setsales2')
BEGIN
    ALTER TABLE [Sales] ADD [ToalPoint] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925124100_setsales2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925124100_setsales2', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925124637_setsales2e')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Location]') AND [c].[name] = N'STREET');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Location] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Location] DROP COLUMN [STREET];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220925124637_setsales2e')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220925124637_setsales2e', N'6.0.9');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221003115533_AddCalcl')
BEGIN
    CREATE TABLE [Calculations] (
        [Id] int NOT NULL IDENTITY,
        [PlanId] uniqueidentifier NOT NULL,
        [Plan] datetime2 NULL,
        [UserName] nvarchar(max) NULL,
        [DateEntry] nvarchar(max) NULL,
        CONSTRAINT [PK_Calculations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221003115533_AddCalcl')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221003115533_AddCalcl', N'6.0.9');
END;
GO

COMMIT;
GO

