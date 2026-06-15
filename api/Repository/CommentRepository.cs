using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CommentModel>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<CommentModel?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if(comment == null)
            {
                return null;
            }
            return comment;
        }

        public async Task<CommentModel?> CreateAsync(CommentModel commentModel)
        {
            // var stock = _context.Stocks.FindAsync(stockId);
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
           
        }

        public async Task<CommentModel?> UpdateAsync(int id, CommentModel commentModel)
        {
            var comment =  _context.Comments.FirstOrDefault(x=>x.Id==id);
            if(comment == null)
            {
                return null;
            }
            comment.Title = commentModel.Title;
            comment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            return comment;
        }

       
    }
}