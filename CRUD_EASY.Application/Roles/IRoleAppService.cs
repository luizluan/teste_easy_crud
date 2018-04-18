using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CRUD_EASY.Roles.Dto;

namespace CRUD_EASY.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
