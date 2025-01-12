using System.ComponentModel.DataAnnotations;

namespace surfs_up_project.Models
{
    public class Equipment
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
