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
            await _context.SaveChangesAsync();
            return table.Id;
        }

        public async Task<int> RepoDeleteAsync(int Id)
        {
            var deleteResults = await _context.Tables.Where(u => u.Id == Id).ExecuteDeleteAsync();
            return deleteResults;
        }

        public async Task<int> RepoUpdateAsync(Table table)
        {
            _context.Tables.Update(table);
            var updateResults = await _context.SaveChangesAsync();

            return updateResults;
        }
        public async Task<List<Table>> RepoGetAllAsync()
        {
            var tables = await _context.Tables.ToListAsync();

            return tables;
        }

        public async Task<Table?> RepoGetByIdAsync(int id)
        {
            var table = await _context.Tables.FirstOrDefaultAsync(t=>t.Id==id);

            return table;
        }

    }
}
