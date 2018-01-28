INSERT INTO dbo.ProductReadModels 
SELECT 
   P.[Id], 
   P.[Name], 
   P.[CategoryId], 
   ( 
      SELECT 
         COUNT(O.Id) 
      FROM 
         Orders AS O 
      WHERE 
         O.ProductId = P.Id 
   ) AS [OrderAmount], 
   ( 
      SELECT 
         COUNT(R.Id) AS [Count], 
         SUM(R.Rating) AS [Sum], 
         AVG(R.Rating) AS [Average] 
      FROM Reviews AS R 
      WHERE R.ProductId = P.Id 
      FOR JSON PATH, WITHOUT_ARRAY_WRAPPER 
   ) AS [Review], 
   ( 
      SELECT '{' + STRING_AGG([FieldValue], ',') + '}' 
      FROM ( 
         SELECT 
            '"' + CONVERT(VARCHAR, Id) + '":' + 
            CASE 
               WHEN 
                  F.Type = 'Integer' 
               THEN 
                  CONVERT(VARCHAR, FV.IntegerValue) 
               ELSE 
                  '"' + FV.StringValue + '"' 
               END 
               AS [FieldValue] 
         FROM FieldValues AS FV 
         JOIN Fields ON F.Id = FV.FieldId 
         WHERE QC.QualityCheckId = Q.Id 
      ) AS FieldValueStrings 
   ) AS [FieldValues]
FROM Products