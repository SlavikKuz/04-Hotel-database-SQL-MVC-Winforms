IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [ClientFullName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Tel] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Notes] nvarchar(max) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Bookings] (
    [Id] bigint NOT NULL IDENTITY,
    [ClientId] bigint NOT NULL,
    [ClientId1] int NULL,
    [OrderDate] datetime2 NOT NULL,
    [DayFrom] datetime2 NOT NULL,
    [DayTill] datetime2 NOT NULL,
    [NumberAdults] int NOT NULL,
    [NumberKids] int NOT NULL,
    [Status] nvarchar(max) NULL,
    [Info] nvarchar(max) NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Bookings_Clients_ClientId1] FOREIGN KEY ([ClientId1]) REFERENCES [Clients] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Holidays] (
    [Id] int NOT NULL IDENTITY,
    [DayHoliday] datetime2 NOT NULL,
    [HolidayName] nvarchar(max) NULL,
    [BookingId] bigint NULL,
    CONSTRAINT [PK_Holidays] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Holidays_Bookings_BookingId] FOREIGN KEY ([BookingId]) REFERENCES [Bookings] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Rooms] (
    [Id] bigint NOT NULL IDENTITY,
    [RoomDescription] nvarchar(max) NULL,
    [NumberBeds] int NOT NULL,
    [Floor] nvarchar(max) NULL,
    [Info] nvarchar(max) NULL,
    [BookingId] bigint NULL,
    [Active] nvarchar(max) NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rooms_Bookings_BookingId] FOREIGN KEY ([BookingId]) REFERENCES [Bookings] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Bookings_ClientId1] ON [Bookings] ([ClientId1]);

GO

CREATE INDEX [IX_Holidays_BookingId] ON [Holidays] ([BookingId]);

GO

CREATE INDEX [IX_Rooms_BookingId] ON [Rooms] ([BookingId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191103102605_initial', N'3.1.0-preview2.19525.5');

GO

