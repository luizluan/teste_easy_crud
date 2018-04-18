using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using CRUD_EASY.EntityFramework;

namespace CRUD_EASY
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(CRUD_EASYCoreModule))]
    public class CRUD_EASYDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CRUD_EASYDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
