using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QAMS.DataAccessLayer.DataContext;
using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.Helper;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<bool> Create(CommentRequestVm comment,int userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());

                if (user is not null)
                {
                    var entity = _mapper.Map<Comment>(comment);
                    entity.StatusId = 1;
                    entity.CreatedBy = userId;
                    entity.CreatedAt = DateTime.Now;
                    entity.CommentorName = user.Name;
                    entity.QuestionId = comment.QuestionId;

                    await _unitOfWork.CommentRepository.Create(entity);

                    return await _unitOfWork.SaveChangesAsync();
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        public async Task<PaginatedList<CommentResponseVm>> GetAll(int questionId, int page, int pageSize)
        {
            try
            {
                return await _unitOfWork.CommentRepository.GetAll(questionId,page,pageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
