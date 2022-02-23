﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Models
{
    [Index(nameof(Name), nameof(BirthDate), IsUnique =true)]
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Guid ContactTypeId { get; set; }        
        public virtual ContactType ContactType { get; set; }
        //public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
