namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2423c477-369a-4c08-9c61-5431664dd091', N'vasya@mail.ru', 0, N'AB5DfH/xO/RWg7THUSZvMsv56y07pswjS04ZDNCnHyb9yqJpyubbSCvTHL3JSPqDDw==', N'a14ee992-b841-4bed-af5b-699a9f0a95e4', NULL, 0, 0, NULL, 1, 0, N'vasya@mail.ru')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fc95e6a3-50fb-471a-9bad-f84733859baa', N'admin@admin.com', 0, N'AHtsYmWnfmUzSmI8PK8eM3ye8KlXFhwIyFbE+id+5Nlma4AyAlPq6uzFLJxfc8TmCg==', N'd5755467-ba5f-4ff3-906d-ad847b3ede63', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bfdd3c2e-9bfb-4774-8054-f3869ca4780c', N'God')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fc95e6a3-50fb-471a-9bad-f84733859baa', N'bfdd3c2e-9bfb-4774-8054-f3869ca4780c')");
        }
        
        public override void Down()
        {
        }
    }
}
