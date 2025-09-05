using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepository;
using Table = Philadelphia_Sweets_booking_System__Resturant_.Models.Table;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys
{
    public class TableRepository : ITableRepository
    {
        private readonly PhiladelphiaSweetsResturandDBContext _context;

        public TableRepository(PhiladelphiaSweetsResturandDBContext context)
        {
            _context = context;
        }

        public async Task<int> RepoAddAsync(Table table)
        {
            _context.Tables.Add(table);
            var results = await _context.SaveChangesAsync();
            return results > 0 ? table.Id : 0;
        }

        public async Task<bool> RepoDeleteAsync(int tableId)
        {
            var tables = await _context.Tables.Where(u => u.Id == tableId).ExecuteDeleteAsync();
            return tables > 0;
        }
        public async Task<int> RepoDeleteAsync(List<int> tableIds)
        {
            var results = await _context.Tables.Where(t => tableIds.Contains(t.Id)).ExecuteDeleteAsync();

            return results;
        }

        public async Task<bool> RepoUpdateAsync(Table table)
        {
            _context.Tables.Update(table);
            var results = await _context.SaveChangesAsync();

            return results > 0;        
        }
        public async Task<List<Table>> RepoGetAllAsync()
        {
            var tables = await _context.Tables.ToListAsync();

            return tables;
        }

        public async Task<Table?> RepoGetByIdAsync(int tableid)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(t=>t.Id==tableid);

            return table;
        }

    }
}
