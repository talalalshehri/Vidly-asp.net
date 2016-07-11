namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'17366fc6-d354-43fb-9333-42a968a95233', N'admin@vidly.com', 0, N'AN4o8yfx5Xel+g44HP/uT5/eehsSR69pGlCJZeX+31BXHK2R7bNbNVF/b1kZZllvaA==', N'a261d240-bd82-479e-be84-216796cd05f8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'47920291-c0ca-466c-af40-18be87e78fba', N'guest@vidly.com', 0, N'AB88vknO7RQIlLUjtGGyAaO4K//mPYVovJB7YZi12dCdtAMFyB0O9GdlWSEK+9YLuw==', N'b27226a4-b502-46b0-b9e1-6024e91b6738', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'11f8a7c7-8d06-4837-a4fd-546e4e8e3929', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'17366fc6-d354-43fb-9333-42a968a95233', N'11f8a7c7-8d06-4837-a4fd-546e4e8e3929')
");

        }

        
        public override void Down()
        {
        }
    }
}
