namespace GymBooker1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StdGymClassTimetables", "Instructor", c => c.String(maxLength: 20));
            AlterColumn("dbo.StdGymClassTimetables", "Hall", c => c.String(maxLength: 12));
            AlterColumn("dbo.StdGymClassTimetables", "Duration", c => c.Int(nullable: false));
            AlterColumn("dbo.StdGymClassTimetables", "Day", c => c.Int(nullable: false));
            AlterColumn("dbo.StdGymClassTimetables", "Hour", c => c.Int(nullable: false));
            AlterColumn("dbo.StdGymClassTimetables", "Minute", c => c.Int(nullable: false));
            AlterColumn("dbo.StdGymClassTimetables", "MaxPeople", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StdGymClassTimetables", "MaxPeople", c => c.Int());
            AlterColumn("dbo.StdGymClassTimetables", "Minute", c => c.Int());
            AlterColumn("dbo.StdGymClassTimetables", "Hour", c => c.Int());
            AlterColumn("dbo.StdGymClassTimetables", "Day", c => c.Int());
            AlterColumn("dbo.StdGymClassTimetables", "Duration", c => c.Int());
            AlterColumn("dbo.StdGymClassTimetables", "Hall", c => c.String());
            AlterColumn("dbo.StdGymClassTimetables", "Instructor", c => c.String());
        }
    }
}
