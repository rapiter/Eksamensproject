using System;
using EksamensProject.Core.Entity;
using Microsoft.EntityFrameworkCore.Internal;

namespace EksamensProject.Infrastructure.SQL
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(EksamensProjectContext context)
        {
            // Deletes and creates database
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            var admin = new User()
            {
                Name = "Max",
                Email = "max@uldahl.dk"
            };
            
            var user = new User()
            {
                Name = "Thomas",
                Email = "thomas@example.dk"
            };

            var style = new Style()
            {
                Era = "New time",
                Name = "Wauw"
            };
            
            var tempo = new Tempo()
            {
                TempoMarking = TempoMarking.Adagietto,
                TimeSignature = TimeSignature.FourFour,
                BeatsPerMinute = 40
            };
            
            var composition = new Composition()
            {
                Duration = 1.1,
                Name = "Yay",
                Style = style,
                Tempo = tempo,
                Year = "2012",
                URL = "https://www.mboxdrive.com/Heaven%20&%20Hell.mp3",
                PictureURL = "https://i.ibb.co/JdftBvn/fuldmaane.jpg",
                Comment = "Epic and adventurous composition"
            };

            var composition2 = new Composition()
            {
                Name = "Someone Is Watching",
                Style = style,
                Tempo = tempo,
                Year = "2012",
                URL = "https://www.mboxdrive.com/Someone%20Is%20Watching.mp3",
                PictureURL = "https://i.ibb.co/JdftBvn/fuldmaane.jpg",
                Comment = "Suspenseful orchestration"
            };
            
            var testimonial = new Testimonial()
            {
                User = admin,
                TestimonialHeader = "Excellent",
                TestimonialBody = "NICE"
            };
            
            var testimonial2 = new Testimonial()
            {
                User = user,
                TestimonialHeader = "Excellent",
                TestimonialBody = "NICE"
            };
            
            var request = new Request()
            {
                User = user,
                RequestHeader = "Classical music for movie",
                RequestBody = "New danish movie about..."
                
            };
            
            // Adding
            context.Users.Add(admin);
            context.Compositions.Add(composition);
            context.Compositions.Add(composition2);
            context.Testimonials.Add(testimonial);
            context.Testimonials.Add(testimonial2);
            context.Requests.Add(request);
            context.SaveChanges();

        }
    }
}