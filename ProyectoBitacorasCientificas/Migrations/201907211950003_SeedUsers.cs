namespace ProyectoBitacorasCientificas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

-- Users 
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [nombre], [primerApellido], [segundoApellido], [telefono], [nickName]) VALUES (N'b90725c9-f672-44d1-b71c-20ded137c6ee', N'josuecjmm@gmail.com', 0, N'AB15glIsZ6/VaGl7yhprL2BxUyrzqIlZOPGE31fQaoTLH13EDohseXNq/v8XAEDFPw==', N'9467e3e5-064b-4302-94e3-42461d57f353', NULL, 0, 0, NULL, 1, 0, N'josuecjmm@gmail.com', NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [nombre], [primerApellido], [segundoApellido], [telefono], [nickName]) VALUES (N'f00757a6-09e5-4946-a53a-354180f39959', N'admin@bitacoras.com', 0, N'AGjbv53vuobMS36Se+QDwjfBW2QewCr4qhBeJsFd0GLpFQMmo9lM3l0izl/uJp/9DQ==', N'cc8f7610-036c-47a9-ac6d-23a49fd44f19', NULL, 0, 0, NULL, 1, 0, N'admin@bitacoras.com', NULL, NULL, NULL, NULL, NULL)

-- Roles 
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1e9e4756-775f-4cf2-8fef-d5a85e6cfd2e', N'CanManageAdministration')

-- UserRoles 
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f00757a6-09e5-4946-a53a-354180f39959', N'1e9e4756-775f-4cf2-8fef-d5a85e6cfd2e')

");
        }
        
        public override void Down()
        {
        }
    }
}
