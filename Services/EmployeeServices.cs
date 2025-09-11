using Microsoft.AspNetCore.Http.HttpResults;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.EmployeeDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services
{
    public class EmployeeServices :  IEmployeeServices
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeServices(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> RegisterEmployeeServicesAsync(EmployeeRegisterDTO newUser)
        {
            var newEmployee = new Employee
            {
                Fname = newUser.Fname,
                Lname = newUser.Lname,
                Email = newUser.Email,
                Role = newUser.Role,
                PasswordHash = newUser.Password
            };

            var registerdUser = await _repo.RegisterEmployeeRepoAsync(newEmployee);

            if(registerdUser==null)
            {
                throw new InvalidOperationException("operation failed, user not created");
            }
            return registerdUser.Id;
        }
    }
}
