using PaylocityDemo.Data.Entities;
using System.Collections.Generic;

namespace PaylocityDemo.Data
{
    public interface IPaylocityDemoRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
    }
}