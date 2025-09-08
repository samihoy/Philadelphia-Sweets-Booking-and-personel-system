using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantTableDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.TableDTO_s;
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

        public async Task<int> AddTableServicesAsync(TableDTO DTO)
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
        public async Task<int> DeleteTableServicesAsync(int id)
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

        public async Task<int> UpdateTableServicesAsync(TableDTO DTO)
        {
            try 
            {
                var table = await _tableRepo.GetTableByIdRepoAsync(DTO.Id);

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

        public async Task<List<TableDTO>> GetAllTablesServicesAsync()
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
        public async Task<GetTableDTO> GetTableByIdServicesAsync(int id)
        {
            try
            {
                var table = await _tableRepo.GetTableByIdRepoAsync(id);

                if (table == null)
                {
                    throw new InvalidOperationException("Operation failed, No table with that ID, object is null");
                }

                var tableDTO = new GetTableDTO
                {
                    Id = table.Id,
                    Seats = table.Seats,
                    TableNumber = table.TableNumber,
                    Bookings = table.Bookings.Select(b => new GetBookingDTO
                    {
                        Id = b.Id,
                        StartTime = b.StartTime,
                        NumberGuests = b.NumberGuests,
                        BookedUnderName = b.BookedUnderName,
                        ContactInformationPhone = b.ContactInformationPhone,
                        DurationMinutes = b.DurationMinutes,

                    }).ToList()
                };

                return tableDTO;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Could not get table. {ex}");
            }
        }

        public async Task<List<TableDTO>> GetTablesByIdServicesAsync(List<int> ids)
        {
            try
            {
                var tables = await _tableRepo.RepoGetTablesByIdAsync(ids);

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
