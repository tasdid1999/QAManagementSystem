
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
    public interface IQuestionRepository
    {
        public Task Create(Question question);

        public Task<PaginatedList<QuestionResponseVm>> GetAll(int page , int pageSize);

        public Task<List<QuestionResponseVm>>GetAllById(int id);

        public Task<List<QuestionResponseVm>> GetAllQuestionBasedOnTeacherComment(int userId);

        public Task<QuestionResponseVm?> GetById(int id);

        public Task<Question?> GetQuestionWithNoComments(int id);
    }
}
