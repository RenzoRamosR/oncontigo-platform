using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration.Extensions;
using oncontigo_platform.IAM.Domain.Model.Aggregates;

namespace oncontigo_platform.Shared.Infrastructure.Persistence.EPC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            builder.Entity<>().ToTable("F");
            builder.Entity<>().HasKey(f => f.Id);
            builder.Entity<>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<>().Property(f => f.NewsApiKey).IsRequired();
            builder.Entity<>().Property(f => f.SourceId).IsRequired();
            **/
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(c => c.Id);
            builder.Entity<User>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(c => c.Email).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(c => c.PasswordHash).IsRequired();
            builder.UseSnakeCaseNamingConvention();

        }
    }
}
