using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.ResponseVm.comment;
using QAMS.ServiceLayer.ClientEntity.comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.comment
{
    public interface ICommentService
    {
        Task<bool> Create(CommentRequestVm comment,int userId);

        Task<List<CommentResponseVm>> GetAll(int questionId);
    }
}
