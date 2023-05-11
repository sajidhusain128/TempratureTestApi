using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{

    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// This is construnctor of ApplicationDbContext which initialize the database model.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<TempUnitConversion> TempUnitConversion { get; set; }
    }
}
