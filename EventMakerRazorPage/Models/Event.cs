using System.ComponentModel.DataAnnotations;

namespace RazorPagesEventMaker.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Name of the Event is required"), MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "Name of the city can not be longer than 18 chars")]
        public string City { get; set; }
        [Required(ErrorMessage = "The date is required")]
        [Range(typeof(DateTime), "8/4/2024", "30/6/2026", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateTime { get; set; }

    }
}
