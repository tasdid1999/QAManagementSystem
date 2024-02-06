﻿using Microsoft.AspNetCore.Identity;
using QAMS.DataAccessLayer.DataContext;
using QAMS.DataAccessLayer.Repository.Question;
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
        }

        public IQuestionRepository QuestionRepository {  get; set; }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync() > 0;
        }
    }
}
