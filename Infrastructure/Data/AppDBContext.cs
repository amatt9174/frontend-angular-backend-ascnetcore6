using System.Linq;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // The if statement below only pertains to if you are using an Sqlite test DB
            // because Sqlite does not handle decimal types so we would need to convert them
            // to double types where they are used.  Does not effect Sql Server which
            // is what we are using.  But I thought I would put it in anyway in case you want to test
            // with Sqlite but I don't see why unless Sql Server is not supported in a different
            // environment.  Sqlite works in all operating systems but so does Sql Server 2019
            // which is what we are using although it is Sql Express.
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in builder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));
                        
                    foreach (var property in properties)
                    {
                        builder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
            
            // builder.Entity<AppMember>().HasKey(k => k.AppMid);
            // builder.Entity<AppMember>().Property(p => p.AppMid).HasDefaultValueSql("NEWID()");

            // builder.Entity<AppMember>().HasIndex(i => i.AppTKey).IsUnique(false);
            // builder.Entity<AppMember>().Property(p => p.AppTKey).IsRequired(false).HasMaxLength(36);

            // builder.Entity<AppMember>().Property(p => p.EMail).IsRequired(true).HasMaxLength(100);
            // builder.Entity<AppMember>().Property(p => p.FirstName).IsRequired(true).HasMaxLength(40);
            // builder.Entity<AppMember>().Property(p => p.MiddleInitial).IsRequired(false).HasMaxLength(1);
            // builder.Entity<AppMember>().Property(P => P.LastName).IsRequired(true).HasMaxLength(40);
            // builder.Entity<AppMember>().Property(P => P.Status).IsRequired(true).HasMaxLength(40);

            // builder.Entity<AppMember>().Property(p => p.DateCreated )
            //     .IsRequired(true).HasDefaultValueSql("getdate()");   
            // builder.Entity<AppMember>().Property(p => p.DateUpdated )
            //     .IsRequired(true).HasDefaultValueSql("getdate()");   
        }
    }
}