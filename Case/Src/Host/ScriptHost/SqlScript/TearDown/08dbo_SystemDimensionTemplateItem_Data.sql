

/* Data for the `dbo.SystemDimensionTemplateItem` table  (Records 1 - 146) */
SET IDENTITY_INSERT SystemDimensionTemplateItem ON
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (1, N'HVAC', N'空调', NULL, NULL, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (2, N'PowerSystem', N'动力', NULL, NULL, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (3, N'ElectricityComsumptionInFunctionArea', N'功能区域用电', NULL, NULL, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (4, N'ElectricityComsumptionInSecondZone', N'辅助区域用电', NULL, NULL, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (5, N'KeySystem', N'关键', NULL, NULL, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (6, N'Special', N'特殊', NULL, NULL, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (7, N'CoolingHeatingSource', N'冷热源', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (8, N'CoolingMachine', N'供冷主机', NULL, 7, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (9, N'HeatingMachine', N'供热主机', NULL, 7, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (10, N'CoolingOrHeatingMachine', N'冷热兼供主机', NULL, 7, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (11, N'AirCooledCoolingMachine', N'风冷冷水机组', NULL, 7, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (12, N'ChilledHeatWaterPump', N'冷冻换热泵', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (13, N'ChilledOrHeatWaterPump', N'冷冻/换热泵', NULL, 12, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (14, N'ChilledWaterPump', N'冷冻泵', NULL, 12, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (15, N'HeatWaterPump', N'换热泵', NULL, 12, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (16, N'CoolingWaterPump', N'冷却泵', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (17, N'CoolingTower', N'冷却塔风机', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (18, N'AirTerminal', N'空调末端', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (19, N'ExhausteFan', N'排风机', NULL, 18, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (20, N'FCU', N'风机盘管', NULL, 18, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (21, N'AHU', N'空调箱', NULL, 18, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (22, N'FAHU', N'新风机', NULL, 18, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (23, N'TerminalReheat', N'末端再热', NULL, 18, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (24, N'DecentralizedAirConditioning', N'分散空调', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (25, N'VRV', N'VRV空调', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (26, N'LiquidDesiccantAirCondition', N'溶液除湿机组', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (27, N'ElectricHeating', N'电采暖设备', NULL, 1, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (28, N'Boiler', N'锅炉', NULL, 2, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (29, N'DrainagePump', N'给排水泵', NULL, 2, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (30, N'DomesticWaterPump', N'生活水泵', NULL, 29, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (31, N'SewagePump', N'排污泵', NULL, 29, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (32, N'RecycledWaterPump', N'中水泵', NULL, 29, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (33, N'SubmersiblePump', N'潜水泵', NULL, 29, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (34, N'Elevator', N'电梯', NULL, 2, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (35, N'Staircase', N'扶梯', NULL, 34, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (36, N'PassengerElevator', N'客梯', NULL, 34, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (37, N'FreightElevator', N'货梯', NULL, 34, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (38, N'DebrisElevator', N'污梯', NULL, 34, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (39, N'Outlet', N'插座', NULL, 3, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (40, N'Lighting', N'照明', NULL, 3, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (41, N'Lobby', N'大堂', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (42, N'GarageLighting', N'车库照明', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (43, N'Service', N'服务部门', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (44, N'ServiceLight', N'服务部门照明', NULL, 43, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (45, N'ServiceOutlet', N'服务部门插座', NULL, 43, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (46, N'InformationRoom', N'信息机房', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (47, N'InformationEquipment', N'信息设备', NULL, 46, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (48, N'HVACEquipment', N'信息设备专用空调', NULL, 46, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (49, N'Canteen', N'厨房餐厅', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (50, N'CookingAppliances', N'厨房炊事设备', NULL, 49, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (51, N'HVACCooking', N'厨房空调机', NULL, 49, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (52, N'SmokeExhaustMachine', N'厨房排烟机', NULL, 49, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (53, N'OutletLighting', N'厨房照明插座', NULL, 49, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (54, N'PublicLighting', N'公共照明', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (55, N'NightSceneLighting', N'夜景照明', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (56, N'WaterHeater', N'热水器', NULL, 4, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (57, N'XMachine', N'X光机', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (58, N'CTMachine', N'CT机', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (59, N'NMR', N'核磁共振', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (60, N'Dialyzer', N'血透', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (61, N'HyperbaricOxygenChamber', N'高压氧舱', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (62, N'Server', N'服务器', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (63, N'Router', N'交换机', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (64, N'AirPurifier', N'空气净化器', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (65, N'Transmitter', N'发射机', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (66, N'PrecisionAirConditioner', N'精密空调', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (67, N'UPSLoss', N'UPS损耗', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (68, N'ICU', N'ICU病房', NULL, 5, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (69, N'LaundryEquipment', N'洗衣房设备', NULL, 6, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (70, N'ElectricitySwimmingPool', N'游泳池用电', NULL, 6, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (71, N'OutsourcingCanteen', N'外包餐厅', NULL, 6, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (72, N'OutsourceingClient', N'外包商户', NULL, 6, 1, 1, N'Demo', '20120101')
GO

INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
VALUES (73, N'Other', N'其他', NULL, 6, 1, 1, N'Demo', '20120101')
GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (74, N'HVAC', N'空调', NULL, NULL, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (75, N'PowerSystem', N'动力', NULL, NULL, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (76, N'ElectricityComsumptionInFunctionArea', N'功能区域用电', NULL, NULL, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (77, N'ElectricityComsumptionInSecondZone', N'辅助区域用电', NULL, NULL, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (78, N'KeySystem', N'关键', NULL, NULL, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (79, N'Special', N'特殊', NULL, NULL, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (80, N'CoolingHeatingSource', N'冷热源', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (81, N'CoolingMachine', N'供冷主机', NULL, 80, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (82, N'HeatingMachine', N'供热主机', NULL, 80, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (83, N'CoolingOrHeatingMachine', N'冷热兼供主机', NULL, 80, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (84, N'AirCooledCoolingMachine', N'风冷冷水机组', NULL, 80, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (85, N'ChilledHeatWaterPump', N'冷冻换热泵', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (86, N'ChilledOrHeatWaterPump', N'冷冻/换热泵', NULL, 85, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (87, N'ChilledWaterPump', N'冷冻泵', NULL, 85, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (88, N'HeatWaterPump', N'换热泵', NULL, 85, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (89, N'CoolingWaterPump', N'冷却泵', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (90, N'CoolingTower', N'冷却塔风机', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (91, N'AirTerminal', N'空调末端', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (92, N'ExhausteFan', N'排风机', NULL, 91, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (93, N'FCU', N'风机盘管', NULL, 91, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (94, N'AHU', N'空调箱', NULL, 91, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (95, N'FAHU', N'新风机', NULL, 91, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (96, N'TerminalReheat', N'末端再热', NULL, 91, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (97, N'DecentralizedAirConditioning', N'分散空调', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (98, N'VRV', N'VRV空调', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (99, N'LiquidDesiccantAirCondition', N'溶液除湿机组', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (100, N'ElectricHeating', N'电采暖设备', NULL, 74, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (101, N'Boiler', N'锅炉', NULL, 75, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (102, N'DrainagePump', N'给排水泵', NULL, 75, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (103, N'DomesticWaterPump', N'生活水泵', NULL, 102, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (104, N'SewagePump', N'排污泵', NULL, 102, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (105, N'RecycledWaterPump', N'中水泵', NULL, 102, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (106, N'SubmersiblePump', N'潜水泵', NULL, 102, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (107, N'Elevator', N'电梯', NULL, 75, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (108, N'Staircase', N'扶梯', NULL, 107, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (109, N'PassengerElevator', N'客梯', NULL, 107, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (110, N'FreightElevator', N'货梯', NULL, 107, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (111, N'DebrisElevator', N'污梯', NULL, 107, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (112, N'Outlet', N'插座', NULL, 76, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (113, N'Lighting', N'照明', NULL, 76, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (114, N'Lobby', N'大堂', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (115, N'GarageLighting', N'车库照明', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (116, N'Service', N'服务部门', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (117, N'ServiceLight', N'服务部门照明', NULL, 116, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (118, N'ServiceOutlet', N'服务部门插座', NULL, 116, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (119, N'InformationRoom', N'信息机房', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (120, N'InformationEquipment', N'信息设备', NULL, 119, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (121, N'HVACEquipment', N'信息设备专用空调', NULL, 119, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (122, N'Canteen', N'厨房餐厅', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (123, N'CookingAppliances', N'厨房炊事设备', NULL, 122, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (124, N'HVACCooking', N'厨房空调机', NULL, 122, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (125, N'SmokeExhaustMachine', N'厨房排烟机', NULL, 122, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (126, N'OutletLighting', N'厨房照明插座', NULL, 122, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (127, N'PublicLighting', N'公共照明', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (128, N'NightSceneLighting', N'夜景照明', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (129, N'WaterHeater', N'热水器', NULL, 77, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (130, N'XMachine', N'X光机', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (131, N'CTMachine', N'CT机', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (132, N'NMR', N'核磁共振', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (133, N'Dialyzer', N'血透', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (134, N'HyperbaricOxygenChamber', N'高压氧舱', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (135, N'Server', N'服务器', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (136, N'Router', N'交换机', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (137, N'AirPurifier', N'空气净化器', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (138, N'Transmitter', N'发射机', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (139, N'PrecisionAirConditioner', N'精密空调', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (140, N'UPSLoss', N'UPS损耗', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (141, N'ICU', N'ICU病房', NULL, 78, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (142, N'LaundryEquipment', N'洗衣房设备', NULL, 79, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (143, N'ElectricitySwimmingPool', N'游泳池用电', NULL, 79, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (144, N'OutsourcingCanteen', N'外包餐厅', NULL, 79, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (145, N'OutsourceingClient', N'外包商户', NULL, 79, 2, 1, N'Demo', '20120101')
--GO

--INSERT INTO [dbo].[SystemDimensionTemplateItem] ([Id], [code], [Name], [Comment], [ParentId], [TemplateId], [Status], [UpdateUser], [UpdateTime])
--VALUES (146, N'Other', N'其他', NULL, 79, 2, 1, N'Demo', '20120101')
--GO


SET IDENTITY_INSERT SystemDimensionTemplateItem OFF
GO
