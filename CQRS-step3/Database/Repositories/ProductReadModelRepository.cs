using System.Data.SqlClient;
using CQRS_step3.Domain.Store;
using CQRS_step3.Domain.Store.Models;
using Dapper;

namespace CQRS_step3.Database.Repositories
{
public class ProductReadModelRepository : IProductReadModelRepository
{
    private readonly SqlConnection _sqlConnection;

    public ProductReadModelRepository(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public ProductReadModel Find(int productId)
    {
        return _sqlConnection.QuerySingle<ProductReadModel>("SELECT * FROM ProductReadModels WHERE Id = @Id", new { Id = productId });
    }

    public void Insert(ProductReadModel product)
    {
        _sqlConnection.Execute(
            @"INSERT INTO ProductReadModels (Id, Name, CategoryId, OrderAmount, Review, FieldValues) 
            VALUES(@Id, @Name, @CategoryId, @OrderAmount @Review, @FieldValues)",
            product);
    }

    public void Update(ProductReadModel product)
    {
        _sqlConnection.Execute(
            @"UPDATE ProductReadModels (Name, CategoryId, OrderAmount, Review, FieldValues) 
            VALUES(@Name, @CategoryId, @OrderAmount @Review, @FieldValues)
            WHERE Id = @Id",
            product);
    }
}
}