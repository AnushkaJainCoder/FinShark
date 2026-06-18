using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
  
        private readonly IStockRepository _stockrepo;
        public StockController( IStockRepository stockRepository)
        {
            
            _stockrepo = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
            var stocks = await _stockrepo.GetAllAsync();
            var stockDTO = stocks.Select(s => s.ToStockDto());
            return Ok(stockDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              

            var stock = await _stockrepo.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockRequestDto stockDto)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockrepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
            var stock = await _stockrepo.UpdateAsync(id, updateDto);
            return Ok(stock.ToStockDto());
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
            var stock = await _stockrepo.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
           
            return NoContent();
        }

    }
}