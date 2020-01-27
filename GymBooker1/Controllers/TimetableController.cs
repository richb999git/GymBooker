﻿using GymBooker1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymBooker1.Controllers
{
    public class TimetableController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void UpdateCalendar()
        {
            List<CalendarItem> TimetableOld = db.CalendarItems.OrderBy(x => x.GymClassTime).ToList<CalendarItem>();
            List<StdGymClassTimetable> StdTimetable = db.StdGymClassTimetables.ToList<StdGymClassTimetable>();

            if (CalcCriteriaForTimeTable(StdTimetable, TimetableOld, 
                out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew))
            {
                List<CalendarItem> newTimeTable = CalculateTimetable(StdTimetable, TimetableNew, NextDate, TotalDays);
                SaveTimetable(newTimeTable);
            }
        }


        // Can now be tested
        // Needs: List<StdGymClassTimetable>StdTimetable, List<CalendarItem> TimetableOld
        //   - StdTimetable could be empty. 
        //   - TimetableOld could be empty, same (i.e same day), part way through or fully through (but will have full amount of days)
        // Should populate and "out" NextDate, TotalDays and TimetableNew (up to last date of old timetable)
        // and return true OR return null to not produce timetable
        public static bool CalcCriteriaForTimeTable(List<StdGymClassTimetable> StdTimetable, List<CalendarItem> TimetableOld, 
            out DateTime NextDate, out int TotalDays, out List<CalendarItem> TimetableNew)
        {
            NextDate = new DateTime();
            TotalDays = 0;
            TimetableNew = new List<CalendarItem>();
            DateTime DateNow = DateTime.Now; // take date now so it is locked in (in case near midnight)

            if (!StdTimetable.Any()) return false;

            if (!TimetableOld.Any())
            {
                // create a whole new list from -7 days to + 28 days. -7 to keep a record of class goers
                NextDate = DateNow.AddDays(-7);
                TotalDays = (7 + 28);
                return true;
            }
            else
            {
                TimetableOld = TimetableOld.OrderBy(x => x.GymClassTime).ToList();
                // search from start of TimetableOld until you get to a date max 7 days before today                
                int i = 0;
                while (i < TimetableOld.Count && TimetableOld[i].GymClassTime.Date < DateNow.AddDays(-7).Date) i++; // change to a lower number to test or positive

                if (i >= TimetableOld.Count) // If not found (i.e. we are more than 28 days since last checked) then create a whole new list
                {
                    NextDate = DateNow.AddDays(-7);
                    TotalDays = (7 + 28);
                    return true;
                }

                if (i == 0) return false; // no change so no need to create a new timetable

                // int startDatePositionInNewTimetable = i;  // not needed
                // If found create new list starting from that point to end of data
                while (i < TimetableOld.Count)
                {
                    TimetableNew.Add(TimetableOld[i]);
                    i++;
                }
                // and then add new days to max + 28 days
                // days to add would be 7 + 28 less days in new timetable (Last date in old timetable i-1 less date in start of new timetable)
                TimeSpan span = TimetableOld[i - 1].GymClassTime.Subtract(TimetableNew[0].GymClassTime);
                TotalDays = 7 + 28 - span.Days - 1;
                NextDate = TimetableOld[i - 1].GymClassTime.AddDays(1); 
                return true;
            }
        }


        // Can now be tested
        // Calculate up-to-date calendar using std timetable as basis and old timetable as start
        // Needs: DateTime NextDate, int TotalDays, List<StdGymClassTimetable> StdTimetable, List<CalendarItem> TimetableNew
        //  - NextDate will be "DateNow.AddDays(-7);" if this method is run
        //  - TotalDays will be Max (7 + 28) i.e. full 7 days in past + 28 days in future, or a number of days left if adding
        //       E.g. if it is yesterday since last created then only 1 day would need to be added
        //  - StdTimetable comes from the database
        //  - TimetableNew would be whatever was in the timetable when it was last created (i.e. TimetableOld - from the database)
        // Should populate and return TimetableNew ready to save to database
        public static List<CalendarItem> CalculateTimetable(List<StdGymClassTimetable> StdTimetable, List<CalendarItem> TimetableNew, DateTime NextDate, int TotalDays)
        { 
            ///// DayOfWeek change
            DayOfWeek DayOfWeekOfFirstItem = NextDate.DayOfWeek; // Enum: Sunday 0, Monday 1 etc Saturday 6
                                                                    // Find first occurence of day of the week in the std timetable (or followng day if no classes on that day)
                                                                    // either loop through from start to find the index
                                                                    // add each item of the std timetable to the new timetable each day until + 28 days looping around the std timetable
            var StdTimetableArray = StdTimetable.OrderBy(a => a.Day).ThenBy(a => a.Hour).ToArray();
            int j = 0;
            while (StdTimetableArray[j].Day < DayOfWeekOfFirstItem) j++;

            // int startPositionInStdTimetable = j; // not needed
            // now loop through all items in standard timetable to end (to Saturday) then loop back to start (Sunday) then on to day before start (j-1)
            DayOfWeek currentDayOfWeek = DayOfWeekOfFirstItem; // Sunday 0, Monday 1 etc Saturday 6

            for (int i = 0; i < TotalDays; i++)  //loop through adding days to new timetable (35 days (7 + 28)) some of which may be taken from previous timetable
            {
                // j is std timetable array item number. Need to loop back to start when end is reached
                while (j < StdTimetableArray.Count() && StdTimetableArray[j].Day == currentDayOfWeek) //loop through each day's classes and add to new timetable
                {
                    if (StdTimetableArray[j].Deleted == false)
                    {
                        int Hour = (int)StdTimetableArray[j].Hour;
                        int Minute = (int)StdTimetableArray[j].Minute;
                        TimeSpan ts = new TimeSpan(Hour, Minute, 0);
                        DateTime GymClassTime = NextDate.Date + ts;

                        CalendarItem item = new CalendarItem
                        {
                            GymClassId = StdTimetableArray[j].GymClassId,
                            Instructor = StdTimetableArray[j].Instructor,
                            Duration = StdTimetableArray[j].Duration,
                            Hall = StdTimetableArray[j].Hall,
                            UserIds = "",
                            GymClassTime = GymClassTime,
                            MaxPeople = StdTimetableArray[j].MaxPeople
                        };

                        TimetableNew.Add(item);
                    }

                    j++;
                }
                currentDayOfWeek++;
                if (currentDayOfWeek > DayOfWeek.Saturday) currentDayOfWeek = 0;
                NextDate = NextDate.AddDays(1);
                // loop back to start of std timetable if end reached
                if (j >= StdTimetableArray.Count()) j = 0;
            }
            return TimetableNew;
        }

        private void SaveTimetable(List<CalendarItem> TimetableNew)
        {
            // delete old calendar and save new
            db.Database.ExecuteSqlCommand("delete from CalendarItems");
            //db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('CalendarItems', RESEED, 0)"); // reseed if wanted (set id to 0) - specific to MS SQL
            db.CalendarItems.AddRange(TimetableNew); // saves in random order, can't save in order.
            db.SaveChanges();
        }

        

    }
}
