using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using CRUD_EASY.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace CRUD_EASY.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CRUD_EASY.EntityFramework.CRUD_EASYDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CRUD_EASY";
        }

        protected override void Seed(CRUD_EASY.EntityFramework.CRUD_EASYDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
