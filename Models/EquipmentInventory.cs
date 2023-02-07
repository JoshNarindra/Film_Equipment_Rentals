using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Film_Equipment_Rentals.Models
{
    public class EquipmentInventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Equipment Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Equipment Type")]
        public string? Type { get; set; }

        [Required]
        [Display(Name = "Price per unit per week")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Total Inventory")]
        public int Inventory { get; set; }

    }
}
