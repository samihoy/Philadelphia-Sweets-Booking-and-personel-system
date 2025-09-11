using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.EmployeeDTO_s;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface IEmployeeServices
    {
        Task<int> RegisterEmployeeServicesAsync(EmployeeRegisterDTO newUser);
    }
}
