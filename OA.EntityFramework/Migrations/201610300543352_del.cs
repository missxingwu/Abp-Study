namespace OA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class del : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Q_RolePermission", "Q_Permission_pid", "dbo.Q_Permission");
            DropForeignKey("dbo.Q_UserVipPermission", "Q_Permission_pid", "dbo.Q_Permission");
            DropForeignKey("dbo.Q_UserVipPermission", "Q_UserInfo_uId", "dbo.Q_UserInfo");
            DropForeignKey("dbo.Q_RolePermission", "Q_Role_rId", "dbo.Q_Role");
            DropIndex("dbo.Q_RolePermission", new[] { "Q_Permission_pid" });
            DropIndex("dbo.Q_RolePermission", new[] { "Q_Role_rId" });
            DropIndex("dbo.Q_UserVipPermission", new[] { "Q_Permission_pid" });
            DropIndex("dbo.Q_UserVipPermission", new[] { "Q_UserInfo_uId" });
            DropTable("dbo.Q_RolePermission");
            DropTable("dbo.Q_UserVipPermission");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Q_UserVipPermission",
                c => new
                    {
                        vipId = c.Int(nullable: false, identity: true),
                        vipUserId = c.Int(),
                        vipPermission = c.Int(),
                        vipRemark = c.String(),
                        vipIsDel = c.Boolean(),
                        vipAddTime = c.DateTime(),
                        Id = c.Int(nullable: false),
                        Q_Permission_pid = c.Int(),
                        Q_UserInfo_uId = c.Int(),
                    })
                .PrimaryKey(t => t.vipId);
            
            CreateTable(
                "dbo.Q_RolePermission",
                c => new
                    {
                        rpId = c.Int(nullable: false, identity: true),
                        rpRId = c.Int(),
                        rpPId = c.Int(),
                        rpIsDel = c.Boolean(),
                        rpAddTime = c.DateTime(),
                        Id = c.Int(nullable: false),
                        Q_Permission_pid = c.Int(),
                        Q_Role_rId = c.Int(),
                    })
                .PrimaryKey(t => t.rpId);
            
            CreateIndex("dbo.Q_UserVipPermission", "Q_UserInfo_uId");
            CreateIndex("dbo.Q_UserVipPermission", "Q_Permission_pid");
            CreateIndex("dbo.Q_RolePermission", "Q_Role_rId");
            CreateIndex("dbo.Q_RolePermission", "Q_Permission_pid");
            AddForeignKey("dbo.Q_RolePermission", "Q_Role_rId", "dbo.Q_Role", "rId");
            AddForeignKey("dbo.Q_UserVipPermission", "Q_UserInfo_uId", "dbo.Q_UserInfo", "uId");
            AddForeignKey("dbo.Q_UserVipPermission", "Q_Permission_pid", "dbo.Q_Permission", "pid");
            AddForeignKey("dbo.Q_RolePermission", "Q_Permission_pid", "dbo.Q_Permission", "pid");
        }
    }
}
