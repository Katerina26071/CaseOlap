using System.Linq;
using System.Web.Mvc;
using MvcSmallScreen.Models;
using MvcSmallScreen.ViewModels;

namespace MvcSmallScreen.Controllers
{
    public class ShoppingCartController : Controller
    {
        PCStoreEntities storeDB = new PCStoreEntities();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/1
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedGoods = storeDB.Goods
                .Single(goods => goods.GoodsId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext); cart.AddToCart(addedGoods);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/1
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string goodName = storeDB.Carts
                .Single(item => item.RecordId == id).Goods.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(goodName) + " был удален из корзины.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
	}
}