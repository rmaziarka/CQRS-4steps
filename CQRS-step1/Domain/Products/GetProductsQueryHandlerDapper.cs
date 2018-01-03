using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using CQRS_step1.Models;
using MediatR;

namespace CQRS_step1.Domain.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly SqlConnection _connection;

        public GetProductsQueryHandler(SqlConnection connection)
        {
            _connection = connection;
        }

        IEnumerable<ProductVm> IRequestHandler<GetProductsQuery, IEnumerable<ProductVm>>.Handle(GetProductsQuery command)
        {
            List<ProductVm> products;
            using (var multi = _connection.QueryMultiple(_query))
            {
                products = multi.Read<ProductVm>().ToList();
                // to be continued
            }

            return products;
        }

        private string _query = @"
	        CREATE TABLE #Products
	        (
	            Id int, 
	            Name NVarchar(128),
		        Price decimal,
		        CategoryName NVarchar(128),
		        MainPictureUrl NVarchar(max),
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
		        PP.Url AS MainPictureUrl, 
		        M.Name AS ManufacturerName
		        MP.Url AS ManufacturerMainPictureUrl,
		        (SELECT TOP 1 COUNT(*) FROM OrderItem AS OI WHERE P.Id = OI.ProductId GROUP BY OI.ProductId) AS OrdersNumber 
		        (SELECT TOP 1 AVG(R.Rating) FROM Review AS R WHERE P.Id = R.ProductId GROUP BY R.ProductId) AS AverageReviewRating 
	        FROM Product AS P
	        INNER JOIN Category C ON P.CategoryId = C.Id
	        LEFT JOIN ProductPicture PP ON PP.ProductId = P.Id AND PP.Main = 1
	        INNER JOIN Manufacturer M ON P.ManufacturerId = M.Id
	        LEFT JOIN ManufacturerPicture MP ON M.PictureId = MP.Id AND MP.Main = 1
	        WHERE P.CategoryId = @CategoryId
            ORDER BY P.Id
            OFFSET @Take * (@Take - 1) ROWS
            FETCH NEXT @Page ROWS ONLY;
	
	        -- Query all found products
	        SELECT * FROM #Products
	
	        - Query all related related
	        SELECT RP.BaseId AS MainProductId, P.Id, P.Name, PP.Url AS MainPictureUrl
	        FROM RelatedProduct RP
	        LEFT JOIN Product PP ON RP.RelatedId = P.Id
	        LEFT JOIN ProductPicture PP ON PP.ProductId = P.Id AND PP.Main = 1
	        WHERE RP.BaseId IN (SELECT Id FROM #Products)
	
	        -- Query all field values
	        SELECT 
		        FV.ProductId AS MainProductId,
		        F.Name AS Name,
		        (CASE 
			        WHEN FV.Type = 'INT' THEN FV.IntegerValue
			        ELSE FV.StringValue
		        END) AS Value
	        FROM FieldValue FV
	        INNER JOIN Field F ON FV.FieldId = F.Id
	        WHERE FV.ProductId IN (SELECT Id FROM #Products)
	";
    }
}