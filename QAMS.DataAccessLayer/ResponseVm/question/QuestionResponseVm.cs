﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.ResponseVm.question
{
    public class QuestionResponseVm
    {
        public int  Id {  get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public int StatusId { get; set; }
        public bool IsCommentBoxActivate { get; set; } = false;
    }
}
