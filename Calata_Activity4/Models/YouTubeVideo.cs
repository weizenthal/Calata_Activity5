using System.ComponentModel.DataAnnotations;

namespace Calata_Activity4.Models
{
    public class YouTubeVideo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "YouTube URL")]
        public string VideoUrl { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        public string Reflection { get; set; } = string.Empty;
    }
}