using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this CommentModel CommentModel)
        {
            return new CommentDto
            {
                Id = CommentModel.Id,
                Title = CommentModel.Title,
                Content = CommentModel.Content,
                CreatedOn = CommentModel.CreatedOn,
                StockId = CommentModel.StockId

            };
        }
        public static CommentModel ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            return new CommentModel
            {

                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId

            };
        }
    }
}