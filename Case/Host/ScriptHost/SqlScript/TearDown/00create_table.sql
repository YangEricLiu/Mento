/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     11/14/2012 4:08:45 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.AdvancedProperty') and o.name = 'FK_AdvancedProperty_Uom')
alter table dbo.AdvancedProperty
   drop constraint FK_AdvancedProperty_Uom
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.AdvancedProperty') and o.name = 'FK_HierarchyDynamicProperty_Hierarchy')
alter table dbo.AdvancedProperty
   drop constraint FK_HierarchyDynamicProperty_Hierarchy
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.AdvancedPropertyValue') and o.name = 'FK_HierarchyDynamicPropertyValue_HierarchyDynamicProperty')
alter table dbo.AdvancedPropertyValue
   drop constraint FK_HierarchyDynamicPropertyValue_HierarchyDynamicProperty
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.AreaDimension') and o.name = 'FK_AREADIME_REFERENCE_HIERARCH')
alter table dbo.AreaDimension
   drop constraint FK_AREADIME_REFERENCE_HIERARCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CalendarItem') and o.name = 'FK_CalendarItem_Calendar')
alter table dbo.CalendarItem
   drop constraint FK_CalendarItem_Calendar
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CarbonFactor') and o.name = 'FK_CARBONFA_REFERENCE_COMMODIT')
alter table dbo.CarbonFactor
   drop constraint FK_CARBONFA_REFERENCE_COMMODIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CarbonFactorItem') and o.name = 'FK_CARBONFA_REFERENCE_CARBONFA')
alter table dbo.CarbonFactorItem
   drop constraint FK_CARBONFA_REFERENCE_CARBONFA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostCommodity') and o.name = 'FK_CostCommodity_Commodity')
alter table dbo.CostCommodity
   drop constraint FK_CostCommodity_Commodity
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostCommodity') and o.name = 'FK_CostCommodity_HierarchyAdvancedPropertyVersion')
alter table dbo.CostCommodity
   drop constraint FK_CostCommodity_HierarchyAdvancedPropertyVersion
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostCommodity') and o.name = 'FK_CostCommodity_Uom')
alter table dbo.CostCommodity
   drop constraint FK_CostCommodity_Uom
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostComplexItem') and o.name = 'FK_CostComplexItem_CostCommodity')
alter table dbo.CostComplexItem
   drop constraint FK_CostComplexItem_CostCommodity
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostComplexItem') and o.name = 'FK_CostComplexItem_Tag')
alter table dbo.CostComplexItem
   drop constraint FK_CostComplexItem_Tag
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostComplexItem') and o.name = 'FK_CostComplexItem_Tag1')
alter table dbo.CostComplexItem
   drop constraint FK_CostComplexItem_Tag1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostComplexItem') and o.name = 'FK_CostComplexItem_Tag2')
alter table dbo.CostComplexItem
   drop constraint FK_CostComplexItem_Tag2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostComplexItem') and o.name = 'FK_CostComplexItem_TouTariff')
alter table dbo.CostComplexItem
   drop constraint FK_CostComplexItem_TouTariff
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.CostSimpleItem') and o.name = 'FK_CostSimpleItem_CostCommodity')
alter table dbo.CostSimpleItem
   drop constraint FK_CostSimpleItem_CostCommodity
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Dashboard') and o.name = 'FK_DASHBOAR_REFERENCE_HIERARCH')
alter table dbo.Dashboard
   drop constraint FK_DASHBOAR_REFERENCE_HIERARCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Dashboard') and o.name = 'FK_DASHBOAR_REFERENCE_HIERARCH1')
alter table dbo.Dashboard
   drop constraint FK_DASHBOAR_REFERENCE_HIERARCH1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Dashboard') and o.name = 'FK_DASHBOAR_REFERENCE_USER')
alter table dbo.Dashboard
   drop constraint FK_DASHBOAR_REFERENCE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Dashboard') and o.name = 'FK_DASHBOAR_REFERENCE_USER1')
alter table dbo.Dashboard
   drop constraint FK_DASHBOAR_REFERENCE_USER1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Edge') and o.name = 'FK_Edge_Tag_End')
alter table dbo.Edge
   drop constraint FK_Edge_Tag_End
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Hierarchy') and o.name = 'FK_HIERARCH_REFERENCE_TIMEZONE')
alter table dbo.Hierarchy
   drop constraint FK_HIERARCH_REFERENCE_TIMEZONE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.HierarchyAdvancedPropertyVersion') and o.name = 'FK_HierarchyAdvancedPropertyVersion_Hierarchy')
alter table dbo.HierarchyAdvancedPropertyVersion
   drop constraint FK_HierarchyAdvancedPropertyVersion_Hierarchy
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.HierarchyCalendar') and o.name = 'FK_HIERARCH_REFERENCE_HIERARCH')
alter table dbo.HierarchyCalendar
   drop constraint FK_HIERARCH_REFERENCE_HIERARCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.HierarchyCalendarReference') and o.name = 'FK_HIERARCH_REFERENCE_HIERARCHY')
alter table dbo.HierarchyCalendarReference
   drop constraint FK_HIERARCH_REFERENCE_HIERARCHY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.HierarchyCalendarReference') and o.name = 'FK_HIERARCH_REFERENCE_HIERARCHYVERSION')
