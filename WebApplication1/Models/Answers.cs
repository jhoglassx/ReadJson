using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Answers
    {
        [Key]
        public string _id { get; set; }
        public string ChecklistName { get; set; }
        public string ChecklistDescription { get; set; }
        public string LevelOrder { get; set; }
        public string SectionOrder { get; set; }
        public string SectionName { get; set; }
        public string QuestionOrder { get; set; }
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
        public string AnswerLabel { get; set; }
        public string Patient { get; set; }
        public string Professional { get; set; }
        public string Checklist { get; set; }
        public string Date { get; set; }
        public string History { get; set; }
        public string __v { get; set; }
    }
}
