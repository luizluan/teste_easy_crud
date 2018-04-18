using System.Threading.Tasks;
using Abp.Application.Services;
using CRUD_EASY.Sessions.Dto;

namespace CRUD_EASY.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
