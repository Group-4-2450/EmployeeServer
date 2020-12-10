using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Authorization
{
    public class EmployeeExpensesAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, EmployeeExpenses>
    {
        readonly UserManager<Employee> _userManager;

        public EmployeeExpensesAuthorizationHandler(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, EmployeeExpenses resource)
        {
            if(context.User == null)
            {
                return Task.CompletedTask;
            }

            if(context.User.IsInRole(AuthorizationRoles.ExecutivesRole))
            {
                return Task.CompletedTask;
            }

            if(context.User.IsInRole(AuthorizationRoles.ManagersRole))
            {
                return Task.CompletedTask;
            }

            if(context.User.IsInRole(AuthorizationRoles.HumanResourcesRole))
            {
                if(requirement == EmployeeExpensesOperations.Read || requirement == EmployeeExpensesOperations.Create 
                    || requirement == EmployeeExpensesOperations.Update)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if(context.User.IsInRole(AuthorizationRoles.EmployeeRole))
            {
                var creatingNew = resource.Id == default && requirement == EmployeeExpensesOperations.Create;

                if(creatingNew)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            return Task.CompletedTask;
        }
    }
}
