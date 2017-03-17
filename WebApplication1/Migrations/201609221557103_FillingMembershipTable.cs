namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillingMembershipTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.MembershipTypes (Name, DiscountRate, DurationInMonth, Price) VALUES ('free', 0, 0, 0)");
            Sql("INSERT INTO dbo.MembershipTypes (Name, DiscountRate, DurationInMonth, Price) VALUES ('bronze', 1, 5, 100)");
            Sql("INSERT INTO dbo.MembershipTypes (Name, DiscountRate, DurationInMonth, Price) VALUES ('silver', 3, 10, 250)");
            Sql("INSERT INTO dbo.MembershipTypes (Name, DiscountRate, DurationInMonth, Price) VALUES ('gold', 6, 15, 500)");
        }
        
        public override void Down()
        {
        }
    }
}
