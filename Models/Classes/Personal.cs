using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Personal
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string PersonelName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string PersonalSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(400)]
        public string PersonelImage { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }
        public ICollection<Current> Currents { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }

    }
}