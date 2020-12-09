﻿using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace EmployeeWebApplication.Authorization
{
    public class EmployeeExpensesOperations
    {
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement { Name = nameof(Create) };

        public static OperationAuthorizationRequirement Read = new OperationAuthorizationRequirement { Name = nameof(Read) };

        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement { Name = nameof(Update) };

        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = nameof(Delete) };
    }
}
