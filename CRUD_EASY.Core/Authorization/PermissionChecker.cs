using Abp.Authorization;
using CRUD_EASY.Authorization.Roles;
using CRUD_EASY.Authorization.Users;

namespace CRUD_EASY.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
