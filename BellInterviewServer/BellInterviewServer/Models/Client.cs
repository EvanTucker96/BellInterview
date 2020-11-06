using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BellInterviewClient
{
    public class Client
    {
        [Key]
        public Guid clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }


    }
}
