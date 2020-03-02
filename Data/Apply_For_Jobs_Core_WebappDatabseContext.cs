using Microsoft.EntityFrameworkCore;

namespace Apply_Jobs.Models
{
    //The databse context responsible for connecting to the databse and mapping the business layer classes.
    public class Apply_JobsDatabseContext : DbContext
    {
        public Apply_JobsDatabseContext(DbContextOptions<Apply_JobsDatabseContext> options)
            : base(options)
        {
        }

        public DbSet<Apply_Jobs.BusinessLayer.Advertisement> Advertisement { get; set; }

        public DbSet<Apply_Jobs.BusinessLayer.Application> Application { get; set; }

        public DbSet<Apply_Jobs.BusinessLayer.Candidate> Candidate { get; set; }

        public DbSet<Apply_Jobs.BusinessLayer.Employer> Employer { get; set; }
    }
}
