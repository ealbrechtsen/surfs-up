using System.ComponentModel.DataAnnotations;

namespace surfs_up_api.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

    }
}
