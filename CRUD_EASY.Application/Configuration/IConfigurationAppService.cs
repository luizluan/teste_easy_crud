using System.Threading.Tasks;
using Abp.Application.Services;
using CRUD_EASY.Configuration.Dto;

namespace CRUD_EASY.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}