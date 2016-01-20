using System.Collections.Generic;
using MvcSmallScreen.Models;

namespace MvcSmallScreen.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}