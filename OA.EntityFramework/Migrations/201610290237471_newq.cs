namespace OA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Q_PermissionButton",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UorRId = c.Int(),
                        pbPId = c.Int(),
                        pbUorRStatr = c.Int(),
                        rpIndex = c.Boolean(),
                        rpCreate = c.Boolean(),
                        rpEdit = c.Boolean(),
                        rpDelete = c.Boolean(),
                        rpSetButton = c.Boolean(),
                        rpSetPermission = c.Boolean(),
                        rpChangePwd = c.Boolean(),
                        rpDeleteAll = c.Boolean(),
                        rpAddTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Q_RolePermission", "rpIndex");
            DropColumn("dbo.Q_RolePermission", "rpCreate");
            DropColumn("dbo.Q_RolePermission", "rpEdit");
            DropColumn("dbo.Q_RolePermission", "rpDelete");
            DropColumn("dbo.Q_RolePermission", "rpSetButton");
            DropColumn("dbo.Q_RolePermission", "rpSetPermission");
            DropColumn("dbo.Q_RolePermission", "rpChangePwd");
            DropColumn("dbo.Q_RolePermission", "rpDeleteAll");
            DropColumn("dbo.Q_UserVipPermission", "vipIndex");
            DropColumn("dbo.Q_UserVipPermission", "vipCreate");
            DropColumn("dbo.Q_UserVipPermission", "vipEdit");
            DropColumn("dbo.Q_UserVipPermission", "vipDelete");
            DropColumn("dbo.Q_UserVipPermission", "vipSetButton");
            DropColumn("dbo.Q_UserVipPermission", "vipSetPermission");
            DropColumn("dbo.Q_UserVipPermission", "vipChangePwd");
            DropColumn("dbo.Q_UserVipPermission", "vipDeleteAll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Q_UserVipPermission", "vipDeleteAll", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_UserVipPermission", "vipChangePwd", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_UserVipPermission", "vipSetPermission", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_UserVipPermission", "vipSetButton", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_UserVipPermission", "vipDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_UserVipPermission", "vipEdit", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_UserVipPermission", "vipCreate", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_UserVipPermission", "vipIndex", c => c.Boolean(nullable: false));
            AddColumn("dbo.Q_RolePermission", "rpDeleteAll", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpChangePwd", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpSetPermission", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpSetButton", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpDelete", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpEdit", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpCreate", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpIndex", c => c.Boolean());
            DropTable("dbo.Q_PermissionButton");
        }
    }
}
