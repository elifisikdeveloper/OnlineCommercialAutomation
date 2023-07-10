using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class SalesTransaction
    {
        [Key]
        public int SalesTransactionId { get; set; }

        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
        public int CurrentId { get; set; }
        public virtual Current Currents { get; set; }
        public int PersonelId { get; set; }
        public virtual Personal Personals{ get; set; }
    }
}