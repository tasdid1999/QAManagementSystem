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
             await _context.comments.AddAsync(comment);
        }

        public Task<List<CommentResponseVm>> GetAll(int questionId)
        {
          return _context.comments.AsNoTracking()
                                  .Where(comment => comment.QuestionId == questionId)
                                  .OrderByDescending(comment => comment.CreatedAt)
                                  .Select(comment => new CommentResponseVm { Description = comment.Description , Id = comment.Id })
                                  .ToListAsync();
        }
    }
}
