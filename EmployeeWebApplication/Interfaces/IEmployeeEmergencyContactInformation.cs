using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApplication.Interfaces
{
    interface IEmployeeEmergencyContactInformation
    {
        Task CreateNewEmergencyContactAsync();
        Task GetAllContactInformationAsync();
        Task GetContactInformationForEmployeeAync(int id);
        Task UpdateEmergencyContanctInfoForEmployee(int id);
        Task DeleteEmergencyContactInfoForEmployee(int id);
    }
}
