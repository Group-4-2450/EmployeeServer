﻿using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace EmployeeWebApplication.Authorization
{
    public static class EmployeeOperations
    {
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement { Name = nameof(Create) };

        public static OperationAuthorizationRequirement Read = new OperationAuthorizationRequirement { Name = nameof(Read) };
        
        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement { Name = nameof(Update) };

        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = nameof(Delete) };

        public static OperationAuthorizationRequirement ListExpenses = new OperationAuthorizationRequirement { Name = nameof(ListExpenses) };

        public static OperationAuthorizationRequirement DownloadAllEmployees = new OperationAuthorizationRequirement { Name = nameof(DownloadAllEmployees) };
    }
}
