using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PhiladelphiaSweetsResturandDBContext _context;

        public EmployeeRepository(PhiladelphiaSweetsResturandDBContext context)
        {
            _context = context;
        }

        public async Task<Employee?> RegisterEmployeeRepoAsync(Employee newUser)
        {
            _context.Employees.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;

        }
    }
}
