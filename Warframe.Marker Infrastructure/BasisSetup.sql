Use master
Go
create DATABASE [Warframe.Market_Infrastructure.DataBaseContext];
Go

use [Warframe.Market_Infrastructure.DataBaseContext];
Go
create schema [enum]
Go


-- Create Enum Tables

create table [enum].[PlatformType] (
	ID int not null primary key,
    Type varchar(4) not null,
);

create table [enum].[IconFormatType] (
    ID int not null primary key,
    Type varchar(4) not null,
);

create table [enum].[OrderType] (
    ID int not null primary key,
    Type varchar(4) not null,
);

create table [enum].[RegionType] (
    ID int not null primary key,
    Type varchar(10) not null,
);

create table [enum].[StatusType] (
    ID int not null primary key,
    Type varchar(10) not null,
);

create table [enum].[RoleType] (
	ID int not null primary key,
    Type varchar(10) not null,
);

create table [enum].[SubTypeType] (
	ID int not null primary key,
    Type varchar(20) not null,
);


-- Create Content Tables

create table [dbo].[LinkedAccounts] (
    ID int not null identity(1,1) primary key,
	HasSteamProfile bit not null,
	HasPatreonProfile bit not null,
	HasXboxProfile bit not null,
	HasDiscordProfile bit not null
);

create table [dbo].[Tag] (
    ID int not null identity(1,1) primary key,
	Text nvarchar(100),
);

create table [dbo].[User] (
    ID int not null identity(1,1) primary key,
	InGameName nvarchar(1000),
	LastSeen datetimeoffset Null,
	Reputation int not null,
	Avatar nvarchar(max),
	RegionID int foreign key references [enum].[RegionType](ID),
	StatusID int foreign key references [enum].[StatusType](ID),
);

create table [dbo].[LoginUser] (
    ID int not null identity(1,1) primary key,
	CheckCode nvarchar(max),
	Banned bit,
	Anonymous bit,
	HasMail bit,
	Verification bit,
	UnreadMessages tinyint,
	WrittenReviews tinyint,
	UserID int foreign key references [dbo].[User](ID),
	PlatformID int foreign key references [enum].[PlatformType](ID),
	RoleID int foreign key references [enum].[RoleType](ID),
	LinkedAccountsID int foreign key references [dbo].[LinkedAccounts](ID),
);

create table [dbo].[Translation] (
    ID int not null identity(1,1) primary key,
    En nvarchar(1000),
    Ru nvarchar(1000),
    Ko nvarchar(1000),
    Fr nvarchar(1000),
	Sv nvarchar(1000),
    De nvarchar(1000),
	ZhHant nvarchar(1000),
    ZhHans nvarchar(1000),
	Pt nvarchar(1000),
    Es nvarchar(1000),
	Pl nvarchar(1000)
);

create table [dbo].[Item] (
    ID int not null identity(1,1) primary key,
	ExternalID nvarchar(100) null,
	UrlName nvarchar(100),
	Thumb nvarchar(1000),
	Ducats int,
	TradingTax int,
	MasteryLevel tinyint,
	MaxRank tinyint,
	Icon nvarchar(max),
	IconFormatID int foreign key references [enum].[IconFormatType](ID),
	DescriptionID int foreign key references [dbo].[Translation](ID),
	WikiLinkID int foreign key references [dbo].[Translation](ID),
	ItemNameID int foreign key references [dbo].[Translation](ID),
);

create table [dbo].[Order] (
    ID int not null identity(1,1) primary key,
	CreationDate DateTimeOffset not null,
	LastUpdate DateTimeOffset not null,
	Quantity int not null,
	Visible bit not null,
	Platinum int not null,
	ModRank tinyint,
	UserID int not null foreign key references [dbo].[User](ID),
	SubTypeTypeID int not null foreign key references [enum].[SubTypeType](ID),
	PlatformTypeID int not null foreign key references [enum].[PlatformType](ID),
	RegionTypeID int not null foreign key references [enum].[RegionType](ID),
	OrderTypeID int not null foreign key references [enum].[OrderType](ID),
);

create table [dbo].[ItemTag] (
    ID int not null identity(1,1) primary key,
	ItemID int not null foreign key references [dbo].[Item](ID),
	TagID int not null foreign key references [dbo].[Tag](ID),
);

create table [dbo].[SetItem] (
    ID int not null identity(1,1) primary key,
	ChildQuantity tinyint not null,
	ChildItemID int not null foreign key references [dbo].[Item](ID),
	ParentItemID int not null foreign key references [dbo].[Item](ID),
);


-- Insert Enum Table Content

insert into [enum].[PlatformType] (ID, Type) values (1, 'Pc')

insert into [enum].[IconFormatType] (ID, Type) values (1, 'Land')
insert into [enum].[IconFormatType] (ID, Type) values (2, 'Port')
				   
insert into [enum].[OrderType] (ID, Type) values (1, 'Sell')
insert into [enum].[OrderType] (ID, Type) values (2, 'Buy')
				   
insert into [enum].[RegionType] (ID, Type) values (1, 'De')
insert into [enum].[RegionType] (ID, Type) values (2, 'En')
insert into [enum].[RegionType] (ID, Type) values (3, 'Fr')
insert into [enum].[RegionType] (ID, Type) values (4, 'Ko')
insert into [enum].[RegionType] (ID, Type) values (5, 'Ru')
insert into [enum].[RegionType] (ID, Type) values (6, 'Sv')
insert into [enum].[RegionType] (ID, Type) values (7, 'ZhHant')
insert into [enum].[RegionType] (ID, Type) values (8, 'ZhHans')
insert into [enum].[RegionType] (ID, Type) values (9, 'Pt')
insert into [enum].[RegionType] (ID, Type) values (10, 'Es')
insert into [enum].[RegionType] (ID, Type) values (11, 'Pl')
						
insert into [enum].[StatusType] (ID, Type) values (1, 'Ingame')
insert into [enum].[StatusType] (ID, Type) values (2, 'Offline')
insert into [enum].[StatusType] (ID, Type) values (3, 'Online')

insert into [enum].[RoleType] (ID, Type) values (1, 'Anonymous')
insert into [enum].[RoleType] (ID, Type) values (2, 'User')
insert into [enum].[RoleType] (ID, Type) values (3, 'Moderator')
insert into [enum].[RoleType] (ID, Type) values (4, 'Admin')

insert into [enum].[SubTypeType] (ID, Type) values (1, 'Intact')
insert into [enum].[SubTypeType] (ID, Type) values (2, 'Exceptional')
insert into [enum].[SubTypeType] (ID, Type) values (3, 'Flawless')
insert into [enum].[SubTypeType] (ID, Type) values (4, 'Radiant')

Go