using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyFamilyDashboard.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Public Properties 

        public DbSet<SettingsDataModel> Settings { get; set; }
        public DbSet<TodoListDataModel> TodoLists { get; set; }
        public DbSet<RecipeDataModel> Recipes { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor, expecting database options
        /// </summary>
        /// <param name="options">The database context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=PF0QCAMZ\\SQLEXPRESS;Database=MyFamilyDashboardEF;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecipeDataModel>().HasMany(r => r.Ingredients).WithOne(i => i.Recipe);
            //modelBuilder.Entity<SettingsDataModel>();
        }
    }

}
