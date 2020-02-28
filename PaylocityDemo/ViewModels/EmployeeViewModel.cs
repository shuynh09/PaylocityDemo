using System.ComponentModel.DataAnnotations;

namespace PaylocityDemo.ViewModels
{
    public class EmployeeViewModel
    {
        public string FullName { get; set; }
        public string[] Dependents { get; set; }
    }
}
