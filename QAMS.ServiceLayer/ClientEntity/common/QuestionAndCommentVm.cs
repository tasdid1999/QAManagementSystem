using QAMS.DataAccessLayer.Domain;
using QAMS.DataAccessLayer.Helper;
using QAMS.DataAccessLayer.ResponseVm.comment;
using QAMS.DataAccessLayer.ResponseVm.question;
using QAMS.ServiceLayer.ClientEntity.comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.ClientEntity.common
{
    public class QuestionAndCommentVm
    {
        public QuestionResponseVm Question { get; set; }

        public PaginatedList<CommentResponseVm> Comments { get; set; }

        public CommentRequestVm CommentRequestVm { get; set; }
        public QuestionAndCommentVm(QuestionResponseVm question, PaginatedList<CommentResponseVm> comments)
        {
            Question = question;
            Comments = comments;
            CommentRequestVm = new CommentRequestVm();
        }
    }
}
