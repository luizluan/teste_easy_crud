using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CRUD_EASY.Roles.Dto;
using CRUD_EASY.Users.Dto;

namespace CRUD_EASY.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}