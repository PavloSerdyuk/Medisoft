namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelDoctSpecialization : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Doctors", "Specialization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Specialization", c => c.String());
        }
    }
}
