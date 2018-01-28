namespace CQRS_step3.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductReadModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.ProductReadModels",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        OrderAmount = c.Int(nullable: false),
                        Review = c.String(nullable: false),
                        FieldValues = c.String(nullable: false),
                    })
                .Index(t => t.CategoryId)
                .Index(t => t.OrderAmount)
                .PrimaryKey(t => t.Id);

            // JSON indexes - review average and sum
            Sql(@"ALTER TABLE dbo.ProductReadModels
                    ADD vReviewAverage AS JSON_VALUE(Review, '$.Review.Average')
                  CREATE INDEX Idx_ProductReadModels_ReviewAverage
                    ON dbo.ProductReadModels(vReviewAverage)");

            Sql(@"ALTER TABLE dbo.ProductReadModels
                    ADD vReviewSum AS JSON_VALUE(Review, '$.Review.Sum')
                  CREATE INDEX Idx_ProductReadModels_ReviewSum
                    ON dbo.ProductReadModels(vReviewSum)");

            // data migration
            SqlFile("Database/MigrationFiles/ProductReadModel-Creation.sql");
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductReadModels");
        }
    }
}
