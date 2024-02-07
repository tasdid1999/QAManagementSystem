
using QAMS.DataAccessLayer.Helper;
using QAMS.DataAccessLayer.ResponseVm.question;
using QAMS.ServiceLayer.ClientEntity.question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.questionService
{
    public interface IQuestionService
    {
        Task<bool> CreateQuestionAsync(QuestionRequestVm question,int userId);
        Task<PaginatedList<QuestionResponseVm>> GetAllQuestionsAsync(int page , int pageSize);
        Task<List<QuestionResponseVm>> GetAllQuestionsByIdAsync(int id);
        Task<QuestionResponseVm?> GetQuestionByIdAsync(int id);
    }
}
