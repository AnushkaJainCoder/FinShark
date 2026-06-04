using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StockModel> CreateAsync(StockModel stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<StockModel?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<StockModel>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<StockModel?> GetByIdAsync(int id)
        {

            return await _context.Stocks.FindAsync(id);
        }

        public async Task<StockModel?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = updateStockRequestDto.Symbol;
            stock.CompanyName = updateStockRequestDto.CompanyName;
            stock.Purchase = updateStockRequestDto.Purchase;
            stock.LastDiv = updateStockRequestDto.LastDiv;
            stock.Industry = updateStockRequestDto.Industry;
            stock.MarketCap = updateStockRequestDto.MarketCap;

            await _context.SaveChangesAsync();
            return stock;
        }
    }
}