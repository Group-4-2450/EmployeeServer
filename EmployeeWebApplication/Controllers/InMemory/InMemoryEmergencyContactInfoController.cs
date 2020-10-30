using EmployeeWebApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Controllers.InMemory
{
    public class InMemoryEmergencyContactInfoController : IEmployeeEmergencyContactInformation
    {
        public Task CreateNewEmergencyContactAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmergencyContactInfoForEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetAllContactInformationAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetContactInformationForEmployeeAync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmergencyContanctInfoForEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
