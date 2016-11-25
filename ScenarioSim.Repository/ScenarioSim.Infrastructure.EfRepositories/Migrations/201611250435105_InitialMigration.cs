namespace ScenarioSim.Infrastructure.EfRepositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScenarioPerformances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartTime = c.DateTimeOffset(nullable: false, precision: 7),
                        EndTime = c.DateTimeOffset(nullable: false, precision: 7),
                        ScenarioId = c.Guid(nullable: false),
                        PerformerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performers", t => t.PerformerId, cascadeDelete: true)
                .ForeignKey("dbo.Scenarios", t => t.ScenarioId, cascadeDelete: true)
                .Index(t => t.ScenarioId)
                .Index(t => t.PerformerId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ScenarioPerformanceId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Timestamp = c.DateTimeOffset(nullable: false, precision: 7),
                        TaskId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScenarioPerformances", t => t.ScenarioPerformanceId, cascadeDelete: true)
                .Index(t => t.ScenarioPerformanceId);
            
            CreateTable(
                "dbo.EventParameters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Value = c.String(),
                        ParameterType = c.String(),
                        Event_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scenarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SchemaId = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schemata", t => t.SchemaId, cascadeDelete: true)
                .Index(t => t.SchemaId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScenarioAssets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Transform_Position_X = c.Single(nullable: false),
                        Transform_Position_Y = c.Single(nullable: false),
                        Transform_Position_Z = c.Single(nullable: false),
                        Transform_Rotation_X = c.Single(nullable: false),
                        Transform_Rotation_Y = c.Single(nullable: false),
                        Transform_Rotation_Z = c.Single(nullable: false),
                        Transform_Scale_X = c.Single(nullable: false),
                        Transform_Scale_Y = c.Single(nullable: false),
                        Transform_Scale_Z = c.Single(nullable: false),
                        AssetId = c.Guid(nullable: false),
                        ScenarioId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Scenarios", t => t.ScenarioId, cascadeDelete: true)
                .Index(t => t.AssetId)
                .Index(t => t.ScenarioId);
            
            CreateTable(
                "dbo.ScenarioEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        TaskId = c.Guid(nullable: false),
                        Entry = c.Boolean(),
                        Scenario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Scenarios", t => t.Scenario_Id)
                .Index(t => t.TaskId)
                .Index(t => t.Scenario_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ActorId = c.Guid(nullable: false),
                        ParentTaskId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        CompositeTask_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.ParentTaskId)
                .ForeignKey("dbo.Tasks", t => t.CompositeTask_Id)
                .Index(t => t.ActorId)
                .Index(t => t.ParentTaskId)
                .Index(t => t.CompositeTask_Id);
            
            CreateTable(
                "dbo.ScenarioTaskDefinitions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ScenarioId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                        TaskValuesId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scenarios", t => t.ScenarioId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.TaskValues", t => t.TaskValuesId, cascadeDelete: true)
                .Index(t => t.ScenarioId)
                .Index(t => t.TaskId)
                .Index(t => t.TaskValuesId);
            
            CreateTable(
                "dbo.TaskValues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParameterName = c.String(),
                        EventName = c.String(),
                        Target_X = c.Single(),
                        Target_Y = c.Single(),
                        Target_Z = c.Single(),
                        D = c.Single(),
                        W = c.Single(),
                        MeanDelay = c.Single(),
                        VarianceDelay = c.Single(),
                        Delay = c.Single(),
                        A = c.Single(),
                        W1 = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schemata",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        TaskId = c.Int(nullable: false),
                        Task_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
            CreateTable(
                "dbo.TaskTransitions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SchemaId = c.Guid(nullable: false),
                        SourceTaskId = c.Guid(nullable: false),
                        DestinationTaskId = c.Guid(nullable: false),
                        PerformerActionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.DestinationTaskId, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.PerformerActionId, cascadeDelete: true)
                .ForeignKey("dbo.Schemata", t => t.SchemaId, cascadeDelete: false)
                .ForeignKey("dbo.Tasks", t => t.SourceTaskId, cascadeDelete: false)
                .Index(t => t.SchemaId)
                .Index(t => t.SourceTaskId)
                .Index(t => t.DestinationTaskId)
                .Index(t => t.PerformerActionId);
            
            CreateTable(
                "dbo.TaskPerformances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ScenarioPerformanceId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                        Timestamp = c.DateTimeOffset(nullable: false, precision: 7),
                        TaskPerformanceValuesId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScenarioPerformances", t => t.ScenarioPerformanceId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.TaskPerformanceValues", t => t.TaskPerformanceValuesId, cascadeDelete: true)
                .Index(t => t.ScenarioPerformanceId)
                .Index(t => t.TaskId)
                .Index(t => t.TaskPerformanceValuesId);
            
            CreateTable(
                "dbo.TaskPerformanceValues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ElapsedTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgramScenarios",
                c => new
                    {
                        Program_Id = c.Guid(nullable: false),
                        Scenario_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Program_Id, t.Scenario_Id })
                .ForeignKey("dbo.Programs", t => t.Program_Id, cascadeDelete: true)
                .ForeignKey("dbo.Scenarios", t => t.Scenario_Id, cascadeDelete: true)
                .Index(t => t.Program_Id)
                .Index(t => t.Scenario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskPerformances", "TaskPerformanceValuesId", "dbo.TaskPerformanceValues");
            DropForeignKey("dbo.TaskPerformances", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskPerformances", "ScenarioPerformanceId", "dbo.ScenarioPerformances");
            DropForeignKey("dbo.ScenarioPerformances", "ScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.TaskTransitions", "SourceTaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskTransitions", "SchemaId", "dbo.Schemata");
            DropForeignKey("dbo.TaskTransitions", "PerformerActionId", "dbo.Events");
            DropForeignKey("dbo.TaskTransitions", "DestinationTaskId", "dbo.Tasks");
            DropForeignKey("dbo.Schemata", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Scenarios", "SchemaId", "dbo.Schemata");
            DropForeignKey("dbo.ScenarioTaskDefinitions", "TaskValuesId", "dbo.TaskValues");
            DropForeignKey("dbo.ScenarioTaskDefinitions", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.ScenarioTaskDefinitions", "ScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.ScenarioEvents", "Scenario_Id", "dbo.Scenarios");
            DropForeignKey("dbo.ScenarioEvents", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "CompositeTask_Id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "ParentTaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.ScenarioAssets", "ScenarioId", "dbo.Scenarios");
            DropForeignKey("dbo.ScenarioAssets", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.ProgramScenarios", "Scenario_Id", "dbo.Scenarios");
            DropForeignKey("dbo.ProgramScenarios", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.ScenarioPerformances", "PerformerId", "dbo.Performers");
            DropForeignKey("dbo.Events", "ScenarioPerformanceId", "dbo.ScenarioPerformances");
            DropForeignKey("dbo.EventParameters", "Event_Id", "dbo.Events");
            DropIndex("dbo.ProgramScenarios", new[] { "Scenario_Id" });
            DropIndex("dbo.ProgramScenarios", new[] { "Program_Id" });
            DropIndex("dbo.TaskPerformances", new[] { "TaskPerformanceValuesId" });
            DropIndex("dbo.TaskPerformances", new[] { "TaskId" });
            DropIndex("dbo.TaskPerformances", new[] { "ScenarioPerformanceId" });
            DropIndex("dbo.TaskTransitions", new[] { "PerformerActionId" });
            DropIndex("dbo.TaskTransitions", new[] { "DestinationTaskId" });
            DropIndex("dbo.TaskTransitions", new[] { "SourceTaskId" });
            DropIndex("dbo.TaskTransitions", new[] { "SchemaId" });
            DropIndex("dbo.Schemata", new[] { "Task_Id" });
            DropIndex("dbo.ScenarioTaskDefinitions", new[] { "TaskValuesId" });
            DropIndex("dbo.ScenarioTaskDefinitions", new[] { "TaskId" });
            DropIndex("dbo.ScenarioTaskDefinitions", new[] { "ScenarioId" });
            DropIndex("dbo.Tasks", new[] { "CompositeTask_Id" });
            DropIndex("dbo.Tasks", new[] { "ParentTaskId" });
            DropIndex("dbo.Tasks", new[] { "ActorId" });
            DropIndex("dbo.ScenarioEvents", new[] { "Scenario_Id" });
            DropIndex("dbo.ScenarioEvents", new[] { "TaskId" });
            DropIndex("dbo.ScenarioAssets", new[] { "ScenarioId" });
            DropIndex("dbo.ScenarioAssets", new[] { "AssetId" });
            DropIndex("dbo.Scenarios", new[] { "SchemaId" });
            DropIndex("dbo.EventParameters", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "ScenarioPerformanceId" });
            DropIndex("dbo.ScenarioPerformances", new[] { "PerformerId" });
            DropIndex("dbo.ScenarioPerformances", new[] { "ScenarioId" });
            DropTable("dbo.ProgramScenarios");
            DropTable("dbo.TaskPerformanceValues");
            DropTable("dbo.TaskPerformances");
            DropTable("dbo.TaskTransitions");
            DropTable("dbo.Schemata");
            DropTable("dbo.TaskValues");
            DropTable("dbo.ScenarioTaskDefinitions");
            DropTable("dbo.Tasks");
            DropTable("dbo.ScenarioEvents");
            DropTable("dbo.ScenarioAssets");
            DropTable("dbo.Programs");
            DropTable("dbo.Scenarios");
            DropTable("dbo.Performers");
            DropTable("dbo.EventParameters");
            DropTable("dbo.Events");
            DropTable("dbo.ScenarioPerformances");
            DropTable("dbo.Assets");
            DropTable("dbo.Actors");
        }
    }
}
