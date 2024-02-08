using QAMS.DataAccessLayer.Repository.comment;
using QAMS.DataAccessLayer.Repository.question;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; }

        ICommentRepository CommentRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
