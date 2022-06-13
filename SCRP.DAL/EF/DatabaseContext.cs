using SCRP.Foundation.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRP.DAL.EF
{
    public class DatabaseContext : DbContext
    {

        public DbSet<HelpCampaignDetail> HelpCampaignDetails { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<ImagePostMapping> ImagePostMappings { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<MemberHelpCampaignMapping> MemberHelpCampaignMappings { get; set; }



        //public DbSet<MemberHelpCampaign> MemberHelpCampaigns { get; set; }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<PetType> PetTypes { get; set; }

        public DbSet<PostType> PostTypes { get; set; }







        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DatabaseContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }



    }
}
