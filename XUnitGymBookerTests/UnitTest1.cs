using System;
using Xunit;
using GymBooker1.Controllers;
using GymBooker1.Models;
using System.Collections.Generic;
using System.Linq;


namespace XUnitGymBookerTests
{
    public class CalendarTests
    {

        List<StdGymClassTimetable> stdTimetable = new List<StdGymClassTimetable>();
        List<CalendarItem> timetableOld_TooOld = new List<CalendarItem>();
        List<CalendarItem> timetableOld_Current = new List<CalendarItem>();
        List<CalendarItem> timetableOld_Part_1 = new List<CalendarItem>();
        List<CalendarItem> timetableOld_Part_27 = new List<CalendarItem>();
        List<CalendarItem> timetableOld_Part_28 = new List<CalendarItem>();
        List<CalendarItem> timetableOld_Part_35 = new List<CalendarItem>();

        public CalendarTests()
        {
            stdTimetable = new List<StdGymClassTimetable>() {
                        new StdGymClassTimetable { GymClassId = 1, Day = 0, Hour = 8, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = 0, Hour = 9, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = 0, Hour = 10, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = 0, Hour = 11, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = 0, Hour = 13, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = 0, Hour = 14, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = 0, Hour = 15, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = 0, Hour = 16, Minute = 45, MaxPeople = 20 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Monday, Hour = 6, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Monday, Hour = 7, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Monday, Hour = 8, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Monday, Hour = 9, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Monday, Hour = 11, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Monday, Hour = 12, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Monday, Hour = 13, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Monday, Hour = 14, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Monday, Hour = 16, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Monday, Hour = 17, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Monday, Hour = 18, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Monday, Hour = 19, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Monday, Hour = 21, Minute = 0, MaxPeople = 20 },

                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Tuesday, Hour = 7, Minute = 0, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Tuesday, Hour = 8, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Tuesday, Hour = 9, Minute = 30, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Tuesday, Hour = 10, Minute = 45, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Tuesday, Hour = 12, Minute = 0, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Tuesday, Hour = 13, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Tuesday, Hour = 14, Minute = 30, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Tuesday, Hour = 15, Minute = 45, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Tuesday, Hour = 16, Minute = 0, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Tuesday, Hour = 18, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Tuesday, Hour = 19, Minute = 30, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Tuesday, Hour = 20, Minute = 45, Instructor = "John Deer", MaxPeople = 20 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Wednesday, Hour = 8, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Wednesday, Hour = 9, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Wednesday, Hour = 10, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Wednesday, Hour = 11, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Wednesday, Hour = 13, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Wednesday, Hour = 14, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Wednesday, Hour = 15, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Wednesday, Hour = 16, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Wednesday, Hour = 17, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Wednesday, Hour = 19, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Wednesday, Hour = 20, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Wednesday, Hour = 6, Minute = 45 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Thursday, Hour = 9, Minute = 0, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Thursday, Hour = 10, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Thursday, Hour = 11, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Thursday, Hour = 12, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Thursday, Hour = 13, Minute = 0, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Thursday, Hour = 15, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Thursday, Hour = 16, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Thursday, Hour = 17, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Thursday, Hour = 18, Minute = 0, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Thursday, Hour = 20, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Thursday, Hour = 6, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Thursday, Hour = 7, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Friday, Hour = 10, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Friday, Hour = 11, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Friday, Hour = 12, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Friday, Hour = 13, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 6, Day = DayOfWeek.Friday, Hour = 14, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 7, Day = DayOfWeek.Friday, Hour = 16, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 8, Day = DayOfWeek.Friday, Hour = 17, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Friday, Hour = 18, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Friday, Hour = 20, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Friday, Hour = 6, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Friday, Hour = 7, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Friday, Hour = 8, Minute = 45 },

                        new StdGymClassTimetable() { GymClassId = 1, Day = DayOfWeek.Saturday, Hour = 7, Minute = 0, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 2, Day = DayOfWeek.Saturday, Hour = 8, Minute = 15, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 3, Day = DayOfWeek.Saturday, Hour = 9, Minute = 30, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = 4, Day = DayOfWeek.Saturday, Hour = 10, Minute = 45, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 5, Day = DayOfWeek.Saturday, Hour = 12, Minute = 0, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 13, Day = DayOfWeek.Saturday, Hour = 13, Minute = 15, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 12, Day = DayOfWeek.Saturday, Hour = 14, Minute = 30, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = 11, Day = DayOfWeek.Saturday, Hour = 15, Minute = 45, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = 10, Day = DayOfWeek.Saturday, Hour = 16, Minute = 0, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = 9, Day = DayOfWeek.Saturday, Hour = 17, Minute = 15, Instructor = "Natalie Spears" }
            };

