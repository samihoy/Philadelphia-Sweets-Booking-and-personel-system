using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantTableDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.TableDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface ITableServices
    {
        Task<List<TableDTO>> GetAllTablesServicesAsync();
        Task<List<TableDTO>> GetTablesByIdServicesAsync(List<int> ids);
        Task<GetTableDTO> GetTableByIdServicesAsync(int id);
        Task<int> AddTableServicesAsync(TableDTO DTO);
        Task<int> UpdateTableServicesAsync(TableDTO DTO);
        Task<int> DeleteTableServicesAsync(int id);
    }
}
