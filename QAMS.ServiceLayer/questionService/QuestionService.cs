using AutoMapper;
using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.UnitOfWork;
using QAMS.ServiceLayer.ClientEntity.question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.questionService
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateQuestionAsync(QuestionRequestVm question)
        {
            var entity = _mapper.Map<Question>(question);

            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = 

            await _unitOfWork.QuestionRepository.Create();
        }

        public Task<List<QuestionResponseVm>> GetAllQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<QuestionResponseVm> GetQuestionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
