using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
