using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this StockModel stockModel)
        {
            return new StockDto
            {
              Id = stockModel.Id,
              Symbol = stockModel.Symbol,
              CompanyName = stockModel.CompanyName,
              Purchase = stockModel.Purchase,
              LastDiv = stockModel.LastDiv,
              Industry = stockModel.Industry,
              MarketCap = stockModel.MarketCap

            };
        }

        public static StockModel ToStockFromCreateDto(this CreateStockRequestDto createStockRequestDto)
        {
            return new StockModel
            {
                Symbol = createStockRequestDto.Symbol,
                CompanyName = createStockRequestDto.CompanyName,
                Purchase = createStockRequestDto.Purchase,
                LastDiv = createStockRequestDto.LastDiv,
                MarketCap = createStockRequestDto.MarketCap,
                Industry = createStockRequestDto.Industry
            };
        }
    }
}

// Without mappers, your API wouldn't automatically know how to turn a StockModel (your database entity) into a StockDto