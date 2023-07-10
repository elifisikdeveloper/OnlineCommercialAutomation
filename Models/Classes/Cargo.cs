using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Cargo
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Personal { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
   
        public string Delivery { get; set; }
        public DateTime Date { get; set; }
    }
}