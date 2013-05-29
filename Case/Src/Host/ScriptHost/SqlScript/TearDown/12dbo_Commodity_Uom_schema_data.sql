

----------------------------drop vtag-commodity fk-------------------------
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tag_Commodity]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tag]'))
ALTER TABLE [dbo].[Tag] DROP CONSTRAINT [FK_Tag_Commodity]
GO

----------------------------drop costcommodity fk----------------------------
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CostCommodity_Commodity]') AND parent_object_id = OBJECT_ID(N'[dbo].[CostCommodity]'))
ALTER TABLE [dbo].[CostCommodity] DROP CONSTRAINT [FK_CostCommodity_Commodity]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CostCommodity_Uom]') AND parent_object_id = OBJECT_ID(N'[dbo].[CostCommodity]'))
ALTER TABLE [dbo].[CostCommodity] DROP CONSTRAINT [FK_CostCommodity_Uom]
GO

-----------------------------------------------------------------------------
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AdvancedProperty_Uom]') AND parent_object_id = OBJECT_ID(N'[dbo].[AdvancedProperty]'))
ALTER TABLE [dbo].[AdvancedProperty] DROP CONSTRAINT [FK_AdvancedProperty_Uom]
GO


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CARBONFA_REFERENCE_COMMODIT]') AND parent_object_id = OBJECT_ID(N'[dbo].[CarbonFactor]'))
ALTER TABLE [dbo].[CarbonFactor] DROP CONSTRAINT [FK_CARBONFA_REFERENCE_COMMODIT]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CARBONFA_REFERENCE_CARBONFA]') AND parent_object_id = OBJECT_ID(N'[dbo].[CarbonFactorItem]'))
ALTER TABLE [dbo].[CarbonFactorItem] DROP CONSTRAINT [FK_CARBONFA_REFERENCE_CARBONFA]
GO



----------------------------create commodity uom tables--------------------
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CarbonFactor') and o.name = 'FK_CARBONFACTOR_REFERENCE_COMMODITY')
alter table CarbonFactor
   drop constraint FK_CARBONFACTOR_REFERENCE_COMMODITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UomGroup') and o.name = 'FK_UOMGROUP_REFERENCE_COMMODITY')
alter table UomGroup
   drop constraint FK_UOMGROUP_REFERENCE_COMMODITY
go

alter table Commodity
   drop constraint PK_COMMODITY
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Commodity')
            and   type = 'U')
   drop table Commodity
go

/*==============================================================*/
/* Table: Commodity                                             */
/*==============================================================*/
create table Commodity (
   Id                   bigint               identity(1,1) not for replication,
   code                 nvarchar(100)        null,
   Comment              nvarchar(200)        null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        null,
   UpdateTime           datetime             null,
   Version              rowversion           null
)
go

alter table Commodity
   add constraint PK_COMMODITY primary key (Id)
go


-----------------------------------------------------

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UomGroup') and o.name = 'FK_UOMGROUP_REFERENCE_COMMODITY')
alter table UomGroup
   drop constraint FK_UOMGROUP_REFERENCE_COMMODITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UomGroupRelation') and o.name = 'FK_UOMGROUPRELATION_REFERENCE_UOMGROUP')
alter table UomGroupRelation
   drop constraint FK_UOMGROUPRELATION_REFERENCE_UOMGROUP
go

alter table UomGroup
   drop constraint PK_UOMGROUP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UomGroup')
            and   type = 'U')
   drop table UomGroup
go

/*==============================================================*/
/* Table: UomGroup                                              */
/*==============================================================*/
create table UomGroup (
   Id                   bigint               identity(1,1) not for replication,
   code                 nvarchar(100)        null,
   Comment              nvarchar(400)        null,
   UpdateUser           nvarchar(100)        null,
   UpdateTime           datetime             null,
   Version              rowversion           null,
   CommodityId          bigint               null,
   IsEnergyConsumptionGroup bit                  null
)
go

alter table UomGroup
   add constraint PK_UOMGROUP primary key (Id)
go

alter table UomGroup
   add constraint FK_UOMGROUP_REFERENCE_COMMODITY foreign key (CommodityId)
      references Commodity (Id)
go


---------------------------------------

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UomGroupRelation') and o.name = 'FK_UOMGROUPRELATION_REFERENCE_UOMGROUP')
alter table UomGroupRelation
   drop constraint FK_UOMGROUPRELATION_REFERENCE_UOMGROUP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UomGroupRelation') and o.name = 'FK_UOM_REFERENCE_UOMGROUPRELATION')
