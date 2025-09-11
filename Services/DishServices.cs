using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.DishDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services
{
    public class DishServices : IDishServices
    {
        private readonly IDishRepository _repo;
        private readonly DishApiHttpServices _dishApiService;

        public DishServices(IDishRepository repo, DishApiHttpServices apiApiservice)
        {
            _repo = repo;
            _dishApiService = apiApiservice;
        }

        public async Task<int> AddDishFromApiServices(string dishName)
        {
            try
            {
                var apiDish = await _dishApiService.GetDishFromApiAsync(dishName);
                    
           
                if (apiDish==null)
                {
                    throw new InvalidOperationException($"No dish with the name: {dishName} existin the api database");
                }
                var dish = new Dish
                {
                    Name = apiDish.strMeal,
                    Description = apiDish.strCategory,
                    pictureUrl = apiDish.strMealThumb,
                    Video = apiDish.strYoutube,
                    Ingredients = new List<string>
                    {
                        apiDish.strIngredient1,
                        apiDish.strIngredient2,
                        apiDish.strIngredient3,
                        apiDish.strIngredient4,
                        apiDish.strIngredient5,
                        apiDish.strIngredient6,
                        apiDish.strIngredient7,
                        apiDish.strIngredient8,
                    }

                };
                await _repo.AddDishRepoAsyn(dish);
                
                return dish.Id;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Operation failed with error: {ex}");
            }

        }

        public async Task<int> AddDishServicesAsync(CreateDishDTO dishDto)
        {

            try
            {
                var dish = new Dish
                {
                    Price = dishDto.Price,
                    Name = dishDto.Name,
                    Description = dishDto.Description,
                    Ingredients = dishDto.Ingredients.ToList()

                };
                var dishId = await _repo.AddDishRepoAsyn(dish);
                return dishId;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Operation Failed, could not add dish to databse {ex}");
            }
            
        }

        public async Task<int> AddDishToMenuServicesAsync(int dishId, int menuId)
        {

            try
            {
                var rowsAffected = await _repo.AddDishToMenuRepoAsync(dishId, menuId);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Operation Failed, {ex}");
            }

        }

        public async Task<int> DeleteDishServicesAsync(int id)
        {

            try
            {
                var rowsAffected = await _repo.DeleteDishRepoAsync(id);
                return rowsAffected;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Operation Failed {ex}");
            }
        }

        public async Task<List<DishDTO>> GetAllDishesServicesAsync()
        {
            try
            {
                var dishes = await _repo.GetAllDishesRepAsync();
                
                var dishesDto = dishes.Select(d=> new DishDTO
                {
                    Id = d.Id,
                    Price = d.Price,
                    Name = d.Name,
                    Description = d.Description,
                    Ingredients = d.Ingredients.ToList(),
                    IsPopular = d.IsPopular,
                    picturUrl = d.pictureUrl,
                    Video = d.Video
                }).ToList();

                return dishesDto;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Operation Failed {ex}");
            }
        }

        public async Task<DishDTO> GetDishByIdServicesAsync(int id)
        {
            try
            {
                var dish = await _repo.GetDishByIdRepoAsync(id);

                var dishDto = new DishDTO
                {
                    Id = dish.Id,
                    Price = dish.Price,
                    Name = dish.Name,
                    Description = dish.Description,
                    Ingredients = dish.Ingredients.ToList(),
                    IsPopular = dish.IsPopular,
                    picturUrl = dish.pictureUrl,
                    Video = dish.Video
                };
                return dishDto;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Operation Failed {ex}");
            }
        }

        public async Task<DishDTO> GetDishByNameServicesAsync(string name)
        {
            try
            {
                var dish = await _repo.GetDishByNameRepoAsync(name);

                var dishDto = new DishDTO
                {
                    Id = dish.Id,
                    Price = dish.Price,
                    Name = dish.Name,
                    Description = dish.Description,
                    Ingredients = dish.Ingredients.ToList(),
                    IsPopular = dish.IsPopular,
                    picturUrl= dish.pictureUrl,
                    Video=dish.Video
                };
                return dishDto;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Operation Failed {ex}");
            }
        }

        public async Task<int> UpdateDishServicesAsync(UpdateDIshDTO updatedDishdto)
        {
            try
            {
                var dish = await _repo.GetDishByIdRepoAsync(updatedDishdto.Id);

                if (dish == null)
                {
                    return 0;
                }
                 
                dish.Name = updatedDishdto.Name;
                dish.Price = updatedDishdto.Price;
                dish.Description = updatedDishdto.Description;
                dish.IsPopular = updatedDishdto.IsPopular;
                dish.Ingredients = updatedDishdto.Ingredients.ToList();
                dish.Menus = updatedDishdto.Menus.ToList();
                dish.pictureUrl = updatedDishdto.PictureUrl;
                dish.Video = updatedDishdto.Video;

                var rowsAffected = await _repo.UpdateDishRepoAsync(dish);
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Operation Failed {ex}");
            }
        }
    }
}
