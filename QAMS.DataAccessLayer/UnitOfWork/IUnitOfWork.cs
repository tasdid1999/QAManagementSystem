using QAMS.DataAccessLayer.Repository.Question;
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

        Task<bool> SaveChangesAsync();
    }
}
