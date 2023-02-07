using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Film_Equipment_Rentals.Models
{
    public class OrderTicket
    {
        [Key]
        public int Id { get; set; }

        //Foreign Keys
        public int EquipmentInventoryId { get; set; }
        [Display(Name = "Equipment Name")]
        public EquipmentInventory? EquipObj { get; set; }

        //Additional Attributes
        [Required]
        [Display(Name = "Quantity")]
        public float Quantity { get; set; }

        [Required]
        [Display(Name = "Total")]
        public float Total { get; set; }

        [Required]
        [Display(Name = "Status of Order")]
        public bool Status { get; set; }
    }
}
