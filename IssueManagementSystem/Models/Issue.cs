using System.ComponentModel.DataAnnotations;

namespace IssueManagementSystem.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="Title field must be fill")]
        [StringLength(20,MinimumLength = 3 ,ErrorMessage = "Title cannot be longer than 20 characters.")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public string Assignee { get; set; }
    }
}

