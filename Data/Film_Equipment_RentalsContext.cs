using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Film_Equipment_Rentals.Models;

namespace Film_Equipment_Rentals.Data
{
    public class Film_Equipment_RentalsContext : DbContext
    {
        public Film_Equipment_RentalsContext (DbContextOptions<Film_Equipment_RentalsContext> options)
            : base(options)
        {
        }

        public DbSet<Film_Equipment_Rentals.Models.EquipmentInventory> EquipmentInventory { get; set; } = default!;

        public DbSet<Film_Equipment_Rentals.Models.OrderTicket> OrderTicket { get; set; }
    }
}
