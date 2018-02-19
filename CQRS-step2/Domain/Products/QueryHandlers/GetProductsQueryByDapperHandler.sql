CREATE TABLE #Products
(
	Id int, 
	Name NVarchar(128),
	Price decimal,
	CategoryName NVarchar(128),
	PictureUrl NVarchar(max),
	ManufacturerName NVarchar(128),
	ManufacturerMainPictureUrl NVarchar(max),
	OrdersNumber int,
	AverageReviewRating float
)

	
-- Products to temporal table
INSERT INTO #Products
SELECT  
	P.Id, P.Name, P.Price,
	C.Name AS CategoryName,
	PPP.Url AS MainPictureUrl,
	M.Name AS ManufacturerName,
	MP.Url AS ManufacturerMainPictureUrl,
	(SELECT TOP 1 COUNT(*) FROM OrderItems AS OI WHERE P.Id = OI.ProductId GROUP BY OI.ProductId) AS OrdersNumber,
	(SELECT TOP 1 AVG(R.Rating) FROM Reviews AS R WHERE P.Id = R.ProductId GROUP BY R.ProductId) AS AverageReviewRating 
FROM dbo.Products AS P
INNER JOIN Categories C ON P.CategoryId = C.Id
LEFT JOIN ProductPictures PP ON PP.ProductId = P.Id AND PP.IsMain = 1
LEFT JOIN Pictures PPP ON PPP.Id = PP.PictureId
INNER JOIN Manufacturers M ON P.ManufacturerId = M.Id
LEFT JOIN Pictures MP ON M.PictureId = MP.Id
WHERE @CategoryId IS NULL OR P.CategoryId = @CategoryId
	
ORDER BY P.Id 
OFFSET @Take * (@Page - 1) ROWS
FETCH NEXT @Take ROWS ONLY;
	

-- Query all found products
SELECT * FROM #Products
	

-- Query related products
SELECT 
	RP.MainProductId, RP.ProductId,
	P.Id, P.Name AS ProductName, 
	PPP.Url AS PictureUrl
FROM RelatedProducts RP
LEFT JOIN Products P ON RP.ProductId = P.Id
LEFT JOIN ProductPictures PP ON PP.ProductId = P.Id AND PP.IsMain = 1
LEFT JOIN Pictures PPP ON PP.PictureId = PPP.Id
WHERE RP.MainProductId IN (SELECT Id FROM #Products)
	

-- Query field values
SELECT 
	FV.ProductId, FV.StringValue, FV.IntegerValue,
	F.Name AS FieldName, F.Type AS FieldType
FROM FieldValues FV
INNER JOIN Fields F ON FV.FieldId = F.Id
WHERE FV.ProductId IN (SELECT Id FROM #Products)
	

-- Query latest reviews
SELECT TOP 4
	R.Rating, R.CreateDate, R.ProductId,
	U.Name AS UserName
FROM Reviews R
JOIN Users U ON R.UserId = U.Id
WHERE R.ProductId IN (SELECT Id FROM #Products)
ORDER BY R.CreateDate DESC
	

-- Query discounts
SELECT TOP 3
	D.Value, D.MainProductId, D.ProductId,
	P.Name AS ProductName
FROM Discounts D
JOIN Products P ON D.ProductId = P.Id
WHERE D.MainProductId IN (SELECT Id FROM #Products)
ORDER BY D.Value DESC
	
DROP TABLE #Products