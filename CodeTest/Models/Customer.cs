﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Models
{
    public class Customer
    {        
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; } 

        public string Postcode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
