using surfs_up_project.Models;

public class ShoppingCartItem
{
    public int Id { get; private set; }
    public Product Product { get; private set; }

    // Ingen Quantity-felt, da vi kun tillader én af hver slags
    public ShoppingCartItem(int id, Product product)
    {
        Id = id;
        Product = product;
    }
}
