namespace surfs_up_project.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartItem(int id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
