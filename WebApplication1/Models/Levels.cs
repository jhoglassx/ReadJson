using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Levels
    {
        [Key]
        public string _id { get; set; }
        public string Order { get; set; }
        public string Checklist { get; set; }
        public string __v { get; set; }

        public virtual List<Sections> Sections { get; set; }

    }
}
