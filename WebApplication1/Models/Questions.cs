using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Questions
    {
        [Key]
        public string _id { get; set; }

        public string Order { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string __v { get; set; }
    }
}
