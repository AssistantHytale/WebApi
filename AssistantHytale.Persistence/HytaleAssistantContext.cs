using Microsoft.EntityFrameworkCore;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence
{
    public class HytaleAssistantContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Server> Servers { get; set; }


        public HytaleAssistantContext(DbContextOptions<HytaleAssistantContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User.MapRelationships(modelBuilder);
            UserPermission.MapRelationships(modelBuilder);
            Contributor.MapRelationships(modelBuilder);
            Setting.MapRelationships(modelBuilder);
            Server.MapRelationships(modelBuilder);
        }
    }

}
