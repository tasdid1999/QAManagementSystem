using Azure;
using Microsoft.EntityFrameworkCore;
using QAMS.DataAccessLayer.DataContext;
using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.Helper;
using QAMS.DataAccessLayer.ResponseVm.comment;
using QAMS.DataAccessLayer.ResponseVm.question;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QAMS.DataAccessLayer.Repository.comment
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Comment comment)
        {
            try
            {
                await _context.comments.AddAsync(comment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginatedList<CommentResponseVm>> GetAll(int questionId, int page, int pageSize)
        {
            try
            {
                var query = _context.comments.AsNoTracking()
                                  .Where(comment => comment.QuestionId == questionId)
                                  .OrderByDescending(comment => comment.CreatedAt)
                                  .Select(comment => new CommentResponseVm { Description = comment.Description, Id = comment.Id, CommentorName = comment.CommentorName, CreatedAt = comment.CreatedAt });
                                  
                var response = await PaginatedList<CommentResponseVm>.CreateAsync(query, page, pageSize);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
