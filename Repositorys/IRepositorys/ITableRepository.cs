using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Table = Philadelphia_Sweets_booking_System__Resturant_.Models.Table;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepository
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllTablesAsync();
        Task<Table?> GetTableByIdAsync(int id);
        //-----------------------------------------------
        Task<int> AddTableAsync(Table table);
        Task<bool> EditTableAsync(Table table);
        //-----------------------------------------------
        Task<bool> DeleteTableAsync(int tableId);
        Task<int> DeleteTablesAsync(List<int> tableIds);
    }
}
