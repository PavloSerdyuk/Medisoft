namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnEndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Declarations", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Declarations", "EndDate");
        }
    }
}
