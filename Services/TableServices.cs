using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantTableDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepository;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;
using System.Collections.Immutable;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services
{
    public class TableServices : ITableServices
    {
        private readonly ITableRepository _tableRepo;

        public TableServices(ITableRepository repo)
        {
            _tableRepo = repo;
        }

        public async Task<int> AddTableAsync(TableDTO DTO)
        {
            try
            {
                var table = new Table
                {
                    Seats = DTO.Seats,
                    TableNumber = DTO.TableNumber
                };

                return await _tableRepo.RepoAddTableAsync(table);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Failed to add table {ex}");
            }
        }
        public async Task<int> DeleteTableAsync(int id)
        {
            try
            {
                var rowsAffected = await _tableRepo.RepoDeleteTableAsync(id);

                if (rowsAffected==0)
                {
                    throw new InvalidOperationException($"Failed to delete table with ID {id}");
                }
                return rowsAffected;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Failed to delete table. {ex}");
            }

        }

        public async Task<int> UpdateTableAsync(TableDTO DTO)
        {
            try 
            {
                var table = await _tableRepo.RepoGetTableByIdAsync(DTO.Id);

                if (table != null)
                {
                    table.Seats = DTO.Seats;
                    table.TableNumber = DTO.TableNumber;
                    
                };

                var rowsAffected = await _tableRepo.RepoUpdateTableAsync(table);
                return rowsAffected;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Failed to update table. {ex}");
            }
        }

        public async Task<List<TableDTO>> GetAllTablesAsync()
        {
            try
            { 
                var tables = await _tableRepo.RepoGetAllTablesAsync();
                var TableDTOs = tables.Select(t => new TableDTO
                {
                    Id=t.Id,
                    Seats = t.Seats,
                    TableNumber=t.TableNumber

                }).ToList();
                return TableDTOs;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Operation failed. {ex}");
            }
        }
        public async Task<TableDTO> GetTableByIdAsync(int id)
        {
            try
            {
                var table = await _tableRepo.RepoGetTableByIdAsync(id);

                if (table == null)
                {
                    throw new InvalidOperationException("Operation failed, No table with that ID, object is null");
                }

                var tableDTO = new TableDTO
                {
                    Id = table.Id,
                    Seats = table.Seats,
                    TableNumber=table.TableNumber
                };

                return tableDTO;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Could not get table. {ex}");
            }
        }

        public async Task<List<TableDTO>> GetTablesByIdAsync(List<int> ids)
        {
            var tables = await _tableRepo.RepoGetTablesByIdAsync(ids);

            try
            {
                var tableDTOs = tables.Select(t => new TableDTO
                {
                    Id = t.Id,
                    Seats = t.Seats,
                    TableNumber = t.TableNumber
                }).ToList();

                return tableDTOs;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get Tables");
            }
        }
    }
}