alter table UomGroupRelation
   drop constraint FK_UOM_REFERENCE_UOMGROUPRELATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UomGroupRelation')
            and   type = 'U')
   drop table UomGroupRelation
go

/*==============================================================*/
/* Table: UomGroupRelation                                      */
/*==============================================================*/
create table UomGroupRelation (
   "Precision"          int                  null,
   GroupId              bigint               null,
   UomId                bigint               null,
   IsBase               bit                  null,
   IsCommon             bit                  null,
   IsStandardCoal       bit                  null,
   Factor               decimal(18,8)              null
)
go

alter table UomGroupRelation
   add constraint FK_UOMGROUPRELATION_REFERENCE_UOMGROUP foreign key (GroupId)
      references UomGroup (Id)
go

alter table UomGroupRelation
   add constraint FK_UOM_REFERENCE_UOMGROUPRELATION foreign key (UomId)
      references Uom (Id)
go


----------------------------------


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UomGroupRelation') and o.name = 'FK_UOM_REFERENCE_UOMGROUPRELATION')
alter table UomGroupRelation
   drop constraint FK_UOM_REFERENCE_UOMGROUPRELATION
go

alter table Uom
   drop constraint PK_UOM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Uom')
            and   type = 'U')
   drop table Uom
go

/*==============================================================*/
/* Table: Uom                                                   */
/*==============================================================*/
create table Uom (
   Id                   bigint               identity(1,1) not for replication,
   code                 nvarchar(100)        null,
   Comment              nvarchar(200)        null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        null,
   UpdateTime           datetime             null,
   Version              rowversion           null
)
go

alter table Uom
   add constraint PK_UOM primary key (Id)
go



--------------------------------------------------



if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CarbonFactor') and o.name = 'FK_CARBONFA_REFERENCE_COMMODIT')
alter table CarbonFactor
   drop constraint FK_CARBONFA_REFERENCE_COMMODIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CarbonFactorItem') and o.name = 'FK_CARBONFA_REFERENCE_CARBONFA')
alter table CarbonFactorItem
   drop constraint FK_CARBONFA_REFERENCE_CARBONFA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CarbonFactor')
            and   type = 'U')
   drop table CarbonFactor
go

/*==============================================================*/
/* Table: CarbonFactor                                          */
/*==============================================================*/
create table CarbonFactor (
   Id                   bigint               identity(1,1) not for replication,
   CommodityId          bigint               null,
   FactorType           int                  null,
   UpdateUser           varchar(100)         null,
   UpdateTime           datetime             null,
   Version              rowversion           null,
   constraint PK_CARBONFACTOR primary key (Id)
)
go

alter table CarbonFactor
   add constraint FK_CARBONFA_REFERENCE_COMMODIT foreign key (CommodityId)
      references Commodity (Id)
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CarbonFactorItem') and o.name = 'FK_CARBONFA_REFERENCE_CARBONFA')
alter table CarbonFactorItem
   drop constraint FK_CARBONFA_REFERENCE_CARBONFA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CarbonFactorItem')
            and   type = 'U')
   drop table CarbonFactorItem
go

/*==============================================================*/
/* Table: CarbonFactorItem                                      */
/*==============================================================*/
create table CarbonFactorItem (
   Id                   bigint               identity(1,1) not for replication,
   CarbonFactorId       bigint               null,
   EffectiveTime        datetime             null,
   FactorValue          decimal(15,6)        null,
   constraint PK_CARBONFACTORITEM primary key (Id)
)
go

alter table CarbonFactorItem
   add constraint FK_CARBONFA_REFERENCE_CARBONFA foreign key (CarbonFactorId)
      references CarbonFactor (Id)
go


----------------------------end create commodity uom tables-----------------------


----------------------------create commodity uom data-----------------------------
DELETE FROM CarbonFactor
DELETE FROM UomGroupRelation
DELETE FROM UomGroup
DELETE FROM Commodity
DELETE FROM Uom

