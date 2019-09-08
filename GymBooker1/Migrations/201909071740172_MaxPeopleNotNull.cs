namespace GymBooker1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxPeopleNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CalendarItems", "MaxPeople", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CalendarItems", "MaxPeople", c => c.Int());
        }
    }
}
