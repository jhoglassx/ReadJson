using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CheckList
    {
        [Key]
        public string _id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Professional { get; set; }
        public string __v { get; set; }

        public virtual List<AnswerTypes> AnswerTypes { get; set; }

        public virtual List<Levels> Levels { get; set; }
    }
}
