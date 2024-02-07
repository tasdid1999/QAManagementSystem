using AutoMapper;
using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.Helper;
using QAMS.DataAccessLayer.ResponseVm.question;
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
        public async Task<bool> CreateQuestionAsync(QuestionRequestVm question, int userId)
        {
            var entity = _mapper.Map<Question>(question);

            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = userId;
            entity.StatusId = 1;

            await _unitOfWork.QuestionRepository.Create(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaginatedList<QuestionResponseVm>> GetAllQuestionsAsync(int page , int pageSize)
        {
            var listOfQuestion = await _unitOfWork.QuestionRepository.GetAll(page, pageSize);

            return listOfQuestion;
        }

        public async Task<List<QuestionResponseVm>> GetAllQuestionsByIdAsync(int id)
        {
            var listOfQuestion = await _unitOfWork.QuestionRepository.GetAllById(id);

            return listOfQuestion;
        }
        public Task<QuestionResponseVm?> GetQuestionByIdAsync(int id)
        {
           return _unitOfWork.QuestionRepository.GetById(id);
        }
    }
}

       

