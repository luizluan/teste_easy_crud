using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using CRUD_EASY.EntityFramework;

namespace CRUD_EASY.Migrator
{
    [DependsOn(typeof(CRUD_EASYDataModule))]
    public class CRUD_EASYMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<CRUD_EASYDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}