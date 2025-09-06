using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantTableDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface ITableServices
    {
        Task<List<TableDTO>> GetAllTablesAsync();
        Task<TableDTO> GetTableByIdAsync(int id);
        Task<int> AddTableAsync(TableDTO DTO);
        Task<int> UpdateTableAsync(TableDTO DTO);
        Task<int> DeleteTableAsync(int id);
    }
}
