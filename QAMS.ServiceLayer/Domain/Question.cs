﻿using QAMS.DataAccessLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.Domain
{
    public class Question : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string Tilte { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }


    }
}
