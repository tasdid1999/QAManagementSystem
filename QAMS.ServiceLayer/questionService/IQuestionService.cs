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
        Task<bool> CreateQuestionAsync(QuestionRequestVm question);
        Task<List<QuestionResponseVm>> GetAllQuestionsAsync();
        Task<QuestionResponseVm> GetQuestionByIdAsync(int id);
    }
}