alter table dbo.HierarchyCalendarReference
   drop constraint FK_HIERARCH_REFERENCE_HIERARCHYVERSION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PeakTariff') and o.name = 'FK_TARIFFPEAK_REFERENCE_TARIFF')
alter table dbo.PeakTariff
   drop constraint FK_TARIFFPEAK_REFERENCE_TARIFF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PeakTariffTime') and o.name = 'FK_PEAKTARI_REFERENCE_PEAKTARI')
alter table dbo.PeakTariffTime
   drop constraint FK_PEAKTARI_REFERENCE_PEAKTARI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SystemDimension') and o.name = 'FK_SYSTEMDI_REFERENCE_HIERARCH')
alter table dbo.SystemDimension
   drop constraint FK_SYSTEMDI_REFERENCE_HIERARCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SystemDimension') and o.name = 'FK_SYSTEMDI_REFERENCE_SYSTEMDI')
alter table dbo.SystemDimension
   drop constraint FK_SYSTEMDI_REFERENCE_SYSTEMDI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.SystemDimensionTemplateItem') and o.name = 'FK_SYSTEMDI_REFERENCE_SYSTEMDIT')
alter table dbo.SystemDimensionTemplateItem
   drop constraint FK_SYSTEMDI_REFERENCE_SYSTEMDIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Tag') and o.name = 'FK_Tag_AreaDimension')
alter table dbo.Tag
   drop constraint FK_Tag_AreaDimension
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Tag') and o.name = 'FK_Tag_Commodity')
alter table dbo.Tag
   drop constraint FK_Tag_Commodity
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Tag') and o.name = 'FK_Tag_Hierarchy')
alter table dbo.Tag
   drop constraint FK_Tag_Hierarchy
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Tag') and o.name = 'FK_Tag_SystemDimension')
alter table dbo.Tag
   drop constraint FK_Tag_SystemDimension
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Tag') and o.name = 'FK_Tag_Timezone')
alter table dbo.Tag
   drop constraint FK_Tag_Timezone
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TargetBaseline') and o.name = 'FK_TargetBaseline_Tag')
alter table dbo.TargetBaseline
   drop constraint FK_TargetBaseline_Tag
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TargetBaselineDataVersion') and o.name = 'FK_TargetBaselineDataVersion_TargetBaseline')
alter table dbo.TargetBaselineDataVersion
   drop constraint FK_TargetBaselineDataVersion_TargetBaseline
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TargetBaselineNormalDate') and o.name = 'FK_TargetBaselineNormalDate_TargetBaseline')
alter table dbo.TargetBaselineNormalDate
   drop constraint FK_TargetBaselineNormalDate_TargetBaseline
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TargetBaselineSpecialDate') and o.name = 'FK_TargetBaselineSpecialDate_TargetBaseline')
alter table dbo.TargetBaselineSpecialDate
   drop constraint FK_TargetBaselineSpecialDate_TargetBaseline
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TouTariffItem') and o.name = 'FK_TARIFFITEM_REFERENCE_TARIFF')
alter table dbo.TouTariffItem
   drop constraint FK_TARIFFITEM_REFERENCE_TARIFF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.UomGroup') and o.name = 'FK_UOMGROUP_REFERENCE_COMMODITY')
alter table dbo.UomGroup
   drop constraint FK_UOMGROUP_REFERENCE_COMMODITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.UomGroupRelation') and o.name = 'FK_UOMGROUPRELATION_REFERENCE_UOMGROUP')
