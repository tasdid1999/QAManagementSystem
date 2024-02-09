using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.ClientEntity.question
{
    public class QuestionRequestVm
    {
        [Required(ErrorMessage ="Required Field")]
        [MinLength(5, ErrorMessage = "at least 5 character need")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(20, ErrorMessage = "at least 20 character need")]
        public string Description { get; set; }

       
    }
}
