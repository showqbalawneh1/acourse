using System;

using System.ComponentModel.DataAnnotations;

namespace Acourse.Models
{
    public class course
    {
        [Key]
        public int courseId { get; set; }
        [Required (ErrorMessage = "Please enter a course name.")]
        public string cname { get; set; }
        public string describtion { get; set; }
        [Required(ErrorMessage = "Please enter a field id.")]
        public int fieldId { get; set; }
        public field field { get; set; }
        public string Slug =>
            cname?.Replace(' ', '-').ToLower();
        public course()
        {
        }
    }
}
