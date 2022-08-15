using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCTraining.Models;
using static MVCTraining.Data.ApplicationDbcontext;

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
            if (!dbContext.FieldSurveys.Any(r => r.Area == "Norrköping"))
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

            if (!dbContext.FieldSurveys.Any(r => r.Area == "Söderköping"))
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
