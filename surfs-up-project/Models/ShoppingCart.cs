namespace surfs_up_project.Models
{
    public class ShoppingCart
    {
        // Static list to hold shopping cart items
        private List<ShoppingCartItem> _items = new List<ShoppingCartItem>()
        {
             // slette lortet??
            new ShoppingCartItem(1, new Product(1, "The Minilog", "/images/the_minilog.webp", 6, 21, 2.75, 38.8, "Shortboard", 565), 1),
            new ShoppingCartItem(2, new Product(2, "The Wide Glider", "/images/the_wide_glider.webp", 7.1, 21.75, 2.75, 44.16, "Funboard", 685), 2),
            new ShoppingCartItem(3, new Product(3, "The Golden Ratio", "/images/the_golden_ratio.webp", 6.3, 21.85, 2.9, 43.22, "Funboard", 695), 3),
            new ShoppingCartItem(4, new Product(4, "Mahi Mahi", "/images/mahi_mahi.webp", 5.4, 20.75, 2.3, 29.39, "Fish", 645), 4)
        };

        // Optional dates for pickup and return
        public DateTime? PickUpDate { get; set; } 
        public DateTime? ReturnDate { get; set; }


        // Adds an item to the cart (CREATE)
        public void AddItem(Product product, int quantity) 
        {
            var maxId = _items.Max(x => x.Id);
            var item = new ShoppingCartItem(maxId + 1, product, quantity);
            _items.Add(item);
        }


        // Returns the current list of items in the cart (READ)
        public List<ShoppingCartItem> GetItems() => _items;//READ


        // Increases the quantity of an item in the cart
        public void IncreaseQuantity(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Quantity++; // Increment quantity
            }
        }


        // Decreases the quantity of an item in the cart, but not below 1
        public void DecreaseQuantity(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null && item.Quantity > 1) 
            {
                item.Quantity--; // Decrement quantity if greater than 1
            }
        }


        // Removes an item from the cart by ID
        public void DeleteItem(int id) 
        {
            var item = _items.FirstOrDefault(x => x.Id == id);

            // Cnecks if category has been found 
            if (item != null)
            {
                
                _items.Remove(item); // If the item is found, remove it
            }
        }

        // empty cart method ??
    }
}
