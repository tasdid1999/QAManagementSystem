using QAMS.DataAccessLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.Repository.question
{
    public interface IQuestionRepository
    {
        public Task Create(Question question);

        public Task<List<Question>> GetAll();

        public Task<Question> GetById(int id);
    }
}
