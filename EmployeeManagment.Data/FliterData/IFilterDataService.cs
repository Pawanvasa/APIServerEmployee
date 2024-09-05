using EmployeeManagment.Services.Models;

namespace EmployeeManagment.Services.FliterData
{
    public interface IFilterDataService
    {
        FilteredDataResult GetFilterData(string spName, SPPararm? parameters = null);
    }
}
