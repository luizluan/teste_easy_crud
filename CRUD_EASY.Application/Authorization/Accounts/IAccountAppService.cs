using System.Threading.Tasks;
using Abp.Application.Services;
using CRUD_EASY.Authorization.Accounts.Dto;

namespace CRUD_EASY.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
