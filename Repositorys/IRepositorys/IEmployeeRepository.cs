using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys
{
    public interface IEmployeeRepository
    {
        Task<Employee?> RegisterEmployeeRepoAsync(Employee newUser);
    }
}
