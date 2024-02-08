using Microsoft.AspNetCore.Identity;
using QAMS.DataAccessLayer.DataContext;
using QAMS.DataAccessLayer.Repository.comment;
using QAMS.DataAccessLayer.Repository.question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;
        
       
        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;

            QuestionRepository = new QuestionRepository(_dbcontext);
            CommentRepository = new CommentRepository(_dbcontext);
        }

        public IQuestionRepository QuestionRepository {  get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public async Task<bool> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync() > 0;
        }
    }
}
