using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Models
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Ranking { get; set; }
        public bool Favorite { get; set; }
        public string Description { get; set; }
        [ForeignKey("ContactId")]
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
