using Abp.AutoMapper;
using CRUD_EASY.Sessions.Dto;

namespace CRUD_EASY.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}