--------Commodity--------
SET IDENTITY_INSERT Commodity ON
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (1,'Electricity',N'电',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (2,'Water',N'自来水',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (3,'Gas',N'天然气',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (4,'SoftWater',N'软水',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (5,'Petrol',N'汽油',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (6,'LowPressureSteam',N'低压蒸汽',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (7,'DieselOil',N'柴油',1,'DEMO','2011-12-19 00:00:00')
------ modified on 2012-05-15 ------
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (0,'Other',N'其他',1,'DEMO','2011-12-19 00:00:00')
------ modified on 2012-07-26 ------
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (8,'HeatQ',N'热量',1,'DEMO','2012-07-26 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (9,'CoolQ',N'冷量',1,'DEMO','2012-07-26 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (10,'Coal',N'煤',1,'DEMO','2012-07-26 00:00:00')
INSERT INTO Commodity (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (11,'CoalOil',N'煤油',1,'DEMO','2012-07-26 00:00:00')

SET IDENTITY_INSERT Commodity OFF

--------Uom--------
SET IDENTITY_INSERT Uom ON
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (1,'KWH',N'千瓦时',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (2,'KVARH',N'千乏时',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (3,'KVAH',N'千伏安时',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (4,'KW',N'千瓦',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (5,'m3',N'立方米',1,'DEMO','2011-12-19 00:00:00')
--INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (6,'m3/hour',N'立方米/小时',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (7,'ppm',N'百万分比浓度',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (8,'kg',N'千克',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (9,'Ton',N'吨',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (10,'J',N'焦',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (11,'GJ',N'千焦',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (12,'RMB',N'人民币',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (13,'m2',N'平方米',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (14,'h',N'小时',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (15,'m',N'分',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (16,'s',N'秒',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (17,'oC',N'摄氏度',1,'DEMO','2011-12-19 00:00:00')
------ added on 2012-05-15-------
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (18,'kgce',N'千克标煤',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (19,'kgCO2',N'千克二氧化碳',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (20,'Tree',N'棵树',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (21,'Person',N'人',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (22,'KW/M2',N'千瓦/平方米',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (23,'KWH/M2',N'千瓦时/平方米',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (24,'KW/Person',N'千瓦/人',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (25,'KWH/Person',N'千瓦时/人',1,'DEMO','2011-12-19 00:00:00')
------ added on 2012-05-29-------
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (26,'kg/M2',N'千克/平方米',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (27,'T/M2',N'吨/平方米',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (28,'m3/M2',N'立方米/平方米',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (29,'kg/Person',N'千克/人',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (30,'T/Person',N'吨/人',1,'DEMO','2011-12-19 00:00:00')
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (31,'m3/Person',N'立方米/人',1,'DEMO','2011-12-19 00:00:00')
------ added on 2012-10-23-------
INSERT INTO Uom (Id,code,Comment,Status,UpdateUser,UpdateTime) VALUES (32,'null',N'无',1,'DEMO','2011-12-19 00:00:00')
SET IDENTITY_INSERT Uom OFF

--------UomGroup--------
SET IDENTITY_INSERT UomGroup ON
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (1,'ElectricityRealEnergyGroup',N'电能组','DEMO','2012-05-07 19:48:01',1,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (2,'ElectricityDemandGroup',N'电功率组','DEMO','2012-05-07 19:48:01',1,0)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (3,'ElectricityReactiveEnergyGroup',N'','DEMO','2012-05-07 19:48:01',1,0)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (4,'ElectricityApparentEnergyGroup',N'','DEMO','2012-05-07 19:48:01',1,0)
--INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (5,'WaterFlowRateGroup',N'水流量组','DEMO','2012-05-07 19:48:01',2,0)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (6,'WaterMassGroup',N'水质量组','DEMO','2012-05-07 19:48:01',2,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (7,'GasFlowRateGroup',N'天然气流量组','DEMO','2012-05-07 19:48:01',3,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (8,'SoftWaterMassGroup',N'软水质量组','DEMO','2012-05-07 19:48:01',4,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (9,'GasolineMassGroup',N'汽油质量组','DEMO','2012-05-07 19:48:01',5,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (10,'LowPressureSteamMassGroup',N'低压蒸汽质量组','DEMO','2012-05-07 19:48:01',6,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (11,'DieselOilMassGroup',N'柴油质量组','DEMO','2012-05-07 19:48:01',7,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (12,'HeatQEnergyGroup',N'热量能量组','DEMO','2012-05-07 19:48:01',8,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (13,'CoolQEnergyGroup',N'冷量能量组','DEMO','2012-05-07 19:48:01',9,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (14,'CoalMassGroup',N'煤质量组','DEMO','2012-05-07 19:48:01',10,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (15,'CoalOilMassGroup',N'煤油质量组','DEMO','2012-05-07 19:48:01',11,1)
INSERT INTO UomGroup (Id,code,Comment,UpdateUser,UpdateTime,CommodityId,IsEnergyConsumptionGroup) VALUES (16,'OtherGroup',N'其他组','DEMO','2012-05-15 19:48:01',0,0)
SET IDENTITY_INSERT UomGroup OFF

--------UomGroupRelation--------
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,1,1,1,1,1,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,2,4,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,3,2,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,4,3,1,1,0,1)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,5,6,1,1,0,1)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,6,8,1,0,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,6,9,1,1,1,1)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,6,5,1,1,0,1)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,7,8,1,0,1,1)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,7,9,0,0,0,1000)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,7,5,1,1,1,1)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,8,8,1,0,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,8,9,1,1,1,1)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,8,5,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,9,8,1,1,1,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,9,9,0,0,0,1000)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,10,8,1,1,1,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,10,9,0,0,0,1000)
--INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,10,5,0,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,11,8,1,1,1,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,11,9,0,0,0,1000)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,12,1,0,1,1,3600000)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,12,10,1,0,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,13,1,0,1,1,3600000)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,13,10,1,0,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,14,8,1,1,1,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,14,9,0,0,0,1000)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,15,8,1,1,1,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,15,9,0,0,0,1000)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,16,18,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,16,19,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (1,16,20,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,13,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,21,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,22,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,23,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,24,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,25,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,26,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,27,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,28,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,29,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,30,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (0,16,31,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (2,16,12,1,1,0,1)
INSERT INTO UomGroupRelation (Precision,GroupId,UomId,IsBase,IsCommon,IsStandardCoal,Factor) VALUES (2,16,32,1,1,0,1)


--------CarbonFactor--------
SET IDENTITY_INSERT CarbonFactor ON
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (1,1,'DEMO','2012-05-07 20:13:02',1)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (2,1,'DEMO','2012-05-07 20:13:02',2)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (3,1,'DEMO','2012-05-07 20:13:02',3)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (4,1,'DEMO','2012-05-07 20:13:02',4)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (5,1,'DEMO','2012-05-07 20:13:02',5)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (6,1,'DEMO','2012-05-07 20:13:02',6)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (7,1,'DEMO','2012-05-07 20:13:02',7)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (8,2,'DEMO','2012-05-07 20:13:02',0)
INSERT INTO CarbonFactor (Id,FactorType,UpdateUser,UpdateTime,CommodityId) VALUES (9,3,'DEMO','2012-05-07 20:13:02',0)
SET IDENTITY_INSERT CarbonFactor OFF

--------CarbonFactorItem--------
SET IDENTITY_INSERT CarbonFactorItem ON
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (1,1,'2011-01-01 00:00:00',0.3300)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (2,2,'2011-01-01 00:00:00',0.0857)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (3,3,'2011-01-01 00:00:00',1.2143)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (4,4,'2011-01-01 00:00:00',0.4857)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (5,5,'2011-01-01 00:00:00',1.4714)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (6,6,'2011-01-01 00:00:00',0.1286)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (7,7,'2011-01-01 00:00:00',1.4571)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (8,8,'2011-01-01 00:00:00',2.6200)
insert into CarbonFactorItem (Id,carbonfactorid,effectivetime,factorvalue) values (9,9,'2011-01-01 00:00:00',0.0546)
SET IDENTITY_INSERT CarbonFactorItem OFF






----------------------------end create commodity uom data-------------------------


----------------------------create vtag-commodity fk-------------------------
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Commodity] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO

ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Commodity]
GO

----------------------------create cost commodity fk-------------------------
ALTER TABLE [dbo].[CostCommodity]  WITH NOCHECK ADD  CONSTRAINT [FK_CostCommodity_Commodity] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO

ALTER TABLE [dbo].[CostCommodity] CHECK CONSTRAINT [FK_CostCommodity_Commodity]

ALTER TABLE [dbo].[CostCommodity]  WITH NOCHECK ADD  CONSTRAINT [FK_CostCommodity_Uom] FOREIGN KEY([UomId])
REFERENCES [dbo].[Uom] ([Id])
GO

ALTER TABLE [dbo].[CostCommodity] CHECK CONSTRAINT [FK_CostCommodity_Uom]

-----------------------------------------------------------------------------
ALTER TABLE [dbo].[AdvancedProperty]  WITH NOCHECK ADD  CONSTRAINT [FK_AdvancedProperty_Uom] FOREIGN KEY([UomId])
REFERENCES [dbo].[Uom] ([Id])
GO

ALTER TABLE [dbo].[AdvancedProperty] CHECK CONSTRAINT [FK_AdvancedProperty_Uom]

