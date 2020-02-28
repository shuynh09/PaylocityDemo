using PaylocityDemo.ViewModels;

namespace PaylocityDemo.Services
{
    public interface IQuoteService
    {
        BenefitViewModel CalculateBenefits(EmployeeViewModel employee);
    }
}