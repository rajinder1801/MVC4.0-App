using MVC40_Knockout_App.Models;
using System.Collections.Generic;

namespace MVC40_Knockout_App.Contracts
{
    public interface IEmployeeInfoService
    {
        List<EmployeeInfo> Employees { get; }

        EmployeeInfo FindEmployee(int id);

        bool UpdateEmployee(int id, EmployeeInfo employee);

        void InsertEmployee(EmployeeInfo employee);

        void DeleteEmployee(int id);
    }
}
