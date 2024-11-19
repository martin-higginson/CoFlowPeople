using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions.Internal;
using CoFlowPeople.Server.Utils;
using CoFlowPeople.Server.Models.Data;

namespace CoFlowPeople.Server.Data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        

        

        public DbSet<Person> Person { get; set; }

		public void Migrate()
		{
            //Database.Migrate();

            // Add Seed Data...
            this.Add(new Person()
            {
                Id = 1,
                FirstName = "Joe",
                LastName = "Soap",
                DateOfBirth = new DateTime(year: 1982, month: 06, day: 06),
                DateCreated = DateTime.Now

            });


            this.SaveChanges();



		}

		protected static void UseSingularTableNames(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName().ToSnake().ToLower());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_configuration.GetValue("DB:ConnectionString", ""))
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UseSingularTableNames(modelBuilder);
        }


    }
}
