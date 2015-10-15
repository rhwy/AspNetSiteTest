IF EXISTS(SELECT * FROM sys.tables WHERE object_id=OBJECT_ID('[dbo].[WebTestTableCategories]'))
BEGIN
	DROP TABLE [dbo].[WebTestTableCategories]
END
GO
CREATE TABLE [dbo].[WebTestTableCategories] 
(
	Id INT NOT NULL,
	Name NVARCHAR(20) NOT NULL 
)
GO
INSERT INTO [dbo].[WebTestTableCategories] (Id,Name) VALUES (1,'Lion'),(2,'Tiger'),(3,'Leopard'),(4,'Lynx'),(5,'Cat')
GO

IF EXISTS(SELECT * FROM sys.tables WHERE object_id=OBJECT_ID('[dbo].[WebTestTable]'))
BEGIN
	DROP TABLE [dbo].[WebTestTable]
END
GO
CREATE TABLE [dbo].[WebTestTable] 
(
	Id NVARCHAR(36) NOT NULL CONSTRAINT DF_WebTestTable_Id DEFAULT(CAST(NewId() as NVARCHAR(36))),
	Content NVARCHAR(512) NOT NULL ,
	Created DATETIME NOT NULL CONSTRAINT DF_WebTestTable_Created DEFAULT(GETDATE()),
	Category INT NOT NULL CONSTRAINT DF_WebTestTable_Category DEFAULT(0)
)

INSERT INTO [dbo].[WebTestTable] (Content,Category) VALUES
('Lorem ipsum dolor sit amet, consectetur adipiscing elit.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Nulla maximus nunc at ex scelerisque, id faucibus dolor aliquet.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Nulla eget dui vel nulla venenatis iaculis vel non diam.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Etiam maximus neque in arcu ultricies vestibulum.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Suspendisse quis elit nec ipsum mollis laoreet.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Maecenas lobortis neque quis massa lobortis volutpat.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Praesent a arcu ac eros consequat auctor id sed quam.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Mauris nec dolor sit amet mauris elementum iaculis vel sed justo.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Fusce sed risus sit amet ante semper aliquam vel non felis.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Mauris blandit augue ut nisl sagittis, id consequat lectus ultricies.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Vivamus vel dui feugiat, tempor nulla vitae, placerat eros.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Phasellus laoreet sem a lectus condimentum eleifend.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Quisque lacinia turpis ac metus bibendum, ac volutpat nulla iaculis.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Ut eleifend sapien at massa tristique, at consectetur ligula luctus.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId())),
('Suspendisse cursus nibh non ex scelerisque mollis.',(SELECT TOP 1 Id FROM WebTestTableCategories ORDER BY NewId()))
GO

SELECT * FROM [dbo].[WebTestTable]



IF EXISTS (SELECT * FROM sys.procedures WHERE object_id=OBJECT_ID('[dbo].[TestProcedureThatDoNothing]'))
BEGIN
	DROP PROCEDURE [dbo].[TestProcedureThatDoNothing]
END
GO

CREATE PROCEDURE [dbo].[TestProcedureThatDoNothing]
AS
BEGIN
	-- NOTHING HAPPEND HERE!
	select 42
END
