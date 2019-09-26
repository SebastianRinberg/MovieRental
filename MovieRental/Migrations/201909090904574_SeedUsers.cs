namespace MovieRental.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d51f72d-a53a-4be5-bae1-75d0824c4c6f', N'admin@movierental.com', 0, N'AGFmu6jn7DJVmgzys/Ju1/dNmSPq27aYYDreDOPiJezlvOrubYSolYsgPTPmHQO4DQ==', N'1ddb0937-1df5-4cfb-97e1-45a2f9913c2a', NULL, 0, 0, NULL, 1, 0, N'admin@movierental.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d2848e6-2a89-48ed-b4c6-ed8aeeb02fd9', N'guest@movierentral.com', 0, N'ANJ0mAVxT6U9Zq2S2PEVc1ekl8smjSZZrjBRsBmICqoZgz8SuXHFN1Er0lIE2jbwTA==', N'dd0b7f35-cb7d-4679-8ecd-714d878bd16e', NULL, 0, 0, NULL, 1, 0, N'guest@movierentral.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ed20ed92-fbeb-453b-bf33-0ab751bb584b', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0d51f72d-a53a-4be5-bae1-75d0824c4c6f', N'ed20ed92-fbeb-453b-bf33-0ab751bb584b')
    ");
        }

        public override void Down()
        {
        }
    }
}
