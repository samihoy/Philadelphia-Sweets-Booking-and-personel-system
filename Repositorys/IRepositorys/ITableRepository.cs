using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Table = Philadelphia_Sweets_booking_System__Resturant_.Models.Table;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepository
{
    public interface ITableRepository
    {
        Task<List<Table>> RepoGetAllTablesAsync();
        Task<List<Table>> RepoGetTablesByIdAsync(List<int> ids);
        Task<Table?> RepoGetTableByIdAsync(int id);
        Task<int> RepoAddTableAsync(Table table);
        Task<int> RepoUpdateTableAsync(Table table);
        Task<int> RepoDeleteTableAsync(int Id);
    }
}
