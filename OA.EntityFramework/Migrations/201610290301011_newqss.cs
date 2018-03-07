namespace OA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newqss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Q_PermissionButton", "Q_Permission_pid", c => c.Int());
            CreateIndex("dbo.Q_PermissionButton", "Q_Permission_pid");
            AddForeignKey("dbo.Q_PermissionButton", "Q_Permission_pid", "dbo.Q_Permission", "pid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Q_PermissionButton", "Q_Permission_pid", "dbo.Q_Permission");
            DropIndex("dbo.Q_PermissionButton", new[] { "Q_Permission_pid" });
            DropColumn("dbo.Q_PermissionButton", "Q_Permission_pid");
        }
    }
}
