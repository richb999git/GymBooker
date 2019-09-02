namespace GymBooker1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StdGymClassTimetables", "Instructor", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.StdGymClassTimetables", "Hall", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StdGymClassTimetables", "Hall", c => c.String(maxLength: 12));
            AlterColumn("dbo.StdGymClassTimetables", "Instructor", c => c.String(maxLength: 20));
        }
    }
}
