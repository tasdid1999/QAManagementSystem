using AutoMapper;
using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.ResponseVm.comment;
using QAMS.DataAccessLayer.UnitOfWork;
using QAMS.ServiceLayer.ClientEntity.comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.comment
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Create(CommentRequestVm comment,int userId)
        {
            var entity = _mapper.Map<Comment>(comment);
            entity.StatusId = 1;
            entity.CreatedBy = userId;
            entity.CreatedAt = DateTime.Now;

            await _unitOfWork.CommentRepository.Create(entity);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<CommentResponseVm>> GetAll(int questionId)
        {
           return await _unitOfWork.CommentRepository.GetAll(questionId);
        }
    }
}
