namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b5520cad-3a48-4e2f-9e3f-bd08e4abd2d7', N'admin01@abc.com', 0, N'AAnMxtLqfdo46c5jL/wwwnoUx2muhKm+9cFnJ2jHJl9+WqrVZqCVlH1HheL8Ji4oxg==', N'd2ae9c24-6ff8-4ed0-a9d8-c88a268c730d', NULL, 0, 0, NULL, 1, 0, N'admin01@abc.com')");

            Sql("INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'cb7d1903-75b2-4a8a-840f-fd1f7c07e32e', N'guest@abc.com', 0, N'AIdKq1P0Ed+14rjFEWKR9D32B/grH82WTF3pDkO0p7a8upftEw76KREdI5HxviTBpw==', N'ba644a81-b01d-45e2-89ce-d06632d59140', NULL, 0, 0, NULL, 1, 0, N'guest@abc.com')");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e8df4746-b8d4-4bd8-af60-fa58f569cc5b', N'CanManageMovies')");

            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b5520cad-3a48-4e2f-9e3f-bd08e4abd2d7', N'e8df4746-b8d4-4bd8-af60-fa58f569cc5b')");
        }
        
        public override void Down()
        {
        }
    }
}
