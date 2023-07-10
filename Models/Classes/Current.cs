using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CurrentName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CurrentSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string  CjurrentCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CurrentMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string CurrentPassword { get; set; }

        public bool Status { get; set; }

        public Personal Personals { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}