using PaylocityDemo.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaylocityDemo.Data
{
    public class PaylocityDemoRepository : IPaylocityDemoRepository
    {
        public readonly PaylocityDemoContext _context;

        public PaylocityDemoRepository(PaylocityDemoContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.SingleOrDefault(x => x.Id == id);
        }
    }
}
