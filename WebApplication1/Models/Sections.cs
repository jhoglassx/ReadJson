using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Sections
    {
        [Key]
        public string _id { get; set; }
        public string Name { get; set; }
        public string Checklist { get; set; }
        public string Level { get; set; }
        public string __v { get; set; }

        public virtual List<Questions> Questions { get; set; }

    }
}
