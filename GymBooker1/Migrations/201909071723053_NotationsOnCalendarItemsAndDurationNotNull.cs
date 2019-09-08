namespace GymBooker1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotationsOnCalendarItemsAndDurationNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalendarItems", "Instructor", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.CalendarItems", "Duration", c => c.Int(nullable: false));
            AlterColumn("dbo.CalendarItems", "Hall", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalendarItems", "Hall", c => c.String());
            AlterColumn("dbo.CalendarItems", "Duration", c => c.Int());
            AlterColumn("dbo.CalendarItems", "Instructor", c => c.String());
        }
    }
}
