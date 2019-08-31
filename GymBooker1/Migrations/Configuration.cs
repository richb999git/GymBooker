namespace GymBooker1.Migrations
{
    using GymBooker1.Controllers;
    using GymBooker1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymBooker1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GymBooker1.Models.ApplicationDbContext";
        }

        protected override void Seed(GymBooker1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            

            AddClasses();
            
            //var x = new TimetableController();
            //x.UpdateCalendar();

            void AddClasses()
            {
                var BodyPump =      new GymClass() { Category = "Tone", Name = "BodyPump", Description = "Addictive workout challenges all of your major muscle groups by using a blend of the best gym exercises including squats, pressing and pulling movements. Using high repetitions and light weights, this class will help you to achieve a more toned and healthy body." };
                var Pilates =       new GymClass() { Category = "Mind", Name = "Pilates", Description = "A system of physical conditioning involving low-impact exercises and stretches designed to strengthen muscles of the torso and often performed using specialised equipment. Great if your goal is weight loss, toning, strength & conditioning, build muscle, training for an event or general fitness." };
                var Spinning =      new GymClass() { Category = "Cardio", Name = "Spinning", Description = "Group cycling classes combine interval based cycling drills with music to create challenging workouts for participants of all fitness levels." };
                var Kettlebells =   new GymClass() { Category = "Tone", Name = "Kettlebells", Description = "Strengthen and tone your whole body! You will swing, lunge and squat your way to a more toned body whilst improving your strength, flexibility and cardiovascular endurance in our Kettlebells class. Come join a class and get to grips with a kettlebell, and find out why it's a powerful tool for improving your fitness and overall body composition." };
                var Yoga =          new GymClass() { Category = "Mind", Name = "Yoga", Description = "Focuses on tuning into the body, building strength and maintaining flexibility for functional movements" };               
                var Circuits =      new GymClass() { Category = "Cardio", Name = "Circuits", Description = "A high intensity workout that will help tone your body and shed fat, this is a great class to attend. Circuits is a high energy and fast-paced class which involves working your way around different exercise stations performing each exercise as many times as you can in a set amount of time. Join in this classic class for a fun way to work out!" };
                var BoxFit =        new GymClass() { Category = "Cardio", Name = "Box Fit", Description = "A circuit style blend of many different fighting related exercises and drills. Incorporating the bag, battle ropes, skipping and some TRX. Participants will also pair up to perform some pad work. This class packs a real punch!" };
                var Step =          new GymClass() { Category = "Cardio", Name = "Step", Description = "This great cardio workout is choreographed. As you progress, so will the movements, always giving you something new and fun to experience in the class. You’ll have a fantastic athletic workout that helps to burn fat and tone up to some great music! Great if your goal is weight loss, toning or general fitness." };
                var Combat =        new GymClass() { Category = "Cardio", Name = "Combat", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." };
                var Zumba =         new GymClass() { Category = "Cardio", Name = "Zumba", Description = "Join the party with this fusion of Latin international rhythms and easy-to-follow moves. Through both low and high intensity movements, you’ll be dancing your way through this calorie burning dance workout. Great if your goal is weight loss or general fitness." };
                var Strength =      new GymClass() { Category = "Strength", Name = "Strength", Description = "Develop your full body STRENGTH! Each class includes 8 strength exercises with perfect form and control to hit the whole body.Plus, we always end with a finisher exercise to make sure you leave with those post-workout endorphins rushing round your body!" };
                var LegsBumsTums =  new GymClass() { Category = "Tone", Name = "Legs, Bums, Tums", Description = "Shape up and burn fat as you lunge, step and squat your way to fitness in this ever-popular, fun class using both weights and your own bodyweight. The high repetition based routines will put your legs, bums and tums through their paces in a bid to trim down those areas we love to hate - trust us, your body will thank you for it!" };
                var BodyTone =      new GymClass() { Category = "Tone", Name = "Body Tone", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" };
                var BurnIt =        new GymClass() { Category = "Cardio", Name = "Burn It", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." };
                var AbsoluteAbs =   new GymClass() { Category = "Tone", Name = "Absolute Abs", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" };

                if (!context.GymClasses.Any())
                {
                    context.GymClasses.AddOrUpdate((p => p.Name), BodyPump, Pilates, Spinning, Kettlebells, Yoga, Circuits, BoxFit, Step, Combat, Zumba, Strength, LegsBumsTums, BodyTone, BurnIt, AbsoluteAbs);
                }

                if (!context.StdGymClassTimetables.Any())
                {
                        context.StdGymClassTimetables.AddOrUpdate(
                        //    // because it's not been saved the foreign key value is not available and you cant just use an integer
                        
                        new StdGymClassTimetable() { GymClassId = BodyPump, Day = 0, Hour = 8, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Pilates, Day = 0, Hour = 9, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Spinning, Day = 0, Hour = 10, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 0, Hour = 11, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Yoga, Day = 0, Hour = 13, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Circuits, Day = 0, Hour = 14, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = BoxFit, Day = 0, Hour = 15, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Step, Day = 0, Hour = 16, Minute = 45, MaxPeople = 20 },
                        

                        new StdGymClassTimetable() { GymClassId = BodyPump, Day = 1, Hour = 6, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Pilates, Day = 1, Hour = 7, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Spinning, Day = 1, Hour = 8, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 1, Hour = 9, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Yoga, Day = 1, Hour = 11, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Circuits, Day = 1, Hour = 12, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = BoxFit, Day = 1, Hour = 13, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Step, Day = 1, Hour = 14, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Combat, Day = 1, Hour = 16, Minute = 0, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = Strength, Day = 1, Hour = 17, Minute = 15, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = AbsoluteAbs, Day = 1, Hour = 18, Minute = 30, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = BodyTone, Day = 1, Hour = 19, Minute = 45, MaxPeople = 20 },
                        new StdGymClassTimetable() { GymClassId = BurnIt, Day = 1, Hour = 21, Minute = 0, MaxPeople = 20 },

                        new StdGymClassTimetable() { GymClassId = BodyPump, Day = 2, Hour = 7, Minute = 0, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Pilates, Day = 2, Hour = 8, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Spinning, Day = 2, Hour = 9, Minute = 30, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 2, Hour = 10, Minute = 45, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Yoga, Day = 2, Hour = 12, Minute = 0, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Circuits, Day = 2, Hour = 13, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = BoxFit, Day = 2, Hour = 14, Minute = 30, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Step, Day = 2, Hour = 15, Minute = 45, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Combat, Day = 2, Hour = 16, Minute = 0, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = Strength, Day = 2, Hour = 18, Minute = 15, Instructor = "John Deer", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = AbsoluteAbs, Day = 2, Hour = 19, Minute = 30, Instructor = "John Deer", Hall = "Hall 2", MaxPeople = 25 },
                        new StdGymClassTimetable() { GymClassId = BodyTone, Day = 2, Hour = 20, Minute = 45, Instructor = "John Deer", MaxPeople = 20 },

                        new StdGymClassTimetable() { GymClassId = BodyPump, Day = 3, Hour = 8, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = Pilates, Day = 3, Hour = 9, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = Spinning, Day = 3, Hour = 10, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 3, Hour = 11, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = Yoga, Day = 3, Hour = 13, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = Circuits, Day = 3, Hour = 14, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = BoxFit, Day = 3, Hour = 15, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = Step, Day = 3, Hour = 16, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = Combat, Day = 3, Hour = 17, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = Strength, Day = 3, Hour = 19, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = AbsoluteAbs, Day = 3, Hour = 20, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = BodyTone, Day = 3, Hour = 6, Minute = 45 },

                        new StdGymClassTimetable() { GymClassId = BodyPump, Day = 4, Hour = 9, Minute = 0, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Pilates, Day = 4, Hour = 10, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Spinning, Day = 4, Hour = 11, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 4, Hour = 12, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Yoga, Day = 4, Hour = 13, Minute = 0, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Circuits, Day = 4, Hour = 15, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = BoxFit, Day = 4, Hour = 16, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Step, Day = 4, Hour = 17, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Combat, Day = 4, Hour = 18, Minute = 0, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = Strength, Day = 4, Hour = 20, Minute = 15, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = AbsoluteAbs, Day = 4, Hour = 6, Minute = 30, Instructor = "Steve Jobs", MaxPeople = 30 },
                        new StdGymClassTimetable() { GymClassId = BodyTone, Day = 4, Hour = 7, Minute = 45, Instructor = "Steve Jobs", Hall = "Hall 2", MaxPeople = 30 },

                        new StdGymClassTimetable() { GymClassId = BodyPump, Day = 5, Hour = 10, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = Pilates, Day = 5, Hour = 11, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = Spinning, Day = 5, Hour = 12, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 5, Hour = 13, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = Yoga, Day = 5, Hour = 14, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = Circuits, Day = 5, Hour = 16, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = BoxFit, Day = 5, Hour = 17, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = Step, Day = 5, Hour = 18, Minute = 45 },
                        new StdGymClassTimetable() { GymClassId = Combat, Day = 5, Hour = 20, Minute = 0 },
                        new StdGymClassTimetable() { GymClassId = Strength, Day = 5, Hour = 6, Minute = 15 },
                        new StdGymClassTimetable() { GymClassId = AbsoluteAbs, Day = 5, Hour = 7, Minute = 30 },
                        new StdGymClassTimetable() { GymClassId = BodyTone, Day = 5, Hour = 8, Minute = 45 },

                        new StdGymClassTimetable() { GymClassId = BodyPump, Day = 6, Hour = 7, Minute = 0, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = Pilates, Day = 6, Hour = 8, Minute = 15, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = Spinning, Day = 6, Hour = 9, Minute = 30, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 6, Hour = 10, Minute = 45, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = Yoga, Day = 6, Hour = 12, Minute = 0, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = Circuits, Day = 6, Hour = 13, Minute = 15, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = BoxFit, Day = 6, Hour = 14, Minute = 30, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = Step, Day = 6, Hour = 15, Minute = 45, Instructor = "Natalie Spears" },
                        new StdGymClassTimetable() { GymClassId = Combat, Day = 6, Hour = 16, Minute = 0, Instructor = "Natalie Spears", Hall = "Hall 2" },
                        new StdGymClassTimetable() { GymClassId = Strength, Day = 6, Hour = 17, Minute = 15, Instructor = "Natalie Spears" }

                    );

                }
 
                //context.Database.ExecuteSqlCommand("delete from StdGymClassTimetables");
                // 
                // or:
                //context.StdGymClassTimetables.RemoveRange(context.StdGymClassTimetables);
                //context.SaveChanges();
            }


            //context.GymClasses.AddOrUpdate(x => x.Id,
            //    new GymClass() { Id = 1, Name = "BodyPump", Description = "Addictive workout challenges all of your major muscle groups by using a blend of the best gym exercises including squats, pressing and pulling movements. Using high repetitions and light weights, this class will help you to achieve a more toned and healthy body." },
            //    new GymClass() { Id = 2, Name = "Pilates", Description = "A system of physical conditioning involving low-impact exercises and stretches designed to strengthen muscles of the torso and often performed using specialised equipment. Great if your goal is weight loss, toning, strength & conditioning, build muscle, training for an event or general fitness." },
            //    new GymClass() { Id = 3, Name = "Spinning", Description = "Group cycling classes combine interval based cycling drills with music to create challenging workouts for participants of all fitness levels." },
            //    new GymClass() { Id = 4, Name = "Kettlebells", Description = "Strengthen and tone your whole body! You will swing, lunge and squat your way to a more toned body whilst improving your strength, flexibility and cardiovascular endurance in our Kettlebells class. Come join a class and get to grips with a kettlebell, and find out why it's a powerful tool for improving your fitness and overall body composition." },
            //    new GymClass() { Id = 5, Name = "Yoga", Description = "Focuses on tuning into the body, building strength and maintaining flexibility for functional movements" },               
            //    new GymClass() { Id = 6, Name = "Circuits", Description = "A high intensity workout that will help tone your body and shed fat, this is a great class to attend. Circuits is a high energy and fast-paced class which involves working your way around different exercise stations performing each exercise as many times as you can in a set amount of time. Join in this classic class for a fun way to work out!" },
            //    new GymClass() { Id = 7, Name = "Box Fit", Description = "A circuit style blend of many different fighting related exercises and drills. Incorporating the bag, battle ropes, skipping and some TRX. Participants will also pair up to perform some pad work. This class packs a real punch!" },
            //    new GymClass() { Id = 8, Name = "Step", Description = "This great cardio workout is choreographed. As you progress, so will the movements, always giving you something new and fun to experience in the class. You’ll have a fantastic athletic workout that helps to burn fat and tone up to some great music! Great if your goal is weight loss, toning or general fitness." },
            //    new GymClass() { Id = 9, Name = "Combat", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." },
            //    new GymClass() { Id = 10, Name = "Zumba", Description = "Join the party with this fusion of Latin international rhythms and easy-to-follow moves. Through both low and high intensity movements, you’ll be dancing your way through this calorie burning dance workout. Great if your goal is weight loss or general fitness." },
            //    new GymClass() { Id = 11, Name = "Strength", Description = "Develop your full body STRENGTH!Each class includes 8 strength exercises with perfect form and control to hit the whole body.Plus, we always end with a finisher exercise to make sure you leave with those post-workout endorphins rushing round your body!" },
            //    new GymClass() { Id = 12, Name = "Legs, Bums, Tums", Description = "Shape up and burn fat as you lunge, step and squat your way to fitness in this ever-popular, fun class using both weights and your own bodyweight. The high repetition based routines will put your legs, bums and tums through their paces in a bid to trim down those areas we love to hate - trust us, your body will thank you for it!" },
            //    new GymClass() { Id = 13, Name = "Body Tone", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" },
            //    new GymClass() { Id = 14, Name = "Burn It", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." },
            //    new GymClass() { Id = 15, Name = "Absolute Abs", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" }
            //);

            //var BodyPump = context.GymClasses.First(c => c.Name == "BodyPump");
            //var Pilates = context.GymClasses.First(c => c.Name == "Pilates");
            //var Spinning = context.GymClasses.First(c => c.Name == "Spinning");
            //var Kettlebells = context.GymClasses.First(c => c.Name == "Kettlebells");
            //var Yoga = context.GymClasses.First(c => c.Name == "Yoga");
            //var Circuits = context.GymClasses.First(c => c.Name == "Circuits");
            //var BoxFit = context.GymClasses.First(c => c.Name == "Box Fit");
            //var Step = context.GymClasses.First(c => c.Name == "Step");
            //var Combat = context.GymClasses.First(c => c.Name == "Combat");
            //var Strength = context.GymClasses.First(c => c.Name == "Strength");
            //var AbsoluteAbs = context.GymClasses.First(c => c.Name == "Absolute Abs");
            //var BodyTone = context.GymClasses.First(c => c.Name == "Body Tone");
            //var BurnIt = context.GymClasses.First(c => c.Name == "Burn It");
            //var LegsBumsTums = context.GymClasses.First(c => c.Name == "Legs, Bums, Tums");
            //var Zumba = context.GymClasses.First(c => c.Name == "Zumba");

            //context.StdGymClassTimetables.AddOrUpdate(x => x.Id,
            //    // because it's not been saved the foreign key value is not available and you cant just use an integer



                //new StdGymClassTimetable() { GymClassId = BodyPump, Day = 1, Hour = 6, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = Pilates, Day = 1, Hour = 7, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = Spinning, Day = 1, Hour = 8, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 1, Hour = 9, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = Yoga, Day = 1, Hour = 11, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = Circuits, Day = 1, Hour = 12, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = BoxFit, Day = 1, Hour = 13, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = Step, Day = 1, Hour = 14, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = Combat, Day = 1, Hour = 16, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = Strength, Day = 1, Hour = 17, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = AbsoluteAbs, Day = 1, Hour = 18, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = BodyTone, Day = 1, Hour = 19, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = BurnIt, Day = 1, Hour = 21, Minute = 0 }

            //new StdGymClassTimetable() { GymClassId = BodyPump, Day = 2, Hour = 7, Minute = 0 },
            //new StdGymClassTimetable() { GymClassId = Pilates, Day = 2, Hour = 8, Minute = 15 },
            //new StdGymClassTimetable() { GymClassId = Spinning, Day = 2, Hour = 9, Minute = 30 },
            //new StdGymClassTimetable() { GymClassId = Kettlebells, Day = 2, Hour = 10, Minute = 45 },
            //new StdGymClassTimetable() { GymClassId = Yoga, Day = 2, Hour = 12, Minute = 0 },
            //new StdGymClassTimetable() { GymClassId = Circuits, Day = 2, Hour = 13, Minute = 15 },
            //new StdGymClassTimetable() { GymClassId = BoxFit, Day = 2, Hour = 14, Minute = 30 },
            //new StdGymClassTimetable() { GymClassId = Step, Day = 2, Hour = 15, Minute = 45 },
            //new StdGymClassTimetable() { GymClassId = Combat, Day = 2, Hour = 16, Minute = 0 },
            //new StdGymClassTimetable() { GymClassId = Strength, Day = 2, Hour = 18, Minute = 15 },
            //new StdGymClassTimetable() { GymClassId = AbsoluteAbs, Day = 2, Hour = 19, Minute = 30 },
            //new StdGymClassTimetable() { GymClassId = BodyTone, Day = 2, Hour = 20, Minute = 45 }

                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "BodyPump"), Day = 3, Hour = 8, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Pilates"), Day = 3, Hour = 9, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Spinning"), Day = 3, Hour = 10, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Kettlebells"), Day = 3, Hour = 11, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Yoga"), Day = 3, Hour = 13, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Circuits"), Day = 3, Hour = 14, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Box Fit"), Day = 3, Hour = 15, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Step"), Day = 3, Hour = 16, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Combat"), Day = 3, Hour = 17, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Strength"), Day = 3, Hour = 19, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Absolute Abs"), Day = 3, Hour = 20, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Body Tone"), Day = 3, Hour = 6, Minute = 45 },

                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "BodyPump"), Day = 4, Hour = 9, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Pilates"), Day = 4, Hour = 10, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Spinning"), Day = 4, Hour = 11, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Kettlebells"), Day = 4, Hour = 12, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Yoga"), Day = 4, Hour = 13, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Circuits"), Day = 4, Hour = 15, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Box Fit"), Day = 4, Hour = 16, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Step"), Day = 4, Hour = 17, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Combat"), Day = 4, Hour = 18, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Strength"), Day = 4, Hour = 20, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Absolute Abs"), Day = 4, Hour = 6, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Body Tone"), Day = 4, Hour = 7, Minute = 45 },

                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "BodyPump"), Day = 5, Hour = 10, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Pilates"), Day = 5, Hour = 11, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Spinning"), Day = 5, Hour = 12, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Kettlebells"), Day = 5, Hour = 13, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Yoga"), Day = 5, Hour = 14, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Circuits"), Day = 5, Hour = 16, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Box Fit"), Day = 5, Hour = 17, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Step"), Day = 5, Hour = 18, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Combat"), Day = 5, Hour = 20, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Strength"), Day = 5, Hour = 6, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Absolute Abs"), Day = 5, Hour = 7, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Body Tone"), Day = 5, Hour = 8, Minute = 45 },

                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "BodyPump"), Day = 6, Hour = 7, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Pilates"), Day = 6, Hour = 8, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Spinning"), Day = 6, Hour = 9, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Kettlebells"), Day = 6, Hour = 10, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Yoga"), Day = 6, Hour = 12, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Circuits"), Day = 6, Hour = 13, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Box Fit"), Day = 6, Hour = 14, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Step"), Day = 6, Hour = 15, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Combat"), Day = 6, Hour = 16, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Strength"), Day = 6, Hour = 17, Minute = 15 },

                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "BodyPump"), Day = 7, Hour = 8, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Pilates"), Day = 7, Hour = 9, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Spinning"), Day = 7, Hour = 10, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Kettlebells"), Day = 7, Hour = 11, Minute = 45 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Yoga"), Day = 7, Hour = 13, Minute = 0 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Circuits"), Day = 7, Hour = 14, Minute = 15 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Box Fit"), Day = 7, Hour = 15, Minute = 30 },
                //new StdGymClassTimetable() { GymClassId = context.GymClasses.First(c => c.Name == "Step"), Day = 7, Hour = 16, Minute = 45 }



                //);



        }


    }
}
