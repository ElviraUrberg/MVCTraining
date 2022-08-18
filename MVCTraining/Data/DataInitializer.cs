using Microsoft.EntityFrameworkCore;
using MVCTraining.Models;
using static MVCTraining.Data.ApplicationDbContext;

namespace MVCTraining.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();

            SeedFieldsurveys(dbContext);
        }

        private static void SeedFieldsurveys(ApplicationDbContext dbContext)
        {
            if (!dbContext.FieldSurveys.Any(r => r.Category == "Skadat räcke" && r.Latitude == 58.5535 && r.Longitude == 16.2410))
            {
                dbContext.FieldSurveys.Add(new FieldSurvey
                {
                    Service = "Felanmälan",
                    Area = "Norrköping",
                    Category = "Skadat räcke",
                    Status = "Ladda upp som ny",
                    Photopath = "https://picsum.photos/200/300",
                    Comment = "Skadat räcke vid E22",
                    Latitude = 58.5535,
                    Longitude = 16.2410
                });
            }

            if (!dbContext.FieldSurveys.Any(r => r.Category == "Ojämn väg" && r.Latitude == 58.4931 && r.Longitude == 16.3064))
            {
                dbContext.FieldSurveys.Add(new FieldSurvey
                {
                    Service = "Felanmälan",
                    Area = "Söderköping",
                    Category = "Ojämn väg",
                    Status = "Ladda upp som ny",
                    Photopath = "https://picsum.photos/200/300",
                    Comment = "Ojämn väg",
                    Latitude = 58.4931,
                    Longitude = 16.3064
                });
            }

            dbContext.SaveChanges();
        }
    }
}
