-----------------------------------Preset data------------------------------------
SET IDENTITY_INSERT [User] ON
INSERT INTO [User](Id,Name,RealName,UserType,Password,Comment,Title,Telephone,Email,Status,UpdateUser,UpdateTime)
VALUES(3,'Admin','Admin',1,'161EBD7D45089B3446EE4E0D86DBCF92','Admin','Admin','0100000','11@11.11',1,'Admin',GETDATE())
SET IDENTITY_INSERT [User] OFF

SET IDENTITY_INSERT Hierarchy ON
INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(2,-1,'Mento','自动化测试',1,'Mento',NULL,2,'/2/',1,'Mento',GETDATE())
SET IDENTITY_INSERT Hierarchy OFF

INSERT INTO Customer(HierarchyId,Address,Manager,Telephone,Email,StartTime)
VALUES(2,'beijing','auto','01000000','111@11@.11',GETDATE())

SET IDENTITY_INSERT [User] ON
INSERT INTO [User](Id,Name,RealName,UserType,Password,Comment,Title,Telephone,Email,Status,UpdateUser,UpdateTime)
VALUES(2,'AutoCustomer','Auto',2,'161EBD7D45089B3446EE4E0D86DBCF92','auto','auto','0100000','11@11.11',1,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT [User] OFF

SET IDENTITY_INSERT UserCustomer ON
INSERT INTO UserCustomer(Id,UserId,HierarchyId)
VALUES(2,2,2)
SET IDENTITY_INSERT UserCustomer OFF

/*
SET IDENTITY_INSERT SystemDimensionTemplate ON
INSERT INTO SystemDimensionTemplate([Id],[Name],[Comment],[CustomerId],[Status],UpdateUser,UpdateTime)
VALUES(2,'自动化测试',NULL,2,1,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT SystemDimensionTemplate OFF*/


-----------------------------------Hierarchy------------------------------------
/*HierarchyType: Customer=-1, Organization = 0, Site = 1, Building = 2*/
SET IDENTITY_INSERT Hierarchy ON
INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(3,0,'HierarchyEV','HierarchyEV',1,'HierarchyEV',2,2,'/2/3/',1,'Mento',GETDATE())


/*Hierarchy for customer settings -- add calendar*/
INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(4,1,'AddCalendarProperty','AddCalendarProperty',1,'test',2,2,'/2/4/',1,'AutoCustomer',GETDATE())

INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(5,1,'12345','12345',1,'test',2,2,'/2/5/',1,'AutoCustomer',GETDATE())

INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(6,1,'systemAssociate','systemAssociate',1,'test',2,2,'/2/6/',1,'AutoCustomer',GETDATE())

INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(7,2,'AreaDimension','AreaDimension',1,'test',6,2,'/2/6/7/',1,'AutoCustomer',GETDATE())

INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(8,2,'AddPeopleProperty','AddPeopleProperty',1,'test',4,1,'/2/4/8/',1,'AutoCustomer',GETDATE())

INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(9,2,'124','124',1,'test',5,1,'/2/5/9/',1,'AutoCustomer',GETDATE())

INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(10,0,'SiteEV','SiteEV',1,'SiteEV',3,2,'/2/3/10/',1,'Mento',GETDATE())

INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(11,0,'BuildingEV','BuildingEV',1,'BuildingEV',10,2,'/2/3/10/11/',1,'Mento',GETDATE())
SET IDENTITY_INSERT Hierarchy OFF

-----------------------------------System Dimension------------------------------------
/*System dimention for associate/disassociate tag
SET IDENTITY_INSERT SystemDimension ON
INSERT INTO SystemDimension(Id,TemplateItemId,HierarchyId,UpdateUser,UpdateTime)
VALUES(1,,6,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT SystemDimension OFF*/

-----------------------------------Tag------------------------------------
/*Tag for Energy view -- single tag*/
SET IDENTITY_INSERT [Tag] ON
INSERT INTO [Tag] ([ID],[Type],[GuidCode],[Code],[Name],[TimezoneId],[Comment],[MeterCode],[ChannelId],[CalculationType],[CalculationStep],[UomId],[CommodityId],[StartTime],[EnergyConsumption],[DayNightRatio],[Formula],[FormulaRpn],[CustomerId],[HierarchyId],[SystemDimensionId],[AreaDimensionId],[Status],[UpdateUser],[UpdateTime])
VALUES(1,1,5373062981773366147,'P0','P0',1,'P0','P0',0,1,NULL,1,1,'2011-12-31',0,NULL,NULL,NULL,2,3,NULL,NULL,1,'OTSTool','2013-01-09 16:46:33.497')
SET IDENTITY_INSERT [Tag] OFF

/*Tag for Formula -- Add_V1 ＝ Add_P1 + Amy_c_P1*/
SET IDENTITY_INSERT Tag ON
INSERT INTO [Tag] ([ID],[Type],[GuidCode],[Code],[Name],[TimezoneId],[Comment],[MeterCode],[ChannelId],[CalculationType],[CalculationStep],[UomId],[CommodityId],[StartTime],[EnergyConsumption],[DayNightRatio],[Formula],[FormulaRpn],[CustomerId],[HierarchyId],[SystemDimensionId],[AreaDimensionId],[Status],[UpdateUser],[UpdateTime])
VALUES(2,1,5703362057196811983,'Add_P1','Add_P1',1,NULL,'Add_P1',1,1,NULL,1,1,'2012-12-31',0,NULL,NULL,NULL,1,NULL,NULL,NULL,1,'AutoCustomer','2013-01-10 16:46:33.497')
SET IDENTITY_INSERT Tag OFF

/*Tag for Formula -- Add_V1 ＝ Add_P1 + Amy_c_P1*/
SET IDENTITY_INSERT Tag ON
INSERT INTO [Tag] ([ID],[Type],[GuidCode],[Code],[Name],[TimezoneId],[Comment],[MeterCode],[ChannelId],[CalculationType],[CalculationStep],[UomId],[CommodityId],[StartTime],[EnergyConsumption],[DayNightRatio],[Formula],[FormulaRpn],[CustomerId],[HierarchyId],[SystemDimensionId],[AreaDimensionId],[Status],[UpdateUser],[UpdateTime])
VALUES(3,1,5278057844565827450,'Amy_c_P1电_分散空调','Amy_c_P1',1,NULL,'123',5,1,NULL,1,1,GETDATE(),0,NULL,NULL,NULL,1,NULL,NULL,NULL,1,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT Tag OFF

/*Tag for Formula -- Add_V1 ＝ Add_P1 + Amy_c_P1*/
/*Tag for tag associate/disassociate with system dimension node*/
SET IDENTITY_INSERT Tag ON
INSERT INTO [Tag] ([ID],[Type],[GuidCode],[Code],[Name],[TimezoneId],[Comment],[MeterCode],[ChannelId],[CalculationType],[CalculationStep],[UomId],[CommodityId],[StartTime],[EnergyConsumption],[DayNightRatio],[Formula],[FormulaRpn],[CustomerId],[HierarchyId],[SystemDimensionId],[AreaDimensionId],[Status],[UpdateUser],[UpdateTime])
VALUES(4,2,4788817874500286044,'Add_V1','Add_V1',1,NULL,NULL,0,1,1,1,1,GETDATE(),0,NULL,NULL,NULL,1,NULL,NULL,NULL,1,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT Tag OFF

/*Tag for tag associate/disassociate with area dimension node*/
SET IDENTITY_INSERT Tag ON
INSERT INTO [Tag] ([ID],[Type],[GuidCode],[Code],[Name],[TimezoneId],[Comment],[MeterCode],[ChannelId],[CalculationType],[CalculationStep],[UomId],[CommodityId],[StartTime],[EnergyConsumption],[DayNightRatio],[Formula],[FormulaRpn],[CustomerId],[HierarchyId],[SystemDimensionId],[AreaDimensionId],[Status],[UpdateUser],[UpdateTime])
VALUES(5,1,4875414180730017321,'AddforAreaAssociate','AddforAreaAssociate',1,NULL,'AddforAreaAssociate',1,1,NULL,1,1,GETDATE(),0,NULL,NULL,NULL,1,NULL,NULL,NULL,1,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT Tag OFF

/*Tag for tag associate/disassociate with hierarchy node*/
SET IDENTITY_INSERT Tag ON
INSERT INTO Tag(Id,Type,GuidCode,Code,Name,TimezoneId,Comment,MeterCode,ChannelId,CalculationType,CalculationStep,UomId,CommodityId,StartTime,EnergyConsumption,DayNightRatio,Formula,FormulaRpn,CustomerId,HierarchyId,SystemDimensionId,AreaDimensionId,Status,UpdateUser,UpdateTime)
VALUES(6,2,5339177129305000926,'Amy_m_V1_Vtagconst1','Amy_m_V1_Vtagconst1',1,NULL,NULL,0,1,1,1,1,GETDATE(),0,NULL,NULL,NULL,1,NULL,NULL,NULL,1,'AutoCustomer',GETDATE())
SET IDENTITY_INSERT Tag OFF

SET IDENTITY_INSERT Tag ON
INSERT INTO [Tag] ([ID],[Type],[GuidCode],[Code],[Name],[TimezoneId],[Comment],[MeterCode],[ChannelId],[CalculationType],[CalculationStep],[UomId],[CommodityId],[StartTime],[EnergyConsumption],[DayNightRatio],[Formula],[FormulaRpn],[CustomerId],[HierarchyId],[SystemDimensionId],[AreaDimensionId],[Status],[UpdateUser],[UpdateTime])
VALUES(7,1,5373062981773366148,'P1','P1',1,'P1','P1',0,1,NULL,1,1,'2011-12-31',0,NULL,NULL,NULL,2,11,NULL,NULL,1,'OTSTool','2013-01-09 16:46:33.497')
SET IDENTITY_INSERT [Tag] OFF
