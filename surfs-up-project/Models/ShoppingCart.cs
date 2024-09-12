namespace surfs_up_project.Models
{
    public static class ShoppingCart
    {
        private static List<ShoppingCartItem> _items = new List<ShoppingCartItem>()
        {
            new ShoppingCartItem(1, new Product(1, "The Minilog", "/images/the_minilog.webp", 6, 21, 2.75, 38.8, "Shortboard", 565), 1),
            new ShoppingCartItem(2, new Product(2, "The Wide Glider", "/images/the_wide_glider.webp", 7.1, 21.75, 2.75, 44.16, "Funboard", 685), 2),
            new ShoppingCartItem(3, new Product(3, "The Golden Ratio", "/images/the_golden_ratio.webp", 6.3, 21.85, 2.9, 43.22, "Funboard", 695), 3),
            new ShoppingCartItem(4, new Product(4, "Mahi Mahi", "/images/mahi_mahi.webp", 5.4, 20.75, 2.3, 29.39, "Fish", 645), 4)
        };

        public static void AddItem(Product product, int quantity) //CREATE 
        {
            var maxId = _items.Max(x => x.Id);
            var item = new ShoppingCartItem(maxId + 1, product, quantity);
            _items.Add(item);
        }

        public static List<ShoppingCartItem> GetItems() => _items;//READ



        // TODO: Update quantity metode her senere :)))))



        public static void DeleteItem(int id) // Metode til at slette en kategori baseret på dens ID
        {
            var item = _items.FirstOrDefault(x => x.Id == id);

            // Tjekker om kategorien blev fundet.
            if (item != null)
            {
                // Hvis kategorien blev fundet, fjernes den fra _categories-listen.
                _items.Remove(item); // Fjerner kategorien fra listen
            }
            // Hvis kategorien ikke findes, sker der ingenting.
        }
    }
}
