using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Consulta
    {
        public Patient patient { get; set; }
        public ICollection<Answers> answers { get; set; }

        public CheckList checkList { get; set; }

    }
}
