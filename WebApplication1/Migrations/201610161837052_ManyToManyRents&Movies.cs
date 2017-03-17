namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyRentsMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        dateOfDeal = c.DateTime(nullable: false),
                        dateOfReturn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.RentMovies",
                c => new
                    {
                        Rent_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rent_Id, t.Movie_Id })
                .ForeignKey("dbo.Rents", t => t.Rent_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Rent_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.RentMovies", "Rent_Id", "dbo.Rents");
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropIndex("dbo.RentMovies", new[] { "Movie_Id" });
            DropIndex("dbo.RentMovies", new[] { "Rent_Id" });
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            DropTable("dbo.RentMovies");
            DropTable("dbo.Rents");
        }
    }
}
