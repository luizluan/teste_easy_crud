using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using CRUD_EASY.Authorization.Users;
using CRUD_EASY.MultiTenancy;
using CRUD_EASY.Users;
using Microsoft.AspNet.Identity;

namespace CRUD_EASY
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class CRUD_EASYAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected CRUD_EASYAppServiceBase()
        {
            LocalizationSourceName = CRUD_EASYConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}