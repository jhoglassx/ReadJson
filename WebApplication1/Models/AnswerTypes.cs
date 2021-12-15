using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AnswerTypes
    {
        [Key]
        public string _id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string professional { get; set; }
        public string __v { get; set; }
    }
}
