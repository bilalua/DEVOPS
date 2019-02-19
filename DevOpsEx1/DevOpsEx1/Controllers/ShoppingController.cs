//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Mvc;
//using DevOpsExe1.Models;
//using System.Web.Http;
//using System.Web.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace DevOpsExe1.Controllers
//{
//    [Route("api/[Controller]")]
//    public class ShoppingController : Controller
//    {
//        private readonly ShoppingContext _context;

//        public ShoppingController(ShoppingContext context)
//        {
//            _context = context;

//            if (_context.ShoppingItems.Count() == 0)
//            {
//                // Create a new TodoItem if collection is empty,
//                // which means you can't delete all TodoItems.
//                _context.ShoppingItems.Add(new ShoppingCart { BuyerName = "Foaud", ItemName = "Coke", ItemPrice = 50, ItemQuantity = 2 });
//                //_context.TodoItems.Add(new TodoItem { Name = "Item1" });
//                _context.SaveChanges();
//            }
//        }

        



//        ///<controller>
//        // GET: api/<controller>
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetShoppingCart()
//        {
//            return await _context.ShoppingItems.ToListAsync();
          
//        }



//        // GET: api/Todo/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ShoppingCart>> GetShoppingCart(long id)
//        {
//            var todoItem = await _context.ShoppingItems.FindAsync(id);

//            if (todoItem == null)
//            {
//                return NotFound();
//            }

//            return todoItem;
//        }


//        [HttpPost]
//        public async Task<ActionResult<ShoppingCart>> PostShoppingItem(ShoppingCart ShopedItem)
//        {
//            _context.ShoppingItems.Add(ShopedItem);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetShoppingCart", new { id = ShopedItem.Id, BuyerName = ShopedItem.BuyerName, ItemName = ShopedItem.ItemName, ItemPrice = ShopedItem.ItemPrice, ItemQuantity = ShopedItem.ItemQuantity }, ShopedItem);
//        }



//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutShoppingItem(long id, ShoppingCart CartItem)
//        {
//            if (id != CartItem.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(CartItem).State = EntityState.Modified;
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }


//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ShoppingCart>> DeleteTodoItem(long id)
//        {
//            var cartItem = await _context.ShoppingItems.FindAsync(id);
//            if (cartItem == null)
//            {
//                return NotFound();
//            }

//            _context.ShoppingItems.Remove(cartItem);
//            await _context.SaveChangesAsync();

//            return cartItem;
//        }



//        //// GET api/<controller>/5
//        //[HttpGet("{id}")]
//        //public string Get(int id)
//        //{
//        //    return "value";
//        //}

//        // POST api/<controller>
//        //[HttpPost]
//        //public void Post([FromBody]string value)
//        //{
//        //}

//        //// PUT api/<controller>/5
//        //[HttpPut("{id}")]
//        //public void Put(int id, [FromBody]string value)
//        //{
//        //}

//        //// DELETE api/<controller>/5
//        //[HttpDelete("{id}")]
//        //public void Delete(int id)
//        //{
//        //}
//    }
//}
