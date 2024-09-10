namespace surfs_up_project.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }

        public ShoppingCartItem(int id, Product product, int amount)
        {
            Id = id;
            Product = product;
            Amount = amount;
        }
    }
}
