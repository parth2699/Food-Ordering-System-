/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OnlineFoodOrderingSystem.DAL;
using WebApplication1.DAL;

namespace OnlineFoodOrderingSystem.Models
{
    public partial class FoodTrolley //trolley because punny
    {
        Food_Ordering db = new Food_Ordering(); 

        public string FoodCartID { get; set; }

        public const string CartSessionKey = "cartId"; //session 

        public static FoodTrolley GetCart(HttpContextBase context) //base class for HTTP requests  
        {
            var cart = new FoodTrolley();
            cart.FoodCartID = cart.GetCartId(context);

            return cart;
        }

        public static FoodTrolley GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(MenuItemId menuItemID)
        {
            var cartItem = db.Carts.SingleOrDefault(c=>c.CartId == FoodCartID && c.MenuItemID == menuItemID.Id);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    MenuItemId = menuItemID.Id,
                    CartId = FoodCartID,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = db.Carts.SingleOrDefault(cart => cart.CartId == FoodCartID && cart.MenuItemID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }

                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(cart => cart.CartId == FoodCartID);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == FoodCartID).ToList();
        }

        public int GetCount()
        {
            int? count =
                (from cartItems in db.Carts where cartItems.CartId == FoodCartID select (int?) cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.Carts
                where cartItems.CartId == FoodCartID
                              select (int?) cartItems.Count*cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(EmployeeOrder customerOrder)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderedFoood = new OrderedFoood
                {
                    MenuItemID = item.MenuItemID, CustomerOrderId = customerOrder.Id, Quantity = item.Count
                };

                orderTotal += (item.Count*item.Product.Price);

                db.OrderedFoood.Add(orderedFoood);
            }

            customerOrder.Amount = orderTotal;

            db.SaveChanges();

            EmptyCart();

            return customerOrder.Id;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }

                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var foodCart = db.Carts.Where(c => c.CartId == FoodCartID);
            foreach (Cart item in foodCart)
            {
                item.CartId = userName;
            }

            db.SaveChanges();
        }

    }
}*/