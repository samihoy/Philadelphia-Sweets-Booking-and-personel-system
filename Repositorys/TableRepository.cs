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

        public async Task<int> RepoAddTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return table.Id;
        }

        public async Task<int> RepoDeleteTableAsync(int Id)
        {
            var deleteResults = await _context.Tables.Where(u => u.Id == Id).ExecuteDeleteAsync();
            return deleteResults;
        }

        public async Task<int> RepoUpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            var updateResults = await _context.SaveChangesAsync();

            return updateResults;
        }
        public async Task<List<Table>> RepoGetAllTablesAsync()
        {
            var tables = await _context.Tables.ToListAsync();

            return tables;
        }

        public async Task<Table?> RepoGetTableByIdAsync(int id)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(t=>t.Id==id);

            return table;
        }

        public async Task<List<Table>> RepoGetTablesByIdAsync(List<int> ids)
        {
            var tables = await _context.Tables.Where(t => ids.Contains(t.Id)).ToListAsync();

            return tables;
        }
    }
}
