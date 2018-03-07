namespace OA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quanxian : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Q_RolePermission", "rpIndex", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpCreate", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpEdit", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpDelete", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpSetButton", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpSetPermission", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpChangePwd", c => c.Boolean());
            AddColumn("dbo.Q_RolePermission", "rpDeleteAll", c => c.Boolean());
            AddColumn("dbo.Q_UserVipPermission", "vipIndex", c => c.Boolean(nullable: true));
            AddColumn("dbo.Q_UserVipPermission", "vipCreate", c => c.Boolean(nullable: true));
            AddColumn("dbo.Q_UserVipPermission", "vipEdit", c => c.Boolean(nullable: true));
            AddColumn("dbo.Q_UserVipPermission", "vipDelete", c => c.Boolean(nullable: true));
            AddColumn("dbo.Q_UserVipPermission", "vipSetButton", c => c.Boolean(nullable: true));
            AddColumn("dbo.Q_UserVipPermission", "vipSetPermission", c => c.Boolean(nullable: true));
            AddColumn("dbo.Q_UserVipPermission", "vipChangePwd", c => c.Boolean(nullable: true));
            AddColumn("dbo.Q_UserVipPermission", "vipDeleteAll", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Q_UserVipPermission", "vipDeleteAll");
            DropColumn("dbo.Q_UserVipPermission", "vipChangePwd");
            DropColumn("dbo.Q_UserVipPermission", "vipSetPermission");
            DropColumn("dbo.Q_UserVipPermission", "vipSetButton");
            DropColumn("dbo.Q_UserVipPermission", "vipDelete");
            DropColumn("dbo.Q_UserVipPermission", "vipEdit");
            DropColumn("dbo.Q_UserVipPermission", "vipCreate");
            DropColumn("dbo.Q_UserVipPermission", "vipIndex");
            DropColumn("dbo.Q_RolePermission", "rpDeleteAll");
            DropColumn("dbo.Q_RolePermission", "rpChangePwd");
            DropColumn("dbo.Q_RolePermission", "rpSetPermission");
            DropColumn("dbo.Q_RolePermission", "rpSetButton");
            DropColumn("dbo.Q_RolePermission", "rpDelete");
            DropColumn("dbo.Q_RolePermission", "rpEdit");
            DropColumn("dbo.Q_RolePermission", "rpCreate");
            DropColumn("dbo.Q_RolePermission", "rpIndex");
        }
    }
}
