using System.Linq;
using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using CRUD_EASY.EntityFramework;

namespace CRUD_EASY.Migrations.SeedData
{
    public class DefaultSettingsCreator
    {
        private readonly CRUD_EASYDbContext _context;

        public DefaultSettingsCreator(CRUD_EASYDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com");
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer");

            //Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en");
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}