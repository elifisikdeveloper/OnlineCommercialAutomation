using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoiceSerialNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoiceRotationNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public String TaxOffice { get; set; }
        public DateTime  Time { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Deliverer { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string  Recipient { get; set; }

        public decimal TotalPrice { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}