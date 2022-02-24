using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem.Domain.Models
{
    [Index(nameof(Date), nameof(Ranking))]
    public class Reservation
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Ranking { get; set; }
        public bool Favorite { get; set; }
        public string Description { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
