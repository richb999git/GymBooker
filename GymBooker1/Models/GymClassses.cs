﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GymBooker1.Models
{
    public class GymClasses : IdentityUser
    {
        //public virtual GymClass GymClass { get; set; }
        //public virtual StdGymClassTimetable StdGymClassTimetable { get; set; }
        //public virtual CalendarItem CalendarItem { get; set; }
    }

    public class StdGymClassTimetables : IdentityUser
    {
        //public virtual GymClass GymClass { get; set; }
        //public virtual StdGymClassTimetable StdGymClassTimetable { get; set; }
        //public virtual CalendarItem CalendarItem { get; set; }
    }

    public class CalendarItems : IdentityUser
    {
        //public virtual GymClass GymClass { get; set; }
        //public virtual StdGymClassTimetable StdGymClassTimetable { get; set; }
        //public virtual CalendarItem CalendarItem { get; set; }
    }

    public class GymClass
    {
        public int Id { get; set; }

        [Display(Name = "Class Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool Deleted { get; set; } = false;
    }

    public class StdGymClassTimetable
    {
        public int Id { get; set; }

        [ForeignKey("GymClass")]
        [Display(Name = "Class Id")]
        public int GymClassId { get; set; }
        public virtual GymClass GymClass { get; set; } // navigation property for foreign key

        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string Instructor { get; set; } = "Jenny Body";

        [StringLength(12, MinimumLength = 2)]
        [Required]
        public string Hall { get; set; } = "Hall 1";

        [Range(20, 1440)]
        public int Duration { get; set; } = 60; // minutes

        [Range(0, 6)]
        public DayOfWeek Day { get; set; }

        [Range(0, 23)]
        public int Hour { get; set; }

        [Range(0, 59)]
        public int Minute { get; set; }

        [Range(1, 100)]
        [Display(Name = "Max People")]
        public int MaxPeople { get; set; } = 20;

        [Display(Name = "Cancelled")]
        public bool Deleted { get; set; } = false;
    }

    public class CalendarItem
    {
        public int Id { get; set; }

        [ForeignKey("GymClass")]
        public int GymClassId { get; set; }
        public virtual GymClass GymClass { get; set; } // navigation property for foreign key

        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string Instructor { get; set; }

        [Range(20, 1440)]
        public int Duration { get; set; }  // minutes

        [StringLength(12, MinimumLength = 2)]
        [Required]
        public string Hall { get; set; }

        public string UserIds { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date/Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy hh:mm tt}")]
        //[CustomValidation(typeof(GymClassDateValidation), nameof(GymClassDateValidation.WithinCalendarValidate))]
        public DateTime GymClassTime { get; set; } // this is a specific date/time. In StdGymClassTimetable it uses Day/Hour/Minute

        [Range(1, 100)]
        [Display(Name = "Max People")]
        public int MaxPeople { get; set; }
    }


    //public class GymClassDateValidation
    //{
    //    public static ValidationResult WithinCalendarValidate(DateTime date)
    //    {
    //        return date > DateTime.Now.AddDays(28) || date < DateTime.Now.AddHours(-8)
    //            ? new ValidationResult("Can't add a class outside the current calendar")
    //            : ValidationResult.Success;
    //    }
    //}


    public static class GetPics
    {
        public static string[] Get2Pics(string Name)
        { 
            // show 2 pics from particular Gym class side by side (or only one on small screens)*@
            // use array for now

            string[] circuits = new string[2] { "Circuits2.jpg", "Circuits3.jpg" };
            string[] step = new string[2] { "Step2.jpg", "Step3.jpg" };
            string[] boxfit = new string[2] { "BoxFit2.jpg", "BoxFit3.jpg" };
            string[] zumba = new string[2] { "Zumba2.jpg", "Zumba3.jpg" };
            string[] spin = new string[2] { "Spin2.jpg", "Spin3.jpg" };
            string[] burnit = new string[2] { "BurnIt2.jpg", "BurnIt3.jpg" };
            string[] combat = new string[2] { "Combat2.jpg", "Combat3.jpg" };
            string[] abs = new string[2] { "AbsoluteAbs2.jpg", "AbsoluteAbs3.jpg" }; 
            string[] lbt = new string[2] { "LegsBumsTums2.jpg", "LegsBumsTums3.jpg" };
            string[] pump = new string[2] { "BodyPump2.jpg", "BodyPump3.jpg" };
            string[] tone = new string[2] { "BodyTone2.jpg", "BodyTone3.jpg" };
            string[] kettlebells = new string[2] { "Kettlebells2.jpg", "Kettlebells3.jpg" };
            string[] yoga = new string[2] { "Yoga2.jpg", "Yoga3.jpg" };
            string[] pilates = new string[2] { "Pilates2.jpg", "Pilates3.jpg" };
            string[] strength = new string[2] { "Strength2.jpg", "Strength3.jpg" };
            string[] pics = new string[2];

            switch (Name)
            {
                case "Circuits":
                    pics = circuits;
                    break;
                case "Step":
                    pics = step;
                    break;
                case "Box Fit":
                    pics = boxfit;
                    break;
                case "Zumba":
                    pics = zumba;
                    break;
                case "Spinning":
                    pics = spin;
                    break;
                case "Burn It":
                    pics = burnit;
                    break;
                case "Combat":
                    pics = combat;
                    break;
                case "Absolute Abs":
                    pics = abs;
                    break;
                case "Legs, Bums, Tums":
                    pics = lbt;
                    break;
                case "BodyPump":
                    pics = pump;
                    break;
                case "Body Tone":
                    pics = tone;
                    break;
                case "Kettlebells":
                    pics = kettlebells;
                    break;
                case "Yoga":
                    pics = yoga;
                    break;
                case "Pilates":
                    pics = pilates;
                    break;
                case "Strength":
                    pics = strength;
                    break;
                default:
                    pics = abs;
                    break;
            }

            return pics;
        }


        public static string[] GetCategoryPic(string category)
        {

            string[] cardio = new string[7] { "BoxFit1.jpg", "BurnIt1.jpg", "Circuits1.jpg", "Combat1.jpg", "Spin1.jpg", "Step1.jpg", "Zumba1.jpg" };
            string[] tone = new string[5] { "AbsoluteAbs1.jpg", "BodyPump1.jpg", "BodyTone1.jpg", "Kettlebells1.jpg", "LegsBumsTums1.jpg" };
            string[] mind = new string[2] { "Pilates1.jpg", "Yoga1.jpg" };
            string[] strength = new string[1] { "Strength1.jpg" };
            string[] pics = new string[20];

            switch (category)
            {
                case "Cardio":
                    pics = cardio;
                    break;
                case "Tone":
                    pics = tone;
                    break;
                case "Mind":
                    pics = mind;
                    break;
                case "Strength":
                    pics = strength;
                    break;
                default:
                    pics = cardio;
                    break;
            }
            return pics;
        }

    }


}