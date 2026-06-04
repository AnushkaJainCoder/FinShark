using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<StockModel>> GetAllAsync();
        Task<StockModel?> GetByIdAsync(int id);
        Task<StockModel> CreateAsync(StockModel stock);
        Task<StockModel?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);
        Task<StockModel?> DeleteAsync(int id);
        
    }
}