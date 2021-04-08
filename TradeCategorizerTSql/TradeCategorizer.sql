
CREATE DATABASE TradeCategorizer
GO

USE TradeCategorizer
GO

/* Creating Tables */

CREATE TABLE Category(
	id int IDENTITY(1,1) NOT NULL,
	categoryName varchar(20) NOT NULL,
	minValue float NULL,
	maxValue float NULL,
	clientSector varchar(20) NOT NULL,
	PRIMARY KEY (id)
)
GO

CREATE TABLE Portfolio(
	id int IDENTITY(1,1) NOT NULL,
	value float NOT NULL,
	clientSector varchar(20) NOT NULL,
	PRIMARY KEY (id)
) 
GO

CREATE TABLE CategorizedPortfolio(
	id INT IDENTITY(1,1) NOT NULL,
	portId INT NOT NULL,
	categoryName VARCHAR(20) NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (portId) REFERENCES Portfolio (id)
)
GO

/* Inserting Categories */

INSERT INTO Category (
	categoryName,
	minValue,
	maxValue,
	clientSector
) 
VALUES
(
	'LOWRISK',
	NULL,
	1000000,
	'Public'
),
(
	'MEDIUMRISK',
	1000000,
	NULL,
	'Public'
),
(
	'HIGHRISK',
	1000000,
	NULL,
	'Private'
)
GO

/* Inserting Sample Trades */

INSERT INTO Portfolio (
	value,
	clientSector
)
VALUES 
(
	2000000,
	'Private'
),
(
	400000,
	'Public'
),
(
	500000,
	'Public'
),
(
	3000000,
	'Public'
)
GO


/* Creating view to select categorized trades */

CREATE VIEW vwTradeCategories AS
SELECT p.id [TradeId], c.categoryName [Category]
FROM Portfolio p
OUTER APPLY (
	SELECT TOP 1 c.categoryName
	FROM Category c
	WHERE c.clientSector = p.clientSector
		AND (
			(c.minValue IS NOT NULL AND p.value >= c.minValue) 
			OR 
			(c.maxValue IS NOT NULL AND p.value < c.maxValue)
		) 
) c
GO

CREATE PROCEDURE CategorizeTrades
AS 
	INSERT INTO CategorizedPortfolio ( 
		portId, 
		categoryName
	)
	SELECT TradeId, Category FROM vwTradeCategories
	WHERE tradeId NOT IN (
		SELECT portId FROM CategorizedPortfolio
	)
GO
	


/* Categorizing sample portfolio */ 


EXEC CategorizeTrades
GO 

SELECT * FROM CategorizedPortfolio;


