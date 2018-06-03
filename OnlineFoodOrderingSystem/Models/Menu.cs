using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Models
{
    public class Menu
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The food name is required")]
        [MaxLength(20, ErrorMessage = "The maximum length is 20 chars")]
    
        public string Name { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Has to be decimal")]
        [Range(0,5,ErrorMessage = "The maximum value is 5 digits")]
        public Decimal Price { get;set; }


        public string Description { get; set; }

        [Display(Name = "Updated At")]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }

        public int FoodCategoryID { get; set; }

        public virtual FoodCategory Category { get; set; }

        public virtual ICollection<OrderedFoood> OrderedFooods { get; set; } 

    }
}