using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepository)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commentRepo.GetAllAsync();
            var commentDto = result.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto createCommentDto)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
            if (!await _stockRepo.IsStockExist(stockId))
            {
                return BadRequest("stock doesnot exist");
            }
            var comment = createCommentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());

        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id,[FromBody] UpdateCommentDto updateCommentDto)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
           var comment = await  _commentRepo.UpdateAsync(Id, updateCommentDto.ToCommentFromUpdate());
           if(comment == null)
            {
               return NotFound("Comment not found");
            }
            return  Ok(comment.ToCommentDto());
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
              
            var comment =  await _commentRepo.DeleteAsync(Id);
            if(comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}