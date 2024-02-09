
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

        Task<PaginatedList<QuestionResponseVm>> GetAllQuestionBasedOnTeacherComment(int userId,int page,int pageSize);
        Task<PaginatedList<QuestionResponseVm>> GetAllQuestionsByIdAsync(int id, int page, int pageSize);
        Task<QuestionResponseVm?> GetQuestionByIdAsync(int id);

        Task<bool> DeleteQuestionAsync(int questionid);
    }
}
