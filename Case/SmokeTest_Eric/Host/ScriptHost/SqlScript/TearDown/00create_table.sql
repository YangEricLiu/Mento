/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     4/10/2013 4:11:26 PM                         */
/*==============================================================*/


if exists (select 1
          from sysobjects
          where id = object_id('dbo.data_auth_on_hierarchy_delete')
          and type = 'TR')
   drop trigger dbo.data_auth_on_hierarchy_delete
go

if exists (select 1
          from sysobjects
          where id = object_id('dbo.data_auth_on_usercustomer_delete')
          and type = 'TR')
   drop trigger dbo.data_auth_on_usercustomer_delete
go

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
   where r.fkeyid = object_id('dbo.RolePrivilege') and o.name = 'FK_RolePrivilege_Privilege')
alter table dbo.RolePrivilege
   drop constraint FK_RolePrivilege_Privilege
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.RolePrivilege') and o.name = 'FK_RolePrivilege_Role')
alter table dbo.RolePrivilege
   drop constraint FK_RolePrivilege_Role
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
   where r.fkeyid = object_id('dbo.TagDirectRefer') and o.name = 'FK_TagDirectRefer_Tag')
alter table dbo.TagDirectRefer
   drop constraint FK_TagDirectRefer_Tag
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
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.UserCustomer') and o.name = 'FK_UserCustomer_User')
alter table dbo.UserCustomer
   drop constraint FK_UserCustomer_User
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.UserRole') and o.name = 'FK_UserRole_Role')
alter table dbo.UserRole
   drop constraint FK_UserRole_Role
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.UserRole') and o.name = 'FK_UserRole_User')
alter table dbo.UserRole
   drop constraint FK_UserRole_User
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
           where  id = object_id('dbo.ReceiveShareInfo')
            and   type = 'U')
   drop table dbo.ReceiveShareInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Role')
            and   type = 'U')
   drop table dbo.Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.RolePrivilege')
            and   type = 'U')
   drop table dbo.RolePrivilege
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.SendShareInfo')
            and   type = 'U')
   drop table dbo.SendShareInfo
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
           where  id = object_id('dbo.TagDirectRefer')
            and   type = 'U')
   drop table dbo.TagDirectRefer
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
           where  id = object_id('dbo.UserRole')
            and   type = 'U')
   drop table dbo.UserRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Widget')
            and   type = 'U')
   drop table dbo.Widget
go

