using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymBooker1.Models
{
    //public class MyUser : IdentityUser
    //{
    //    public virtual MyUserInfo MyUserInfo { get; set; }
    //}

    //public class MyUserInfo
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}

    

    /*
    public class MyDbContext : IdentityDbContext<MyUser>
    {
        public MyDbContext()
            : base("DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<MyUserInfo> MyUserInfo { get; set; }
    }
    */


}


//context.GymClasses.AddOrUpdate(x => x.Id,
//                new GymClass() { Id = 1, Name = "BodyPump", Description = "Addictive workout challenges all of your major muscle groups by using a blend of the best gym exercises including squats, pressing and pulling movements. Using high repetitions and light weights, this class will help you to achieve a more toned and healthy body." },
//                new GymClass() { Id = 2, Name = "Pilates", Description = "A system of physical conditioning involving low-impact exercises and stretches designed to strengthen muscles of the torso and often performed using specialised equipment. Great if your goal is weight loss, toning, strength & conditioning, build muscle, training for an event or general fitness." },
//                new GymClass() { Id = 3, Name = "Spinning", Description = "Group cycling classes combine interval based cycling drills with music to create challenging workouts for participants of all fitness levels." },
//                new GymClass() { Id = 4, Name = "Kettlebells", Description = "Strengthen and tone your whole body! You will swing, lunge and squat your way to a more toned body whilst improving your strength, flexibility and cardiovascular endurance in our Kettlebells class. Come join a class and get to grips with a kettlebell, and find out why it's a powerful tool for improving your fitness and overall body composition." },
//                new GymClass() { Id = 5, Name = "Yoga", Description = "Focuses on tuning into the body, building strength and maintaining flexibility for functional movements" },               
//                new GymClass() { Id = 6, Name = "Circuits", Description = "A high intensity workout that will help tone your body and shed fat, this is a great class to attend. Circuits is a high energy and fast-paced class which involves working your way around different exercise stations performing each exercise as many times as you can in a set amount of time. Join in this classic class for a fun way to work out!" },
//                new GymClass() { Id = 7, Name = "Box Fit", Description = "A circuit style blend of many different fighting related exercises and drills. Incorporating the bag, battle ropes, skipping and some TRX. Participants will also pair up to perform some pad work. This class packs a real punch!" },
//                new GymClass() { Id = 8, Name = "Step", Description = "This great cardio workout is choreographed. As you progress, so will the movements, always giving you something new and fun to experience in the class. You’ll have a fantastic athletic workout that helps to burn fat and tone up to some great music! Great if your goal is weight loss, toning or general fitness." },
//                new GymClass() { Id = 9, Name = "Combat", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." },
//                new GymClass() { Id = 10, Name = "Zumba", Description = "Join the party with this fusion of Latin international rhythms and easy-to-follow moves. Through both low and high intensity movements, you’ll be dancing your way through this calorie burning dance workout. Great if your goal is weight loss or general fitness." },
//                new GymClass() { Id = 11, Name = "Strength", Description = "Develop your full body STRENGTH!Each class includes 8 strength exercises with perfect form and control to hit the whole body.Plus, we always end with a finisher exercise to make sure you leave with those post-workout endorphins rushing round your body!" },
//                new GymClass() { Id = 12, Name = "Legs, Bums, Tums", Description = "Shape up and burn fat as you lunge, step and squat your way to fitness in this ever-popular, fun class using both weights and your own bodyweight. The high repetition based routines will put your legs, bums and tums through their paces in a bid to trim down those areas we love to hate - trust us, your body will thank you for it!" },
//                new GymClass() { Id = 13, Name = "Body Tone", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" },
//                new GymClass() { Id = 14, Name = "Burn It", Description = "Spending as much time as possible in your optimum training zone for burning calories and fat, this session focusses on using only your bodyweight in varying styles of High Intensity Interval Training (HIIT) including Tabata (eight rounds of 20-seconds-on, 10-seconds-off intervals). Expect to see side effects such as burning more calories for longer after your workout and generally feeling awesome! Great if you’re looking to shape up, trim down and seriously boost your fitness levels." },
//                new GymClass() { Id = 15, Name = "Absolute Abs", Description = "A class designed to target the area we all love to hate! Whether your goal is a 6 pack or a flat stomach… crunch, twist and plank your way to the abs you’ve always wanted. Are you ready to put your core to the test?" }
//            );