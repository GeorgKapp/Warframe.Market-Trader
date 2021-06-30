Use master
Go
create DATABASE [Warframe.Market_Infrastructure.DataBaseContext];
Go

use [Warframe.Market_Infrastructure.DataBaseContext];
Go
CREATE SCHEMA [enum]
Go
-- Create Enum Tables

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
    Type varchar(2) not null,
);

create table [enum].[StatusType] (
    ID int not null primary key,
    Type varchar(10) not null,
);
-- Create Content Tables

create table [dbo].[Tag] (
    ID int not null identity(1,1) primary key,
	Text nvarchar(100),
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
						
insert into [enum].[StatusType] (ID, Type) values (1, 'Ingame')
insert into [enum].[StatusType] (ID, Type) values (2, 'Offline')
insert into [enum].[StatusType] (ID, Type) values (3, 'Online')

Go