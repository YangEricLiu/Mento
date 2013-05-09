
GO
INSERT INTO Privilege(Code,Comment)VALUES
('1100','Common.DashboardView'),
('1101','Common.DashboardManagement'),
('1102','Common.PersonalInfoManagement '),
('1200','Role.DashboardSharing'),
('1201','Role.EnergyUsage'),
('1202','Role.CarbonEmission'),
('1203','Role.EnergyCost'),
('1204','Role.EnergyEfficiency '),
('1205','Role.EnergyExport'),
('1206','Role.PlatformManagement'),
('1207','Role.HierarchyManagement'),
('1208','Role.TagManagement'),
('1209','Role.KPIConfiguration '),
('1210','Role.TagMapping '),
('1211','Role.CustomerInfoView '),
('1212','Role.CustomerInfoManagement')

GO

GO

INSERT INTO RolePrivilege (RoleId,PrivilegeCode,UpdateTime,UpdateUser)VALUES
('1',1200,getdate(),''),
('1',1201,getdate(),''),
('1',1202,getdate(),''),
('1',1203,getdate(),''),
('1',1204,getdate(),''),
('1',1206,getdate(),''),
('1',1207,getdate(),''),
('1',1208,getdate(),''),
('1',1209,getdate(),''),
('1',1210,getdate(),''),
('1',1211,getdate(),''),
('2',1200,getdate(),''),
('2',1201,getdate(),''),
('2',1202,getdate(),''),
('2',1203,getdate(),''),
('2',1204,getdate(),''),
('2',1207,getdate(),''),
('2',1208,getdate(),''),
('2',1209,getdate(),''),
('2',1210,getdate(),''),
('2',1211,getdate(),''),
('2',1212,getdate(),''),
('3',1200,getdate(),''),
('3',1201,getdate(),''),
('3',1202,getdate(),''),
('3',1203,getdate(),''),
('3',1204,getdate(),''),
('3',1205,getdate(),''),
('3',1207,getdate(),''),
('3',1208,getdate(),''),
('3',1209,getdate(),''),
('3',1210,getdate(),''),
('3',1211,getdate(),''),
('4',1100,getdate(),''),
('4',1101,getdate(),''),
('4',1102,getdate(),''),
('4',1200,getdate(),''),
('4',1201,getdate(),''),
('4',1202,getdate(),''),
('4',1203,getdate(),''),
('4',1204,getdate(),''),
('4',1211,getdate(),''),
('5',1211,getdate(),'')
GO
