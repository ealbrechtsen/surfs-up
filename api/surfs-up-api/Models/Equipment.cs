using System.ComponentModel.DataAnnotations;

namespace surfs_up_api.Models
{
    public class Equipment
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
