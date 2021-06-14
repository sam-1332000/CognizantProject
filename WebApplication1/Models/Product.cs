using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string ProductImage { get; set; }
        public int QualityOnHand { get; set; }
        public int ReOrderLevel { get; set; }
    }
}
