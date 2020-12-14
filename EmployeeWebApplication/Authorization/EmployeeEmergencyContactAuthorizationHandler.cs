using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Authorization
{
    public class EmployeeEmergencyContactAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, EmployeeEmergencyContact>
    {
        readonly UserManager<Employee> _userManager;

        public EmployeeEmergencyContactAuthorizationHandler(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, EmployeeEmergencyContact resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(AuthorizationRoles.ExecutivesRole))
            {
                if (requirement == EmployeeEmergencyContactOperations.Read)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if (context.User.IsInRole(AuthorizationRoles.ManagersRole))
            {
                if (requirement == EmployeeEmergencyContactOperations.Read)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if (context.User.IsInRole(AuthorizationRoles.HumanResourcesRole))
            {
                if (requirement == EmployeeEmergencyContactOperations.Read)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if (context.User.IsInRole(AuthorizationRoles.EmployeeRole))
            {
                var creatingNew = resource.Id == default && requirement == EmployeeEmergencyContactOperations.Create;
                var updatingOwn = resource != null && resource.EmployeeId == _userManager.GetUserId(context.User);

                if (creatingNew || updatingOwn)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
