using QAMS.DataAccessLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.DataAccessLayer.Domain
{
    public class Question : BaseEntity
    {

        [Required]
        [MinLength(20)]
        public string QuestionDescription { get; set; }


    }
}
