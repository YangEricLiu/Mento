-----------------------------------Preset data------------------------------------
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


-----------------------------------Hierarchy------------------------------------
/*HierarchyType: Customer=-1, Organization = 0, Site = 1, Building = 2*/
SET IDENTITY_INSERT Hierarchy ON
INSERT INTO Hierarchy(Id,Type,Code,Name,TimezoneId,Comment,ParentId,CustomerId,Path,Status,UpdateUser,UpdateTime)
VALUES(3,0,'HierarchyEV','HierarchyEV',1,'HierarchyEV',2,2,'/2/3/',2,'Mento',GETDATE())
SET IDENTITY_INSERT Hierarchy OFF

-----------------------------------Tag------------------------------------
SET IDENTITY_INSERT [Tag] ON
INSERT INTO [Tag] ([ID],[Type],[GuidCode],[Code],[Name],[TimezoneId],[Comment],[MeterCode],[ChannelId],[CalculationType],[CalculationStep],[UomId],[CommodityId],[StartTime],[EnergyConsumption],[DayNightRatio],[Formula],[FormulaRpn],[CustomerId],[HierarchyId],[SystemDimensionId],[AreaDimensionId],[Status],[UpdateUser],[UpdateTime])
VALUES(1,1,5373062981773366147,'P0','P0',1,'P0','P0',0,1,NULL,1,1,'2011-12-31',0,NULL,NULL,NULL,2,3,NULL,NULL,1,'OTSTool','2013-01-09 16:46:33.497')
SET IDENTITY_INSERT [Tag] OFF