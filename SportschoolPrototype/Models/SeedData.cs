using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportschoolPrototype.Data;
using SportschoolPrototype.Models;
using System;
using System.Linq;

namespace SportschoolPrototype.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DatabaseContext>>()))
            {
                // make sure the DB is created
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.members.Any())
                {
                    return;   // DB has been seeded
                }

                var subscriptions = new Subscription[]
                {
                    new Subscription{courseID=1, title="1x per week", description="Used to gain entry once a week", weeklyUses=1},
                    new Subscription{courseID=2, title="3x per week", description="Used to gain entry thrice a week", weeklyUses=3},
                    new Subscription{courseID=3, title="Unlimited", description="Unlimited entry", weeklyUses=99},
                }; 

                foreach (Subscription c in subscriptions)
                {
                    context.subscriptions.Add(c);
                }

                context.SaveChanges();

                var members = new Member[]
                {
                    new Member{firstname="Eva",lastname="Dekkers", subscriptionId=3, TimesLeft=99},
                    new Member{firstname="Gianni",lastname="Cimanez", subscriptionId=3, TimesLeft=99},
                    new Member{firstname="Bart", lastname="Kuppeveld", subscriptionId=2, TimesLeft=3},
                };

                foreach (Member s in members)
                {
                    context.members.Add(s);
                }

                context.SaveChanges();


                var personel = new Personel[]
                {
                    new Personel{firstname="Mike", lastname="Hermsen", typeOfStaff="Janitor"},
                    new Personel{firstname="Rick", lastname="de Jong", typeOfStaff="Personal Coach"},
                    new Personel{firstname="Thomas", lastname="Weijers", typeOfStaff="Personal Coach"},
                };

                foreach (Personel v in personel)
                {
                    context.staff.Add(v);
                }

                context.SaveChanges();

                Member m = new Member { firstname = "john", lastname = "Doe" };
                Member n = new Member { firstname = "Live", lastname = "Love" };

                // Seeding data for courses
                var courses = new Course[]
                {
                    new Course{CourseID=100, coach=null, title="Pilates", description="Pilates lessons for beginners"},
                    new Course{CourseID=110, coach=null, title="Yoga", description="Yoga lessons for beginners"},
                    new Course{CourseID=120, coach=null, title="Poledancing", description="Poledancing lessons for beginners"} 
                };

                foreach (Course course in courses)
                {
                    context.courses.Add(course);
                }

                context.SaveChanges();
            }
        }
    }
}