namespace GymBooker1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instructor = c.String(),
                        Duration = c.Int(),
                        Hall = c.String(),
                        UserIds = c.String(),
                        GymClassTime = c.DateTime(nullable: false),
                        MaxPeople = c.Int(),
                        GymClassId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GymClasses", t => t.GymClassId_Id)
                .Index(t => t.GymClassId_Id);
            
            CreateTable(
                "dbo.GymClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StdGymClassTimetables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instructor = c.String(),
                        Hall = c.String(),
                        Duration = c.Int(),
                        Day = c.Int(),
                        Hour = c.Int(),
                        Minute = c.Int(),
                        MaxPeople = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                        GymClassId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GymClasses", t => t.GymClassId_Id)
                .Index(t => t.GymClassId_Id);
            
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CalendarIds", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StdGymClassTimetables", "GymClassId_Id", "dbo.GymClasses");
            DropForeignKey("dbo.CalendarItems", "GymClassId_Id", "dbo.GymClasses");
            DropIndex("dbo.StdGymClassTimetables", new[] { "GymClassId_Id" });
            DropIndex("dbo.CalendarItems", new[] { "GymClassId_Id" });
            DropColumn("dbo.AspNetUsers", "CalendarIds");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropTable("dbo.StdGymClassTimetables");
            DropTable("dbo.GymClasses");
            DropTable("dbo.CalendarItems");
        }
    }
}