/*==============================================================*/
/* Table: AdjustmentFactor                                      */
/*==============================================================*/
create table dbo.AdjustmentFactor (
   Id                   bigint               identity(1, 1) not for replication,
   FactorType           int                  null,
   StartPowerFactor     decimal(15,6)        null,
   EndPowerFactor       decimal(15,6)        null,
   ValueType            int                  null,
   BaseValue            decimal(15,6)        null,
   Step                 decimal(15,6)        null,
   Increment            decimal(15,6)        null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_ADJUSTMENTFACTOR primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: AdvancedProperty                                      */
/*==============================================================*/
create table dbo.AdvancedProperty (
   Id                   bigint               identity(1, 1),
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   HierarchyId          bigint               not null,
   UomId                bigint               not null,
   Type                 int                  not null constraint DF_AdvancedProperty_Type default (1),
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   Status               int                  not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_HierarchyDynamicPropertySetting primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: AdvancedPropertyValue                                 */
/*==============================================================*/
create table dbo.AdvancedPropertyValue (
   Id                   bigint               identity(1, 1),
   PropertyId           bigint               not null,
   StartDate            date                 not null,
   Value                decimal(21,6)        null,
   constraint PK_HierarchyDynamicPropertySettingValue primary key (PropertyId, StartDate)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: AreaDimension                                         */
/*==============================================================*/
create table dbo.AreaDimension (
   Id                   bigint               identity(1, 1),
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   ParentId             bigint               null,
   HierarchyId          bigint               null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_AREADIMENSION primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Calendar                                              */
/*==============================================================*/
create table dbo.Calendar (
   Id                   bigint               identity(1, 1),
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Type                 int                  null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_Calendar primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: CalendarItem                                          */
/*==============================================================*/
create table dbo.CalendarItem (
   Id                   bigint               identity(1, 1),
   CalendarId           bigint               null,
   Type                 int                  null,
   StartFirstPart       int                  null,
   StartSecondPart      int                  null,
   EndFirstPart         int                  null,
   EndSecondPart        int                  null,
   constraint PK_CalendarItem primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: CarbonFactor                                          */
/*==============================================================*/
create table dbo.CarbonFactor (
   Id                   bigint               identity(1, 1) not for replication,
   CommodityId          bigint               null,
   FactorType           int                  null,
   UpdateUser           varchar(100)         collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_CARBONFACTOR primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: CarbonFactorItem                                      */
/*==============================================================*/
create table dbo.CarbonFactorItem (
   Id                   bigint               identity(1, 1) not for replication,
   CarbonFactorId       bigint               null,
   EffectiveTime        datetime             null,
   FactorValue          decimal(15,6)        null,
   constraint PK_CARBONFACTORITEM primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Commodity                                             */
/*==============================================================*/
create table dbo.Commodity (
   Id                   bigint               identity(1, 1) not for replication,
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_COMMODITY primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: CostCommodity                                         */
/*==============================================================*/
create table dbo.CostCommodity (
   Id                   bigint               identity(1, 1),
   CommodityId          bigint               not null,
   UomId                bigint               not null,
   CostId               bigint               not null,
   constraint PK_CostCommodity primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: CostComplexItem                                       */
/*==============================================================*/
create table dbo.CostComplexItem (
   Id                   bigint               identity(1, 1),
   EffectiveDate        date                 not null,
   DemandCostType       smallint             not null,
   FactorType           smallint             null,
   HourPrice            decimal(15,6)        null,
   HourTagId            bigint               null,
   PaddingCost          decimal(15,6)        null,
   ReactiveTagId        bigint               null,
   RealTagId            bigint               null,
   TransformerCapacity  decimal(15,6)        null,
   TransformerPrice     decimal(15,6)        null,
   TouTariffId          bigint               not null,
   CostCommodityId      bigint               not null,
   constraint PK_CostComplexItem primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: CostSimpleItem                                        */
/*==============================================================*/
create table dbo.CostSimpleItem (
   Id                   bigint               identity(1, 1),
   EffectiveDate        date                 not null,
   Price                decimal(15,6)        not null,
   CostCommodityId      bigint               not null,
   constraint PK_CostSimpleItem primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: CostStartTime                                         */
/*==============================================================*/
create table dbo.CostStartTime (
   Id                   bigint               identity(1, 1),
   CommodityId          bigint               null,
   HierarchyId          bigint               null,
   AreaDimensionId      bigint               null,
   SystemDimensionTemplateItemId bigint               null,
   StartTime            datetime             not null,
   Version              timestamp            not null,
   constraint PK_CostStartTime primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table dbo.Customer (
   HierarchyId          bigint               not null,
   Address              nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Manager              nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Telephone            nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Email                nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   StartTime            datetime             not null,
   constraint PK_Customer primary key (HierarchyId)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Dashboard                                             */
/*==============================================================*/
create table dbo.Dashboard (
   Id                   bigint               identity(1, 1),
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   HierarchyId          bigint               null,
   UserId               bigint               null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   IsFavorite           bit                  null constraint DF_Dashboard_IsFavorite default (0),
   IsRead               bit                  null,
   IsShared             bit                  null,
   CreateTime           datetime             null,
   LastVisitTime        datetime             null,
   AddFavoriteTime      datetime             null,
   CustomerId           bigint               null,
   constraint PK_DASHBOARD primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Edge                                                  */
/*==============================================================*/
create table dbo.Edge (
   Id                   bigint               identity(1, 1),
   EntryEdgeId          bigint               null,
   DirectEdgeId         bigint               null,
   ExitEdgeId           bigint               null,
   StartVertex          bigint               null,
   EndVertex            bigint               null,
   Hops                 int                  null,
   Source               varchar(150)         collate SQL_Latin1_General_CP1_CI_AS null,
   constraint PK_Edge primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Hierarchy                                             */
/*==============================================================*/
create table dbo.Hierarchy (
   Id                   bigint               identity(1, 1),
   Type                 int                  null,
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   TimezoneId           bigint               null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   ParentId             bigint               null,
   CustomerId           bigint               null,
   Path                 hierarchyid     null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_HIERARCHY primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Hierarchy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Type')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Hierarchy', 'column', 'Type'

end


execute sp_addextendedproperty 'MS_Description', 
   '0-Organization 1-Site 2-Building',
   'user', 'dbo', 'table', 'Hierarchy', 'column', 'Type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Hierarchy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Hierarchy', 'column', 'Status'

end


execute sp_addextendedproperty 'MS_Description', 
   '0-Inactive 1-Active',
   'user', 'dbo', 'table', 'Hierarchy', 'column', 'Status'
go

/*==============================================================*/
/* Table: HierarchyAdvancedPropertyVersion                      */
/*==============================================================*/
create table dbo.HierarchyAdvancedPropertyVersion (
   Id                   bigint               identity(1, 1),
   Type                 smallint             not null,
   Version              timestamp            not null,
   HierarchyId          bigint               not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   constraint PK_HierarchyAdvancedPropertyVersion primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: HierarchyCalendar                                     */
/*==============================================================*/
create table dbo.HierarchyCalendar (
   Id                   bigint               identity(1, 1) not for replication,
   PropertyVersionId    bigint               null,
   EffectiveTime        int                  null,
   CalendarId           bigint               null,
   WorkTimeId           bigint               null,
   constraint PK_HIERARCHYCALENDAR primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: HierarchyCalendarReference                            */
/*==============================================================*/
create table dbo.HierarchyCalendarReference (
   Id                   bigint               identity(1, 1) not for replication,
   HierarchyId          bigint               null,
   PropertyVersionId    bigint               null,
   CalendarType         int                  null,
   constraint PK_HIERARCHYCALENDARREFERENCE primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Logo                                                  */
/*==============================================================*/
create table dbo.Logo (
   Id                   bigint               identity(1, 1),
   Logo                 varbinary(Max)       not null,
   HierarchyId          bigint               null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   constraint PK_File primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: PeakTariff                                            */
/*==============================================================*/
create table dbo.PeakTariff (
   Id                   bigint               identity(1, 1) not for replication,
   TouTariffId          bigint               null,
   Price                decimal(15,6)        null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_PEAKTARIFF primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: PeakTariffTime                                        */
/*==============================================================*/
create table dbo.PeakTariffTime (
   Id                   bigint               identity(1, 1) not for replication,
   PeakTariffId         bigint               null,
   StartMonth           int                  null,
   StartDay             int                  null,
   StartTime            int                  null,
   EndMonth             int                  null,
   EndDay               int                  null,
   EndTime              int                  null,
   constraint PK_PEAKTARIFFTIME primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Privilege                                             */
/*==============================================================*/
create table dbo.Privilege (
   Code                 nvarchar(50)         collate SQL_Latin1_General_CP1_CI_AS not null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS not null,
   constraint PK_Right primary key (Code)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: ReceiveShareInfo                                      */
/*==============================================================*/
create table dbo.ReceiveShareInfo (
   Id                   bigint               identity(1, 1),
   ReceiveUserId        bigint               null,
   ReceiveDashboardId   bigint               null,
   ReceiveWidgetId      bigint               null,
   HierarchyId          bigint               null,
   ShareTime            datetime             null,
   ShareItemType        int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   SendUserName         nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   SendUserTitle        int                  null,
   SendUserTelephone    nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   constraint PK_ReceiveShareInfo primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table dbo.Role (
   Id                   bigint               identity(1, 1),
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Comment              nvarchar(50)         collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_Role primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: RolePrivilege                                         */
/*==============================================================*/
create table dbo.RolePrivilege (
   RoleId               bigint               not null,
   PrivilegeCode        nvarchar(50)         collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Version              timestamp            not null,
   constraint PK_RolePrivilege primary key (RoleId, PrivilegeCode)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: SendShareInfo                                         */
/*==============================================================*/
create table dbo.SendShareInfo (
   Id                   bigint               identity(1, 1),
   SendUserId           bigint               null,
   HierarchyId          bigint               null,
   SendDashboardId      bigint               null,
   SendWidgetId         bigint               null,
   ShareTime            datetime             null,
   ShareItemType        int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   ReceiveUserNames     nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   constraint PK_SendShareInfo primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: SystemDimension                                       */
/*==============================================================*/
create table dbo.SystemDimension (
   Id                   bigint               identity(1, 1),
   TemplateItemId       bigint               null,
   HierarchyId          bigint               null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_SYSTEMDIMENSION primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: SystemDimensionTemplate                               */
/*==============================================================*/
create table dbo.SystemDimensionTemplate (
   Id                   bigint               identity(1, 1),
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   CustomerId           bigint               null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_SYSTEMDIMENSIONTEMPLATE primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: SystemDimensionTemplateItem                           */
/*==============================================================*/
create table dbo.SystemDimensionTemplateItem (
   Id                   bigint               identity(1, 1),
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   ParentId             bigint               null,
   TemplateId           bigint               not null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_SYSTEMDIMENSIONTEMPLATEITEM primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Tag                                                   */
/*==============================================================*/
create table dbo.Tag (
   Id                   bigint               identity(1, 1),
   Type                 int                  not null,
   GuidCode             bigint               not null,
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   TimezoneId           bigint               not null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   MeterCode            nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   ChannelId            bigint               null,
   CalculationType      int                  not null,
   CalculationStep      int                  null,
   UomId                bigint               not null,
   CommodityId          bigint               not null,
   StartTime            datetime             null,
   EnergyConsumption    int                  not null constraint DF_Tag_EnergyConsumption default (0),
   DayNightRatio        int                  null constraint DF_Tag_DayNightRatio default (0),
   Formula              nvarchar(4000)       collate SQL_Latin1_General_CP1_CI_AS null,
   FormulaRpn           nvarchar(4000)       collate SQL_Latin1_General_CP1_CI_AS null,
   CustomerId           bigint               null,
   HierarchyId          bigint               null,
   SystemDimensionId    bigint               null,
   AreaDimensionId      bigint               null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_Tag primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TagDirectRefer                                        */
/*==============================================================*/
create table dbo.TagDirectRefer (
   StartId              bigint               not null,
   EndId                bigint               not null,
   constraint PK_TagDirectRefer primary key (StartId, EndId)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TargetBaseline                                        */
/*==============================================================*/
create table dbo.TargetBaseline (
   Id                   bigint               identity(1, 1),
   GuidCode             bigint               not null,
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   TagId                bigint               not null,
   Type                 int                  not null,
   Status               int                  not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_KPIDateConfig primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TargetBaselineDataVersion                             */
/*==============================================================*/
create table dbo.TargetBaselineDataVersion (
   Id                   bigint               identity(1, 1),
   TargetBaselineId     bigint               not null,
   Year                 int                  not null,
   Status               int                  not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_TargetBaselineVersion primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TargetBaselineNormalDate                              */
/*==============================================================*/
create table dbo.TargetBaselineNormalDate (
   Id                   bigint               identity(1, 1),
   TargetBaselineId     bigint               not null,
   DayType              int                  not null,
   Year                 int                  not null,
   StartTime            int                  not null,
   Value                decimal(18,8)        null,
   Status               int                  not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_KPIFigureSetting primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TargetBaselineSpecialDate                             */
/*==============================================================*/
create table dbo.TargetBaselineSpecialDate (
   Id                   bigint               identity(1, 1),
   TargetBaselineId     bigint               not null,
   StartTime            datetime             not null,
   EndTime              datetime             not null,
   Value                decimal(18,8)        not null,
   Status               int                  not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_KPISpecialDateConfig primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Timezone                                              */
/*==============================================================*/
create table dbo.Timezone (
   Id                   bigint               identity(1, 1),
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Offset               decimal              null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_TIMEZONE primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TouTariff                                             */
/*==============================================================*/
create table dbo.TouTariff (
   Id                   bigint               identity(1, 1) not for replication,
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_TOUTARIFF primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TouTariffItem                                         */
/*==============================================================*/
create table dbo.TouTariffItem (
   Id                   bigint               identity(1, 1) not for replication,
   TouTariffId          bigint               null,
   ItemType             int                  null,
   Price                decimal(15,6)        null,
   StartTime            int                  null,
   EndTime              int                  null,
   constraint PK_TOUTARIFFITEM primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Uom                                                   */
/*==============================================================*/
create table dbo.Uom (
   Id                   bigint               identity(1, 1) not for replication,
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_UOM primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: UomGroup                                              */
/*==============================================================*/
create table dbo.UomGroup (
   Id                   bigint               identity(1, 1) not for replication,
   Code                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Comment              nvarchar(400)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   CommodityId          bigint               null,
   IsEnergyConsumptionGroup bit                  null,
   constraint PK_UOMGROUP primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: UomGroupRelation                                      */
/*==============================================================*/
create table dbo.UomGroupRelation (
   "Precision"          int                  null,
   GroupId              bigint               null,
   UomId                bigint               null,
   IsBase               bit                  null,
   IsCommon             bit                  null,
   IsStandardCoal       bit                  null,
   Factor               decimal(18,8)        null
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: "User"                                                */
/*==============================================================*/
create table dbo."User" (
   Id                   bigint               identity(1, 1),
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   RealName             nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UserType             int                  null,
   Password             nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   PasswordToken        sysname              collate SQL_Latin1_General_CP1_CI_AS null,
   PasswordTokenDate    datetime             null,
   Comment              nvarchar(200)        collate SQL_Latin1_General_CP1_CI_AS null,
   Title                int                  null,
   Telephone            nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Email                nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   Status               int                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   Version              timestamp            null,
   constraint PK_USER primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: UserCustomer                                          */
/*==============================================================*/
create table dbo.UserCustomer (
   UserId               bigint               not null,
   HierarchyId          bigint               not null,
   WholeCustomer        bit                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_UserCustomer primary key (UserId, HierarchyId)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: UserDataPrivilege                                     */
/*==============================================================*/
create table dbo.UserDataPrivilege (
   Id                   bigint               identity(1, 1),
   UserId               bigint               not null,
   PrivilegeType        int                  not null,
   PrivilegeItemId      bigint               not null,
   HierarchyPath        hierarchyid     not null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS not null,
   UpdateTime           datetime             not null,
   Version              timestamp            not null,
   constraint PK_UserDataPrivilege primary key (UserId, PrivilegeType, PrivilegeItemId)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: UserRole                                              */
/*==============================================================*/
create table dbo.UserRole (
   UserId               bigint               not null,
   RoleId               bigint               not null,
   constraint PK_UserRole primary key (UserId, RoleId)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Widget                                                */
/*==============================================================*/
create table dbo.Widget (
   Id                   bigint               identity(1, 1),
   Name                 nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   DashboardId          bigint               null,
   LayoutSyntax         nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   ContentSyntax        nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   IsRead               bit                  null,
   IsShared             bit                  null,
   UpdateUser           nvarchar(100)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime             null,
   constraint PK_Widget primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

alter table dbo.AdvancedProperty
   add constraint FK_AdvancedProperty_Uom foreign key (UomId)
      references dbo.Uom (Id)
go

alter table dbo.AdvancedProperty
   add constraint FK_HierarchyDynamicProperty_Hierarchy foreign key (HierarchyId)
      references dbo.Hierarchy (Id)
         on delete cascade
go

alter table dbo.AdvancedPropertyValue
   add constraint FK_HierarchyDynamicPropertyValue_HierarchyDynamicProperty foreign key (PropertyId)
      references dbo.AdvancedProperty (Id)
         on delete cascade
go

alter table dbo.AreaDimension
   add constraint FK_AREADIME_REFERENCE_HIERARCH foreign key (HierarchyId)
      references dbo.Hierarchy (Id)
go

alter table dbo.CalendarItem
   add constraint FK_CalendarItem_Calendar foreign key (CalendarId)
      references dbo.Calendar (Id)
go

alter table dbo.CarbonFactor
   add constraint FK_CARBONFA_REFERENCE_COMMODIT foreign key (CommodityId)
      references dbo.Commodity (Id)
go

alter table dbo.CarbonFactorItem
   add constraint FK_CARBONFA_REFERENCE_CARBONFA foreign key (CarbonFactorId)
      references dbo.CarbonFactor (Id)
go

alter table dbo.CostCommodity
   add constraint FK_CostCommodity_Commodity foreign key (CommodityId)
      references dbo.Commodity (Id)
go

alter table dbo.CostCommodity
   add constraint FK_CostCommodity_HierarchyAdvancedPropertyVersion foreign key (CostId)
      references dbo.HierarchyAdvancedPropertyVersion (Id)
go

alter table dbo.CostCommodity
   add constraint FK_CostCommodity_Uom foreign key (UomId)
      references dbo.Uom (Id)
go

alter table dbo.CostComplexItem
   add constraint FK_CostComplexItem_CostCommodity foreign key (CostCommodityId)
      references dbo.CostCommodity (Id)
go

alter table dbo.CostComplexItem
   add constraint FK_CostComplexItem_Tag foreign key (HourTagId)
      references dbo.Tag (Id)
go

alter table dbo.CostComplexItem
   add constraint FK_CostComplexItem_Tag1 foreign key (ReactiveTagId)
      references dbo.Tag (Id)
go

alter table dbo.CostComplexItem
   add constraint FK_CostComplexItem_Tag2 foreign key (RealTagId)
      references dbo.Tag (Id)
go

alter table dbo.CostComplexItem
   add constraint FK_CostComplexItem_TouTariff foreign key (TouTariffId)
      references dbo.TouTariff (Id)
go

alter table dbo.CostSimpleItem
   add constraint FK_CostSimpleItem_CostCommodity foreign key (CostCommodityId)
      references dbo.CostCommodity (Id)
go

alter table dbo.Edge
   add constraint FK_Edge_Tag_End foreign key (EndVertex)
      references dbo.Tag (Id)
         on delete cascade
go

alter table dbo.Hierarchy
   add constraint FK_HIERARCH_REFERENCE_TIMEZONE foreign key (TimezoneId)
      references dbo.Timezone (Id)
go

alter table dbo.HierarchyAdvancedPropertyVersion
   add constraint FK_HierarchyAdvancedPropertyVersion_Hierarchy foreign key (HierarchyId)
      references dbo.Hierarchy (Id)
go

alter table dbo.HierarchyCalendar
   add constraint FK_HIERARCH_REFERENCE_HIERARCH foreign key (PropertyVersionId)
      references dbo.HierarchyAdvancedPropertyVersion (Id)
go

alter table dbo.HierarchyCalendarReference
   add constraint FK_HIERARCH_REFERENCE_HIERARCHY foreign key (HierarchyId)
      references dbo.Hierarchy (Id)
go

alter table dbo.HierarchyCalendarReference
   add constraint FK_HIERARCH_REFERENCE_HIERARCHYVERSION foreign key (PropertyVersionId)
      references dbo.HierarchyAdvancedPropertyVersion (Id)
go

alter table dbo.PeakTariff
   add constraint FK_TARIFFPEAK_REFERENCE_TARIFF foreign key (TouTariffId)
      references dbo.TouTariff (Id)
go

alter table dbo.PeakTariffTime
   add constraint FK_PEAKTARI_REFERENCE_PEAKTARI foreign key (PeakTariffId)
      references dbo.PeakTariff (Id)
go

alter table dbo.RolePrivilege
   add constraint FK_RolePrivilege_Privilege foreign key (PrivilegeCode)
      references dbo.Privilege (Code)
go

alter table dbo.RolePrivilege
   add constraint FK_RolePrivilege_Role foreign key (RoleId)
      references dbo.Role (Id)
go

alter table dbo.SystemDimension
   add constraint FK_SYSTEMDI_REFERENCE_HIERARCH foreign key (HierarchyId)
      references dbo.Hierarchy (Id)
go

alter table dbo.SystemDimension
   add constraint FK_SYSTEMDI_REFERENCE_SYSTEMDI foreign key (TemplateItemId)
      references dbo.SystemDimensionTemplateItem (Id)
go

alter table dbo.SystemDimensionTemplateItem
   add constraint FK_SYSTEMDI_REFERENCE_SYSTEMDIT foreign key (TemplateId)
      references dbo.SystemDimensionTemplate (Id)
go

alter table dbo.Tag
   add constraint FK_Tag_AreaDimension foreign key (AreaDimensionId)
      references dbo.AreaDimension (Id)
         on delete set null
go

alter table dbo.Tag
   add constraint FK_Tag_Commodity foreign key (CommodityId)
      references dbo.Commodity (Id)
go

alter table dbo.Tag
   add constraint FK_Tag_Hierarchy foreign key (CustomerId)
      references dbo.Hierarchy (Id)
         on delete set null
go

alter table dbo.Tag
   add constraint FK_Tag_SystemDimension foreign key (SystemDimensionId)
      references dbo.SystemDimension (Id)
         on delete set null
go

alter table dbo.Tag
   add constraint FK_Tag_Timezone foreign key (TimezoneId)
      references dbo.Timezone (Id)
go

alter table dbo.TagDirectRefer
   add constraint FK_TagDirectRefer_Tag foreign key (StartId)
      references dbo.Tag (Id)
         on delete cascade
go

alter table dbo.TargetBaseline
   add constraint FK_TargetBaseline_Tag foreign key (TagId)
      references dbo.Tag (Id)
         on delete cascade
go

alter table dbo.TargetBaselineDataVersion
   add constraint FK_TargetBaselineDataVersion_TargetBaseline foreign key (TargetBaselineId)
      references dbo.TargetBaseline (Id)
         on delete cascade
go

alter table dbo.TargetBaselineNormalDate
   add constraint FK_TargetBaselineNormalDate_TargetBaseline foreign key (TargetBaselineId)
      references dbo.TargetBaseline (Id)
         on delete cascade
go

alter table dbo.TargetBaselineSpecialDate
   add constraint FK_TargetBaselineSpecialDate_TargetBaseline foreign key (TargetBaselineId)
      references dbo.TargetBaseline (Id)
         on delete cascade
go

alter table dbo.TouTariffItem
   add constraint FK_TARIFFITEM_REFERENCE_TARIFF foreign key (TouTariffId)
      references dbo.TouTariff (Id)
go

alter table dbo.UomGroup
   add constraint FK_UOMGROUP_REFERENCE_COMMODITY foreign key (CommodityId)
      references dbo.Commodity (Id)
go

alter table dbo.UomGroupRelation
   add constraint FK_UOMGROUPRELATION_REFERENCE_UOMGROUP foreign key (GroupId)
      references dbo.UomGroup (Id)
go

alter table dbo.UserCustomer
   add constraint FK_UserCustomer_User foreign key (UserId)
      references dbo."User" (Id)
go

alter table dbo.UserRole
   add constraint FK_UserRole_Role foreign key (RoleId)
      references dbo.Role (Id)
go

alter table dbo.UserRole
   add constraint FK_UserRole_User foreign key (UserId)
      references dbo."User" (Id)
go


create trigger dbo.data_auth_on_hierarchy_delete on dbo.Hierarchy after delete
AS
DELETE FROM UserDataPrivilege WHERE PrivilegeItemId IN (SELECT Id FROM deleted) AND PrivilegeType=0
go


create trigger dbo.data_auth_on_usercustomer_delete on dbo.UserCustomer after delete
AS
DELETE FROM UserDataPrivilege WHERE UserId IN (SELECT DISTINCT UserId FROM deleted) AND PrivilegeItemId IN (SELECT Id FROM Hierarchy WHERE CustomerId IN (SELECT DISTINCT [HierarchyId] FROM deleted))
go

