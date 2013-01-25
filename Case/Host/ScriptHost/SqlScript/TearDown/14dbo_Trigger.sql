
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[data_auth_on_usercustomer_insert]'))
DROP TRIGGER [dbo].[data_auth_on_usercustomer_insert]
GO
CREATE TRIGGER [dbo].[data_auth_on_usercustomer_insert]
ON [dbo].[UserCustomer]
AFTER INSERT
AS
INSERT INTO UserDataPrivilege(UserId, PrivilegeType, PrivilegeItemId, HierarchyPath, UpdateUser, UpdateTime)
SELECT inserted.UserId,0,Hierarchy.Id,Path,'TRIGGER',GETDATE() 
FROM Hierarchy INNER JOIN inserted ON inserted.HierarchyId=Hierarchy.CustomerId 
WHERE CustomerId=inserted.HierarchyId
GO



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[data_auth_on_usercustomer_delete]'))
DROP TRIGGER [dbo].[data_auth_on_usercustomer_delete]
GO
CREATE TRIGGER [dbo].[data_auth_on_usercustomer_delete]
ON [dbo].[UserCustomer]
AFTER DELETE
AS
DELETE FROM UserDataPrivilege WHERE UserId IN (SELECT DISTINCT UserId FROM deleted) AND PrivilegeItemId IN (SELECT Id FROM Hierarchy WHERE CustomerId IN (SELECT DISTINCT [HierarchyId] FROM deleted))

GO



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[data_auth_on_hierarchy_insert]'))
DROP TRIGGER [dbo].[data_auth_on_hierarchy_insert]
GO
CREATE TRIGGER [dbo].[data_auth_on_hierarchy_insert]
ON [dbo].[Hierarchy]
AFTER INSERT
AS
INSERT INTO UserDataPrivilege(UserId, PrivilegeType, PrivilegeItemId, HierarchyPath, UpdateUser, UpdateTime)
SELECT UserId,0,inserted.Id,inserted.Path,inserted.UpdateUser,inserted.UpdateTime FROM UserCustomer INNER JOIN inserted ON inserted.CustomerId=UserCustomer.HierarchyId

GO



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[data_auth_on_hierarchy_delete]'))
DROP TRIGGER [dbo].[data_auth_on_hierarchy_delete]
GO
CREATE TRIGGER [dbo].[data_auth_on_hierarchy_delete]
ON [dbo].[Hierarchy]
AFTER DELETE
AS
DELETE FROM UserDataPrivilege WHERE PrivilegeItemId IN (SELECT Id FROM deleted) AND PrivilegeType=0

GO

