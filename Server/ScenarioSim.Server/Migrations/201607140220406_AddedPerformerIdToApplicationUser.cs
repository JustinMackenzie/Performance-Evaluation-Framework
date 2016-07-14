namespace ScenarioSim.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPerformerIdToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PerformerId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PerformerId");
        }
    }
}