            // part list - with last 2 items to enable testing
            timetableOld_TooOld = new List<CalendarItem>() 
            {
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-8), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-8), MaxPeople = 20}
            };

            // full list (35 days) - only one per day - time is not important for initial test
            timetableOld_Current = new List<CalendarItem>()
            {
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-7), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-6), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-5), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-4), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-3), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-2), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-1), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(0), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(1), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(2), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(3), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(4), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(5), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(6), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(7), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(8), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(9), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(10), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(10), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(11), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(12), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(13), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(14), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(15), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(16), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(17), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(18), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(19), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(20), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(21), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(22), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(23), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(24), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(25), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(26), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(27), MaxPeople = 20},
            };

            // full list (35 days) - only one per day - time is not important for initial test
            timetableOld_Part_1 = new List<CalendarItem>()
            {
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-8), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-7), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-6), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-5), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-4), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-3), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-2), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-1), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(0), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(1), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(2), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(3), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(4), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(5), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(6), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(7), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(8), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(9), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(10), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(10), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(11), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(12), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(13), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(14), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(15), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(16), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(17), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(18), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(19), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(20), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(21), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(22), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(23), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(24), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(25), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(26), MaxPeople = 20},
            };

            // full list (35 days) - only one per day - time is not important for initial test
            timetableOld_Part_27 = new List<CalendarItem>()
            {
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-34), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-33), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-32), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-32), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-31), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-30), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-29), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-28), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-27), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-26), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-25), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-24), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-23), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-22), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-21), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-20), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-19), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-18), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-17), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-16), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-15), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-14), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-13), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-12), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-11), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-10), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-9), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-8), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-7), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-6), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-5), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-4), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-3), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-2), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-1), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(0), MaxPeople = 20},
            };

            // full list (35 days) - only one per day - time is not important for initial test
            timetableOld_Part_28 = new List<CalendarItem>()
            {
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-35), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-34), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-33), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-32), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-32), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-31), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-30), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-29), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-28), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-27), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-26), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-25), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-24), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-23), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-22), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-21), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-20), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-19), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-18), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-17), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-16), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-15), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-14), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-13), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-12), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-11), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-10), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-9), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-8), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-7), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-6), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-5), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-4), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-3), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-2), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-1), MaxPeople = 20},               
            };

            // full list (35 days) - only one per day - time is not important for initial test - latest is 8 days ago so full timetable required (35 days)
            timetableOld_Part_35 = new List<CalendarItem>()
            {
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-42), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-41), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-40), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-39), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-38), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-37), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-36), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-35), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-34), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-33), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-32), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-32), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-31), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-30), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-29), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-28), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-27), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-26), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-25), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-24), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-23), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-22), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-21), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-20), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-19), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-18), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-17), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-16), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-15), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-14), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-13), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-12), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-11), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-10), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-9), MaxPeople = 20},
                new CalendarItem(){ GymClassId = 1, Instructor = "Natalie Spears", Duration = 60, Hall = "Hall1", UserIds = "", GymClassTime = DateTime.Now.AddDays(-8), MaxPeople = 20},
                
            };
        }

        [Fact]
        public void TimetableController_No_Std_Timetable_Set_So_New_Timetable_Cannot_Be_Created()
        {
            var TimetableOld = new List<CalendarItem>();
            var StdTimetable = new List<StdGymClassTimetable>();

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(0, TotalDays);
            Assert.False(actual);
        }


        [Fact]
        public void TimetableController_No_Old_Timetable_So_New_Timetable_Will_Be_Created()
        {
            var TimetableOld = new List<CalendarItem>();

            var StdTimetable = stdTimetable;

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(35, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(-7), NextDate.Date);
            Assert.True(actual);
        }


        [Fact]
        public void TimetableController_Timetable_That_Is_Too_Old_So_Create_All_New_Timetable()
        {
            var TimetableOld = timetableOld_TooOld;

            var StdTimetable = stdTimetable;

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(35, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(-7), NextDate.Date);
            Assert.True(actual);
        }

        // Test when newest date is today + 27 days (i.e. current), therefore 0 days required
        [Fact]
        public void TimetableController_Timetable_That_Is_Current_So_Does_Not_Need_Updating()
        {
            var TimetableOld = timetableOld_Current;

            var StdTimetable = stdTimetable;

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(0, TotalDays);
            Assert.Equal(new DateTime(), NextDate.Date); // New date only so 1/1/1 0:00:00
            Assert.False(actual);
        }

        // Test when newest date is today + 26 days, therefore 1 day required 
        [Fact]
        public void TimetableController_Timetable_That_Is_Part_Way_Through_Newest_Date_Is_Today_Plus_26_Days_So_Needs_Updating_1_Day()
        {
            var TimetableOld = timetableOld_Part_1;

            var expectedNewTimetable = TimetableOld.FindAll(x => x.GymClassTime > DateTime.Today.AddDays(-7));

            var StdTimetable = stdTimetable;

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(1, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28-1), NextDate.Date);
            Assert.True(actual);
            Assert.Equal(expectedNewTimetable, TimetableNew);
        }

        // Test when newest date is today, therefore 27 days required 
        [Fact]
        public void TimetableController_Timetable_That_Is_Part_Way_Through_Newest_Date_Is_Today_So_Needs_Updating_27_Days()
        {
            var TimetableOld = timetableOld_Part_27;

            var expectedNewTimetable = TimetableOld.FindAll(x => x.GymClassTime > DateTime.Today.AddDays(-7));

            var StdTimetable = stdTimetable;

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(27, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28-27), NextDate.Date);
            Assert.True(actual);
            Assert.Equal(expectedNewTimetable, TimetableNew);
        }

        // Test when newest date is yesterday, therefore 28 days required 
        [Fact]
        public void TimetableController_Timetable_That_Is_Part_Way_Through_Newest_Date_Is_Yesterday_So_Needs_Updating_28_Days()
        {
            var TimetableOld = timetableOld_Part_28;

            var expectedNewTimetable = TimetableOld.FindAll(x => x.GymClassTime > DateTime.Today.AddDays(-7));

            expectedNewTimetable = expectedNewTimetable.OrderBy(x => x.GymClassTime).ToList();

            var StdTimetable = stdTimetable;

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(28, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28 - 28), NextDate.Date);
            Assert.True(actual);
            Assert.Equal(expectedNewTimetable, TimetableNew);
        }

        // Test when all dates are older than 7 days, therefore all 35 days requried 
        [Fact]
        public void TimetableController_Timetable_That_Is_Part_Way_Through_Newest_Date_Is_Older_Than_7_Days_So_Needs_Updating_All_35_Days()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            var actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            Assert.Equal(35, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28 - 35), NextDate.Date);
            Assert.True(actual);
        }


        // Test new timetable. Tests can be checking small parts of the new Timetable


        // Test that a new day has been added, i.e. that the last day in the old list has a date a day later in the new list 
        // (if std timetable has a day after it)
        [Fact]
        public void TimetableController_New_Day_Added_To_Calendar()
        {
            var TimetableOld = timetableOld_Part_1;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            var OldCalendar_NewestDate = TimetableOld.Last().GymClassTime.Date;
            var NewCalendar_NewestDate = newTimeTable2.Last().GymClassTime.Date;

            var OldestDateInNewCalendar = newTimeTable2.First().GymClassTime.Date;

            Assert.Equal(1, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28 - 1), NextDate.Date);
            Assert.True(actual);
            Assert.True(NewCalendar_NewestDate > OldCalendar_NewestDate);
            Assert.True(OldestDateInNewCalendar < DateTime.Now);
            Assert.Equal(DateTime.Now.AddDays(27).Date, NewCalendar_NewestDate);
        }

        [Fact]
        public void TimetableController_27_Days_Added_To_Calendar()
        {
            var TimetableOld = timetableOld_Part_27;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            var OldCalendar_NewestDate = TimetableOld.Last().GymClassTime.Date;
            var NewCalendar_NewestDate = newTimeTable2.Last().GymClassTime.Date;

            var OldestDateInNewCalendar = newTimeTable2.First().GymClassTime.Date;

            Assert.Equal(27, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28 - 27), NextDate.Date);
            Assert.True(actual);
            Assert.True(NewCalendar_NewestDate > OldCalendar_NewestDate.AddDays(27-1));
            Assert.True(OldestDateInNewCalendar < DateTime.Now);
            Assert.Equal(DateTime.Now.AddDays(27).Date, NewCalendar_NewestDate);
        }

        [Fact]
        public void TimetableController_28_Days_Added_To_Calendar()
        {
            var TimetableOld = timetableOld_Part_28;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            var OldCalendar_NewestDate = TimetableOld.Last().GymClassTime.Date;
            var NewCalendar_NewestDate = newTimeTable2.Last().GymClassTime.Date;

            var OldestDateInNewCalendar = newTimeTable2.First().GymClassTime.Date;

            Assert.Equal(28, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28 - 28), NextDate.Date);
            Assert.True(actual);
            Assert.True(NewCalendar_NewestDate > OldCalendar_NewestDate.AddDays(28 - 1));
            Assert.True(OldestDateInNewCalendar < DateTime.Now);
            Assert.Equal(DateTime.Now.AddDays(27).Date, NewCalendar_NewestDate);
        }

        [Fact]
        public void TimetableController_35_Days_Added_To_Calendar()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            var OldCalendar_NewestDate = TimetableOld.Last().GymClassTime.Date;
            var NewCalendar_NewestDate = newTimeTable2.Last().GymClassTime.Date;

            var OldestDateInNewCalendar = newTimeTable2.First().GymClassTime.Date;

            Assert.Equal(35, TotalDays);
            Assert.Equal(DateTime.Today.AddDays(28 - 35), NextDate.Date);
            Assert.True(actual);
            Assert.True(NewCalendar_NewestDate > OldCalendar_NewestDate.AddDays(35 - 1));
            Assert.True(OldestDateInNewCalendar < DateTime.Now);
            Assert.Equal(DateTime.Now.AddDays(27).Date, NewCalendar_NewestDate);
        }

        // Tests that show new timetable includes various properties


        [Fact]
        public void TimetableController_Timetable_includes_Non_Default_Values()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            newTimeTable2.ForEach(x =>
            {
                Assert.NotEqual("", x.Hall);
                Assert.NotEqual("", x.Instructor);
                Assert.Equal("", x.UserIds);
                Assert.NotEqual(0, x.MaxPeople);
                Assert.NotEqual(0, x.Duration);
                Assert.NotEqual(0, x.GymClassId);
                Assert.NotEqual(0, x.GymClassTime.Hour);
                Assert.Contains("Hall", x.Hall); // default set in the model for items that aren't set in the standard Timetable
                Assert.True(x.MaxPeople > 5);
                Assert.True(x.Duration > 15);
            });

            Assert.NotEqual("", newTimeTable2.Last().Hall);
            Assert.NotEqual("", newTimeTable2.Last().Instructor);
            Assert.Equal("", newTimeTable2.Last().UserIds);
            Assert.NotEqual(0, newTimeTable2.Last().MaxPeople);
            Assert.NotEqual(0, newTimeTable2.Last().Duration);
            Assert.NotEqual(0, newTimeTable2.Last().GymClassId);
            Assert.NotEqual(0, newTimeTable2.Last().GymClassTime.Hour);
            Assert.Equal((79 * 5), newTimeTable2.Count); // std timetable has 79 classes in a week. 5 Weeks. Therefore new timetable will have 79x5=395
        }

        // should check that a test on Monday (say) has (random choice of class on that day):
        // Monday - GymClassId = 4, Day = DayOfWeek.Monday, Hour = 9, Minute = 45, MaxPeople = 20 }
        [Fact]
        public void TimetableController_Timetable_For_Every_Monday_Includes_Correct_Data()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            var monday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Monday);

            monday.FindAll(x => x.GymClassId == 4).ForEach(x =>
            {
                Assert.Equal(4, x.GymClassId);
                Assert.Equal(9, x.GymClassTime.Hour);
                Assert.Equal(45, x.GymClassTime.Minute);
                Assert.Equal(20, x.MaxPeople);
                Assert.Equal("Jenny Body", x.Instructor); // Default value
                Assert.Equal("Hall 1", x.Hall); // Default value
                Assert.Equal(60, x.Duration); // Default value
            });

            Assert.Equal(5 * 13, monday.Count); // 5 weeks x 13 total classes on a Monday in Std Timetable
        }

        // should check that a test on Thursday (say) has (random choice of class on that day):
        // Thursday - GymClassId = 4, Day = DayOfWeek.Thursday, Hour = 12, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30
        [Fact]
        public void TimetableController_Timetable_For_Every_Thursday_Includes_Correct_Data()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            var thursday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Thursday);

            thursday.FindAll(x => x.GymClassId == 4).ForEach(x =>
            {
                Assert.Equal(4, x.GymClassId);
                Assert.Equal(12, x.GymClassTime.Hour);
                Assert.Equal(45, x.GymClassTime.Minute);
                Assert.Equal(30, x.MaxPeople);
                Assert.Equal("Steve Jobs", x.Instructor);
                Assert.Equal("Hall 2", x.Hall); 
                Assert.Equal(60, x.Duration); // Default value
            });

            Assert.Equal(5 * 12, thursday.Count); // 5 weeks x 12 total classes on a Thursday in Std Timetable
        }

        // timetable includes classes on every day of the week (as per Std timetable)
        [Fact]
        public void TimetableController_Classes_For_Every_Day_Of_The_Week()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            var sunday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Sunday);
            var monday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Monday);
            var tuesday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Tuesday);
            var wednesday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Wednesday);
            var thursday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Thursday);
            var friday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Friday);
            var saturday = newTimeTable2.FindAll(x => x.GymClassTime.DayOfWeek == DayOfWeek.Saturday);

            Assert.NotEmpty(sunday);
            Assert.NotEmpty(monday);
            Assert.NotEmpty(tuesday);
            Assert.NotEmpty(wednesday);
            Assert.NotEmpty(thursday);
            Assert.NotEmpty(friday);
            Assert.NotEmpty(saturday);
        }

        // timetable includes classes on every day (as per Std timetable) - every date from today - 7 to today + 27
        [Fact]
        public void TimetableController_Classes_For_Every_Day()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            // loop from today -7 to today + 27 and make sure there is a class on each day
            for (var i=-7; i<=27; i++)
            {
                Assert.Equal(DateTime.Now.AddDays(i).Date, newTimeTable2.Find(x => x.GymClassTime.Date == DateTime.Now.AddDays(i).Date).GymClassTime.Date);
            }
        }

        [Fact]
        public void TimetableController_No_Classes_Later_than_27_days_later_Or_Earlier_Then_7_days_earlier()
        {
            var TimetableOld = timetableOld_Part_35;

            var StdTimetable = stdTimetable;

            bool actual = TimetableController.CalcCriteriaForTimeTable(StdTimetable, TimetableOld,
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew);

            List<CalendarItem> newTimeTable2 = TimetableController.CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);

            Assert.Equal(DateTime.Now.AddDays(-7).Date, newTimeTable2.Min(x => x.GymClassTime.Date));
            Assert.Equal(DateTime.Now.AddDays(27).Date, newTimeTable2.Max(x => x.GymClassTime.Date));
        }

        // Most of the above tests are for replacing the whole timetable. If only part is replaced the tests would have to be changed
        // because only later dates are added. So any dates earlier are the same as they were. Therefore tests for unchanged dates
        // should be made against the old timetable (the bit from -7 days to the end of the old timetable).

    }

}
