using System.Threading.Tasks;
using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace EmployeeWebApplication.Authorization
{
    public class EmployeesAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Employee>
    {
        readonly UserManager<Employee> _userManager;

        public EmployeesAuthorizationHandler(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Employee resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(AuthorizationRoles.ExecutivesRole))
            {
                if (requirement == EmployeeOperations.Read || requirement == EmployeeOperations.DownloadAllEmployees)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if (context.User.IsInRole(AuthorizationRoles.ManagersRole))
            {
                if (requirement == EmployeeOperations.Read)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if (context.User.IsInRole(AuthorizationRoles.HumanResourcesRole))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(AuthorizationRoles.EmployeeRole) && resource != null)
            {
                var isCurrentUser = resource.Id == _userManager.GetUserId(context.User);

                if (isCurrentUser && (requirement == EmployeeOperations.Read || requirement == EmployeeOperations.ListExpenses))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
