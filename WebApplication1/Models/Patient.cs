using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Patient
    {
        [Key]

        public string _id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Crn { get; set; }
        public string DateBirth { get; set; }
        public string Date { get; set; }
        public string Avatar { get; set; }
        public string Dignosis { get; set; }
        public string Cid { get; set; }
        public string Caregiver { get; set; }
        public string __v { get; set; }
        public string Photo { get; set; }
    }
}
