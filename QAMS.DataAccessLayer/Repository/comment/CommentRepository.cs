using Microsoft.EntityFrameworkCore;
using QAMS.DataAccessLayer.DataContext;
using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.ResponseVm.comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<List<CommentResponseVm>> GetAll(int questionId)
        {
            try
            {
                return _context.comments.AsNoTracking()
                                  .Where(comment => comment.QuestionId == questionId)
                                  .OrderByDescending(comment => comment.CreatedAt)
                                  .Select(comment => new CommentResponseVm { Description = comment.Description, Id = comment.Id, CommentorName = comment.CommentorName, CreatedAt = comment.CreatedAt })
                                  .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsAnyCommentExist(int questionId)
        {
            try
            {
                return await _context.comments
                               .AsNoTracking()
                               .AnyAsync(comment => comment.QuestionId == questionId);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
