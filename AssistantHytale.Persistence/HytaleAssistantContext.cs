using Microsoft.EntityFrameworkCore;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence
{
    public class HytaleAssistantContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<GuideMeta> GuideMetas { get; set; }
        public DbSet<GuideDetail> GuideDetails { get; set; }
        public DbSet<GuideMetaGuideDetail> GuideMetaGuideDetails { get; set; }
        public DbSet<GuideContent> GuideContents { get; set; }


        public HytaleAssistantContext(DbContextOptions<HytaleAssistantContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("data source=localhost;initial catalog=NMS_Assistant;Integrated Security=True;MultipleActiveResultSets=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User.MapRelationships(modelBuilder);
            Permission.MapRelationships(modelBuilder);
            UserPermission.MapRelationships(modelBuilder);
            Contributor.MapRelationships(modelBuilder);
            Setting.MapRelationships(modelBuilder);
            Server.MapRelationships(modelBuilder);
            GuideMeta.MapRelationships(modelBuilder);
            GuideDetail.MapRelationships(modelBuilder);
            GuideMetaGuideDetail.MapRelationships(modelBuilder);
            GuideContent.MapRelationships(modelBuilder);
        }
    }

}