alter table dbo.UomGroupRelation
   drop constraint FK_UOMGROUPRELATION_REFERENCE_UOMGROUP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.AdjustmentFactor')
            and   type = 'U')
   drop table dbo.AdjustmentFactor
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.AdvancedProperty')
            and   type = 'U')
   drop table dbo.AdvancedProperty
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.AdvancedPropertyValue')
            and   type = 'U')
   drop table dbo.AdvancedPropertyValue
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.AreaDimension')
            and   type = 'U')
   drop table dbo.AreaDimension
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Calendar')
            and   type = 'U')
   drop table dbo.Calendar
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.CalendarItem')
            and   type = 'U')
   drop table dbo.CalendarItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.CarbonFactor')
            and   type = 'U')
   drop table dbo.CarbonFactor
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.CarbonFactorItem')
            and   type = 'U')
   drop table dbo.CarbonFactorItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Commodity')
            and   type = 'U')
   drop table dbo.Commodity
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.CostCommodity')
            and   type = 'U')
   drop table dbo.CostCommodity
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.CostComplexItem')
            and   type = 'U')
   drop table dbo.CostComplexItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.CostSimpleItem')
            and   type = 'U')
   drop table dbo.CostSimpleItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.CostStartTime')
            and   type = 'U')
   drop table dbo.CostStartTime
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Customer')
            and   type = 'U')
   drop table dbo.Customer
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Dashboard')
            and   type = 'U')
   drop table dbo.Dashboard
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Edge')
            and   type = 'U')
   drop table dbo.Edge
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Hierarchy')
            and   type = 'U')
   drop table dbo.Hierarchy
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.HierarchyAdvancedPropertyVersion')
            and   type = 'U')
   drop table dbo.HierarchyAdvancedPropertyVersion
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.HierarchyCalendar')
            and   type = 'U')
   drop table dbo.HierarchyCalendar
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.HierarchyCalendarReference')
            and   type = 'U')
   drop table dbo.HierarchyCalendarReference
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Logo')
            and   type = 'U')
   drop table dbo.Logo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PeakTariff')
            and   type = 'U')
   drop table dbo.PeakTariff
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PeakTariffTime')
            and   type = 'U')
   drop table dbo.PeakTariffTime
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Privilege')
            and   type = 'U')
   drop table dbo.Privilege
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SystemDimension')
            and   type = 'U')
   drop table dbo.SystemDimension
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SystemDimensionTemplate')
            and   type = 'U')
   drop table dbo.SystemDimensionTemplate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SystemDimensionTemplateItem')
            and   type = 'U')
   drop table dbo.SystemDimensionTemplateItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Tag')
            and   type = 'U')
   drop table dbo.Tag
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TargetBaseline')
            and   type = 'U')
   drop table dbo.TargetBaseline
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TargetBaselineDataVersion')
            and   type = 'U')
   drop table dbo.TargetBaselineDataVersion
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TargetBaselineNormalDate')
            and   type = 'U')
   drop table dbo.TargetBaselineNormalDate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TargetBaselineSpecialDate')
            and   type = 'U')
   drop table dbo.TargetBaselineSpecialDate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Timezone')
            and   type = 'U')
   drop table dbo.Timezone
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TouTariff')
            and   type = 'U')
   drop table dbo.TouTariff
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.TouTariffItem')
            and   type = 'U')
   drop table dbo.TouTariffItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Uom')
            and   type = 'U')
   drop table dbo.Uom
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UomGroup')
            and   type = 'U')
   drop table dbo.UomGroup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UomGroupRelation')
            and   type = 'U')
   drop table dbo.UomGroupRelation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo."User"')
            and   type = 'U')
   drop table dbo."User"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserCustomer')
            and   type = 'U')
   drop table dbo.UserCustomer
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserDataPrivilege')
            and   type = 'U')
   drop table dbo.UserDataPrivilege
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserType')
            and   type = 'U')
   drop table dbo.UserType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserTypePrivilege')
            and   type = 'U')
   drop table dbo.UserTypePrivilege
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UserTypePrivilegeLimit')
            and   type = 'U')
   drop table dbo.UserTypePrivilegeLimit
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sysdiagrams')
            and   type = 'U')
   drop table dbo.sysdiagrams
go


