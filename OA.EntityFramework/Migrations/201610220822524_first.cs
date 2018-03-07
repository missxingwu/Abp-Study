namespace OA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Q_Department",
                c => new
                    {
                        depId = c.Int(nullable: false, identity: true),
                        depPid = c.Int(),
                        depName = c.String(),
                        depRemark = c.String(),
                        depIsDel = c.Boolean(),
                        depAddTime = c.DateTime(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.depId);
            
            CreateTable(
                "dbo.Q_Role",
                c => new
                    {
                        rId = c.Int(nullable: false, identity: true),
                        rDepId = c.Int(),
                        rName = c.String(),
                        rRemark = c.String(),
                        rIsShow = c.Boolean(),
                        rIsDel = c.Boolean(),
                        rAddTime = c.DateTime(),
                        Id = c.Int(nullable: false),
                        Q_Department_depId = c.Int(),
                    })
                .PrimaryKey(t => t.rId)
                .ForeignKey("dbo.Q_Department", t => t.Q_Department_depId)
                .Index(t => t.Q_Department_depId);
            
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
                .PrimaryKey(t => t.rpId)
                .ForeignKey("dbo.Q_Permission", t => t.Q_Permission_pid)
                .ForeignKey("dbo.Q_Role", t => t.Q_Role_rId)
                .Index(t => t.Q_Permission_pid)
                .Index(t => t.Q_Role_rId);
            
            CreateTable(
                "dbo.Q_Permission",
                c => new
                    {
                        pid = c.Int(nullable: false, identity: true),
                        pParent = c.Int(),
                        pName = c.String(),
                        pAreaName = c.String(),
                        pControllerName = c.String(),
                        pActionName = c.String(),
                        pFormMethod = c.Short(nullable: false),
                        pOperationType = c.Short(nullable: false),
                        pIco = c.String(),
                        pOrder = c.Int(),
                        pIsLink = c.Boolean(),
                        pLinkUrl = c.String(),
                        pIsShow = c.Boolean(),
                        pRemark = c.String(),
                        pIsDel = c.Boolean(),
                        pAddTime = c.DateTime(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pid);
            
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
                .PrimaryKey(t => t.vipId)
                .ForeignKey("dbo.Q_Permission", t => t.Q_Permission_pid)
                .ForeignKey("dbo.Q_UserInfo", t => t.Q_UserInfo_uId)
                .Index(t => t.Q_Permission_pid)
                .Index(t => t.Q_UserInfo_uId);
            
            CreateTable(
                "dbo.Q_UserInfo",
                c => new
                    {
                        uId = c.Int(nullable: false, identity: true),
                        uDepId = c.Int(),
                        uLoginName = c.String(),
                        uName = c.String(),
                        uEmail = c.String(),
                        uPwd = c.String(),
                        uGender = c.Boolean(),
                        uPost = c.String(),
                        uRemark = c.String(),
                        uAddress = c.String(),
                        uIsDel = c.Boolean(),
                        uAddTime = c.DateTime(),
                        Id = c.Int(nullable: false),
                        Q_Department_depId = c.Int(),
                    })
                .PrimaryKey(t => t.uId)
                .ForeignKey("dbo.Q_Department", t => t.Q_Department_depId)
                .Index(t => t.Q_Department_depId);
            
            CreateTable(
                "dbo.Q_UserRole",
                c => new
                    {
                        urId = c.Int(nullable: false, identity: true),
                        urUId = c.Int(),
                        urRId = c.Int(),
                        urIsDel = c.Boolean(),
                        urAddtime = c.DateTime(),
                        Id = c.Int(nullable: false),
                        Q_Role_rId = c.Int(),
                        Q_UserInfo_uId = c.Int(),
                    })
                .PrimaryKey(t => t.urId)
                .ForeignKey("dbo.Q_Role", t => t.Q_Role_rId)
                .ForeignKey("dbo.Q_UserInfo", t => t.Q_UserInfo_uId)
                .Index(t => t.Q_Role_rId)
                .Index(t => t.Q_UserInfo_uId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Q_RolePermission", "Q_Role_rId", "dbo.Q_Role");
            DropForeignKey("dbo.Q_UserVipPermission", "Q_UserInfo_uId", "dbo.Q_UserInfo");
            DropForeignKey("dbo.Q_UserRole", "Q_UserInfo_uId", "dbo.Q_UserInfo");
            DropForeignKey("dbo.Q_UserRole", "Q_Role_rId", "dbo.Q_Role");
            DropForeignKey("dbo.Q_UserInfo", "Q_Department_depId", "dbo.Q_Department");
            DropForeignKey("dbo.Q_UserVipPermission", "Q_Permission_pid", "dbo.Q_Permission");
            DropForeignKey("dbo.Q_RolePermission", "Q_Permission_pid", "dbo.Q_Permission");
            DropForeignKey("dbo.Q_Role", "Q_Department_depId", "dbo.Q_Department");
            DropIndex("dbo.Q_UserRole", new[] { "Q_UserInfo_uId" });
            DropIndex("dbo.Q_UserRole", new[] { "Q_Role_rId" });
            DropIndex("dbo.Q_UserInfo", new[] { "Q_Department_depId" });
            DropIndex("dbo.Q_UserVipPermission", new[] { "Q_UserInfo_uId" });
            DropIndex("dbo.Q_UserVipPermission", new[] { "Q_Permission_pid" });
            DropIndex("dbo.Q_RolePermission", new[] { "Q_Role_rId" });
            DropIndex("dbo.Q_RolePermission", new[] { "Q_Permission_pid" });
            DropIndex("dbo.Q_Role", new[] { "Q_Department_depId" });
            DropTable("dbo.Q_UserRole");
            DropTable("dbo.Q_UserInfo");
            DropTable("dbo.Q_UserVipPermission");
            DropTable("dbo.Q_Permission");
            DropTable("dbo.Q_RolePermission");
            DropTable("dbo.Q_Role");
            DropTable("dbo.Q_Department");
        }
    }
}
