﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSV_Parser_Api.Dtos
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string PayrollNumber { get; set; }


        public string Forenames { get; set; }

        public string Surname { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string Telephone { get; set; }


        public string Mobile { get; set; }

        public string Address { get; set; }


        public string Address2 { get; set; }


        public string Postcode { get; set; }


        public string EmailHome { get; set; }

        public DateTime StartDate { get; set; }
    }
}