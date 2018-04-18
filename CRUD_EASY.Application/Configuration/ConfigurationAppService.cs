using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CRUD_EASY.Configuration.Dto;

namespace CRUD_EASY.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CRUD_EASYAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
