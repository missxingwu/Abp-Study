namespace OA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class worl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OT_ActivityParticipant",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        Participant = c.String(),
                        ParticipantType = c.Int(),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_ActivityTemplate",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        ActivityName = c.String(),
                        Description = c.String(),
                        IsEnd = c.Boolean(),
                        ActivityType = c.Int(),
                        IsCondition = c.Boolean(),
                        ParentIndex = c.Int(),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(),
                        GraphicalID = c.String(),
                        PreviousObjectID = c.String(),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_Agency",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        UserID = c.String(),
                        AgentID = c.String(),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        Originator = c.String(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        ParentIndex = c.Int(),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_Attachment",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        InstanceId = c.String(),
                        ActivityId = c.String(),
                        FileName = c.String(),
                        FileUrl = c.String(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        ParentIndex = c.Int(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_ClauseDataItem",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        ColumnName = c.String(),
                        DisplayName = c.String(),
                        ColumnLength = c.Int(),
                        LogicType = c.String(),
                        Description = c.String(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_DataPermission",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        ColumnName = c.String(),
                        Visible = c.Boolean(),
                        Editable = c.Boolean(),
                        Required = c.Boolean(),
                        ParentIndex = c.Int(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_InstanceContext",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentInstanceID = c.String(),
                        SequenceNo = c.String(),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        WorkflowVersion = c.Int(),
                        State = c.Boolean(),
                        NextTokenId = c.String(),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(),
                        FinishDate = c.DateTime(),
                        BusinessTable = c.String(),
                        Originator = c.String(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_Token",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        InstanceId = c.String(),
                        TokenId = c.String(),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        Originator = c.String(),
                        Activity = c.String(),
                        Approval = c.Int(),
                        Participant = c.String(),
                        CreateDate = c.DateTime(),
                        FinishedDate = c.DateTime(),
                        ItemComment = c.String(),
                        ColumnName = c.String(),
                        ParticipantType = c.Int(),
                        Id = c.Int(nullable: true),
                        OT_InstanceContext_ObjectID = c.Guid(),
                    })
                .PrimaryKey(t => t.ObjectID)
                .ForeignKey("dbo.OT_InstanceContext", t => t.OT_InstanceContext_ObjectID)
                .Index(t => t.OT_InstanceContext_ObjectID);
            
            CreateTable(
                "dbo.OT_WorkItem",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        InstanceId = c.String(),
                        TokenId = c.String(),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        WorkflowVersion = c.Int(),
                        Participant = c.String(),
                        State = c.Boolean(),
                        StartTime = c.DateTime(),
                        FinishTime = c.DateTime(),
                        Approval = c.Boolean(),
                        ItemComment = c.String(),
                        ColumnName = c.String(),
                        ParticipantType = c.Int(),
                        GraphicalID = c.String(),
                        ParticipantText = c.String(),
                        Id = c.Int(nullable: true),
                        OT_InstanceContext_ObjectID = c.Guid(),
                    })
                .PrimaryKey(t => t.ObjectID)
                .ForeignKey("dbo.OT_InstanceContext", t => t.OT_InstanceContext_ObjectID)
                .Index(t => t.OT_InstanceContext_ObjectID);
            
            CreateTable(
                "dbo.OT_RuleCellTemplate",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        CurrentActivityID = c.String(),
                        PostActivityID = c.String(),
                        Variable = c.String(),
                        VariableRelation = c.String(),
                        ParentIndex = c.Int(),
                        AndOR = c.String(),
                        InputValue = c.String(),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_WorkChartTrend",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SequenceNo = c.String(),
                        ChartActivityId = c.String(),
                        ChartOptType = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OT_WorkflowClause",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        ChildObjectID = c.String(),
                        WorkflowIcon = c.String(),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        TableName = c.String(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_WorkflowPackage",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        WorkflowPackage = c.String(),
                        ParentIndex = c.Int(),
                        CreateBy = c.String(),
                        CreateDate = c.String(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_WorkflowSheet",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        SheetName = c.String(),
                        SheetURL = c.String(),
                        ParentIndex = c.Int(),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
            CreateTable(
                "dbo.OT_WorkflowTemplate",
                c => new
                    {
                        ObjectID = c.Guid(nullable: false, identity: true),
                        ParentObjectID = c.String(),
                        WorkflowPackage = c.String(),
                        WorkflowName = c.String(),
                        Description = c.String(),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(),
                        version = c.String(),
                        Chart = c.String(),
                        Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.ObjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OT_WorkItem", "OT_InstanceContext_ObjectID", "dbo.OT_InstanceContext");
            DropForeignKey("dbo.OT_Token", "OT_InstanceContext_ObjectID", "dbo.OT_InstanceContext");
            DropIndex("dbo.OT_WorkItem", new[] { "OT_InstanceContext_ObjectID" });
            DropIndex("dbo.OT_Token", new[] { "OT_InstanceContext_ObjectID" });
            DropTable("dbo.OT_WorkflowTemplate");
            DropTable("dbo.OT_WorkflowSheet");
            DropTable("dbo.OT_WorkflowPackage");
            DropTable("dbo.OT_WorkflowClause");
            DropTable("dbo.OT_WorkChartTrend");
            DropTable("dbo.OT_RuleCellTemplate");
            DropTable("dbo.OT_WorkItem");
            DropTable("dbo.OT_Token");
            DropTable("dbo.OT_InstanceContext");
            DropTable("dbo.OT_DataPermission");
            DropTable("dbo.OT_ClauseDataItem");
            DropTable("dbo.OT_Attachment");
            DropTable("dbo.OT_Agency");
            DropTable("dbo.OT_ActivityTemplate");
            DropTable("dbo.OT_ActivityParticipant");
        }
    }
}
