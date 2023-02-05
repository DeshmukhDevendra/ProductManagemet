using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement_Model.Models
{
    public enum Currency 
    { 
        USD , INR, CAD, AUD, EURO
    }

    [Index(nameof(SKU), IsUnique = true)]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int SKU { get; set; }
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public Category Category { get; set; }
        [Required]
        public double BasePrice { get; set; }
        [Required]
        public double MRP { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
        [Required]
        public DateTime DateManufactured { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
