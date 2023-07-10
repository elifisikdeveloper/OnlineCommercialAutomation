using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string  ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string  Brand{ get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; } 
        public virtual Category Categories { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}