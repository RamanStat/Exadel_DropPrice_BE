﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int DiscountId { get; set; }
        
        public virtual Discount Discount { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}
