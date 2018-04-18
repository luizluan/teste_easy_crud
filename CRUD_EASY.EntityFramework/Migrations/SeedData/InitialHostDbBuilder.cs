using CRUD_EASY.EntityFramework;
using EntityFramework.DynamicFilters;

namespace CRUD_EASY.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly CRUD_EASYDbContext _context;

        public InitialHostDbBuilder(CRUD_EASYDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
