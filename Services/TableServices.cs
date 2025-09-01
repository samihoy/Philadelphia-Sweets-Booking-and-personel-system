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

        public async Task<int> AddTableAsync(TableDTO tableDTO)
        {
            var table = new Table 
            {
                Number=tableDTO.Number,
                Seats=tableDTO.Seats,
                IsAvalible=tableDTO.IsAvalible
            };

            var tableId = await _tableRepo.AddTableAsync(table);

            if (tableId==0)
            {
                throw new InvalidOperationException("Operation failed, Table not added");
            }
            return tableId;
        }

        public async Task<bool> RemoveTableAsync(int id)
        {
            var results = await _tableRepo.DeleteTableAsync(id);

            if (results==false)
            {
                throw new InvalidOperationException("Operation failed, No table deleted");
            }
            return results;

        }
        public async Task<int> RemoveTablesAsync(List<int> tableIds)
        {
            var results = await _tableRepo.DeleteTablesAsync(tableIds);

            if(results==0)
            {
                throw new InvalidOperationException("Operation failed, Tables were removed");
            }
            return results;
        }

        public async Task<bool> UpdateTableAsync(TableDTO DTOtable)
        {
            var table = await _tableRepo.GetTableByIdAsync(DTOtable.Id);

            if (table != null)
            {
                table.Number = DTOtable.Number;
                table.Seats = DTOtable.Seats;
                table.IsAvalible = DTOtable.IsAvalible;
            }

            var results = await _tableRepo.EditTableAsync(table);

            if(results==false)
            {
                throw new InvalidOperationException("Operation failed, Changes not saved");
            }
            return results;
            

        }

        public async Task<List<TableDTO>> GetAllTablesAsync()
        {
            var tables = await _tableRepo.GetAllTablesAsync();
            var TableDTOs = tables.Select(t => new TableDTO
            {
                Id=t.Id,
                Number = t.Number,
                Seats = t.Seats,
                IsAvalible = t.IsAvalible
            }).ToList();

            return TableDTOs;
        }

        public async Task<TableDTO> GetTableByIdAsync(int id)
        {
            var table = await _tableRepo.GetTableByIdAsync(id);

            if(table==null)
            {
                throw new InvalidOperationException("Operation failed, No table with that ID, object is null");
            }

            var tableDTO = new TableDTO
            {
                Id = table.Id,
                Number = table.Number,
                Seats = table.Seats,
                IsAvalible = table.IsAvalible
            };

            return tableDTO;
        }
    }
}