/****** Object:  Table [dbo].[Uom]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uom](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_UOM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timezone]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timezone](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Offset] [decimal](18, 0) NULL,
	[Comment] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_TIMEZONE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDataPrivilege]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDataPrivilege](
	[UserId] [bigint] NOT NULL,
	[PrivilegeType] [int] NOT NULL,
	[PrivilegeItemId] [bigint] NOT NULL,
	[HierarchyPath] [hierarchyid] NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_UserDataPrivilege] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[PrivilegeType] ASC,
	[PrivilegeItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hierarchy]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hierarchy](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[TimezoneId] [bigint] NULL,
	[Comment] [nvarchar](200) NULL,
	[ParentId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[Path] [hierarchyid] NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_HIERARCHY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-Organization 1-Site 2-Building' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hierarchy', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0-Inactive 1-Active' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hierarchy', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[AdvancedProperty]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvancedProperty](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[HierarchyId] [bigint] NOT NULL,
	[UomId] [bigint] NOT NULL,
	[Type] [int] NOT NULL,
	[Comment] [nvarchar](200) NULL,
	[Status] [int] NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_HierarchyDynamicPropertySetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvancedPropertyValue]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvancedPropertyValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PropertyId] [bigint] NOT NULL,
	[StartDate] [date] NOT NULL,
	[Value] [decimal](21, 6) NULL,
 CONSTRAINT [PK_HierarchyDynamicPropertySettingValue] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC,
	[StartDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commodity]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commodity](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_COMMODITY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HierarchyAdvancedPropertyVersion]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HierarchyAdvancedPropertyVersion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [smallint] NOT NULL,
	[Version] [timestamp] NOT NULL,
	[HierarchyId] [bigint] NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_HierarchyAdvancedPropertyVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostCommodity]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostCommodity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CommodityId] [bigint] NOT NULL,
	[UomId] [bigint] NOT NULL,
	[CostId] [bigint] NOT NULL,
 CONSTRAINT [PK_CostCommodity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostSimpleItem]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostSimpleItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EffectiveDate] [date] NOT NULL,
	[Price] [decimal](15, 6) NOT NULL,
	[CostCommodityId] [bigint] NOT NULL,
 CONSTRAINT [PK_CostSimpleItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HierarchyCalendar]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HierarchyCalendar](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PropertyVersionId] [bigint] NULL,
	[EffectiveTime] [int] NULL,
	[CalendarId] [bigint] NULL,
	[WorkTimeId] [bigint] NULL,
 CONSTRAINT [PK_HIERARCHYCALENDAR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HierarchyCalendarReference]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HierarchyCalendarReference](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[HierarchyId] [bigint] NULL,
	[PropertyVersionId] [bigint] NULL,
	[CalendarType] [int] NULL,
 CONSTRAINT [PK_HIERARCHYCALENDARREFERENCE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreaDimension]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaDimension](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[ParentId] [bigint] NULL,
	[HierarchyId] [bigint] NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_AREADIMENSION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemDimensionTemplate]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemDimensionTemplate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[CustomerId] [bigint] NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_SYSTEMDIMENSIONTEMPLATE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemDimensionTemplateItem]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemDimensionTemplateItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[ParentId] [bigint] NULL,
	[TemplateId] [bigint] NOT NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_SYSTEMDIMENSIONTEMPLATEITEM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemDimension]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemDimension](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TemplateItemId] [bigint] NULL,
	[HierarchyId] [bigint] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_SYSTEMDIMENSION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[GuidCode] [bigint] NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[TimezoneId] [bigint] NOT NULL,
	[Comment] [nvarchar](200) NULL,
	[MeterCode] [nvarchar](100) NULL,
	[ChannelId] [int] NULL,
	[CalculationType] [int] NOT NULL,
	[CalculationStep] [int] NULL,
	[UomId] [bigint] NOT NULL,
	[CommodityId] [bigint] NOT NULL,
	[StartTime] [datetime] NULL,
	[EnergyConsumption] [int] NOT NULL,
	[DayNightRatio] [int] NULL,
	[Formula] [nvarchar](4000) NULL,
	[FormulaRpn] [nvarchar](4000) NULL,
	[CustomerId] [bigint] NULL,
	[HierarchyId] [bigint] NULL,
	[SystemDimensionId] [bigint] NULL,
	[AreaDimensionId] [bigint] NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetBaseline]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetBaseline](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GuidCode] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[TagId] [bigint] NOT NULL,
	[Type] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_KPIDateConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetBaselineSpecialDate]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetBaselineSpecialDate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TargetBaselineId] [bigint] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Value] [decimal](18, 8) NOT NULL,
	[Status] [int] NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_KPISpecialDateConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetBaselineNormalDate]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetBaselineNormalDate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TargetBaselineId] [bigint] NOT NULL,
	[DayType] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[StartTime] [int] NOT NULL,
	[Value] [decimal](18, 8) NULL,
	[Status] [int] NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_KPIFigureSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TargetBaselineDataVersion]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TargetBaselineDataVersion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TargetBaselineId] [bigint] NOT NULL,
	[Year] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_TargetBaselineVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edge]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Edge](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EntryEdgeId] [bigint] NULL,
	[DirectEdgeId] [bigint] NULL,
	[ExitEdgeId] [bigint] NULL,
	[StartVertex] [bigint] NULL,
	[EndVertex] [bigint] NULL,
	[Hops] [int] NULL,
	[Source] [varchar](150) NULL,
 CONSTRAINT [PK_Edge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTypePrivilegeLimit]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypePrivilegeLimit](
	[UserTypeId] [bigint] NOT NULL,
	[PrivilegeCode] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserTypePrivilegeLimit] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC,
	[PrivilegeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypePrivilege]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypePrivilege](
	[UserTypeId] [bigint] NOT NULL,
	[PrivilegeCode] [nvarchar](100) NOT NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_UserTypeRight] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC,
	[PrivilegeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCustomer]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCustomer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[HierarchyId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserCustomer] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[HierarchyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[RealName] [nvarchar](100) NULL,
	[UserType] [int] NULL,
	[Password] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[Title] [nvarchar](100) NULL,
	[Telephone] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dashboard]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dashboard](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[HierarchyId] [bigint] NULL,
	[UserId] [bigint] NULL,
	[Syntax] [nvarchar](max) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
	[IsFavorite] [bit] NULL,
 CONSTRAINT [PK_DASHBOARD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouTariff]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouTariff](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Code] [nvarchar](100) NULL,
	[Comment] [nvarchar](200) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_TOUTARIFF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostComplexItem]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostComplexItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EffectiveDate] [date] NOT NULL,
	[DemandCostType] [smallint] NOT NULL,
	[FactorType] [smallint] NULL,
	[HourPrice] [decimal](15, 6) NULL,
	[HourTagId] [bigint] NULL,
	[PaddingCost] [decimal](15, 6) NULL,
	[ReactiveTagId] [bigint] NULL,
	[RealTagId] [bigint] NULL,
	[TransformerCapacity] [decimal](15, 6) NULL,
	[TransformerPrice] [decimal](15, 6) NULL,
	[TouTariffId] [bigint] NOT NULL,
	[CostCommodityId] [bigint] NOT NULL,
 CONSTRAINT [PK_CostComplexItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privilege]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Privilege](
	[Code] [char](10) NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Right] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[HierarchyId] [bigint] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Manager] [nvarchar](100) NOT NULL,
	[Telephone] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[StartTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[HierarchyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostStartTime]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostStartTime](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CommodityId] [bigint] NULL,
	[HierarchyId] [bigint] NULL,
	[AreaDimensionId] [bigint] NULL,
	[SystemDimensionTemplateItemId] [bigint] NULL,
	[StartTime] [datetime] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_CostStartTime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdjustmentFactor]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdjustmentFactor](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FactorType] [int] NULL,
	[StartPowerFactor] [decimal](15, 6) NULL,
	[EndPowerFactor] [decimal](15, 6) NULL,
	[ValueType] [int] NULL,
	[BaseValue] [decimal](15, 6) NULL,
	[Step] [decimal](15, 6) NULL,
	[Increment] [decimal](15, 6) NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_ADJUSTMENTFACTOR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendar]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendar](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Type] [int] NULL,
	[Comment] [nvarchar](200) NULL,
	[Status] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_Calendar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logo]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Logo] [varbinary](max) NOT NULL,
	[HierarchyId] [bigint] NULL,
	[UpdateUser] [nvarchar](100) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UomGroup]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UomGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Comment] [nvarchar](400) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
	[CommodityId] [bigint] NULL,
	[IsEnergyConsumptionGroup] [bit] NULL,
 CONSTRAINT [PK_UOMGROUP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarbonFactor]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CarbonFactor](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CommodityId] [bigint] NULL,
	[FactorType] [int] NULL,
	[UpdateUser] [varchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_CARBONFACTOR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CalendarItem]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CalendarId] [bigint] NULL,
	[Type] [int] NULL,
	[StartFirstPart] [int] NULL,
	[StartSecondPart] [int] NULL,
	[EndFirstPart] [int] NULL,
	[EndSecondPart] [int] NULL,
 CONSTRAINT [PK_CalendarItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeakTariff]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeakTariff](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TouTariffId] [bigint] NULL,
	[Price] [decimal](15, 6) NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[UpdateTime] [datetime] NULL,
	[Version] [timestamp] NULL,
 CONSTRAINT [PK_PEAKTARIFF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TouTariffItem]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TouTariffItem](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TouTariffId] [bigint] NULL,
	[ItemType] [int] NULL,
	[Price] [decimal](15, 6) NULL,
	[StartTime] [int] NULL,
	[EndTime] [int] NULL,
 CONSTRAINT [PK_TOUTARIFFITEM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UomGroupRelation]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UomGroupRelation](
	[Precision] [int] NULL,
	[GroupId] [bigint] NULL,
	[UomId] [bigint] NULL,
	[IsBase] [bit] NULL,
	[IsCommon] [bit] NULL,
	[IsStandardCoal] [bit] NULL,
	[Factor] [decimal](18, 8) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeakTariffTime]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeakTariffTime](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PeakTariffId] [bigint] NULL,
	[StartMonth] [int] NULL,
	[StartDay] [int] NULL,
	[StartTime] [int] NULL,
	[EndMonth] [int] NULL,
	[EndDay] [int] NULL,
	[EndTime] [int] NULL,
 CONSTRAINT [PK_PEAKTARIFFTIME] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarbonFactorItem]    Script Date: 11/22/2012 10:56:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarbonFactorItem](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CarbonFactorId] [bigint] NULL,
	[EffectiveTime] [datetime] NULL,
	[FactorValue] [decimal](15, 6) NULL,
 CONSTRAINT [PK_CARBONFACTORITEM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_AdvancedProperty_Type]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[AdvancedProperty] ADD  CONSTRAINT [DF_AdvancedProperty_Type]  DEFAULT ((1)) FOR [Type]
GO
/****** Object:  Default [DF_Dashboard_IsFavorite]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Dashboard] ADD  CONSTRAINT [DF_Dashboard_IsFavorite]  DEFAULT ((0)) FOR [IsFavorite]
GO
/****** Object:  Default [DF_Tag_EnergyConsumption]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF_Tag_EnergyConsumption]  DEFAULT ((0)) FOR [EnergyConsumption]
GO
/****** Object:  Default [DF_Tag_DayNightRatio]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF_Tag_DayNightRatio]  DEFAULT ((0)) FOR [DayNightRatio]
GO
/****** Object:  ForeignKey [FK_AdvancedProperty_Uom]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[AdvancedProperty]  WITH NOCHECK ADD  CONSTRAINT [FK_AdvancedProperty_Uom] FOREIGN KEY([UomId])
REFERENCES [dbo].[Uom] ([Id])
GO
ALTER TABLE [dbo].[AdvancedProperty] CHECK CONSTRAINT [FK_AdvancedProperty_Uom]
GO
/****** Object:  ForeignKey [FK_HierarchyDynamicProperty_Hierarchy]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[AdvancedProperty]  WITH NOCHECK ADD  CONSTRAINT [FK_HierarchyDynamicProperty_Hierarchy] FOREIGN KEY([HierarchyId])
REFERENCES [dbo].[Hierarchy] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdvancedProperty] CHECK CONSTRAINT [FK_HierarchyDynamicProperty_Hierarchy]
GO
/****** Object:  ForeignKey [FK_HierarchyDynamicPropertyValue_HierarchyDynamicProperty]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[AdvancedPropertyValue]  WITH NOCHECK ADD  CONSTRAINT [FK_HierarchyDynamicPropertyValue_HierarchyDynamicProperty] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[AdvancedProperty] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdvancedPropertyValue] CHECK CONSTRAINT [FK_HierarchyDynamicPropertyValue_HierarchyDynamicProperty]
GO
/****** Object:  ForeignKey [FK_AREADIME_REFERENCE_HIERARCH]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[AreaDimension]  WITH NOCHECK ADD  CONSTRAINT [FK_AREADIME_REFERENCE_HIERARCH] FOREIGN KEY([HierarchyId])
REFERENCES [dbo].[Hierarchy] ([Id])
GO
ALTER TABLE [dbo].[AreaDimension] CHECK CONSTRAINT [FK_AREADIME_REFERENCE_HIERARCH]
GO
/****** Object:  ForeignKey [FK_CalendarItem_Calendar]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CalendarItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CalendarItem_Calendar] FOREIGN KEY([CalendarId])
REFERENCES [dbo].[Calendar] ([Id])
GO
ALTER TABLE [dbo].[CalendarItem] CHECK CONSTRAINT [FK_CalendarItem_Calendar]
GO
/****** Object:  ForeignKey [FK_CARBONFA_REFERENCE_COMMODIT]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CarbonFactor]  WITH CHECK ADD  CONSTRAINT [FK_CARBONFA_REFERENCE_COMMODIT] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO
ALTER TABLE [dbo].[CarbonFactor] CHECK CONSTRAINT [FK_CARBONFA_REFERENCE_COMMODIT]
GO
/****** Object:  ForeignKey [FK_CARBONFA_REFERENCE_CARBONFA]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CarbonFactorItem]  WITH CHECK ADD  CONSTRAINT [FK_CARBONFA_REFERENCE_CARBONFA] FOREIGN KEY([CarbonFactorId])
REFERENCES [dbo].[CarbonFactor] ([Id])
GO
ALTER TABLE [dbo].[CarbonFactorItem] CHECK CONSTRAINT [FK_CARBONFA_REFERENCE_CARBONFA]
GO
/****** Object:  ForeignKey [FK_CostCommodity_Commodity]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostCommodity]  WITH NOCHECK ADD  CONSTRAINT [FK_CostCommodity_Commodity] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO
ALTER TABLE [dbo].[CostCommodity] CHECK CONSTRAINT [FK_CostCommodity_Commodity]
GO
/****** Object:  ForeignKey [FK_CostCommodity_HierarchyAdvancedPropertyVersion]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostCommodity]  WITH NOCHECK ADD  CONSTRAINT [FK_CostCommodity_HierarchyAdvancedPropertyVersion] FOREIGN KEY([CostId])
REFERENCES [dbo].[HierarchyAdvancedPropertyVersion] ([Id])
GO
ALTER TABLE [dbo].[CostCommodity] CHECK CONSTRAINT [FK_CostCommodity_HierarchyAdvancedPropertyVersion]
GO
/****** Object:  ForeignKey [FK_CostCommodity_Uom]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostCommodity]  WITH NOCHECK ADD  CONSTRAINT [FK_CostCommodity_Uom] FOREIGN KEY([UomId])
REFERENCES [dbo].[Uom] ([Id])
GO
ALTER TABLE [dbo].[CostCommodity] CHECK CONSTRAINT [FK_CostCommodity_Uom]
GO
/****** Object:  ForeignKey [FK_CostComplexItem_CostCommodity]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostComplexItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CostComplexItem_CostCommodity] FOREIGN KEY([CostCommodityId])
REFERENCES [dbo].[CostCommodity] ([Id])
GO
ALTER TABLE [dbo].[CostComplexItem] CHECK CONSTRAINT [FK_CostComplexItem_CostCommodity]
GO
/****** Object:  ForeignKey [FK_CostComplexItem_Tag]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostComplexItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CostComplexItem_Tag] FOREIGN KEY([HourTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[CostComplexItem] CHECK CONSTRAINT [FK_CostComplexItem_Tag]
GO
/****** Object:  ForeignKey [FK_CostComplexItem_Tag1]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostComplexItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CostComplexItem_Tag1] FOREIGN KEY([ReactiveTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[CostComplexItem] CHECK CONSTRAINT [FK_CostComplexItem_Tag1]
GO
/****** Object:  ForeignKey [FK_CostComplexItem_Tag2]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostComplexItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CostComplexItem_Tag2] FOREIGN KEY([RealTagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[CostComplexItem] CHECK CONSTRAINT [FK_CostComplexItem_Tag2]
GO
/****** Object:  ForeignKey [FK_CostComplexItem_TouTariff]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostComplexItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CostComplexItem_TouTariff] FOREIGN KEY([TouTariffId])
REFERENCES [dbo].[TouTariff] ([Id])
GO
ALTER TABLE [dbo].[CostComplexItem] CHECK CONSTRAINT [FK_CostComplexItem_TouTariff]
GO
/****** Object:  ForeignKey [FK_CostSimpleItem_CostCommodity]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[CostSimpleItem]  WITH NOCHECK ADD  CONSTRAINT [FK_CostSimpleItem_CostCommodity] FOREIGN KEY([CostCommodityId])
REFERENCES [dbo].[CostCommodity] ([Id])
GO
ALTER TABLE [dbo].[CostSimpleItem] CHECK CONSTRAINT [FK_CostSimpleItem_CostCommodity]
GO
/****** Object:  ForeignKey [FK_DASHBOAR_REFERENCE_HIERARCH]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Dashboard]  WITH NOCHECK ADD  CONSTRAINT [FK_DASHBOAR_REFERENCE_HIERARCH] FOREIGN KEY([HierarchyId])
REFERENCES [dbo].[Hierarchy] ([Id])
GO
ALTER TABLE [dbo].[Dashboard] CHECK CONSTRAINT [FK_DASHBOAR_REFERENCE_HIERARCH]
GO
/****** Object:  ForeignKey [FK_DASHBOAR_REFERENCE_HIERARCH1]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Dashboard]  WITH NOCHECK ADD  CONSTRAINT [FK_DASHBOAR_REFERENCE_HIERARCH1] FOREIGN KEY([HierarchyId])
REFERENCES [dbo].[Hierarchy] ([Id])
GO
ALTER TABLE [dbo].[Dashboard] CHECK CONSTRAINT [FK_DASHBOAR_REFERENCE_HIERARCH1]
GO
/****** Object:  ForeignKey [FK_DASHBOAR_REFERENCE_USER]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Dashboard]  WITH NOCHECK ADD  CONSTRAINT [FK_DASHBOAR_REFERENCE_USER] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Dashboard] CHECK CONSTRAINT [FK_DASHBOAR_REFERENCE_USER]
GO
/****** Object:  ForeignKey [FK_DASHBOAR_REFERENCE_USER1]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Dashboard]  WITH NOCHECK ADD  CONSTRAINT [FK_DASHBOAR_REFERENCE_USER1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Dashboard] CHECK CONSTRAINT [FK_DASHBOAR_REFERENCE_USER1]
GO
/****** Object:  ForeignKey [FK_Edge_Tag_End]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Edge]  WITH NOCHECK ADD  CONSTRAINT [FK_Edge_Tag_End] FOREIGN KEY([EndVertex])
REFERENCES [dbo].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Edge] CHECK CONSTRAINT [FK_Edge_Tag_End]
GO
/****** Object:  ForeignKey [FK_HIERARCH_REFERENCE_TIMEZONE]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Hierarchy]  WITH NOCHECK ADD  CONSTRAINT [FK_HIERARCH_REFERENCE_TIMEZONE] FOREIGN KEY([TimezoneId])
REFERENCES [dbo].[Timezone] ([Id])
GO
ALTER TABLE [dbo].[Hierarchy] CHECK CONSTRAINT [FK_HIERARCH_REFERENCE_TIMEZONE]
GO
/****** Object:  ForeignKey [FK_HierarchyAdvancedPropertyVersion_Hierarchy]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[HierarchyAdvancedPropertyVersion]  WITH NOCHECK ADD  CONSTRAINT [FK_HierarchyAdvancedPropertyVersion_Hierarchy] FOREIGN KEY([HierarchyId])
REFERENCES [dbo].[Hierarchy] ([Id])
GO
ALTER TABLE [dbo].[HierarchyAdvancedPropertyVersion] CHECK CONSTRAINT [FK_HierarchyAdvancedPropertyVersion_Hierarchy]
GO
/****** Object:  ForeignKey [FK_HIERARCH_REFERENCE_HIERARCH]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[HierarchyCalendar]  WITH NOCHECK ADD  CONSTRAINT [FK_HIERARCH_REFERENCE_HIERARCH] FOREIGN KEY([PropertyVersionId])
REFERENCES [dbo].[HierarchyAdvancedPropertyVersion] ([Id])
GO
ALTER TABLE [dbo].[HierarchyCalendar] CHECK CONSTRAINT [FK_HIERARCH_REFERENCE_HIERARCH]
GO
/****** Object:  ForeignKey [FK_HIERARCH_REFERENCE_HIERARCHY]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[HierarchyCalendarReference]  WITH NOCHECK ADD  CONSTRAINT [FK_HIERARCH_REFERENCE_HIERARCHY] FOREIGN KEY([HierarchyId])
REFERENCES [dbo].[Hierarchy] ([Id])
GO
ALTER TABLE [dbo].[HierarchyCalendarReference] CHECK CONSTRAINT [FK_HIERARCH_REFERENCE_HIERARCHY]
GO
/****** Object:  ForeignKey [FK_HIERARCH_REFERENCE_HIERARCHYVERSION]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[HierarchyCalendarReference]  WITH NOCHECK ADD  CONSTRAINT [FK_HIERARCH_REFERENCE_HIERARCHYVERSION] FOREIGN KEY([PropertyVersionId])
REFERENCES [dbo].[HierarchyAdvancedPropertyVersion] ([Id])
GO
ALTER TABLE [dbo].[HierarchyCalendarReference] CHECK CONSTRAINT [FK_HIERARCH_REFERENCE_HIERARCHYVERSION]
GO
/****** Object:  ForeignKey [FK_TARIFFPEAK_REFERENCE_TARIFF]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[PeakTariff]  WITH NOCHECK ADD  CONSTRAINT [FK_TARIFFPEAK_REFERENCE_TARIFF] FOREIGN KEY([TouTariffId])
REFERENCES [dbo].[TouTariff] ([Id])
GO
ALTER TABLE [dbo].[PeakTariff] CHECK CONSTRAINT [FK_TARIFFPEAK_REFERENCE_TARIFF]
GO
/****** Object:  ForeignKey [FK_PEAKTARI_REFERENCE_PEAKTARI]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[PeakTariffTime]  WITH NOCHECK ADD  CONSTRAINT [FK_PEAKTARI_REFERENCE_PEAKTARI] FOREIGN KEY([PeakTariffId])
REFERENCES [dbo].[PeakTariff] ([Id])
GO
ALTER TABLE [dbo].[PeakTariffTime] CHECK CONSTRAINT [FK_PEAKTARI_REFERENCE_PEAKTARI]
GO
/****** Object:  ForeignKey [FK_SYSTEMDI_REFERENCE_HIERARCH]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[SystemDimension]  WITH NOCHECK ADD  CONSTRAINT [FK_SYSTEMDI_REFERENCE_HIERARCH] FOREIGN KEY([HierarchyId])
REFERENCES [dbo].[Hierarchy] ([Id])
GO
ALTER TABLE [dbo].[SystemDimension] CHECK CONSTRAINT [FK_SYSTEMDI_REFERENCE_HIERARCH]
GO
/****** Object:  ForeignKey [FK_SYSTEMDI_REFERENCE_SYSTEMDI]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[SystemDimension]  WITH NOCHECK ADD  CONSTRAINT [FK_SYSTEMDI_REFERENCE_SYSTEMDI] FOREIGN KEY([TemplateItemId])
REFERENCES [dbo].[SystemDimensionTemplateItem] ([Id])
GO
ALTER TABLE [dbo].[SystemDimension] CHECK CONSTRAINT [FK_SYSTEMDI_REFERENCE_SYSTEMDI]
GO
/****** Object:  ForeignKey [FK_SYSTEMDI_REFERENCE_SYSTEMDIT]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[SystemDimensionTemplateItem]  WITH NOCHECK ADD  CONSTRAINT [FK_SYSTEMDI_REFERENCE_SYSTEMDIT] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[SystemDimensionTemplate] ([Id])
GO
ALTER TABLE [dbo].[SystemDimensionTemplateItem] CHECK CONSTRAINT [FK_SYSTEMDI_REFERENCE_SYSTEMDIT]
GO
/****** Object:  ForeignKey [FK_Tag_AreaDimension]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Tag]  WITH NOCHECK ADD  CONSTRAINT [FK_Tag_AreaDimension] FOREIGN KEY([AreaDimensionId])
REFERENCES [dbo].[AreaDimension] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_AreaDimension]
GO
/****** Object:  ForeignKey [FK_Tag_Commodity]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Commodity] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Commodity]
GO
/****** Object:  ForeignKey [FK_Tag_Hierarchy]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Tag]  WITH NOCHECK ADD  CONSTRAINT [FK_Tag_Hierarchy] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Hierarchy] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Hierarchy]
GO
/****** Object:  ForeignKey [FK_Tag_SystemDimension]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Tag]  WITH NOCHECK ADD  CONSTRAINT [FK_Tag_SystemDimension] FOREIGN KEY([SystemDimensionId])
REFERENCES [dbo].[SystemDimension] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_SystemDimension]
GO
/****** Object:  ForeignKey [FK_Tag_Timezone]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[Tag]  WITH NOCHECK ADD  CONSTRAINT [FK_Tag_Timezone] FOREIGN KEY([TimezoneId])
REFERENCES [dbo].[Timezone] ([Id])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Timezone]
GO
/****** Object:  ForeignKey [FK_TargetBaseline_Tag]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[TargetBaseline]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetBaseline_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TargetBaseline] CHECK CONSTRAINT [FK_TargetBaseline_Tag]
GO
/****** Object:  ForeignKey [FK_TargetBaselineDataVersion_TargetBaseline]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[TargetBaselineDataVersion]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetBaselineDataVersion_TargetBaseline] FOREIGN KEY([TargetBaselineId])
REFERENCES [dbo].[TargetBaseline] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TargetBaselineDataVersion] CHECK CONSTRAINT [FK_TargetBaselineDataVersion_TargetBaseline]
GO
/****** Object:  ForeignKey [FK_TargetBaselineNormalDate_TargetBaseline]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[TargetBaselineNormalDate]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetBaselineNormalDate_TargetBaseline] FOREIGN KEY([TargetBaselineId])
REFERENCES [dbo].[TargetBaseline] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TargetBaselineNormalDate] CHECK CONSTRAINT [FK_TargetBaselineNormalDate_TargetBaseline]
GO
/****** Object:  ForeignKey [FK_TargetBaselineSpecialDate_TargetBaseline]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[TargetBaselineSpecialDate]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetBaselineSpecialDate_TargetBaseline] FOREIGN KEY([TargetBaselineId])
REFERENCES [dbo].[TargetBaseline] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TargetBaselineSpecialDate] CHECK CONSTRAINT [FK_TargetBaselineSpecialDate_TargetBaseline]
GO
/****** Object:  ForeignKey [FK_TARIFFITEM_REFERENCE_TARIFF]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[TouTariffItem]  WITH NOCHECK ADD  CONSTRAINT [FK_TARIFFITEM_REFERENCE_TARIFF] FOREIGN KEY([TouTariffId])
REFERENCES [dbo].[TouTariff] ([Id])
GO
ALTER TABLE [dbo].[TouTariffItem] CHECK CONSTRAINT [FK_TARIFFITEM_REFERENCE_TARIFF]
GO
/****** Object:  ForeignKey [FK_UOMGROUP_REFERENCE_COMMODITY]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[UomGroup]  WITH CHECK ADD  CONSTRAINT [FK_UOMGROUP_REFERENCE_COMMODITY] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO
ALTER TABLE [dbo].[UomGroup] CHECK CONSTRAINT [FK_UOMGROUP_REFERENCE_COMMODITY]
GO
/****** Object:  ForeignKey [FK_UOMGROUPRELATION_REFERENCE_UOMGROUP]    Script Date: 11/22/2012 10:56:41 ******/
ALTER TABLE [dbo].[UomGroupRelation]  WITH CHECK ADD  CONSTRAINT [FK_UOMGROUPRELATION_REFERENCE_UOMGROUP] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UomGroup] ([Id])
GO
ALTER TABLE [dbo].[UomGroupRelation] CHECK CONSTRAINT [FK_UOMGROUPRELATION_REFERENCE_UOMGROUP]
GO
