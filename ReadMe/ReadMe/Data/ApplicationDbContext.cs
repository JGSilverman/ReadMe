using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReadMe.Models;

namespace ReadMe.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {}

        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Story>(e =>
            {
                e.HasKey(x => x.StoryId);
                e.HasIndex(x => x.AuthorId);

                e.Property(x => x.Title).IsUnicode(false).IsRequired(true);
                e.Property(x => x.Blurb).IsUnicode(false).IsRequired(true);
                e.Property(x => x.Content).IsUnicode(false).IsRequired(true);
                e.Property(x => x.Tags).IsUnicode(false).IsRequired(false);
                e.Property(x => x.ContentWarnings).IsUnicode(false).IsRequired(false);
                e.Property(x => x.AuthorId).IsUnicode(false).IsRequired(true);
                e.Property(x => x.CreatedBy).IsUnicode(false).IsRequired(true);
                e.Property(x => x.ModifiedBy).IsUnicode(false).IsRequired(true);
                e.Property(x => x.CreatedOn).IsUnicode(false).IsRequired(true);
                e.Property(x => x.ModifiedOn).IsUnicode(false).IsRequired(true);
            });
        }
    }
}