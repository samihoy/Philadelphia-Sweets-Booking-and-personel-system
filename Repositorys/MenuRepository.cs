using Microsoft.EntityFrameworkCore;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys
{
    public class MenuRepository : IMenuRepository
    {
        private readonly PhiladelphiaSweetsResturandDBContext _context;

        public MenuRepository(PhiladelphiaSweetsResturandDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewMenuRepoAsync(Menu menu)
        {
            _context.Menues.Add(menu);
            await _context.SaveChangesAsync();

            return menu.Id;
        }

        public async Task<int> DeleteMenuRepoAsync(int id)
        {
            var rowsDeleted = await _context.Menues.Where(m => m.Id == id).ExecuteDeleteAsync();
            return rowsDeleted;
        }

        public async Task<List<Menu>> GetAllMenusWithDishesRepoAsync()
        {
            var allMenus = await _context.Menues.Include(m => m.Dishes).ToListAsync();
            return allMenus;
        }

        public async Task<Menu?> GetMenuByIdWithDishesRepoAsync(int id)
        {
            var menu = await _context.Menues.Include(m=>m.Dishes).FirstOrDefaultAsync(m => m.Id == id);
            return menu;
        }

        public async Task<int> UpdateMenuRepoAsync(Menu menu)
        {
            _context.Menues.Update(menu);
            var rowsUpdated = await _context.SaveChangesAsync();
            return rowsUpdated;
        }
    }
}
