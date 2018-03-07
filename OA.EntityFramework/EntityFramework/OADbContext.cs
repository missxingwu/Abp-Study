using Abp.EntityFramework;
using OA.Entites;
using System.Data.Entity;

namespace OA.EntityFramework
{
    public class OADbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example: 权限
        public virtual IDbSet<Q_Department> Q_Departments { get; set; }
        public virtual IDbSet<Q_Permission> Q_Permissions { get; set; }
        public virtual IDbSet<Q_Role> Q_RoleS { get; set; }
        public virtual IDbSet<Q_UserInfo> Q_UserInfos { get; set; }
        public virtual IDbSet<Q_UserRole> Q_UserRoles { get; set; }
        public virtual IDbSet<Q_PermissionButton> Q_PermissionButtons { get; set; }
        //Example: 流
        public virtual IDbSet<OT_ActivityParticipant> OT_ActivityParticipants { get; set; }
        public virtual IDbSet<OT_ActivityTemplate> OT_ActivityTemplates { get; set; }
        public virtual IDbSet<OT_Agency> OT_Agencys { get; set; }
        public virtual IDbSet<OT_Attachment> OT_Attachments { get; set; }
        public virtual IDbSet<OT_ClauseDataItem> OT_ClauseDataItems { get; set; }
        public virtual IDbSet<OT_DataPermission> OT_DataPermissions { get; set; }
        public virtual IDbSet<OT_InstanceContext> OT_InstanceContexts { get; set; }
        public virtual IDbSet<OT_RuleCellTemplate> OT_RuleCellTemplates { get; set; }
        public virtual IDbSet<OT_Token> OT_Tokens { get; set; }
        public virtual IDbSet<OT_WorkChartTrend> OT_WorkChartTrends { get; set; }
        public virtual IDbSet<OT_WorkflowClause> OT_WorkflowClauses { get; set; }
        public virtual IDbSet<OT_WorkflowPackage> OT_WorkflowPackages { get; set; }
        public virtual IDbSet<OT_WorkflowSheet> OT_WorkflowSheets { get; set; }
        public virtual IDbSet<OT_WorkflowTemplate> OT_WorkflowTemplates { get; set; }
        public virtual IDbSet<OT_WorkItem> OT_WorkItems { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public OADbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in OADataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of OADbContext since ABP automatically handles it.
         */
        public OADbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
