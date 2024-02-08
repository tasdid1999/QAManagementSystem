using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.ResponseVm.comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.Repository.comment
{
    public interface ICommentRepository
    {
        Task Create(Comment comment);

        Task<List<CommentResponseVm>> GetAll(int questionId);
    }
}
