using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CRUD_EASY.MultiTenancy.Dto;

namespace CRUD_EASY.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
