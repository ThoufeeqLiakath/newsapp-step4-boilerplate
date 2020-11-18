using Entities;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.RA;
namespace DAL
{
    //Inherit DbContext class and use Entity Framework Code First Approach
    public class NewsDbContext:DbContext
    {
        /*
        This class should be used as DbContext to speak to database and should make the use of 
        Code First Approach. It should autogenerate the database based upon the model class in 
        your application
        */
        public NewsDbContext()
        {

        }
        public NewsDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here
            modelBuilder.Entity<UserProfile>().HasKey(x => x.UserId);
            modelBuilder.Entity<UserProfile>().Property(x => x.UserId).ValueGeneratedNever();
            modelBuilder.Entity<UserProfile>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(x => x.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");            
            
            
            modelBuilder.Entity<News>().HasKey(x => x.NewsId);
            modelBuilder.Entity<News>().Property(x => x.NewsId).ValueGeneratedOnAdd();
            modelBuilder.Entity<News>().Property(x => x.NewsId).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.Content).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.PublishedAt).IsRequired();
            modelBuilder.Entity<News>().Property(x => x.PublishedAt).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            

            modelBuilder.Entity<Reminder>().HasKey(x => x.ReminderId);
            modelBuilder.Entity<Reminder>().Property(x => x.ReminderId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Reminder>().Property(x => x.ReminderId).IsRequired();
            modelBuilder.Entity<Reminder>().Property(x => x.Schedule).IsRequired();
            modelBuilder.Entity<Reminder>().Property(x => x.NewsId).IsRequired();

        }
        //Create a Dbset for News,USerProfile and Reminders

        public DbSet<News> NewsList { get; set; }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        /*Override OnModelCreating function to configure relationship between entities and initialize*/
        
    }
}

