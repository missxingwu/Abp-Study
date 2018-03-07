namespace OA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newqs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Q_PermissionButton", "pbIndex", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbCreate", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbEdit", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbDelete", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbSetButton", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbSetPermission", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbChangePwd", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbDeleteAll", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "pbAddTime", c => c.DateTime());
            DropColumn("dbo.Q_PermissionButton", "rpIndex");
            DropColumn("dbo.Q_PermissionButton", "rpCreate");
            DropColumn("dbo.Q_PermissionButton", "rpEdit");
            DropColumn("dbo.Q_PermissionButton", "rpDelete");
            DropColumn("dbo.Q_PermissionButton", "rpSetButton");
            DropColumn("dbo.Q_PermissionButton", "rpSetPermission");
            DropColumn("dbo.Q_PermissionButton", "rpChangePwd");
            DropColumn("dbo.Q_PermissionButton", "rpDeleteAll");
            DropColumn("dbo.Q_PermissionButton", "rpAddTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Q_PermissionButton", "rpAddTime", c => c.DateTime());
            AddColumn("dbo.Q_PermissionButton", "rpDeleteAll", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "rpChangePwd", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "rpSetPermission", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "rpSetButton", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "rpDelete", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "rpEdit", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "rpCreate", c => c.Boolean());
            AddColumn("dbo.Q_PermissionButton", "rpIndex", c => c.Boolean());
            DropColumn("dbo.Q_PermissionButton", "pbAddTime");
            DropColumn("dbo.Q_PermissionButton", "pbDeleteAll");
            DropColumn("dbo.Q_PermissionButton", "pbChangePwd");
            DropColumn("dbo.Q_PermissionButton", "pbSetPermission");
            DropColumn("dbo.Q_PermissionButton", "pbSetButton");
            DropColumn("dbo.Q_PermissionButton", "pbDelete");
            DropColumn("dbo.Q_PermissionButton", "pbEdit");
            DropColumn("dbo.Q_PermissionButton", "pbCreate");
            DropColumn("dbo.Q_PermissionButton", "pbIndex");
        }
    }
}
