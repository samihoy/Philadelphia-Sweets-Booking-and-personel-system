using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Table = Philadelphia_Sweets_booking_System__Resturant_.Models.Table;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepository
{
    public interface ITableRepository
    {
        Task<List<Table>> RepoGetAllAsync();
        Task<Table?> RepoGetByIdAsync(int id);
        //-----------------------------------------------
        Task<int> RepoAddAsync(Table table);
        Task<bool> RepoUpdateAsync(Table table);
        //-----------------------------------------------
        Task<bool> RepoDeleteAsync(int tableId);
    }
}
