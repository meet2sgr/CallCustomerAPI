﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCustomerAPI.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Salutation { get; set; }
        public string Initials { get; set; }
        public string Firstname { get; set; }
        public string firstname_ascii { get; set; }
        public string Gender { get; set; }
        public string firstname_country_rank { get; set; }
        public string firstname_country_frequency { get; set; }
        public string Lastname { get; set; }
        public string Lastname_Ascii { get; set; }
        public string Lastname_Country_Rank { get; set; }
        public string Lastname_Country_Frequency { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country_Code { get; set; }
        public string Country_Code_Alpha { get; set; }
        public string Country_Name { get; set; }
        public string Primary_Language_Code { get; set; }
        public string Primary_Language { get; set; }
        public string Balance { get; set; }
        public string Phone_Number { get; set; }
        public string Currency { get; set; }
    }
}
