using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.MenuDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepository _repo;

        public MenuServices(IMenuRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> AddNewMenuServicesAsync(CreateMenuDTO DTO)
        {
            try
            {
                var menu = new Menu
                {
                    Theme = DTO.Theme
                };

                var menuId = await _repo.AddNewMenuRepoAsync(menu);

                return menuId;

            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"operation failed {ex}");
            }
        }

        public async Task<int> DeleteMenuServicesAsync(int id)
        {
            try
            {
                var rowsAffected = await _repo.DeleteMenuRepoAsync(id);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"failed to delete menu {ex}");
            }

        }

        public async Task<List<MenuWithDishesDTO>> GetAllMenusWithDishesServicesAsync()
        {
            try
            {
                var menus = await _repo.GetAllMenusWithDishesRepoAsync();
                var menusDto = menus.Select(m => new MenuWithDishesDTO
                {
                    Id = m.Id,
                    Theme = m.Theme,
                    Dishes = m.Dishes.ToList()
                }).ToList();

                return menusDto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"failed to get menues {ex}");
            }
            throw new NotImplementedException();
        }

        public async Task<MenuWithDishesDTO?> GetMenuByIdWithDishesServicesAsync(int id)
        {
            try
            {
                var menu = await _repo.GetMenuByIdWithDishesRepoAsync(id);

                var menuDto = new MenuWithDishesDTO
                {
                    Id = menu.Id,
                    Theme = menu.Theme,
                    Dishes = menu.Dishes.ToList()
                };

                return menuDto;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get menu{ex}");
            }
            throw new NotImplementedException();
        }

        public async Task<int> UpdateMenuServicesAsync(UpdateMenuThemeDTO dto, int id)
        {
            try
            {
                var menu = await _repo.GetMenuByIdWithDishesRepoAsync(id);

                menu.Theme = dto.Theme;

                var rowsAffected = await _repo.UpdateMenuRepoAsync(menu);

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"failed to update menu{ex}");
            }
            
        }
    }
}
