using System.Linq;
using CRUD_EASY.EntityFramework;
using CRUD_EASY.MultiTenancy;

namespace CRUD_EASY.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly CRUD_EASYDbContext _context;

        public DefaultTenantCreator(CRUD_EASYDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
