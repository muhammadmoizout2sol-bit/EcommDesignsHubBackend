using System.ComponentModel.DataAnnotations;

namespace EcommDesignsHub.Models
{

    public class ProjectModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Project Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string? Title { get; set; }

        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description too long")]
        public string? Description { get; set; }

        public string? ImgUrl { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string? ProjectUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? CreatedBy { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}
