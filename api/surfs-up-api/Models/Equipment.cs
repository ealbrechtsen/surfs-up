using System.ComponentModel.DataAnnotations;

namespace surfs_up_api.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public Equipment()
        {
            
        }
    }
}
