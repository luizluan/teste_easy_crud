using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CRUD_EASY.MultiTenancy;

namespace CRUD_EASY.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}