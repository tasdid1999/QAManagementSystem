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
            try
            {
                await _context.AddAsync(question);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginatedList<QuestionResponseVm>> GetAll(int page , int pageSize)
        {
            try
            {
                var query = _context.questions
                                 .AsNoTracking()
                                 .Where(question => question.StatusId == 1)
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
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<QuestionResponseVm>> GetAllById(int id)
        {
            try
            {
                return await _context.questions
                                .AsNoTracking()
                                .Where(question => question.CreatedBy == id && question.StatusId == 1)
                                .Select(question => new QuestionResponseVm
                                {
                                    Id = question.Id,
                                    Title = question.Title,
                                    Description = question.Description,
                                    CreatedAt = question.CreatedAt,

                                })
                                .ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<QuestionResponseVm>> GetAllQuestionBasedOnTeacherComment(int userId)
        {
           return await _context.questions
                        .AsNoTracking()
                        .Include(x => x.Comments)
                        .Where(q => q.Comments.Any(c => c.CreatedBy == userId) && q.StatusId == 1)
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
            try
            {
                return await _context.questions
                                .AsNoTracking()
                                .Where(question => question.Id == id && question.StatusId == 1)
                                .Select(question => new QuestionResponseVm
                                {
                                    Id = question.Id,
                                    Description = question.Description,
                                    Title = question.Title,
                                    CreatedAt = question.CreatedAt,
                                    CreatedBy = question.CreatedBy,
                                    StatusId = question.StatusId,
                                })
                                .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Question?> GetQuestionWithNoComments(int id)
        {
            try
            {
                return await _context.questions
                                    
                                    .Include(q => q.Comments)
                                    .Where(x=> x.Comments.Any() == false && x.Id == id).FirstOrDefaultAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
