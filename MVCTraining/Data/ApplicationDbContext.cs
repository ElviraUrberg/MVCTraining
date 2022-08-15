using Microsoft.EntityFrameworkCore;
using MVCTraining.Models;

namespace MVCTraining.Data
{
    public class ApplicationDbcontext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {

            }

            public DbSet<FieldSurvey> FieldSurveys { get; set; }
        }
    }
}
