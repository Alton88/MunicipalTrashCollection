namespace MunicipalTrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Phone], [StreetName], [City], [State], [Zip], [Day_Id]) VALUES (N'05a9f1d4-13aa-40aa-8bd7-5f884dc0f23c', N'TrashCollector@TrashPickUp.com', 0, N'AEfOz77g859M+1EQaWG7Rg/6tJQ1OllzuAVtDIO7PHuVMvGKEijigLy9DgmLVOzenw==', N'8aa7ff5c-5da2-4c97-9a61-c29169b9a983', NULL, 0, 0, NULL, 1, 0, N'TrashCollector@TrashPickUp.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Phone], [StreetName], [City], [State], [Zip], [Day_Id]) VALUES (N'1d1bfa06-1c31-4032-8f2f-86fca5828008', N'Guest@TrashPickUp.com', 0, N'AGJm1AR4DrezGIa8ZrojzzheYulnLXjJPljB3RVj6AvohEVLfJCJUonCZTay4tqpiA==', N'e9e245af-00d0-488d-b435-280213b5a475', NULL, 0, 0, NULL, 1, 0, N'Guest@TrashPickUp.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cd3ec04f-1642-4970-b9c3-9ce9d1db69db', N'TrashCollector')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'05a9f1d4-13aa-40aa-8bd7-5f884dc0f23c', N'cd3ec04f-1642-4970-b9c3-9ce9d1db69db')

");
        }
        
        public override void Down()
        {
        }
    }
}
