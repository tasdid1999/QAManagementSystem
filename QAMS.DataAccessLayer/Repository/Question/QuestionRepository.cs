using Microsoft.EntityFrameworkCore;

using QAMS.DataAccessLayer.DataContext;
using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.Helper;
using QAMS.DataAccessLayer.ResponseVm.question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.Repository.question
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Question question)
        {
            await _context.AddAsync(question);
        }

        public async Task<PaginatedList<QuestionResponseVm>> GetAll(int page , int pageSize)
        {
             var query =   _context.questions
                                 .AsNoTracking()
                                 .OrderByDescending(question => question.CreatedAt)
                                 .Select(question => new QuestionResponseVm
                                 {
                                     Id = question.Id,
                                     Title = question.Title,
                                     Description = question.Description,
                                     CreatedAt = question.CreatedAt
                                     
                                 });
            var response = await PaginatedList<QuestionResponseVm>.CreateAsync(query, page, pageSize);

            return response;
        }

        public async Task<List<QuestionResponseVm>> GetAllById(int id)
        {
            return await _context.questions
                                 .AsNoTracking()
                                 .Where(question => question.CreatedBy == id)
                                 .Select(question => new QuestionResponseVm
                                 {
                                     Id = question.Id,
                                     Title = question.Title,
                                     Description = question.Description,
                                     CreatedAt = question.CreatedAt,
                                    
                                 })
                                 .ToListAsync();
        }

        public async Task<QuestionResponseVm?> GetById(int id)
        {
           return await _context.questions
                                .Where(question => question.Id == id)
                                .AsNoTracking()
                                .Select(question => new QuestionResponseVm {Id = question.Id,
                                                                            Description = question.Description,
                                                                            Title = question.Title,
                                                                            CreatedAt = question.CreatedAt,
                                                                            CreatedBy = question.CreatedBy })
                                .FirstOrDefaultAsync();
        }
    }
}
