using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderingSystem.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }

        [Display(Name = "Food category")]
        [Required(ErrorMessage = "please enter type of foof")]
        [MaxLength(45,ErrorMessage = "Category name is a max of 20 chars")]
        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; } 
    }
}