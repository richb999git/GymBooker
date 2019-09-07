namespace GymBooker1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForeignKeyProgramming : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalendarItems", "GymClassId_Id", "dbo.GymClasses");
            DropForeignKey("dbo.StdGymClassTimetables", "GymClassId_Id", "dbo.GymClasses");
            DropIndex("dbo.CalendarItems", new[] { "GymClassId_Id" });
            DropIndex("dbo.StdGymClassTimetables", new[] { "GymClassId_Id" });
            RenameColumn(table: "dbo.CalendarItems", name: "GymClassId_Id", newName: "GymClassId");
            RenameColumn(table: "dbo.StdGymClassTimetables", name: "GymClassId_Id", newName: "GymClassId");
            AlterColumn("dbo.CalendarItems", "GymClassId", c => c.Int(nullable: false));
            AlterColumn("dbo.StdGymClassTimetables", "GymClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.CalendarItems", "GymClassId");
            CreateIndex("dbo.StdGymClassTimetables", "GymClassId");
            AddForeignKey("dbo.CalendarItems", "GymClassId", "dbo.GymClasses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StdGymClassTimetables", "GymClassId", "dbo.GymClasses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StdGymClassTimetables", "GymClassId", "dbo.GymClasses");
            DropForeignKey("dbo.CalendarItems", "GymClassId", "dbo.GymClasses");
            DropIndex("dbo.StdGymClassTimetables", new[] { "GymClassId" });
            DropIndex("dbo.CalendarItems", new[] { "GymClassId" });
            AlterColumn("dbo.StdGymClassTimetables", "GymClassId", c => c.Int());
            AlterColumn("dbo.CalendarItems", "GymClassId", c => c.Int());
            RenameColumn(table: "dbo.StdGymClassTimetables", name: "GymClassId", newName: "GymClassId_Id");
            RenameColumn(table: "dbo.CalendarItems", name: "GymClassId", newName: "GymClassId_Id");
            CreateIndex("dbo.StdGymClassTimetables", "GymClassId_Id");
            CreateIndex("dbo.CalendarItems", "GymClassId_Id");
            AddForeignKey("dbo.StdGymClassTimetables", "GymClassId_Id", "dbo.GymClasses", "Id");
            AddForeignKey("dbo.CalendarItems", "GymClassId_Id", "dbo.GymClasses", "Id");
        }
    }
}
