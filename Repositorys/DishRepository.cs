using Microsoft.EntityFrameworkCore;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys
{
    public class DishRepository : IDishRepository
    {
        private readonly PhiladelphiaSweetsResturandDBContext _context;

        public DishRepository(PhiladelphiaSweetsResturandDBContext context)
        {
            _context = context;
        }

        public async Task<Dish?> AddDishFromApiRepoAsync(Dish apiDish)
        {
            _context.Dishes.Add(apiDish);
            await _context.SaveChangesAsync();
            return apiDish;
        }

        public async Task<int> AddDishRepoAsyn(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
            return dish.Id;
        }

        public async Task<int> AddDishToMenuRepoAsync(int dishId, int menuId)
        {
            var menu = await _context.Menues.FirstOrDefaultAsync(m=>m.Id==menuId);
            var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
            menu.Dishes.Add(dish);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        
        }

        public Task<int> DeleteDishRepoAsync(int id)
        {
            var rowsAffected = _context.Dishes.Where(d => d.Id == id).ExecuteDeleteAsync();
            return rowsAffected;
        }

        public async Task<List<Dish>> GetAllDishesRepAsync()
        {
            var dishes = await _context.Dishes.ToListAsync();
            return dishes;
        
        }

        public async Task<Dish?> GetDishByIdRepoAsync(int id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(d=>d.Id==id);
            return dish;
        }

        public async Task<Dish?> GetDishByNameRepoAsync(string name)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(d=>d.Name==name);
            return dish;
        }

        public async Task<int> UpdateDishRepoAsync(Dish dish)
        {
            _context.Dishes.Update(dish);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
            
        }











        //public async Task<int> AddDishToMenuRepoAsync(int menuId, Dish dish)
        //{
        //    var menu = await _context.Menues.Include(m => m.Dishes).FirstOrDefaultAsync(m => m.Id == menuId);
        //    menu.Dishes.Add(dish);
        //    var rowsAffected = await _context.SaveChangesAsync();
        //    return rowsAffected;

        //}
    }
}
