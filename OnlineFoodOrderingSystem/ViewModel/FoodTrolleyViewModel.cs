using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineFoodOrderingSystem.Models;

namespace OnlineFoodOrderingSystem.ViewModels
{
    public class FoodBasketViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}