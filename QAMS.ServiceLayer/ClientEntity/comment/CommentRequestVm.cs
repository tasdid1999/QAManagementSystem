using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.ClientEntity.comment
{
    public class CommentRequestVm
    {
        [Required(ErrorMessage ="Filed Required")]
        public string Description { get; set; }

        public int QuestionId { get; set; }
    }
}
