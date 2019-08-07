namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingAllRoles : DbMigration
    {
        public override void Up()
        {
//            Sql(@"
//-- Users 
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'647284f8-348f-481b-b9ff-30b90958fa9b', N'consecutives@bitacoras.com', 0, N'ALXShaBQ6VdxamUAOzWqe9Wg6DG+UW04GednD0PNtwA39Bza9EFBPflWetY7GbppJw==', N'b820165d-51b2-42c4-9c93-85cd9d2611c2', NULL, 0, 0, NULL, 1, 0, N'consecutives@bitacoras.com')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8ba66bed-9570-4720-a50f-6c0886a372be', N'consulting@bitacoras.com', 0, N'AIUElMz5d/Jufj1kZURoL2TAJLlplzzBgUXPkSedD2TGqs4BVoJ2ZHLa7Sn+Xvq0+Q==', N'b2765384-04de-4926-aa4b-2cf7d921e381', NULL, 0, 0, NULL, 1, 0, N'consulting@bitacoras.com')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8ee5e9fe-d404-4c5e-91f2-f36f96b12440', N'security@bitacoras.com', 0, N'ABJjWmIQs64mNfu1fwmirnVyOg7EMkTT5cOFvP/y/ErNMgG6p+XptE1c9fYgx0hMbw==', N'fc2edc5d-b39a-42af-ab57-3cfde3fec416', NULL, 0, 0, NULL, 1, 0, N'security@bitacoras.com')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b90725c9-f672-44d1-b71c-20ded137c6ee', N'josuecjmm@gmail.com', 0, N'AB15glIsZ6/VaGl7yhprL2BxUyrzqIlZOPGE31fQaoTLH13EDohseXNq/v8XAEDFPw==', N'9467e3e5-064b-4302-94e3-42461d57f353', NULL, 0, 0, NULL, 1, 0, N'josuecjmm@gmail.com')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c41d3880-b50d-4c41-99f5-5286f26e6396', N'maintenance@bitacoras.com', 0, N'AGGfbLpMDLZY1+PMpDDMI03nxG2D84oWpOQYdgTfZQifNJUHcH9SBrRqLhXTwJkttQ==', N'd624883f-1772-4aba-b08c-7c89bd3fad46', NULL, 0, 0, NULL, 1, 0, N'maintenance@bitacoras.com')
//INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f00757a6-09e5-4946-a53a-354180f39959', N'admin@bitacoras.com', 0, N'AGjbv53vuobMS36Se+QDwjfBW2QewCr4qhBeJsFd0GLpFQMmo9lM3l0izl/uJp/9DQ==', N'cc8f7610-036c-47a9-ac6d-23a49fd44f19', NULL, 0, 0, NULL, 1, 0, N'admin@bitacoras.com')

//-- Roles 
//INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1e9e4756-775f-4cf2-8fef-d5a85e6cfd2e', N'CanManageAdministration')
//INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'42a240b4-15f9-46bd-9d46-ffdb03c0077f', N'CanManageConsecutives')
//INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c5bf407e-7323-46fa-8682-edf08c14aae3', N'CanManageConsulting')
//INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'398798c8-dbbe-4836-9c2b-9c775f4f330a', N'CanManageMantenimiento')
//INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a5b15086-48b3-49c5-b19b-35fe891e2d15', N'CanManageSecurity')



//-- UserRoles 
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f00757a6-09e5-4946-a53a-354180f39959', N'1e9e4756-775f-4cf2-8fef-d5a85e6cfd2e')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c41d3880-b50d-4c41-99f5-5286f26e6396', N'398798c8-dbbe-4836-9c2b-9c775f4f330a')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ee5e9fe-d404-4c5e-91f2-f36f96b12440', N'a5b15086-48b3-49c5-b19b-35fe891e2d15')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ba66bed-9570-4720-a50f-6c0886a372be', N'c5bf407e-7323-46fa-8682-edf08c14aae3')
//INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'647284f8-348f-481b-b9ff-30b90958fa9b', N'42a240b4-15f9-46bd-9d46-ffdb03c0077f')
//");
        }
        
        public override void Down()
        {
        }
    }
}
