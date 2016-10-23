namespace MunicipalTrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Phone], [StreetName], [City], [State], [Zip], [Day_Id]) VALUES (N'a309803f-9e98-4273-a09c-750aef947790', N'Admin@TrashPickUp.com', 0, N'AFIeJWoO/wjL6y4J8Q6jCOMnk5W3ypWu7HAEVdRJV88qxdfwCgQ246F983kpUcc7KQ==', N'34626a05-b75e-4823-99fe-24ee4647f362', NULL, 0, 0, NULL, 1, 0, N'Admin@TrashPickUp.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9bec79c6-f3c0-4c2b-aaa8-84c7b50c392e', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a309803f-9e98-4273-a09c-750aef947790', N'9bec79c6-f3c0-4c2b-aaa8-84c7b50c392e')
");
        }
        
        public override void Down()
        {
        }
    }
}
